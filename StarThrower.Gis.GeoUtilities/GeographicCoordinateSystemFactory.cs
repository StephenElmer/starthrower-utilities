/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.Reflection;
using System.Collections.Generic;
using StarThrower.Logging;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    public static class GeographicCoordinateSystemFactory
    {
        //A static Dictionary of GeographicCoordinateSystems keyed by GeographicCoordinateSystemType | GeographicCoordinateSystemType + Name (in the case of user defined geographic coordinate systems)
        //such that GetInstanceOfGeographicCoordinateSystem first checks to see if the requested geographicCoordinateSystemTypeConst already
        //exists and returns that rather than instantiating a new (duplicate) GeographicCoordinateSystem
        private static Dictionary<string, IGeographicCoordinateSystem> _geographicCoordinateSystems = new Dictionary<string, IGeographicCoordinateSystem>();
        private static object _geographicCoordinateSystemsLock = new object();

        /// <summary>
        /// Gets the instance of the GeographicCoordinateSystem specified by geographicCoordinateSystemTypeConst.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="geographicCoordinateSystemTypeConst"></param>
        /// <returns></returns>
        public static IGeographicCoordinateSystem GetInstanceOfGeographicCoordinateSystem(Type geographicCoordinateSystemType)
        {
            if (geographicCoordinateSystemType == null) throw new ArgumentNullException("geographicCoordinateSystemType");
            if (geographicCoordinateSystemType.Equals(typeof(CoordinateSystems.Geographic.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!GeographicCoordinateSystemTypeExists(geographicCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (geographicCoordinateSystemType.GetInterface("IGeographicCoordinateSystem") != typeof(IGeographicCoordinateSystem)) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_geographicCoordinateSystems.ContainsKey(geographicCoordinateSystemType.Name))
            {
                IGeographicCoordinateSystem gcs = (IGeographicCoordinateSystem)(geographicCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidCoordinateSystemException()).Invoke(new object[] { });
                lock (_geographicCoordinateSystemsLock)
                {
                    if (!_geographicCoordinateSystems.ContainsKey(gcs.Key))
                    {
                        _geographicCoordinateSystems.Add(gcs.Key, gcs);
                    }
                }
            }
            return _geographicCoordinateSystems[geographicCoordinateSystemType.Name];
        }
        public static IGeographicCoordinateSystem GetInstanceOfGeographicCoordinateSystem(string geographicCoordinateSystemTypeName)
        {
            if (geographicCoordinateSystemTypeName == null) throw new ArgumentNullException("geographicCoordinateSystemTypeName");
            if (geographicCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Geographic.UserDefined).Name)) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!GeographicCoordinateSystemTypeExists(geographicCoordinateSystemTypeName)) throw new Exceptions.InvalidCoordinateSystemException();

            Type geographicCoordinateSystemType = GetGeographicCoordinateSystemType(geographicCoordinateSystemTypeName);
            return GetInstanceOfGeographicCoordinateSystem(geographicCoordinateSystemType);
        }
        public static bool GeographicCoordinateSystemTypeExists(string geographicCoordinateSystemTypeName)
        {
            if (geographicCoordinateSystemTypeName == null) throw new ArgumentNullException("geographicCoordinateSystemTypeName");
            if (geographicCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Geographic.Undefined).Name)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(CoordinateSystems.Geographic.Undefined).Namespace && types[i].Name.Equals(geographicCoordinateSystemTypeName))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetGeographicCoordinateSystemType(string geographicCoordinateSystemTypeName)
        {
            if (geographicCoordinateSystemTypeName == null) throw new ArgumentNullException("geographicCoordinateSystemTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(geographicCoordinateSystemTypeName))
                {
                    return types[i];
                }
            }
            return typeof(CoordinateSystems.Geographic.Undefined);
        }

        public static bool UserDefinedGeographicCoordinateSystemExists(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            return _geographicCoordinateSystems.ContainsKey(typeof(CoordinateSystems.Geographic.UserDefined).Name + name);
        }

        public static bool UserDefinedGeographicCoordinateSystemExists(string name, IDatum datum, IPrimeMeridian primeMeridian, IAngularUnit angularUnit)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
            if (!_geographicCoordinateSystems.ContainsKey(key)) return false;
            IGeographicCoordinateSystem gcs = _geographicCoordinateSystems[key];
            if (!(gcs.Datum.Equals(datum) &&
                  gcs.PrimeMeridian.Equals(primeMeridian) &&
                  gcs.AngularUnit.Equals(angularUnit))) return false;
            return true;
        }

        public static IGeographicCoordinateSystem GetInstanceOfNewUserDefinedGeographicCoordinateSystem(string name, IDatum datum, IPrimeMeridian primeMeridian, IAngularUnit angularUnit)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            try
            {
                string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
                if (!_geographicCoordinateSystems.ContainsKey(key))
                {
                    IGeographicCoordinateSystem gcs = new CoordinateSystems.Geographic.UserDefined(name, datum, primeMeridian, angularUnit);
                    lock (_geographicCoordinateSystemsLock)
                    {
                        if (!_geographicCoordinateSystems.ContainsKey(gcs.Key))
                        {
                            _geographicCoordinateSystems.Add(gcs.Key, gcs);
                        }
                    }
                    return _geographicCoordinateSystems[gcs.Key];
                }
                else
                {
                    IGeographicCoordinateSystem gcs = _geographicCoordinateSystems[key];
                    if (!(gcs.Datum.Equals(datum) &&
                          gcs.PrimeMeridian.Equals(primeMeridian) &&
                          gcs.AngularUnit.Equals(angularUnit))) throw new Exceptions.AmbiguousCoordinateSystemException("GeographicCoordinateSystem for name already exists but with different Datum, PrimeMeridian, and/or AngularUnit values.");
                    return gcs;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "GeographicCoordinateSystemFactory.GetInstanceOfNewUserDefinedGeographicCoordinateSystem(string, IDatum, IPrimeMeridian, IAngularUnit)", ex);
                throw;
            }
        }

        public static IGeographicCoordinateSystem GetInstanceOfExistingUserDefinedGeographicCoordinateSystem(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            try
            {
                string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
                if (!_geographicCoordinateSystems.ContainsKey(key)) throw new Exceptions.InvalidCoordinateSystemException("A UserDefined Geographic Coordinate System could not be found for name.");
                return _geographicCoordinateSystems[key];
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "GeographicCoordinateSystemFactory.GetInstanceOfExistingUserDefinedGeographicCoordinateSystem(string)", ex);
                throw;
            }
        }
    }
}


