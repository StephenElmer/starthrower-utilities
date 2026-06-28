// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of PrimeMeridians (e.g. Greenwich) based upon a specified prime meridian type.
    /// </summary>
    public static class PrimeMeridianFactory
    {
        private static Dictionary<string, IPrimeMeridian> _pmList = new Dictionary<string, IPrimeMeridian>();
        private static object _pmListLock = new object();


        /// <summary>
        /// Gets the instance of the PrimeMeridian specified by primeMeridianType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="primeMeridianType">A System.Type which implements IPrimeMeridian.  The UserDefined type is not allowed.</param>
        /// <returns>An instance of the specified System.Type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if primeMeridianType is null.</exception>
        /// <exception cref="Exceptions.InvalidPrimeMeridianTypeException">Thrown if primeMeridianType cannot be found within this assembly or if it does not implement IPrimeMeridian.</exception>
        public static IPrimeMeridian GetInstanceOfPrimeMeridian(Type primeMeridianType)
        {
            ArgumentNullException.ThrowIfNull(primeMeridianType);
            if (!PrimeMeridianTypeExists(primeMeridianType.Name)) throw new Exceptions.InvalidPrimeMeridianTypeException();
            if (primeMeridianType.GetInterface("IPrimeMeridian") != typeof(IPrimeMeridian)) throw new Exceptions.InvalidPrimeMeridianTypeException();

            if (!_pmList.ContainsKey(primeMeridianType.Name))
            {
                IPrimeMeridian pm = (IPrimeMeridian)(primeMeridianType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidPrimeMeridianTypeException()).Invoke(Array.Empty<object>());
                lock (_pmListLock)
                {
                    _pmList.TryAdd(pm.Name, pm);
                }
            }
            return _pmList[primeMeridianType.Name];
        }
        
        /// <summary>
        /// Gets the instance of the PrimeMeridian specified by primeMeridianTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="primeMeridianTypeName">The name of the prime meridian type you want.</param>
        /// <returns>An instance of the specified type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if primeMeridianTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidPrimeMeridianTypeException">Thrown if primeMeridianTypeName does not exist.</exception>
        public static IPrimeMeridian GetInstanceOfPrimeMeridian(string primeMeridianTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(primeMeridianTypeName);
            if (!PrimeMeridianTypeExists(primeMeridianTypeName)) throw new Exceptions.InvalidPrimeMeridianTypeException();

            Type primeMeridianType = GetPrimeMeridianType(primeMeridianTypeName);
            return GetInstanceOfPrimeMeridian(primeMeridianType);
        }

        /// <summary>
        /// Determines whether a type named primeMeridianTypeName exists in the <c>PrimeMeridians</c> namespace.
        /// </summary>
        /// <param name="primeMeridianTypeName">The name of the prime meridian type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if primeMeridianTypeName is null or empty.</exception>
        public static bool PrimeMeridianTypeExists(string primeMeridianTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(primeMeridianTypeName);
            if (primeMeridianTypeName.Equals(typeof(PrimeMeridians.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(PrimeMeridians.Undefined).Namespace && types[i].Name.Equals(primeMeridianTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> named primeMeridianTypeName.
        /// </summary>
        /// <param name="primeMeridianTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="PrimeMeridians.Undefined"/> if no type named primeMeridianTypeName exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if primeMeridianTypeName is null.</exception>
        public static Type GetPrimeMeridianType(string primeMeridianTypeName)
        {
            ArgumentNullException.ThrowIfNull(primeMeridianTypeName);

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(primeMeridianTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(PrimeMeridians.Undefined);
        }
    }
}


