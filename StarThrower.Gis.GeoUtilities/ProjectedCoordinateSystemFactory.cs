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
            ArgumentNullException.ThrowIfNull(projectedCoordinateSystemType);
            if (projectedCoordinateSystemType.Equals(typeof(CoordinateSystems.Projected.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (projectedCoordinateSystemType.GetInterface("IProjectedCoordinateSystem") != typeof(IProjectedCoordinateSystem)) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_projectedCoordinateSystems.ContainsKey(projectedCoordinateSystemType.Name))
            {
                IProjectedCoordinateSystem pcs = (IProjectedCoordinateSystem)(projectedCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidCoordinateSystemException()).Invoke(new object[] { });
                lock (_projectedCoordinateSystemsLock)
                {
                    _projectedCoordinateSystems.TryAdd(pcs.Key, pcs);
                }
            }
            return _projectedCoordinateSystems[projectedCoordinateSystemType.Name];
        }
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(string projectedCoordinateSystemTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(projectedCoordinateSystemTypeName);
            if (projectedCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Projected.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemTypeName)) throw new Exceptions.InvalidCoordinateSystemException();

            Type projectedCoordinateSystemType = GetProjectedCoordinateSystemType(projectedCoordinateSystemTypeName);
            return GetInstanceOfProjectedCoordinateSystem(projectedCoordinateSystemType);
        }
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(Type projectedCoordinateSystemType, IZone zone)
        {
            ArgumentNullException.ThrowIfNull(zone);
            ArgumentNullException.ThrowIfNull(projectedCoordinateSystemType);
            if (projectedCoordinateSystemType.Equals(typeof(CoordinateSystems.Projected.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (projectedCoordinateSystemType.GetInterface("IProjectedCoordinateSystem") != typeof(IProjectedCoordinateSystem)) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_projectedCoordinateSystems.ContainsKey(projectedCoordinateSystemType.Name + "_" + zone.Name))
            {
                IProjectedCoordinateSystem pcs = (IProjectedCoordinateSystem)(projectedCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(IZone) }, null) ?? throw new Exceptions.InvalidCoordinateSystemException()).Invoke(new object[] { zone });
                lock (_projectedCoordinateSystemsLock)
                {
                    _projectedCoordinateSystems.TryAdd(pcs.Key, pcs);
                }
            }
            return _projectedCoordinateSystems[projectedCoordinateSystemType.Name + "_" + zone.Name];
        }
        public static bool ProjectedCoordinateSystemTypeExists(string projectedCoordinateSystemTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectedCoordinateSystemTypeName);
            if (projectedCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Projected.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(CoordinateSystems.Projected.Undefined).Namespace && types[i].Name.Equals(projectedCoordinateSystemTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetProjectedCoordinateSystemType(string projectedCoordinateSystemTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(projectedCoordinateSystemTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(projectedCoordinateSystemTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(CoordinateSystems.Projected.Undefined);
        }

        public static bool UserDefinedProjectedCoordinateSystemExists(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            return _projectedCoordinateSystems.ContainsKey(typeof(CoordinateSystems.Projected.UserDefined).Name + name);
        }

        public static bool UserDefinedProjectedCoordinateSystemExists(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
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
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            try
            {
                string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
                if (!_projectedCoordinateSystems.ContainsKey(key))
                {
                    CoordinateSystems.Projected.UserDefined pcs = new CoordinateSystems.Projected.UserDefined(name, geographicCoordinateSystem, projection, linearUnit);
                    lock (_projectedCoordinateSystemsLock)
                    {
                        _projectedCoordinateSystems.TryAdd(pcs.Key, pcs);
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
            ArgumentNullException.ThrowIfNullOrEmpty(name);
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


