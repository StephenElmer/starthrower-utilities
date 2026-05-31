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
using System.Reflection;
using System.Collections.Generic;

namespace StarThrower.Gis.GeoUtilities
{
    public static class LinearUnitFactory //all except Degree & Grad
    {
        private static Dictionary<string, ILinearUnit> _unitList = new Dictionary<string, ILinearUnit>();
        private static object _unitListLock = new object();


        /// <summary>
        /// Gets the instance of the LinearUnit specified by linearUnitType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="linearUnitType"></param>
        /// <returns>An instance of the specified System.Type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if linearUnitType is null.</exception>
        /// <exception cref="Exceptions.InvalidLinearUnitTypeException">Thrown if linearUnitType cannot be found within this assembly or if it does not implement ILinearUnit.</exception>
        public static ILinearUnit GetInstanceOfLinearUnit(Type linearUnitType)
        {
            if (linearUnitType == null) throw new ArgumentNullException("linearUnitType");
            if (!LinearUnitTypeExists(linearUnitType.Name)) throw new Exceptions.InvalidLinearUnitTypeException();
            if (linearUnitType.GetInterface("ILinearUnit") != typeof(ILinearUnit)) throw new Exceptions.InvalidLinearUnitTypeException();

            if (!_unitList.ContainsKey(linearUnitType.Name))
            {
                ILinearUnit au = (ILinearUnit)(linearUnitType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidLinearUnitTypeException()).Invoke(new object[] { });
                lock (_unitListLock)
                {
                    if (!_unitList.ContainsKey(au.Name))
                    {
                        _unitList.Add(au.Name, au);
                    }
                }
            }
            return _unitList[linearUnitType.Name];
        }
        public static ILinearUnit GetInstanceOfLinearUnit(string linearUnitTypeName)
        {
            if (linearUnitTypeName == null) throw new ArgumentNullException("linearUnitTypeName");
            if (!LinearUnitTypeExists(linearUnitTypeName)) throw new Exceptions.InvalidLinearUnitTypeException();

            Type linearUnitType = GetLinearUnitType(linearUnitTypeName);
            return GetInstanceOfLinearUnit(linearUnitType);
        }
        public static bool LinearUnitTypeExists(string linearUnitTypeName)
        {
            if (linearUnitTypeName == null) throw new ArgumentNullException("linearUnitTypeName");
            if (linearUnitTypeName.Equals(typeof(LinearUnits.Undefined).Name)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(LinearUnits.Undefined).Namespace && types[i].Name.Equals(linearUnitTypeName))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetLinearUnitType(string linearUnitTypeName)
        {
            if (linearUnitTypeName == null) throw new ArgumentNullException("linearUnitTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(linearUnitTypeName))
                {
                    return types[i];
                }
            }
            return typeof(LinearUnits.Undefined);
        }
    }
}
