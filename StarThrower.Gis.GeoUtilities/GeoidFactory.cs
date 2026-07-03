// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;
using System.Collections.Generic;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of Geoids based upon a specified geoid type.
    /// </summary>
    public static class GeoidFactory
    {
        private static Dictionary<string, IGeoid> _geoidList = new Dictionary<string, IGeoid>();
        private static object _geoidListLock = new object();

        /// <summary>
        /// Gets the instance of the Geoid specified by geoidType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="geoidType">The type of geoid you want. Must implement <see cref="IGeoid"/>; Undefined and UserDefined are considered invalid.</param>
        /// <returns>The geoid instance associated with geoidType.</returns>
        /// <exception cref="ArgumentNullException">Thrown if geoidType is null.</exception>
        /// <exception cref="Exceptions.AmbiguousGeoidTypeException">Thrown on the Undefined geoid type.</exception>
        /// <exception cref="Exceptions.InvalidGeoidTypeException">Thrown if geoidType does not exist or does not implement <see cref="IGeoid"/>.</exception>
        public static IGeoid GetInstanceOfGeoid(Type geoidType)
        {
            ArgumentNullException.ThrowIfNull(geoidType);
            //TODO: #29 — throws AmbiguousGeoidTypeException for Undefined, unlike DatumFactory/EllipsoidFactory which throw Invalid*TypeException
            if (geoidType.Equals(typeof(Geoids.Undefined))) throw new Exceptions.AmbiguousGeoidTypeException();
            if (!GeoidTypeExists(geoidType.Name)) throw new Exceptions.InvalidGeoidTypeException();
            if (geoidType.GetInterface("IGeoid") != typeof(IGeoid)) throw new Exceptions.InvalidGeoidTypeException();

            if (!_geoidList.ContainsKey(geoidType.Name))
            {
                IGeoid g = (IGeoid)(geoidType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidGeoidTypeException()).Invoke(Array.Empty<object>());
                lock (_geoidListLock)
                {
                    _geoidList.TryAdd(g.Key, g);
                }
            }
            return _geoidList[geoidType.Name];
        }

        /// <summary>
        /// Gets the instance of the Geoid specified by geoidTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="geoidTypeName">The name of the geoid type you want. Undefined and UserDefined are considered invalid.</param>
        /// <returns>The geoid instance associated with geoidTypeName.</returns>
        /// <exception cref="ArgumentException">Thrown if geoidTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.AmbiguousGeoidTypeException">Thrown on the UserDefined geoid type name.</exception>
        /// <exception cref="Exceptions.InvalidGeoidTypeException">Thrown if geoidTypeName does not exist.</exception>
        public static IGeoid GetInstanceOfGeoid(string geoidTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geoidTypeName);
            if (geoidTypeName.Equals(typeof(Geoids.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousGeoidTypeException();
            if (!GeoidTypeExists(geoidTypeName)) throw new Exceptions.InvalidGeoidTypeException();

            Type geoidType = GetGeoidType(geoidTypeName);
            return GetInstanceOfGeoid(geoidType);
        }

        /// <summary>
        /// Determines whether a type named geoidTypeName exists in the <c>Geoids</c> namespace.
        /// </summary>
        /// <param name="geoidTypeName">The name of the geoid type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if geoidTypeName is null or empty.</exception>
        public static bool GeoidTypeExists(string geoidTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geoidTypeName);
            if (geoidTypeName.Equals(typeof(Geoids.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(Geoids.Undefined).Namespace && types[i].Name.Equals(geoidTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> named geoidTypeName.
        /// </summary>
        /// <param name="geoidTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="Geoids.Undefined"/> if no type named geoidTypeName exists.</returns>
        /// <exception cref="ArgumentException">Thrown if geoidTypeName is null or empty.</exception>
        public static Type GetGeoidType(string geoidTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geoidTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(geoidTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(Geoids.Undefined);
        }

        /// <summary>
        /// Checks to see if a UserDefined Geoid has been instantiated for name.
        /// </summary>
        /// <param name="name">The name of the UserDefined Geoid you are looking for.</param>
        /// <returns>True if a Geoid has been instantiated with this name; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidGeoidTypeException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedGeoidExists(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, Geoid.ValidNamePattern)) throw new Exceptions.InvalidGeoidTypeException("Invalid format for geoid name.");

            return _geoidList.ContainsKey(typeof(Geoids.UserDefined).Name + name);
        }

        //public static bool UserDefinedGeoidExists(string name)
        //{
        //    if (name == null) throw new ArgumentNullException("name");
        //    if (!Strings.IsValid(name, Geoid.VALID_NAME_PATTERN)) throw new Exceptions.InvalidGeoidTypeException("Invalid format for geoid name.");

        //    string key = typeof(Geoids.UserDefined).Name + name;
        //    if (!_geoidList.ContainsKey(key)) return false;
        //    IGeoid g = _geoidList[key];
        //    return true;
        //}

        /// <summary>
        /// Instantiates a UserDefined Geoid.
        /// </summary>
        /// <param name="name">The name of the new Geoid.</param>
        /// <returns>The instance of the new geoid.</returns>
        /// <exception cref="ArgumentException">Thrown if name is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidGeoidTypeException">Thrown if name is incorrectly formatted.</exception>
        public static IGeoid GetInstanceOfNewUserDefinedGeoid(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, Geoid.ValidNamePattern)) throw new Exceptions.InvalidGeoidTypeException("Invalid format for geoid name.");

            string key = typeof(Geoids.UserDefined).Name + name;
            lock (_geoidListLock)
            {
                if (!_geoidList.TryGetValue(key, out IGeoid? g))
                {
                    g = new Geoids.UserDefined(name);
                    _geoidList.TryAdd(key, g);
                    return g;
                }
                else
                {
                    return g;
                }
            }
        }
    }
}


