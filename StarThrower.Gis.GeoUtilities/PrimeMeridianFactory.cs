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
        
        public static IPrimeMeridian GetInstanceOfPrimeMeridian(string primeMeridianTypeName)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(primeMeridianTypeName);
            if (!PrimeMeridianTypeExists(primeMeridianTypeName)) throw new Exceptions.InvalidPrimeMeridianTypeException();

            Type primeMeridianType = GetPrimeMeridianType(primeMeridianTypeName);
            return GetInstanceOfPrimeMeridian(primeMeridianType);
        }

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


