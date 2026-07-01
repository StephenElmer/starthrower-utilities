// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StarThrower.MathUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The central entry point for converting coordinates between coordinate systems, plus
    /// shared constants and reflection-based discovery of the supported types
    /// (angular/linear units, datums, ellipsoids, prime meridians, projections, and coordinate systems).
    /// </summary>
    public static class GeoUtil
    {
        #region Public Constants

        /// <summary>The maximum valid latitude, in decimal degrees.</summary>
        public const int MaxLat = 90;

        /// <summary>The minimum valid latitude, in decimal degrees.</summary>
        public const int MinLat = -90;

        /// <summary>The maximum valid longitude, in decimal degrees.</summary>
        public const int MaxLon = 180;

        /// <summary>The minimum valid longitude, in decimal degrees.</summary>
        public const int MinLon = -180;



        /// <summary>Pi divided by 2 (90 degrees, in radians).</summary>
        public const double PiOver2 = Math.PI / 2.0;

        /// <summary>The multiplier to convert decimal degrees to radians.</summary>
        public const double DegreesToRadians = (Math.PI / 180.0);

        /// <summary>The multiplier to convert radians to decimal degrees.</summary>
        public const double RadiansToDegrees = (180.0 / Math.PI);

        /// <summary>The cosine of 67.5 degrees, used as a threshold in geocentric-to-geodetic coordinate conversion.</summary>
        public const double Cos67P5 = 0.38268343236508977; // cosine of 67.5 degrees

        /// <summary>A correction constant (Toms region 1) used in geocentric-to-geodetic coordinate conversion.</summary>
        public const double ADC = 1.0026000; // Toms region 1 constant

        /// <summary>Two times Pi (360 degrees, in radians).</summary>
        public const double TwoPi = Math.PI * 2.0;

        /// <summary>The multiplier to convert radians to decimal degrees. Equivalent to <see cref="RadiansToDegrees"/>.</summary>
        public const double PiUnder180 = (180.0 / Math.PI);

        /// <summary>The number of arcseconds in one radian.</summary>
        public const double SecondsPerRadian = 206264.8062471; // Seconds in a radian

        /// <summary>The maximum absolute latitude, in radians, for which Molodensky's datum shift method remains valid; beyond this, the three-step geocentric method is used instead.</summary>
        public const double MolodenskyMax = (89.75 * Math.PI / 180.0); // Polar limit

        /// <summary>The geoid height grid scale factor for a 15-minute grid spacing (4 grid cells per degree).</summary>
        public const double ScaleFactor15Minutes = .25; // 4 grid cells per degree at 15 minute spacing

        /// <summary>The geoid height grid scale factor for a 10-degree grid spacing (1/10 grid cell per degree).</summary>
        public const double ScaleFactor10Degrees = 10; //1 / 10.0 grid cells per degree at 10 degree spacing

        /// <summary>The geoid height grid scale factor for a 30-minute grid spacing (2 grid cells per degree).</summary>
        public const double ScaleFactor30Minutes = .5; //2 grid cells per degree at 30 minute spacing

        /// <summary>The geoid height grid scale factor for a 1-degree grid spacing (1 grid cell per degree).</summary>
        public const double ScaleFactor1Degree = 1; //1 grid cell per degree at 1 degree spacing

        /// <summary>The geoid height grid scale factor for a 2-degree grid spacing (1/2 grid cell per degree).</summary>
        public const double ScaleFactor2Degrees = 2; //1 / 2 grid cells per degree at 2 degree spacing


        #endregion


        #region Public Methods

        /// <summary>
        /// Tests whether the specified latitude is within the valid range (<see cref="MinLat"/> to <see cref="MaxLat"/>).
        /// </summary>
        /// <param name="lat">The latitude, in decimal degrees, to test.</param>
        /// <returns>True if lat is between <see cref="MinLat"/> and <see cref="MaxLat"/>, inclusive.</returns>
        public static bool IsValidLat(double lat)
        {
            return (lat <= MaxLat && lat >= MinLat);
        }

        /// <summary>
        /// Tests whether the specified longitude is within the valid range (<see cref="MinLon"/> to <see cref="MaxLon"/>).
        /// </summary>
        /// <param name="lon">The longitude, in decimal degrees, to test.</param>
        /// <returns>True if lon is between <see cref="MinLon"/> and <see cref="MaxLon"/>, inclusive.</returns>
        public static bool IsValidLon(double lon)
        {
            return (lon <= MaxLon && lon >= MinLon);
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="AngularUnit"/> types defined in this assembly
        /// (excluding <see cref="AngularUnits.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select an Angular Unit.
        /// </summary>
        public static Collection<Type> AngularUnitTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(AngularUnits.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(AngularUnits.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="AngularUnit"/> types defined
        /// in this assembly (excluding <see cref="AngularUnits.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select an Angular Unit.
        /// </summary>
        public static Collection<string> AngularUnitTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(AngularUnits.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(AngularUnits.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="Datum"/> types defined in this assembly
        /// (excluding <see cref="Datums.Undefined"/> and <see cref="Datums.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Datum.
        /// </summary>
        public static Collection<Type> DatumTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Datums.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Datums.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(Datums.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="Datum"/> types defined in this
        /// assembly (excluding <see cref="Datums.Undefined"/> and <see cref="Datums.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Datum.
        /// </summary>
        public static Collection<string> DatumTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Datums.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Datums.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(Datums.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="Ellipsoid"/> types defined in this assembly
        /// (excluding <see cref="Ellipsoids.Undefined"/> and <see cref="Ellipsoids.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select an Ellipsoid.
        /// </summary>
        public static Collection<Type> EllipsoidTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Ellipsoids.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Ellipsoids.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(Ellipsoids.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="Ellipsoid"/> types defined in
        /// this assembly (excluding <see cref="Ellipsoids.Undefined"/> and <see cref="Ellipsoids.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select an Ellipsoid.
        /// </summary>
        public static Collection<string> EllipsoidTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Ellipsoids.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Ellipsoids.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(Ellipsoids.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="LinearUnit"/> types defined in this assembly
        /// (excluding <see cref="LinearUnits.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Linear Unit.
        /// </summary>
        public static Collection<Type> LinearUnitTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(LinearUnits.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(LinearUnits.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="LinearUnit"/> types defined in
        /// this assembly (excluding <see cref="LinearUnits.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Linear Unit.
        /// </summary>
        public static Collection<string> LinearUnitTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(LinearUnits.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(LinearUnits.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="PrimeMeridian"/> types defined in this assembly
        /// (excluding <see cref="PrimeMeridians.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Prime Meridian.
        /// </summary>
        public static Collection<Type> PrimeMeridianTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(PrimeMeridians.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(PrimeMeridians.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="PrimeMeridian"/> types defined in
        /// this assembly (excluding <see cref="PrimeMeridians.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Prime Meridian.
        /// </summary>
        public static Collection<string> PrimeMeridianTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(PrimeMeridians.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(PrimeMeridians.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="IProjection"/> implementation types defined in
        /// this assembly (excluding <see cref="Projections.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Projection Type.
        /// </summary>
        public static Collection<Type> ProjectionTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Projections.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Projections.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="IProjection"/> implementation
        /// types defined in this assembly (excluding <see cref="Projections.Undefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Projection Type.
        /// </summary>
        public static Collection<string> ProjectionTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(Projections.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(Projections.Undefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="CoordinateSystems.GeographicCoordinateSystem"/>
        /// types defined in this assembly (excluding <see cref="CoordinateSystems.Geographic.Undefined"/>
        /// and <see cref="CoordinateSystems.Geographic.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Geographic Coordinate System type.
        /// </summary>
        public static Collection<Type> GeographicCoordinateSystemTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(CoordinateSystems.Geographic.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Geographic.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Geographic.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }
        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="CoordinateSystems.GeographicCoordinateSystem"/>
        /// types defined in this assembly (excluding <see cref="CoordinateSystems.Geographic.Undefined"/>
        /// and <see cref="CoordinateSystems.Geographic.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Geographic Coordinate System type.
        /// </summary>
        public static Collection<string> GeographicCoordinateSystemTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(CoordinateSystems.Geographic.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Geographic.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Geographic.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the concrete <see cref="CoordinateSystems.ProjectedCoordinateSystem"/>
        /// types defined in this assembly (excluding <see cref="CoordinateSystems.Projected.Undefined"/>
        /// and <see cref="CoordinateSystems.Projected.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Projected Coordinate System type.
        /// </summary>
        // public static List<ProjectedCoordinateSystemType> GetProjectedCoordinateSystemTypes()
        // {
        //     List<ProjectedCoordinateSystemType> result = new List<ProjectedCoordinateSystemType>();
        //     Array vals = Enum.GetValues(typeof(ProjectedCoordinateSystemType));
        //     for (int i = 0; i < vals.Length; i++)
        //     {
        //         ProjectedCoordinateSystemType t = (ProjectedCoordinateSystemType)(vals.GetValue(i));
        //         if (t != ProjectedCoordinateSystemType.Undefined && t != ProjectedCoordinateSystemType.UserDefined)
        //         {
        //             result.Add(t);
        //         }
        //     }
        //     return result;
        // }
        public static Collection<Type> ProjectedCoordinateSystemTypes
        {
            get
            {
                Collection<Type> result = new Collection<Type>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(CoordinateSystems.Projected.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Projected.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Projected.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i]);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets a collection of the type names of the concrete <see cref="CoordinateSystems.ProjectedCoordinateSystem"/>
        /// types defined in this assembly (excluding <see cref="CoordinateSystems.Projected.Undefined"/>
        /// and <see cref="CoordinateSystems.Projected.UserDefined"/>).
        /// Intended to be used for populating a list or combo box from which a user can select a Projected Coordinate System type.
        /// </summary>
        public static Collection<string> ProjectedCoordinateSystemTypeNames
        {
            get
            {
                Collection<string> result = new Collection<string>();

                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                for (int i = 0; i < types.Length; i++)
                {
                    if (types[i] != null && types[i].Namespace != null && types[i].Name != null &&
                        types[i].Namespace == typeof(CoordinateSystems.Projected.Undefined).Namespace &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Projected.Undefined).Name, StringComparison.Ordinal) &&
                        !types[i].Name.Equals(typeof(CoordinateSystems.Projected.UserDefined).Name, StringComparison.Ordinal))
                    {
                        result.Add(types[i].Name);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Converts a coordinate from one coordinate system to another.
        /// </summary>
        /// <param name="csFrom">The coordinate system the input coordinate is expressed in.</param>
        /// <param name="csTo">The coordinate system to convert the coordinate to.</param>
        /// <param name="xLon">The x (or longitude/easting-equivalent) coordinate, in csFrom.</param>
        /// <param name="yLat">The y (or latitude/northing-equivalent) coordinate, in csFrom.</param>
        /// <param name="zAlt">The vertical (height/altitude) coordinate, in csFrom.</param>
        /// <returns>
        /// The resulting coordinate in csTo, along with the estimated accumulated computational error.
        /// </returns>
        /// <remarks>
        /// Converts csFrom's coordinate to geodetic coordinates, shifts to WGS84 if csFrom and csTo
        /// use different datums or height interpretations, adjusts the height component per
        /// <see cref="HeightType"/> (using the EGM96 or EGM84 geoid models where required), shifts
        /// from WGS84 to csTo's datum, and finally converts to csTo's coordinate system.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if csFrom or csTo is null.</exception>
        public static ITranslationResult Translate(ICoordinateSystem csFrom, ICoordinateSystem csTo, double xLon, double yLat, double zAlt)
        {
            ArgumentNullException.ThrowIfNull(csFrom);
            ArgumentNullException.ThrowIfNull(csTo);

            double wgs84x = 0.0;
            double wgs84y = 0.0;
            double wgs84z = 0.0;

            double shiftedX = 0.0;
            double shiftedY = 0.0;
            double shiftedZ = 0.0;

            //Convert from the source coordinate system into a geodetic coordinate system (based upon the source datum)
            ITranslationResult convertedGeodeticResult = csFrom.ToGeodetic(xLon, yLat, zAlt);

            //If necessary, shift from the source datum to the destination datum
            if ((csFrom.Datum.Equals(csTo.Datum)) &&
                (csFrom.HeightType.Equals(csTo.HeightType) || (csFrom.HeightType == HeightType.NoHeight) || (csTo.HeightType == HeightType.NoHeight)))
            {
                wgs84x = convertedGeodeticResult.xLon;
                wgs84y = convertedGeodeticResult.yLat;
                wgs84z = convertedGeodeticResult.zAlt;
                shiftedX = convertedGeodeticResult.xLon;
                shiftedY = convertedGeodeticResult.yLat;
                shiftedZ = convertedGeodeticResult.zAlt;
                if (csFrom.HeightType == HeightType.NoHeight || csTo.HeightType == HeightType.NoHeight)
                {
                    shiftedZ = 0.0;
                }
            }
            else //shift to wgs84, apply geoid correction, shift to output datum
            {
                if (!(csFrom.Datum is Datums.Wgs1984))
                {
                    csFrom.Datum.ToWgs84(convertedGeodeticResult.xLon, convertedGeodeticResult.yLat, convertedGeodeticResult.zAlt, ref wgs84x, ref wgs84y, ref wgs84z);

                    switch (csFrom.HeightType)
                    {
                        case HeightType.GeoidOrMslHeight:
                        case HeightType.MslEgm96VgNsHeight:
                        case HeightType.MslEgm8410dBlHeight:
                        case HeightType.MslEgm8410dNsHeight:
                            wgs84z = convertedGeodeticResult.zAlt;
                            break;
                        case HeightType.NoHeight:
                            wgs84z = 0.0;
                            break;
                        default:
                            break;
                    }

                    //check input datum validity
                    if (!csFrom.Datum.Validate(wgs84x, wgs84y))
                    {
                        throw new InvalidOperationException("Invalid x, y values for datum.");
                    }
                }
                else //copy the coordites
                {
                    wgs84x = convertedGeodeticResult.xLon;
                    wgs84y = convertedGeodeticResult.yLat;
                    wgs84z = convertedGeodeticResult.zAlt;
                    if (csFrom.HeightType == HeightType.NoHeight)
                    {
                        wgs84z = 0.0;
                    }
                }

                if (csFrom.HeightType != csTo.HeightType)
                {
                    double tempHeight = 0.0;
                    double correctedHeight = 0.0;

                    //Convert the input height value to an ellipsoid height value
                    IGeoid egm96 = GeoidFactory.GetInstanceOfGeoid(typeof(Geoids.Egm96));
                    IGeoid egm84 = GeoidFactory.GetInstanceOfGeoid(typeof(Geoids.Egm84));
                    switch (csFrom.HeightType)
                    {
                        case HeightType.GeoidOrMslHeight:
                            Convert_Geoid_To_Ellipsoid_Height(wgs84x, wgs84y, wgs84z, ref tempHeight);
                            
                            break;
                        case HeightType.MslEgm96VgNsHeight:
                            egm96.ToEllipsoidHeightNs(wgs84x, wgs84y, wgs84z, ref tempHeight);
                            break;
                        case HeightType.MslEgm8410dBlHeight:
                            egm84.ToEllipsoidHeightBl(wgs84x, wgs84y, wgs84z, ref tempHeight);
                            break;
                        case HeightType.MslEgm8410dNsHeight:
                            egm84.ToEllipsoidHeightNs(wgs84x, wgs84y, wgs84z, ref tempHeight);
                            break;
                        case HeightType.EllipsoidHeight:
                        default:
                            tempHeight = wgs84z;
                            break;
                    }

                    //Convert the ellipsoid height value to the output height value
                    switch (csTo.HeightType)
                    {
                        case HeightType.GeoidOrMslHeight:
                            Convert_Ellipsoid_To_Geoid_Height(wgs84x, wgs84y, tempHeight, ref correctedHeight);
                            break;
                        case HeightType.MslEgm96VgNsHeight:
                            egm96.FromEllipsoidHeightNs(wgs84x, wgs84y, tempHeight, ref correctedHeight);
                            break;
                        case HeightType.MslEgm8410dBlHeight:
                            egm84.FromEllipsoidHeightBl(wgs84x, wgs84y, tempHeight, ref correctedHeight);
                            break;
                        case HeightType.MslEgm8410dNsHeight:
                            egm84.FromEllipsoidHeightNs(wgs84x, wgs84y, tempHeight, ref correctedHeight);
                            break;
                        case HeightType.EllipsoidHeight:
                        default:
                            correctedHeight = tempHeight;
                            break;
                    }

                    //Set the output height
                    wgs84z = correctedHeight;
                }


                if (!(csFrom.Datum is Datums.Wgs1984))
                {
                    csTo.Datum.FromWgs84(wgs84x, wgs84y, wgs84z, ref shiftedX, ref shiftedY, ref shiftedZ);

                    switch (csTo.HeightType)
                    {
                        case HeightType.GeoidOrMslHeight:
                        case HeightType.MslEgm96VgNsHeight:
                        case HeightType.MslEgm8410dBlHeight:
                        case HeightType.MslEgm8410dNsHeight:
                            shiftedZ = wgs84z;
                            break;
                        case HeightType.NoHeight:
                            shiftedZ = 0.0;
                            break;
                        default:
                            break;
                    }

                    //check output datum validity
                    if (!csTo.Datum.Validate(wgs84x, wgs84y))
                    {
                        throw new InvalidOperationException("Invalid x, y values for datum.");
                    }
                }
                else //copy the coordinates
                {
                    shiftedX = wgs84x;
                    shiftedY = wgs84y;
                    shiftedZ = wgs84z;
                    if (csTo.HeightType == HeightType.NoHeight)
                    {
                        shiftedZ = 0.0;
                    }
                }
            }

            double ce90 = -1.0;
            double le90 = -1.0;
            double se90 = -1.0;

            //2026/05/24 - modifed to get radians
            //GetDatumShiftError(csFrom.Datum, csTo.Datum, wgs84x, wgs84y, ref ce90, ref le90, ref se90);
            double xRad = wgs84x * DegreesToRadians;
            double yRad = wgs84y * DegreesToRadians;
            GetDatumShiftError(csFrom.Datum, csTo.Datum, xRad, yRad, ref ce90, ref le90, ref se90);

            //Convert from geodetic coordinate system in the target datum to the target coordinate system
            ITranslationResult result = csTo.FromGeodetic(wgs84x, wgs84y, wgs84z);
            result.SetComputationalError(ce90, le90, se90);
            return result;
        }

        #endregion


        //TODO: perhaps these should be refactored into the Datum class or some such place
        #region Private Methods used for translation

        /// <summary>
        /// Converts the specified WGS84 geoid height at the specified geodetic coordinates to the equivalent ellipsoid height, using the EGM96 gravity model and the bilinear interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="geoidHeight">Geoid height, in meters</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        private static void Convert_Geoid_To_Ellipsoid_Height(double xLon, double yLat, double geoidHeight, ref double ellipsoidHeight)
        {
            double deltaHeight = 0.0;
            IGeoid egm96 = GeoidFactory.GetInstanceOfGeoid(typeof(Geoids.Egm96));
            egm96.BlInterpolate(yLat, xLon, GeoUtil.ScaleFactor15Minutes, ref deltaHeight);
            ellipsoidHeight = geoidHeight + deltaHeight;
        }

        /// <summary>
        /// Converts the specified WGS84 ellipsoid height at the specified geodetic coordinates to the equivalent geoid height, using the EGM96 gravity model and the bilinear interpolation method.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians</param>
        /// <param name="yLat">Geodetic yLat in radians</param>
        /// <param name="ellipsoidHeight">Ellipsoid height, in meters</param>
        /// <param name="geoidHeight">Geoid height, in meters.</param>
        private static void Convert_Ellipsoid_To_Geoid_Height(double xLon, double yLat, double ellipsoidHeight, ref double geoidHeight)
        {
            double deltaHeight = 0.0;
            IGeoid egm96 = GeoidFactory.GetInstanceOfGeoid(typeof(Geoids.Egm96));
            egm96.BlInterpolate(yLat, xLon, GeoUtil.ScaleFactor15Minutes, ref deltaHeight);
            geoidHeight = ellipsoidHeight - deltaHeight;
        }

        /// <summary>
        /// Gets the 90% horizontal (circular), vertical (linear), and spherical errors 
        /// for a shift from the specified source datum to the specified destination 
        /// datum at the specified location.
        /// </summary>
        /// <param name="sourceDatum">The datum being shifted from.</param>
        /// <param name="destinationDatum">The datum being shifted to.</param>
        /// <param name="xLon">xLon of point being converted in radians</param>
        /// <param name="yLat">yLat of point being converted in radians</param>
        /// <param name="ce90">Combined 90% circular horizontal error in meters</param>
        /// <param name="le90">Combined 90% linear vertical error in meters</param>
        /// <param name="se90">Combined 90% spherical error in meters</param>
        private static void GetDatumShiftError(IDatum sourceDatum, IDatum destinationDatum, double xLon, double yLat, ref double ce90, ref double le90, ref double se90)
        {
            double sinlat = Math.Sin(yLat);
            double coslat = Math.Cos(yLat);
            double sinlon = Math.Sin(xLon);
            double coslon = Math.Cos(xLon);
            double sigma_delta_lat;
            double sigma_delta_lon;
            double sigma_delta_height;
            double sx, sy, sz;
            double ce90_in = -1.0;
            double le90_in = -1.0;
            double se90_in = -1.0;
            double ce90_out = -1.0;
            double le90_out = -1.0;
            double se90_out = -1.0;

            if ((yLat < (-90 * Math.PI / 180)) || (yLat > (90 * Math.PI / 180)))
            {
                throw new ArgumentOutOfRangeException(nameof(yLat));
            }
            if ((xLon < (-Math.PI)) || (xLon > (2 * Math.PI)))
            {
                throw new ArgumentOutOfRangeException(nameof(xLon));
            }
            if (sourceDatum.GetType().Equals(destinationDatum.GetType()))
            {
                return;
            }

            if (sourceDatum is Datums.Wgs1984 ||
                sourceDatum is Datums.Wgs1972 ||
                sourceDatum.IsSevenParamDatum)
            {
                ce90_in = 0.0;
                le90_in = 0.0;
                se90_in = 0.0;
            }
            else if (!sourceDatum.IsSevenParamDatum)
            {
                if ((sourceDatum.SigmaX < 0)
                    || (sourceDatum.SigmaY < 0)
                    || (sourceDatum.SigmaZ < 0))
                {
                    ce90_in = -1.0;
                    le90_in = -1.0;
                    se90_in = -1.0;
                }
                else
                {
                    sx = (sourceDatum.SigmaX * sinlat * coslon);
                    sy = (sourceDatum.SigmaY * sinlat * sinlon);
                    sz = (sourceDatum.SigmaZ * coslat);
                    sigma_delta_lat = Math.Sqrt((sx * sx) + (sy * sy) + (sz * sz));
                    sx = (sourceDatum.SigmaX * sinlon);
                    sy = (sourceDatum.SigmaY * coslon);
                    sigma_delta_lon = Math.Sqrt((sx * sx) + (sy * sy));
                    sx = (sourceDatum.SigmaX * coslat * coslon);
                    sy = (sourceDatum.SigmaY * coslat * sinlon);
                    sz = (sourceDatum.SigmaZ * sinlat);
                    sigma_delta_height = Math.Sqrt((sx * sx) + (sy * sy) + (sz * sz));
                    ce90_in = 2.146 * (sigma_delta_lat + sigma_delta_lon) / 2.0;
                    le90_in = 1.6449 * sigma_delta_height;
                    se90_in = 2.5003 * (sourceDatum.SigmaX + sourceDatum.SigmaY + sourceDatum.SigmaZ) / 3.0;
                }
            }


            //calculate output datum errors
            if (destinationDatum is Datums.Wgs1984 ||
                destinationDatum is Datums.Wgs1972 ||
                destinationDatum.IsSevenParamDatum)
            {
                ce90_out = 0.0;
                le90_out = 0.0;
                se90_out = 0.0;
            }
            else if (!destinationDatum.IsSevenParamDatum)
            {
                if ((destinationDatum.SigmaX < 0)
                    || (destinationDatum.SigmaY < 0)
                    || (destinationDatum.SigmaZ < 0))
                {
                    ce90_out = -1.0;
                    le90_out = -1.0;
                    se90_out = -1.0;
                }
                else
                {
                    sx = (destinationDatum.SigmaX * sinlat * coslon);
                    sy = (destinationDatum.SigmaY * sinlat * sinlon);
                    sz = (destinationDatum.SigmaZ * coslat);
                    sigma_delta_lat = Math.Sqrt((sx * sx) + (sy * sy) + (sz * sz));
                    sx = (destinationDatum.SigmaX * sinlon);
                    sy = (destinationDatum.SigmaY * coslon);
                    sigma_delta_lon = Math.Sqrt((sx * sx) + (sy * sy));
                    sx = (destinationDatum.SigmaX * coslat * coslon);
                    sy = (destinationDatum.SigmaY * coslat * sinlon);
                    sz = (destinationDatum.SigmaZ * sinlat);
                    sigma_delta_height = Math.Sqrt((sx * sx) + (sy * sy) + (sz * sz));
                    ce90_out = 2.146 * (sigma_delta_lat + sigma_delta_lon) / 2.0;
                    le90_out = 1.6449 * sigma_delta_height;
                    se90_out = 2.5003 * (destinationDatum.SigmaX + destinationDatum.SigmaY + destinationDatum.SigmaZ) / 3.0;
                }
            }


            //combine errors
            if ((ce90 < 0.0) || (ce90_in < 0.0) || (ce90_out < 0.0))
            {
                ce90 = -1.0;
                le90 = -1.0;
                se90 = -1.0;
            }
            else
            {
                ce90 = Math.Sqrt((ce90 * ce90) + (ce90_in * ce90_in) + (ce90_out * ce90_out));
                if (ce90 < 1.0)
                {
                    ce90 = 1.0;
                }
                if ((le90 < 0.0) || (le90_in < 0.0) || (le90_out < 0.0))
                {
                    le90 = -1.0;
                    se90 = -1.0;
                }
                else
                {
                    le90 = Math.Sqrt((le90 * le90) + (le90_in * le90_in) + (le90_out * le90_out));
                    if (le90 < 1.0)
                    {
                        le90 = 1.0;
                    }
                    if ((se90 < 0.0) || (se90_in < 0.0) || (se90_out < 0.0))
                    {
                        se90 = -1.0;
                    }
                    else
                    {
                        se90 = Math.Sqrt((se90 * se90) + (se90_in * se90_in) + (se90_out * se90_out));
                        if (se90 < 1.0)
                        {
                            se90 = 1.0;
                        }
                    }
                }
            }
        }

        #endregion


        #region Internal Methods

        /// <summary>
        /// This is the basic conversion for UTM to lat/lons. All other UTM to Lat/lon functions will call
        /// this one with the appropriate parameters. The equations used here are from Chapter 3, pgs. 11-19
        /// and Chapter 8 pgs., 48-65.
        /// </summary>
        /// <param name="x">easting from lon0 (in meters) (NOTE: assumed to have false eastings and northings already removed)</param>
        /// <param name="y">northing from lat0 (in meters) (NOTE: assumed to have false eastings and northings already removed)</param>
        /// <param name="utmCoordSys">the UTM coordinate system supplying the reference latitude, central meridian, scale factor, and datum/ellipsoid.</param>
        /// <param name="lon">the returned xLon for UTM(x,y)</param>
        /// <param name="lat">the returned yLat for UTM(x,y)</param>
        /// <returns>This function always returns true, for now.</returns>
        internal static bool UtmToLatLon(double x, double y, IProjectedCoordinateSystem utmCoordSys, ref double lon, ref double lat)
        {
            double k0 = utmCoordSys["Scale_Factor"];
            double lat0 = utmCoordSys["Latitude_of_Origin"];
            double lon0 = utmCoordSys["Central_Meridian"];

            double phi0 = lat0 * MathUtil.Degree;
            double lambda0 = lon0 * MathUtil.Degree;

            double f = utmCoordSys.Datum.Ellipsoid.Flattening; //DATUM_F (flattening)
            double es = utmCoordSys.Datum.Ellipsoid.FirstEccentricitySquared; //2.0 * f - f * f
            double a = utmCoordSys.Datum.Ellipsoid.EquatorialRadius; //DATUM_A (semi-major axis)

            double m0 = M(phi0, a, es);

            //equations 8-17, 8-18
            double et2 = es / (1.0 - es);
            double m = m0 + y / k0;
            double e1 = (1.0 - Math.Sqrt(1.0 - es)) / (1.0 + Math.Sqrt(1.0 - es));
            double mu = m / (a * (1.0 - es / 4.0 - 3.0 * es * es / 64.0 - 5.0 * es * es * es / 256.0));
            double phi1 = mu + (3.0 * e1 / 2.0 - 27.0 * Math.Pow(e1, 3.0) / 32.0) * Math.Sin(2.0 * mu) + (21.0 * e1 * e1 / 16.0 - 55.0 * Math.Pow(e1, 4.0) / 32.0) * Math.Sin(4.0 * mu) + (151.0 * Math.Pow(e1, 3.0) / 96.0) * Math.Sin(6.0 * mu) + (1097.0 * Math.Pow(e1, 4.0) / 512.0) * Math.Sin(8.0 * mu);
            double c1 = et2 * Math.Pow(Math.Cos(phi1), 2.0);
            double t1 = Math.Pow(Math.Tan(phi1), 2.0);
            double n1 = a / Math.Sqrt(1 - es * Math.Pow(Math.Sin(phi1), 2.0));
            double r1 = a * (1.0 - es) / Math.Pow(1.0 - es * Math.Pow(Math.Sin(phi1), 2.0), 1.5);
            double d = x / (n1 * k0);
            lat = (phi1 - (n1 * Math.Tan(phi1) / r1) * ((d * d / 2.0 - ((5.0 + 3.0 * t1 + 10.0 * c1 - 4.0 * c1 * c1 - 9.0 * et2) * Math.Pow(d, 4.0) / 24.0) + ((61.0 + 90.0 * t1 + 298.0 * c1 + 45.0 * t1 * t1 - 252.0 * et2 - 3.0 * c1 * c1) * Math.Pow(d, 6.0) / 720.0)))) / MathUtil.Degree;
            lon = ((lambda0 + (d - (1.0 + 2.0 * t1 + c1) * Math.Pow(d, 3.0) / 6.0 + (5.0 - 2.0 * c1 + 28.0 * t1 - 3.0 * c1 * c1 + 8.0 * et2 + 24.0 * t1 * t1) * Math.Pow(d, 5.0) / 120.0) / Math.Cos(phi1))) / MathUtil.Degree;

            return true;
        }

        /// <summary>
        /// This is the basic conversion for lat/lons to UTM. All other Lat/lon to UTM functions will call
        /// this one with the appropriate parameters. The equations used here are from Chapter 3, pgs. 11-19
        /// and Chapter 8 pgs., 48-65.
        /// </summary>
        /// <param name="lon">xLon</param>
        /// <param name="lat">yLat</param>
        /// <param name="utmCoordSys">the UTM coordinate system supplying the reference latitude, central meridian, scale factor, and datum/ellipsoid.</param>
        /// <param name="x">the returned easting(x) for UTM(lon,lat) (NOTE: these returned coordinates will requires the false eastings and northings to be added.)</param>
        /// <param name="y">the returned northing(y) for UTM(lon,lat) (NOTE: these returned coordinates will requires the false eastings and northings to be added.)</param>
        /// <returns>This function always returns true, for now.</returns>
        internal static bool LatLonToUtm(double lon, double lat, IProjectedCoordinateSystem utmCoordSys, ref double x, ref double y)
        {
            double k0 = utmCoordSys["Scale_Factor"];
            double lat0 = utmCoordSys["Latitude_of_Origin"];
            double lon0 = utmCoordSys["Central_Meridian"];

            //These are the parameters for the Clarke 1866 ellipsoid. If we wish to use
            //any other ellipsoid, these parameters can be replaced with other values or
            //a function call. table 1,pg. 12
            double f = utmCoordSys.Datum.Ellipsoid.Flattening; //DATUM_F
            double es = utmCoordSys.Datum.Ellipsoid.FirstEccentricitySquared; //2.0 * f - f * f;
            double a = utmCoordSys.Datum.Ellipsoid.EquatorialRadius; //DATUM_A


            double lambda = lon * MathUtil.Degree;
            double phi = lat * MathUtil.Degree;

            double phi0 = lat0 * MathUtil.Degree;
            double lambda0 = lon0 * MathUtil.Degree;

            double m0 = M(phi0, a, es);
            double m = M(phi, a, es);
            //equations 8-9 through 8-15
            double et2 = es / (1 - es);
            double n = a / Math.Sqrt(1 - es * Math.Pow(Math.Sin(phi), 2.0));
            double t = Math.Pow(Math.Tan(phi), 2.0);
            double c = et2 * Math.Pow(Math.Cos(phi), 2.0);
            double A = (lambda - lambda0) * Math.Cos(phi);
            x = k0 * n * (A + (1.0 - t + c) * A * A * A / 6.0 + (5.0 - 18.0 * t + t * t + 72.0 * c - 58.0 * et2) * Math.Pow(A, 5.0) / 120.0);
            y = k0 * (m - m0 + n * Math.Tan(phi) * (A * A / 2.0 + (5.0 - t + 9.0 * c + 4 * c * c) * Math.Pow(A, 4.0) / 24.0 + (61.0 - 58.0 * t + t * t + 600.0 * c - 330.0 * et2) * Math.Pow(A, 6.0) / 720.0));

            return true;
        }

        /// <summary>
        /// This function calculates the the distance along the meridian to the yLat, phi.
        /// It is based on the material in Chapter 3 of Snyder.
        /// </summary>
        /// <param name="phi">the yLat that we want a distance to</param>
        /// <param name="a">equatorial radius</param>
        /// <param name="es">eccentricity of the ellipsoid, squared</param>
        /// <returns>The distance along the meridian to the yLat, phi.</returns>
        internal static double M(double phi, double a, double es)
        {
            if (phi == 0.0)
            {
                return 0.0;
            }
            else
            {
                //equation 3-21, pg. 17
                return a * ((1.0 - es / 4.0 - 3.0 * es * es / 64.0 - 5.0 * es * es * es / 256.0) * phi - (3.0 * es / 8.0 + 3.0 * es * es / 32.0 + 45.0 * es * es * es / 1024.0) * Math.Sin(2.0 * phi) + (15.0 * es * es / 256.0 + 45.0 * es * es * es / 1024.0) * Math.Sin(4.0 * phi) - (35.0 * es * es * es / 3072.0) * Math.Sin(6.0 * phi));
            }
        }

        /// <summary>
        /// This function only requires northing, easting , reference yLat, central meridian, the scale
        /// factor, false northing, false easting, and a bool parameter that is true if the zone is in
        /// the southern hemisphere. All other parameters for the conversion are assumed to be the defaults
        /// for UTMs.
        /// </summary>
        /// <param name="xLon1">The UTM easting.</param>
        /// <param name="yLat1">The UTM northing.</param>
        /// <param name="utmCoordSys">The UTM coordinate system the input is expressed in, supplying the false easting/northing, scale factor, and (if zoned) southern-hemisphere flag.</param>
        /// <param name="xLon2">The resulting longitude.</param>
        /// <param name="yLat2">The resulting latitude.</param>
        internal static void UtmToLatLonDetail(double xLon1, double yLat1, IProjectedCoordinateSystem utmCoordSys, ref double xLon2, ref double yLat2)
        {
            // Check if this is a southern hemisphere zone
            bool isSouthernHemisphere = false;
            IZone? zone = (utmCoordSys as IZonedCoordinateSystem)?.Zone;
            if (zone != null)
            {
                isSouthernHemisphere = zone.IsSouthernHemisphere;
            }

            // Remove false northing for southern hemisphere FIRST
            if (isSouthernHemisphere)
            {
                //yLat1 = 10000000.0 - yLat1;
                yLat1 = yLat1 - 10000000.0;
            }

            xLon1 -= utmCoordSys["False_Easting"];
            yLat1 -= utmCoordSys["False_Northing"];
            UtmToLatLon(xLon1, yLat1, utmCoordSys, ref xLon2, ref yLat2);
            xLon2 = MathUtil.RoundTo(xLon2, utmCoordSys.SignificantDigits);
            yLat2 = MathUtil.RoundTo(yLat2, utmCoordSys.SignificantDigits);
        }
        //internal static void UtmToLatLonDetail(double xLon1, double yLat1, IProjectedCoordinateSystem utmCoordSys, ref double xLon2, ref double yLat2)
        //{
        //    //if (southernHemisphere)
        //    //if (CsUtil.IsSouthernHemisphere(utmCoordSys.Projection.LatitudinalZone))
        //    //if (yLat1 < 0)
        //    //{
        //    //    yLat1 = 1.0e7 - yLat1; //remove false northing for southern hemisphere
        //    //}
        //    xLon1 -= utmCoordSys["False_Easting"]; //utmCoordSys.falseEasting;
        //    yLat1 -= utmCoordSys["False_Northing"]; //utmCoordSys.falseNorthing;
        //    UtmToLatLon(xLon1, yLat1, utmCoordSys, ref xLon2, ref yLat2);
        //    xLon2 = MathUtil.RoundTo(xLon2, utmCoordSys.SignificantDigits);
        //    yLat2 = MathUtil.RoundTo(yLat2, utmCoordSys.SignificantDigits);
        //}

        /// <summary>
        /// This function requires northing, easting , reference yLat, central meridian, scale factor,
        /// False easting, false northing, and a bool parameter that is true if the zone is in the
        /// southern hemisphere. All other parameters for the conversion are assumed to be the defaults
        /// for UTMs.
        /// </summary>
        /// <param name="xLon1">The longitude.</param>
        /// <param name="yLat1">The latitude.</param>
        /// <param name="utmCoordSys">The UTM coordinate system to convert to, supplying the false easting/northing and scale factor.</param>
        /// <param name="xLon2">The resulting UTM easting.</param>
        /// <param name="yLat2">The resulting UTM northing.</param>
        internal static void LatLonToUtmDetail(double xLon1, double yLat1, IProjectedCoordinateSystem utmCoordSys, ref double xLon2, ref double yLat2)
        {
            if (yLat1 > 84.0 || yLat1 < -80.0)
            {
                throw new ArgumentOutOfRangeException(nameof(yLat1), "Initial yLat must fall between -80.0 and 84.0");
            }

            // Check if this is a southern hemisphere zone
            bool isSouthernHemisphere = false;
            IZone? zone = (utmCoordSys as IZonedCoordinateSystem)?.Zone;
            if (zone != null)
            {
                isSouthernHemisphere = zone.IsSouthernHemisphere;
            }

            LatLonToUtm(xLon1, yLat1, utmCoordSys, ref xLon2, ref yLat2);
            xLon2 += utmCoordSys["False_Easting"];
            yLat2 += utmCoordSys["False_Northing"];

            // Apply false northing for southern hemisphere
            if (isSouthernHemisphere)
            {
                yLat2 = 10000000.0 + yLat2;
            }

            xLon2 = MathUtil.RoundTo(xLon2, utmCoordSys.SignificantDigits);
            yLat2 = MathUtil.RoundTo(yLat2, utmCoordSys.SignificantDigits);
        }
        //internal static void LatLonToUtmDetail(double xLon1, double yLat1, IProjectedCoordinateSystem utmCoordSys, ref double xLon2, ref double yLat2)
        //{
        //    if (yLat1 > 84.0 || yLat1 < -80.0)
        //    {
        //        throw new ArgumentOutOfRangeException("Initial yLat must fall between -80.0 and 84.0", "yLat1");
        //    }
        //    else
        //    {
        //        LatLonToUtm(xLon1, yLat1, utmCoordSys, ref xLon2, ref yLat2);
        //        xLon2 += utmCoordSys["False_Easting"];
        //        yLat2 += utmCoordSys["False_Northing"];
        //        if (yLat2 < 0.0) //false northing for southern hemisphere
        //        {
        //            yLat2 = 10000000.0 - yLat2;
        //        }
        //        yLat2 -= utmCoordSys["False_Northing"];
        //        xLon2 = MathUtil.RoundTo(xLon2, utmCoordSys.SignificantDigits);
        //        yLat2 = MathUtil.RoundTo(yLat2, utmCoordSys.SignificantDigits);
        //    }
        //}

        #endregion

    }
}


