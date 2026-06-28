// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Reflection;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of map Projections based upon a specified projection type
    /// and a set of named projection parameters.
    /// </summary>
    public static class ProjectionFactory
    {
        /// <summary>
        /// Creates a new instance of the Projection specified by projectionType, configured with the given parameters.
        /// </summary>
        /// <param name="projectionType">The type of projection you want. Must implement <see cref="IProjection"/>.</param>
        /// <param name="parameters">The named parameters (e.g. False_Easting, Central_Meridian) used to configure the projection.</param>
        /// <returns>A new projection instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if projectionType is null.</exception>
        /// <exception cref="Exceptions.InvalidProjectionTypeException">Thrown if projectionType does not exist or does not implement <see cref="IProjection"/>.</exception>
        public static IProjection GetInstanceOfProjection(Type projectionType, ProjectionParameter[] parameters)
        {
            ArgumentNullException.ThrowIfNull(projectionType);
            if (!ProjectionTypeExists(projectionType.Name)) throw new Exceptions.InvalidProjectionTypeException();
            if (projectionType.GetInterface("IProjection") != typeof(IProjection)) throw new Exceptions.InvalidProjectionTypeException();

            IProjection p = (IProjection)(projectionType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(ProjectionParameter[]) }, null) ?? throw new Exceptions.InvalidProjectionTypeException()).Invoke(new object[] { parameters });
            return p;
        }

        /// <summary>
        /// Creates a new instance of the Projection specified by projectionTypeName, configured with the given parameters.
        /// </summary>
        /// <param name="projectionTypeName">The name of the projection type you want.</param>
        /// <param name="parameters">The named parameters (e.g. False_Easting, Central_Meridian) used to configure the projection.</param>
        /// <returns>A new projection instance.</returns>
        /// <exception cref="ArgumentException">Thrown if projectionTypeName is null or empty.</exception>
        /// <exception cref="Exceptions.InvalidProjectionTypeException">Thrown if projectionTypeName does not exist.</exception>
        public static IProjection GetInstanceOfProjection(string projectionTypeName, ProjectionParameter[] parameters)
        {
            ArgumentException.ThrowIfNullOrEmpty(projectionTypeName);
            if (!ProjectionTypeExists(projectionTypeName)) throw new Exceptions.InvalidProjectionTypeException();

            Type projectionType = GetProjectionType(projectionTypeName);
            return GetInstanceOfProjection(projectionType, parameters);
        }

        /// <summary>
        /// Determines whether a type named projectionTypeName exists in the <c>Projections</c> namespace.
        /// </summary>
        /// <param name="projectionTypeName">The name of the projection type to look for.</param>
        /// <returns>True if the type exists; otherwise, false.</returns>
        /// <exception cref="ArgumentException">Thrown if projectionTypeName is null or empty.</exception>
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

        /// <summary>
        /// Gets the <see cref="Type"/> named projectionTypeName.
        /// </summary>
        /// <param name="projectionTypeName">The name of the type to look for.</param>
        /// <returns>The matching type, or <see cref="Projections.Undefined"/> if no type named projectionTypeName exists.</returns>
        /// <exception cref="ArgumentException">Thrown if projectionTypeName is null or empty.</exception>
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


