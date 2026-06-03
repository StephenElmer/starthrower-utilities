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
using StarThrower.Logging;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    public static class GeoidFactory
    {
        private static Dictionary<string, IGeoid> _geoidList = new Dictionary<string, IGeoid>();
        private static object _geoidListLock = new object();

        public static IGeoid GetInstanceOfGeoid(Type geoidType)
        {
            ArgumentNullException.ThrowIfNull(geoidType);
            if (geoidType.Equals(typeof(Geoids.Undefined))) throw new Exceptions.AmbiguousGeoidTypeException();
            if (!GeoidTypeExists(geoidType.Name)) throw new Exceptions.InvalidGeoidTypeException();
            if (geoidType.GetInterface("IGeoid") != typeof(IGeoid)) throw new Exceptions.InvalidGeoidTypeException();

            if (!_geoidList.ContainsKey(geoidType.Name))
            {
                IGeoid g = (IGeoid)(geoidType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidGeoidTypeException()).Invoke(new object[] { });
                lock (_geoidListLock)
                {
                    _geoidList.TryAdd(g.Key, g);
                }
            }
            return _geoidList[geoidType.Name];
        }
        public static IGeoid GetInstanceOfGeoid(string geoidTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(geoidTypeName);
            if (geoidTypeName.Equals(typeof(Geoids.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousGeoidTypeException();
            if (!GeoidTypeExists(geoidTypeName)) throw new Exceptions.InvalidGeoidTypeException();

            Type geoidType = GetGeoidType(geoidTypeName);
            return GetInstanceOfGeoid(geoidType);
        }
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

        public static IGeoid GetInstanceOfNewUserDefinedGeoid(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            if (!StringUtil.IsValid(name, Geoid.ValidNamePattern)) throw new Exceptions.InvalidGeoidTypeException("Invalid format for geoid name.");

            try
            {
                string key = typeof(Geoids.UserDefined).Name + name;
                if (!_geoidList.ContainsKey(key))
                {
                    Geoids.UserDefined g = new Geoids.UserDefined(name);
                    lock (_geoidListLock)
                    {
                        if (!_geoidList.ContainsKey(g.Key))
                        {
                            _geoidList.Add(g.Key, g);
                        }
                    }
                    return _geoidList[g.Key];
                }
                else
                {
                    IGeoid g = _geoidList[key];
                    return g;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "GeoidFactory.GetInstanceOfNewUserDefinedGeoid(string)", ex);
                throw;
            }
        }
    }
}


