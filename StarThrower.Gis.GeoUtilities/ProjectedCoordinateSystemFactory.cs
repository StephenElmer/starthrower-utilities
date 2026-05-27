/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using StarThrower.Logging;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    public static class ProjectedCoordinateSystemFactory
    {
        //A static Dictionary of ProjectedCoordinateSystems keyed by ProjectedCoordinateSystemType | ProjectedCoordinateSystemType + Name | ProjectedCoordinateSystemType,longitudinalZone,latitudinalZone
        //such that GetInstanceOfProjectedCoordinateSystem first checks to see if the requested projectedCoordinateSystemTypeConst,longitudinalZone,latitudinalZone already
        //exists and returns that rather than instantiating a new (duplicate) ProjecteDcoordinateSystem
        private static Dictionary<string, IProjectedCoordinateSystem> _projectedCoordinateSystems = new Dictionary<string, IProjectedCoordinateSystem>();
        private static object _projectedCoordinateSystemsLock = new object();
        
        /// <summary>
        /// Gets the instance of the ProjectedCoordinateSystem specified by projectedCoordinateSystemType, centralMeridian, and latitudeOfOrigin.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="projectedCoordinateSystemType">A System.Type which implements IProjectedCoordinateSystem.  The UserDefined type is not allowed.</param>
        /// <returns>An instance of the specified System.Type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if projectedCoordinateSystemType is null.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if projectedCoordinateSystemType is UserDefined.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if projectedCoordinateSystemType cannot be found within this assembly or if it does not implement IProjectedCoordinateSystem.</exception>
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(Type projectedCoordinateSystemType)
        {
            if (projectedCoordinateSystemType == null) throw new ArgumentNullException("projectedCoordinateSystemType");
            if (projectedCoordinateSystemType.Equals(typeof(CoordinateSystems.Projected.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (!projectedCoordinateSystemType.GetInterface("IProjectedCoordinateSystem").Equals(typeof(IProjectedCoordinateSystem))) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_projectedCoordinateSystems.ContainsKey(projectedCoordinateSystemType.Name))
            {
                IProjectedCoordinateSystem pcs = (IProjectedCoordinateSystem)projectedCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null).Invoke(new object[] { });
                lock (_projectedCoordinateSystemsLock)
                {
                    if (!_projectedCoordinateSystems.ContainsKey(pcs.Key))
                    {
                        _projectedCoordinateSystems.Add(pcs.Key, pcs);
                    }
                }
            }
            return _projectedCoordinateSystems[projectedCoordinateSystemType.Name];
        }
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(string projectedCoordinateSystemTypeName)
        {
            if (projectedCoordinateSystemTypeName == null) throw new ArgumentNullException("projectedCoordinateSystemTypeName");
            if (projectedCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Projected.UserDefined).Name)) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemTypeName)) throw new Exceptions.InvalidCoordinateSystemException();

            Type projectedCoordinateSystemType = GetProjectedCoordinateSystemType(projectedCoordinateSystemTypeName);
            return GetInstanceOfProjectedCoordinateSystem(projectedCoordinateSystemType);
        }
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(Type projectedCoordinateSystemType, IZone zone)
        {
            if (zone == null) throw new ArgumentNullException("zone");
            if (projectedCoordinateSystemType == null) throw new ArgumentNullException("projectedCoordinateSystemType");
            if (projectedCoordinateSystemType.Equals(typeof(CoordinateSystems.Projected.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (!projectedCoordinateSystemType.GetInterface("IProjectedCoordinateSystem").Equals(typeof(IProjectedCoordinateSystem))) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_projectedCoordinateSystems.ContainsKey(projectedCoordinateSystemType.Name + "_" + zone.Name))
            {
                IProjectedCoordinateSystem pcs = (IProjectedCoordinateSystem)projectedCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(IZone) }, null).Invoke(new object[] { zone });
                lock (_projectedCoordinateSystemsLock)
                {
                    if (!_projectedCoordinateSystems.ContainsKey(pcs.Key))
                    {
                        _projectedCoordinateSystems.Add(pcs.Key, pcs);
                    }
                }
            }
            return _projectedCoordinateSystems[projectedCoordinateSystemType.Name + "_" + zone.Name];
        }
        public static bool ProjectedCoordinateSystemTypeExists(string projectedCoordinateSystemTypeName)
        {
            if (projectedCoordinateSystemTypeName == null) throw new ArgumentNullException("projectedCoordinateSystemTypeName");
            if (projectedCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Projected.Undefined).Name)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace.Equals(typeof(CoordinateSystems.Projected.Undefined).Namespace) && types[i].Name.Equals(projectedCoordinateSystemTypeName))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetProjectedCoordinateSystemType(string projectedCoordinateSystemTypeName)
        {
            if (projectedCoordinateSystemTypeName == null) throw new ArgumentNullException("projectedCoordinateSystemTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(projectedCoordinateSystemTypeName))
                {
                    return types[i];
                }
            }
            return typeof(CoordinateSystems.Projected.Undefined);
        }

        public static bool UserDefinedProjectedCoordinateSystemExists(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            return _projectedCoordinateSystems.ContainsKey(typeof(CoordinateSystems.Projected.UserDefined).Name + name);
        }

        public static bool UserDefinedProjectedCoordinateSystemExists(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
            if (!_projectedCoordinateSystems.ContainsKey(key)) return false;
            IProjectedCoordinateSystem pcs = _projectedCoordinateSystems[key];
            if (!(pcs.GeographicCoordinateSystem.Equals(geographicCoordinateSystem) &&
                  pcs.LinearUnit.Equals(linearUnit) &&
                  pcs.Projection.Equals(projection))) return false;
            return true;
        }

        public static IProjectedCoordinateSystem GetInstanceOfNewUserDefinedProjectedCoordinateSystem(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            try
            {
                string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
                if (!_projectedCoordinateSystems.ContainsKey(key))
                {
                    IProjectedCoordinateSystem pcs = new CoordinateSystems.Projected.UserDefined(name, geographicCoordinateSystem, projection, linearUnit);
                    lock (_projectedCoordinateSystemsLock)
                    {
                        if (!_projectedCoordinateSystems.ContainsKey(pcs.Key))
                        {
                            _projectedCoordinateSystems.Add(pcs.Key, pcs);
                        }
                    }
                    return _projectedCoordinateSystems[pcs.Key];
                }
                else
                {
                    IProjectedCoordinateSystem pcs = _projectedCoordinateSystems[key];
                    if (!(pcs.GeographicCoordinateSystem.Equals(geographicCoordinateSystem) &&
                          pcs.LinearUnit.Equals(linearUnit) &&
                          pcs.Projection.Equals(projection))) throw new Exceptions.AmbiguousCoordinateSystemException("ProjectedCoordinateSystem for name already exists with different GeographicCoordinateSystem, Projection, and/or LinearUnit values.");
                    return pcs;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "ProjectedCoordinateSystemFactory.GetInstanceOfNewUserDefinedProjectedCoordinateSystem(string, GeographicCoordinateSystem, ProjectionParameter[], LinearUnit)", ex);
                throw;
            }
        }

        public static IProjectedCoordinateSystem GetInstanceOfExistingUserDefinedProjectedCoordinateSystem(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            try
            {
                string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
                if (!_projectedCoordinateSystems.ContainsKey(key)) throw new Exceptions.InvalidCoordinateSystemException("A UserDefined ProjectedCoordinateSystem could not be found for name.");
                return _projectedCoordinateSystems[key];
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "ProjectedCoordinateSystemFactory.GetInstanceOfExistingUserDefinedProjectedCoordinateSystem(string, GeographicCoordinateSystem, ProjectionParameter[], LinearUnit)", ex);
                throw;
            }
        }
    }
}
