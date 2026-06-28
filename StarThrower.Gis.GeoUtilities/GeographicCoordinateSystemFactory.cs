// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;
using System.Collections.Generic;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of GeographicCoordinateSystems based upon a specified type.
    /// </summary>
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
        /// <param name="geographicCoordinateSystemType">The type of geographic coordinate system you want. Must implement <see cref="IGeographicCoordinateSystem"/>; UserDefined is not allowed.</param>
        /// <returns>The geographic coordinate system instance associated with geographicCoordinateSystemType.</returns>
        /// <exception cref="ArgumentNullException">Thrown if geographicCoordinateSystemType is null.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if geographicCoordinateSystemType is UserDefined.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if geographicCoordinateSystemType does not exist or does not implement <see cref="IGeographicCoordinateSystem"/>.</exception>
        public static IGeographicCoordinateSystem GetInstanceOfGeographicCoordinateSystem(Type geographicCoordinateSystemType)
        {
            ArgumentNullException.ThrowIfNull(geographicCoordinateSystemType);
            if (geographicCoordinateSystemType.Equals(typeof(CoordinateSystems.Geographic.UserDefined))) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!GeographicCoordinateSystemTypeExists(geographicCoordinateSystemType.Name)) throw new Exceptions.InvalidCoordinateSystemException();
            if (geographicCoordinateSystemType.GetInterface("IGeographicCoordinateSystem") != typeof(IGeographicCoordinateSystem)) throw new Exceptions.InvalidCoordinateSystemException();

            if (!_geographicCoordinateSystems.ContainsKey(geographicCoordinateSystemType.Name))
            {
                IGeographicCoordinateSystem gcs = (IGeographicCoordinateSystem)(geographicCoordinateSystemType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidCoordinateSystemException()).Invoke(Array.Empty<object>());
                lock (_geographicCoordinateSystemsLock)
                {
                    _geographicCoordinateSystems.TryAdd(gcs.Key, gcs);
                }
            }
            return _geographicCoordinateSystems[geographicCoordinateSystemType.Name];
        }
        /// <summary>
        /// Gets the instance of the GeographicCoordinateSystem specified by geographicCoordinateSystemTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="geographicCoordinateSystemTypeName">The name of the geographic coordinate system type you want. UserDefined is not allowed.</param>
        /// <returns>The geographic coordinate system instance associated with geographicCoordinateSystemTypeName.</returns>
        /// <exception cref="ArgumentException">Thrown if geographicCoordinateSystemTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if geographicCoordinateSystemTypeName is UserDefined.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if geographicCoordinateSystemTypeName does not exist.</exception>
        public static IGeographicCoordinateSystem GetInstanceOfGeographicCoordinateSystem(string geographicCoordinateSystemTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geographicCoordinateSystemTypeName);
            if (geographicCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Geographic.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousCoordinateSystemException();
            if (!GeographicCoordinateSystemTypeExists(geographicCoordinateSystemTypeName)) throw new Exceptions.InvalidCoordinateSystemException();

            Type geographicCoordinateSystemType = GetGeographicCoordinateSystemType(geographicCoordinateSystemTypeName);
            return GetInstanceOfGeographicCoordinateSystem(geographicCoordinateSystemType);
        }

        /// <summary>
        /// Determines whether a type named geographicCoordinateSystemTypeName exists in the <c>CoordinateSystems.Geographic</c> namespace.
        /// </summary>
        /// <param name="geographicCoordinateSystemTypeName">The name of the geographic coordinate system type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if geographicCoordinateSystemTypeName is null or empty.</exception>
        public static bool GeographicCoordinateSystemTypeExists(string geographicCoordinateSystemTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geographicCoordinateSystemTypeName);
            if (geographicCoordinateSystemTypeName.Equals(typeof(CoordinateSystems.Geographic.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(CoordinateSystems.Geographic.Undefined).Namespace && types[i].Name.Equals(geographicCoordinateSystemTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> named geographicCoordinateSystemTypeName.
        /// </summary>
        /// <param name="geographicCoordinateSystemTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="CoordinateSystems.Geographic.Undefined"/> if no type named geographicCoordinateSystemTypeName exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if geographicCoordinateSystemTypeName is null.</exception>
        public static Type GetGeographicCoordinateSystemType(string geographicCoordinateSystemTypeName)
        {
            ArgumentNullException.ThrowIfNull(geographicCoordinateSystemTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(geographicCoordinateSystemTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(CoordinateSystems.Geographic.Undefined);
        }

        /// <summary>
        /// Checks to see if a UserDefined GeographicCoordinateSystem has been instantiated for name.
        /// This version of the function is agnostic of the Datum, PrimeMeridian, and AngularUnit of the coordinate system.
        /// </summary>
        /// <param name="name">The name of the UserDefined GeographicCoordinateSystem you are looking for.</param>
        /// <returns>True if a GeographicCoordinateSystem has been instantiated with this name; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null, empty, or incorrectly formatted.</exception>
        public static bool UserDefinedGeographicCoordinateSystemExists(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            return _geographicCoordinateSystems.ContainsKey(typeof(CoordinateSystems.Geographic.UserDefined).Name + name);
        }

        /// <summary>
        /// Checks to see if a UserDefined GeographicCoordinateSystem has been instantiated for name, datum, primeMeridian, and angularUnit.
        /// </summary>
        /// <param name="name">The name of the UserDefined GeographicCoordinateSystem you are looking for.</param>
        /// <param name="datum">The Datum of the coordinate system you are looking for.</param>
        /// <param name="primeMeridian">The PrimeMeridian of the coordinate system you are looking for.</param>
        /// <param name="angularUnit">The AngularUnit of the coordinate system you are looking for.</param>
        /// <returns>True if a UserDefined GeographicCoordinateSystem has been instantiated with these values; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null, empty, or incorrectly formatted.</exception>
        public static bool UserDefinedGeographicCoordinateSystemExists(string name, IDatum datum, IPrimeMeridian primeMeridian, IAngularUnit angularUnit)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
            if (!_geographicCoordinateSystems.TryGetValue(key, out IGeographicCoordinateSystem? gcs)) return false;
            if (!(gcs.Datum.Equals(datum) &&
                  gcs.PrimeMeridian.Equals(primeMeridian) &&
                  gcs.AngularUnit.Equals(angularUnit))) return false;
            return true;
        }

        /// <summary>
        /// Instantiates a UserDefined GeographicCoordinateSystem.
        /// </summary>
        /// <param name="name">The name of the new GeographicCoordinateSystem.</param>
        /// <param name="datum">The Datum of the new coordinate system.</param>
        /// <param name="primeMeridian">The PrimeMeridian of the new coordinate system.</param>
        /// <param name="angularUnit">The AngularUnit of the new coordinate system.</param>
        /// <returns>The instance of the new coordinate system.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null, empty, or incorrectly formatted.</exception>
        /// <exception cref="Exceptions.AmbiguousCoordinateSystemException">Thrown if a coordinate system already exists for name with different Datum, PrimeMeridian, and/or AngularUnit values.</exception>
        public static IGeographicCoordinateSystem GetInstanceOfNewUserDefinedGeographicCoordinateSystem(string name, IDatum datum, IPrimeMeridian primeMeridian, IAngularUnit angularUnit)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
            lock (_geographicCoordinateSystemsLock)
            {
                if (!_geographicCoordinateSystems.TryGetValue(key, out IGeographicCoordinateSystem? gcs))
                {
                    gcs = new CoordinateSystems.Geographic.UserDefined(name, datum, primeMeridian, angularUnit);
                    _geographicCoordinateSystems.TryAdd(key, gcs);
                    return gcs;
                }
                if (!(gcs.Datum.Equals(datum) &&
                    gcs.PrimeMeridian.Equals(primeMeridian) &&
                    gcs.AngularUnit.Equals(angularUnit))) throw new Exceptions.AmbiguousCoordinateSystemException("GeographicCoordinateSystem for name already exists but with different Datum, PrimeMeridian, and/or AngularUnit values.");
                return gcs;
            }
        }

        /// <summary>
        /// Gets the instance of the specified UserDefined GeographicCoordinateSystem.
        /// </summary>
        /// <param name="name">The name of the coordinate system you are looking for.</param>
        /// <returns>The coordinate system you are looking for.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null, empty, or incorrectly formatted.</exception>
        /// <exception cref="Exceptions.InvalidCoordinateSystemException">Thrown if the instance could not be found.</exception>
        public static IGeographicCoordinateSystem GetInstanceOfExistingUserDefinedGeographicCoordinateSystem(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, CoordinateSystems.GeographicCoordinateSystem.ValidNamePattern)) throw new Exceptions.InvalidCoordinateSystemException("Invalid format for coordinate system name.");

            string key = typeof(CoordinateSystems.Geographic.UserDefined).Name + name;
            if (!_geographicCoordinateSystems.TryGetValue(key, out IGeographicCoordinateSystem? value)) throw new Exceptions.InvalidCoordinateSystemException("A UserDefined Geographic Coordinate System could not be found for name.");
            return value;
        }
    }
}


