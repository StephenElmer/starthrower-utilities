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

namespace StarThrower.Gis.GeoUtilities
{
    public static class AngularUnitFactory //Degree & Grad
    {
        private static Dictionary<string, IAngularUnit> _unitList = new Dictionary<string, IAngularUnit>();
        private static object _unitListLock = new Object();        
        
        /// <summary>
        /// Gets the instance of the AngularUnit specified by angularUnitType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="angularUnitType"></param>
        /// <returns></returns>
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
        public static IAngularUnit GetInstanceOfAngularUnit(string angularUnitTypeName)
        {
            ArgumentNullException.ThrowIfNull(angularUnitTypeName);
            if (!AngularUnitTypeExists(angularUnitTypeName)) throw new Exceptions.InvalidAngularUnitTypeException();

            Type angularUnitType = GetAngularUnitType(angularUnitTypeName);
            return GetInstanceOfAngularUnit(angularUnitType);
        }

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


