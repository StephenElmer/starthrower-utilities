// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of LinearUnits (e.g. Meter, Foot) based upon a specified linear unit type.
    /// </summary>
    public static class LinearUnitFactory //all except Degree & Grad
    {
        private static Dictionary<string, ILinearUnit> _unitList = new Dictionary<string, ILinearUnit>();
        private static object _unitListLock = new object();


        /// <summary>
        /// Gets the instance of the LinearUnit specified by linearUnitType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="linearUnitType">The type of linear unit you want. Must implement <see cref="ILinearUnit"/>.</param>
        /// <returns>An instance of the specified System.Type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if linearUnitType is null.</exception>
        /// <exception cref="Exceptions.InvalidLinearUnitTypeException">Thrown if linearUnitType cannot be found within this assembly or if it does not implement ILinearUnit.</exception>
        public static ILinearUnit GetInstanceOfLinearUnit(Type linearUnitType)
        {
            ArgumentNullException.ThrowIfNull(linearUnitType);
            if (!LinearUnitTypeExists(linearUnitType.Name)) throw new Exceptions.InvalidLinearUnitTypeException();
            if (linearUnitType.GetInterface("ILinearUnit") != typeof(ILinearUnit)) throw new Exceptions.InvalidLinearUnitTypeException();

            if (!_unitList.ContainsKey(linearUnitType.Name))
            {
                ILinearUnit au = (ILinearUnit)(linearUnitType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidLinearUnitTypeException()).Invoke(Array.Empty<object>());
                lock (_unitListLock)
                {
                    _unitList.TryAdd(au.Name, au);
                }
            }
            return _unitList[linearUnitType.Name];
        }

        /// <summary>
        /// Gets the instance of the LinearUnit specified by linearUnitTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="linearUnitTypeName">The name of the linear unit type you want.</param>
        /// <returns>An instance of the specified type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if linearUnitTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidLinearUnitTypeException">Thrown if linearUnitTypeName does not exist.</exception>
        public static ILinearUnit GetInstanceOfLinearUnit(string linearUnitTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(linearUnitTypeName);
            if (!LinearUnitTypeExists(linearUnitTypeName)) throw new Exceptions.InvalidLinearUnitTypeException();

            Type linearUnitType = GetLinearUnitType(linearUnitTypeName);
            return GetInstanceOfLinearUnit(linearUnitType);
        }

        /// <summary>
        /// Determines whether a type named linearUnitTypeName exists in the <c>LinearUnits</c> namespace.
        /// </summary>
        /// <param name="linearUnitTypeName">The name of the linear unit type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if linearUnitTypeName is null or empty.</exception>
        public static bool LinearUnitTypeExists(string linearUnitTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(linearUnitTypeName);
            if (linearUnitTypeName.Equals(typeof(LinearUnits.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(LinearUnits.Undefined).Namespace && types[i].Name.Equals(linearUnitTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> named linearUnitTypeName.
        /// </summary>
        /// <param name="linearUnitTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="LinearUnits.Undefined"/> if no type named linearUnitTypeName exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if linearUnitTypeName is null or empty.</exception>
        public static Type GetLinearUnitType(string linearUnitTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(linearUnitTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(linearUnitTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(LinearUnits.Undefined);
        }
    }
}


