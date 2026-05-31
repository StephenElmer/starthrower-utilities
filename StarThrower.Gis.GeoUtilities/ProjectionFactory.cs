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

namespace StarThrower.Gis.GeoUtilities
{
    public static class ProjectionFactory
    {
        public static IProjection GetInstanceOfProjection(Type projectionType, ProjectionParameter[] parameters)
        {
            if (projectionType == null) throw new ArgumentNullException("projectionType");
            if (!ProjectionTypeExists(projectionType.Name)) throw new Exceptions.InvalidProjectionTypeException();
            if (projectionType.GetInterface("IProjection") != typeof(IProjection)) throw new Exceptions.InvalidProjectionTypeException();
            
            IProjection p = (IProjection)(projectionType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(ProjectionParameter[]) }, null) ?? throw new Exceptions.InvalidProjectionTypeException()).Invoke(new object[] { parameters });
            return p;
        }
        public static IProjection GetInstanceOfProjection(string projectionTypeName, ProjectionParameter[] parameters)
        {
            if (projectionTypeName == null) throw new ArgumentNullException("projectionTypeName");
            if (!ProjectionTypeExists(projectionTypeName)) throw new Exceptions.InvalidProjectionTypeException();

            Type projectionType = GetProjectionType(projectionTypeName);
            return GetInstanceOfProjection(projectionType, parameters);
        }
        public static bool ProjectionTypeExists(string projectionTypeName)
        {
            if (projectionTypeName == null) throw new ArgumentNullException("projectionTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(Projections.Undefined).Namespace && types[i].Name.Equals(projectionTypeName))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetProjectionType(string projectionTypeName)
        {
            if (projectionTypeName == null) throw new ArgumentNullException("projectionTypeName");
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(projectionTypeName))
                {
                    return types[i];
                }
            }
            return typeof(Projections.Undefined);
        }
    }
}


