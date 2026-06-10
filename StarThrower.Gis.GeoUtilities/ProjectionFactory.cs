// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;

namespace StarThrower.Gis.GeoUtilities
{
    public static class ProjectionFactory
    {
        public static IProjection GetInstanceOfProjection(Type projectionType, ProjectionParameter[] parameters)
        {
            ArgumentNullException.ThrowIfNull(projectionType);
            if (!ProjectionTypeExists(projectionType.Name)) throw new Exceptions.InvalidProjectionTypeException();
            if (projectionType.GetInterface("IProjection") != typeof(IProjection)) throw new Exceptions.InvalidProjectionTypeException();
            
            IProjection p = (IProjection)(projectionType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(ProjectionParameter[]) }, null) ?? throw new Exceptions.InvalidProjectionTypeException()).Invoke(new object[] { parameters });
            return p;
        }
        public static IProjection GetInstanceOfProjection(string projectionTypeName, ProjectionParameter[] parameters)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectionTypeName);
            if (!ProjectionTypeExists(projectionTypeName)) throw new Exceptions.InvalidProjectionTypeException();

            Type projectionType = GetProjectionType(projectionTypeName);
            return GetInstanceOfProjection(projectionType, parameters);
        }
        public static bool ProjectionTypeExists(string projectionTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectionTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(Projections.Undefined).Namespace && types[i].Name.Equals(projectionTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetProjectionType(string projectionTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectionTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(projectionTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(Projections.Undefined);
        }
    }
}


