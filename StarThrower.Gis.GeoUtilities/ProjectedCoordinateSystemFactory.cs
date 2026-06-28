// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of ProjectedCoordinateSystems based upon a specified type,
    /// optionally with an associated zone (e.g. for UTM).
    /// </summary>
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
                IProjectedCoordinateSystem pcs = (IProjectedCoordinateSystem)(projectedCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidCoordinateSystemException()).Invoke(Array.Empty<object>());
                lock (_projectedCoordinateSystemsLock)
                {
                    _projectedCoordinateSystems.TryAdd(pcs.Key, pcs);
                }
            }
            return _projectedCoordinateSystems[projectedCoordinateSystemType.Name];
        }
        /// <summary>
        /// Gets the instance of the ProjectedCoordinateSystem specified by projectedCoordinateSystemTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="projectedCoordinateSystemTypeName">The name of the projected coordinate system type you want. UserDefined is not allowed.</param>
        /// <returns>The coordinate system instance associated with projectedCoordinateSystemTypeName.</returns>
        /// <exception cref="ArgumentNullException">Thrown if projectedCoordinateSystemTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if projectedCoordinateSystemTypeName is UserDefined.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if projectedCoordinateSystemTypeName does not exist.</exception>
        public static IProjectedCoordinateSystem GetInstanceOfProjectedCoordinateSystem(string projectedCoordinateSystemTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(projectedCoordinateSystemTypeName);
            if (projectedCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Projected.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!ProjectedCoordinateSystemTypeExists(projectedCoordinateSystemTypeName)) throw new Exceptions.InvalidCoordinateSystemException();

            Type projectedCoordinateSystemType = GetProjectedCoordinateSystemType(projectedCoordinateSystemTypeName);
            return GetInstanceOfProjectedCoordinateSystem(projectedCoordinateSystemType);
        }

        /// <summary>
        /// Gets the instance of the ProjectedCoordinateSystem specified by projectedCoordinateSystemType and zone.
        /// If an instance does not exist, one is created. Used for zoned coordinate systems (e.g. UTM).
        /// </summary>
        /// <param name="projectedCoordinateSystemType">The type of projected coordinate system you want. Must implement <see cref="IProjectedCoordinateSystem"/> and accept an <see cref="IZone"/> constructor parameter; UserDefined is not allowed.</param>
        /// <param name="zone">The zone the coordinate system instance is associated with.</param>
        /// <returns>The coordinate system instance associated with projectedCoordinateSystemType and zone.</returns>
        /// <exception cref="ArgumentNullException">Thrown if projectedCoordinateSystemType or zone is null.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if projectedCoordinateSystemType is UserDefined.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if projectedCoordinateSystemType does not exist or does not implement <see cref="IProjectedCoordinateSystem"/>.</exception>
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
        /// <summary>
        /// Determines whether a type named projectedCoordinateSystemTypeName exists in the <c>CoordinateSystems.Projected</c> namespace.
        /// </summary>
        /// <param name="projectedCoordinateSystemTypeName">The name of the projected coordinate system type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if projectedCoordinateSystemTypeName is null or empty.</exception>
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

        /// <summary>
        /// Gets the <see cref="Type"/> named projectedCoordinateSystemTypeName.
        /// </summary>
        /// <param name="projectedCoordinateSystemTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="CoordinateSystems.Projected.Undefined"/> if no type named projectedCoordinateSystemTypeName exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if projectedCoordinateSystemTypeName is null or empty.</exception>
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

        /// <summary>
        /// Checks to see if a UserDefined ProjectedCoordinateSystem has been instantiated for name.
        /// This version of the function is agnostic of the GeographicCoordinateSystem, Projection, and LinearUnit of the coordinate system.
        /// </summary>
        /// <param name="name">The name of the UserDefined ProjectedCoordinateSystem you are looking for.</param>
        /// <returns>True if a ProjectedCoordinateSystem has been instantiated with this name; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedProjectedCoordinateSystemExists(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            return _projectedCoordinateSystems.ContainsKey(typeof(CoordinateSystems.Projected.UserDefined).Name + name);
        }

        /// <summary>
        /// Checks to see if a UserDefined ProjectedCoordinateSystem has been instantiated for name, geographicCoordinateSystem, projection, and linearUnit.
        /// </summary>
        /// <param name="name">The name of the UserDefined ProjectedCoordinateSystem you are looking for.</param>
        /// <param name="geographicCoordinateSystem">The GeographicCoordinateSystem of the coordinate system you are looking for.</param>
        /// <param name="projection">The Projection of the coordinate system you are looking for.</param>
        /// <param name="linearUnit">The LinearUnit of the coordinate system you are looking for.</param>
        /// <returns>True if a UserDefined ProjectedCoordinateSystem has been instantiated with these values; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedProjectedCoordinateSystemExists(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
            if (!_projectedCoordinateSystems.TryGetValue(key, out IProjectedCoordinateSystem? pcs)) return false;
            if (!(pcs.GeographicCoordinateSystem.Equals(geographicCoordinateSystem) &&
                  pcs.LinearUnit.Equals(linearUnit) &&
                  pcs.Projection.Equals(projection))) return false;
            return true;
        }

        /// <summary>
        /// Instantiates a UserDefined ProjectedCoordinateSystem.
        /// </summary>
        /// <param name="name">The name of the new ProjectedCoordinateSystem.</param>
        /// <param name="geographicCoordinateSystem">The GeographicCoordinateSystem of the new coordinate system.</param>
        /// <param name="projection">The Projection of the new coordinate system.</param>
        /// <param name="linearUnit">The LinearUnit of the new coordinate system.</param>
        /// <returns>The instance of the new coordinate system.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if name is incorrectly formatted.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if a coordinate system already exists for name with different GeographicCoordinateSystem, Projection, and/or LinearUnit values.</exception>
        public static IProjectedCoordinateSystem GetInstanceOfNewUserDefinedProjectedCoordinateSystem(string name, IGeographicCoordinateSystem geographicCoordinateSystem, IProjection projection, ILinearUnit linearUnit)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
            lock (_projectedCoordinateSystemsLock)
            {
                if (!_projectedCoordinateSystems.TryGetValue(key, out IProjectedCoordinateSystem? pcs))
                {
                    pcs = new CoordinateSystems.Projected.UserDefined(name, geographicCoordinateSystem, projection, linearUnit);
                    _projectedCoordinateSystems.TryAdd(key, pcs);
                    return pcs;
                }
                if (!(pcs.GeographicCoordinateSystem.Equals(geographicCoordinateSystem) &&
                    pcs.LinearUnit.Equals(linearUnit) &&
                    pcs.Projection.Equals(projection))) throw new Exceptions.AmbiguousCoordinateSystemException("ProjectedCoordinateSystem for name already exists with different GeographicCoordinateSystem, Projection, and/or LinearUnit values.");
                return pcs;
            }
        }

        /// <summary>
        /// Gets the instance of the specified UserDefined ProjectedCoordinateSystem.
        /// </summary>
        /// <param name="name">The name of the coordinate system you are looking for.</param>
        /// <returns>The coordinate system you are looking for.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if name is incorrectly formatted OR if the instance could not be found.</exception>
        public static IProjectedCoordinateSystem GetInstanceOfExistingUserDefinedProjectedCoordinateSystem(string name)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.ProjectedCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for projected coordinate system name.");

            string key = typeof(CoordinateSystems.Projected.UserDefined).Name + name;
            if (!_projectedCoordinateSystems.TryGetValue(key, out IProjectedCoordinateSystem? value)) throw new Exceptions.InvalidCoordinateSystemException("A UserDefined ProjectedCoordinateSystem could not be found for name.");
            return value;
        }
    }
}


