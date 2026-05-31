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
            if (angularUnitType == null) throw new ArgumentNullException("angularUnitType");
            if (!AngularUnitTypeExists(angularUnitType.Name)) throw new Exceptions.InvalidAngularUnitTypeException();
            if (angularUnitType.GetInterface("IAngularUnit") != typeof(IAngularUnit)) throw new Exceptions.InvalidAngularUnitTypeException();

            if (!_unitList.ContainsKey(angularUnitType.Name))
            {
                IAngularUnit au = (IAngularUnit)(angularUnitType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidAngularUnitTypeException()).Invoke(new object[] { });
                lock (_unitListLock)
                {
                    if (!_unitList.ContainsKey(au.Name))
                    {
                        _unitList.Add(au.Name, au);
                    }
                }
            }
            return _unitList[angularUnitType.Name];
        }

        public static IAngularUnit GetInstanceOfAngularUnit(string angularUnitTypeName)
        {
            if (angularUnitTypeName == null) throw new ArgumentNullException("angularUnitTypeName");
            if (!AngularUnitTypeExists(angularUnitTypeName)) throw new Exceptions.InvalidAngularUnitTypeException();

            Type angularUnitType = GetAngularUnitType(angularUnitTypeName);
            return GetInstanceOfAngularUnit(angularUnitType);
        }

        public static bool AngularUnitTypeExists(string angularUnitTypeName)
        {
            if (angularUnitTypeName == null) throw new ArgumentNullException("angularUnitTypeName");
            if (angularUnitTypeName.Equals(typeof(AngularUnits.Undefined).Name)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(AngularUnits.Undefined).Namespace && types[i].Name.Equals(angularUnitTypeName))
                {
                    return true;
                }
            }
            return false;
        }

        public static Type GetAngularUnitType(string angularUnitTypeName)
        {
            if (angularUnitTypeName == null) throw new ArgumentNullException("angularUnitTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(angularUnitTypeName))
                {
                    return types[i];
                }
            }
            return typeof(AngularUnits.Undefined);
        }
    }
}


