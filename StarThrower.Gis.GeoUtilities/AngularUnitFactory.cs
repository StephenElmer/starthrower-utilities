// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of AngularUnits (e.g. Degree, Grad) based upon a specified angular unit type.
    /// </summary>
    public static class AngularUnitFactory //Degree & Grad
    {
        private static Dictionary<string, IAngularUnit> _unitList = new Dictionary<string, IAngularUnit>();
        private static object _unitListLock = new Object();

        /// <summary>
        /// Gets the instance of the AngularUnit specified by angularUnitType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="angularUnitType">The type of angular unit you want. Must implement <see cref="IAngularUnit"/>; <c>Undefined</c> is considered invalid.</param>
        /// <returns>The angular unit instance associated with angularUnitType.</returns>
        /// <exception cref="ArgumentNullException">Thrown if angularUnitType is null.</exception>
        /// <exception cref="Exceptions.InvalidAngularUnitTypeException">Thrown if angularUnitType does not exist or does not implement <see cref="IAngularUnit"/>.</exception>
        public static IAngularUnit GetInstanceOfAngularUnit(Type angularUnitType)
        {
            ArgumentNullException.ThrowIfNull(angularUnitType);
            if (!AngularUnitTypeExists(angularUnitType.Name)) throw new Exceptions.InvalidAngularUnitTypeException();
            if (angularUnitType.GetInterface("IAngularUnit") != typeof(IAngularUnit)) throw new Exceptions.InvalidAngularUnitTypeException();

            if (!_unitList.ContainsKey(angularUnitType.Name))
            {
                IAngularUnit au = (IAngularUnit)(angularUnitType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidAngularUnitTypeException()).Invoke(Array.Empty<object>());
                lock (_unitListLock)
                {
                    _unitList.TryAdd(au.Name, au);
                }
            }
            return _unitList[angularUnitType.Name];
        }

        /// <summary>
        /// Gets the instance of the AngularUnit specified by angularUnitTypeName.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="angularUnitTypeName">The name of the angular unit type you want.</param>
        /// <returns>The angular unit instance associated with angularUnitTypeName.</returns>
        /// <exception cref="ArgumentNullException">Thrown if angularUnitTypeName is null.</exception>
        /// <exception cref="Exceptions.InvalidAngularUnitTypeException">Thrown if angularUnitTypeName does not exist.</exception>
        public static IAngularUnit GetInstanceOfAngularUnit(string angularUnitTypeName)
        {
            ArgumentNullException.ThrowIfNull(angularUnitTypeName);
            if (!AngularUnitTypeExists(angularUnitTypeName)) throw new Exceptions.InvalidAngularUnitTypeException();

            Type angularUnitType = GetAngularUnitType(angularUnitTypeName);
            return GetInstanceOfAngularUnit(angularUnitType);
        }

        /// <summary>
        /// Determines whether a type named angularUnitTypeName exists in the <c>AngularUnits</c> namespace.
        /// </summary>
        /// <param name="angularUnitTypeName">The name of the angular unit type to look for.</param>
        /// <returns>True if the type exists (other than <c>Undefined</c>); otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if angularUnitTypeName is null.</exception>
        public static bool AngularUnitTypeExists(string angularUnitTypeName)
        {
            ArgumentNullException.ThrowIfNull(angularUnitTypeName);

            if (angularUnitTypeName.Equals(typeof(AngularUnits.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(AngularUnits.Undefined).Namespace && types[i].Name.Equals(angularUnitTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> named angularUnitTypeName.
        /// </summary>
        /// <param name="angularUnitTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="AngularUnits.Undefined"/> if no type named angularUnitTypeName exists.</returns>
        /// <exception cref="ArgumentNullException">Thrown if angularUnitTypeName is null.</exception>
        public static Type GetAngularUnitType(string angularUnitTypeName)
        {
            ArgumentNullException.ThrowIfNull(angularUnitTypeName);

            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(angularUnitTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(AngularUnits.Undefined);
        }
    }
}


