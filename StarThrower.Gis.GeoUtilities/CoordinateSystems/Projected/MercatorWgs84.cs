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

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected
{
    /// <summary>
    /// This class provides conversions between Geodetic coordinates
    /// (latitude and longitude in radians) and Mercator projection coordinates
    /// (easting and northing in meters).
    /// </summary>
    public class MercatorWgs84 : ProjectedCoordinateSystem
    {
        private const double MAX_LAT = ((Math.PI * 89.5) / 180.0); //89.5 degrees in radians



        #region Construction

        internal MercatorWgs84() : this(0.0, 0.0, 0.0, 1.0, 0.0) { }

        internal MercatorWgs84(double falseEasting, double falseNorthing, double centralMeridian, double scaleFactor, double latitudeOfOrigin)
        {
            this.GeographicCoordinateSystem = GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(Geographic.GeodeticWgs84));
            this.Projection = new Projections.Mercator(falseEasting, falseNorthing, centralMeridian, scaleFactor, latitudeOfOrigin);
            this.LinearUnit = LinearUnitFactory.GetInstanceOfLinearUnit(typeof(LinearUnits.Meter));

        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts Mercator projection (easting and northing) coordinates to geodetic (latitude and longitude)
        /// coordinates, according to the current ellipsoid and Mercator projection coordinates.
        /// </summary>
        /// <param name="easting">Easting (X) in meters.</param>
        /// <param name="northing">Northing (Y) in meters.</param>
        /// <param name="zAlt">Altitude value in meters.</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Geodetic coordinates (Latitude (phi) in radians, Longitude (lambda) in radians).</returns>
        public override ITranslationResult ToGeodetic(double easting, double northing, double zAlt)
        {
            //Ellipsoid Parameters, default to WGS 84
            double Merc_a = this.Datum.Ellipsoid.EquatorialRadius; //6378137.0 Semi-major axis of ellipsoid in meters
            double Merc_f = this.Datum.Ellipsoid.Flattening; // 1 / 298.257223563 Flattening of ellipsoid
            double Merc_e = this.Datum.Ellipsoid.FirstEccentricity; //0.08181919084262188000; //Eccentricity of ellipsoid
            double Merc_es = this.Datum.Ellipsoid.FirstEccentricitySquared; //0.0066943799901413800; //Eccentricity squared
            double es2 = Merc_es * Merc_es;
            double es3 = es2 * Merc_es;
            double es4 = es3 * Merc_es;

            //Isometric to geodetic latitude parameters, default to WGS 84
            double Merc_ab = Merc_es / 2.0 + 5.0 * es2 / 24.0 + es3 / 12.0 + 13.0 * es4 / 360.0; //0.00335655146887969400
            double Merc_bb = 7.0 * es2 / 48.0 + 29.0 * es3 / 240.0 + 811.0 * es4 / 11520.0; //0.00000657187271079536
            double Merc_cb = 7.0 * es3 / 120.0 + 81.0 * es4 / 1120.0; //0.00000001764564338702
            double Merc_db = 4279.0 * es4 / 161280.0; //0.00000000005328478445

            //Mercator projection Parameters
            double Merc_Origin_Lat = this.Projection["Latitude_of_Origin"]; // 0.0 Latitude of origin in radians
            double Merc_Origin_Long = this.Projection["Central_Meridian"]; // 0.0 Longitude of origin in radians
            double Merc_False_Northing = this.Projection["False_Northing"]; // 0.0 False northing in meters
            double Merc_False_Easting = this.Projection["False_Easting"]; // 0.0 False easting in meters
            double Merc_Scale_Factor = this.Projection["Scale_Factor"]; // 1.0 Scale factor

            //Maximum variance for easting and northing values for WGS 84.
            ITranslationResult deltas = FromGeodetic((Merc_Origin_Long + Math.PI), MAX_LAT, 0.0);
            double deltaE = deltas.xLon;
            double deltaN = deltas.yLat;
            if (deltaE < 0)
            {
                deltaE = -deltaE;
            }
            deltaE *= 1.01;
            deltaE -= Merc_False_Easting;
            deltaN *= 1.01;
            deltaN -= Merc_False_Northing;
            double Merc_Delta_Easting = deltaE; // 20237883.0; //easting - false easting
            double Merc_Delta_Northing = deltaN; // 23421740.0; //northing - false northing  (TODO: for some reason this is calculating to 34965482.265666179



            if ((easting < (Merc_False_Easting - Merc_Delta_Easting)) || (easting > (Merc_False_Easting + Merc_Delta_Easting)))
            {
                throw new ArgumentOutOfRangeException("easting");
            }

            if ((northing < (Merc_False_Northing - Merc_Delta_Northing)) || (northing > (Merc_False_Northing + Merc_Delta_Northing)))
            {
                throw new ArgumentOutOfRangeException("northing");
            }
            
            double dy = northing - Merc_False_Northing;
            double dx = easting - Merc_False_Easting;
            double resultLon = Merc_Origin_Long + dx / (Merc_Scale_Factor * Merc_a);
            double xphi = GeoUtil.PiOver2 - 2.0 * Math.Atan(1.0 / Math.Exp(dy / (Merc_Scale_Factor * Merc_a)));
            double resultLat = xphi + Merc_ab * Math.Sin(2.0 * xphi) + Merc_bb * Math.Sin(4.0 * xphi) + Merc_cb * Math.Sin(6.0 * xphi) + Merc_db * Math.Sin(8.0 * xphi);
            if (resultLon > Math.PI)
            {
                resultLon -= GeoUtil.TwoPi;
            }
            if (resultLat < -Math.PI)
            {
                resultLat += GeoUtil.TwoPi;
            }
            double resultAlt = zAlt;


            return new Translations.GenericResult(resultLon, resultLat, resultAlt);
        }

        /// <summary>
        /// Converts geodetic (latitude and longitude) coordinates to Mercator projection 
        /// (easting and northing) coordinates, according to the current ellipsoid and Mercator 
        /// projection parameters.
        /// </summary>
        /// <param name="longitude">Longitude (lambda) in radians</param>
        /// <param name="latitude">Latitude (phi) in radians</param>
        /// <param name="zAlt">Altitude value in meters</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Mercator coordinates (Easting in meters, Northing in meters).</returns>
        public override ITranslationResult FromGeodetic(double longitude, double latitude, double zAlt)
        {
            //Ellipsoid Parameters, default to WGS 84
            double Merc_a = this.Datum.Ellipsoid.EquatorialRadius; //6378137.0 Semi-major axis of ellipsoid in meters
            double Merc_f = this.Datum.Ellipsoid.Flattening; // 1 / 298.257223563 Flattening of ellipsoid
            double Merc_e = this.Datum.Ellipsoid.FirstEccentricity; //0.08181919084262188000; //Eccentricity of ellipsoid
            double Merc_es = this.Datum.Ellipsoid.FirstEccentricitySquared; //0.0066943799901413800; //Eccentricity squared

            //Mercator projection Parameters
            double Merc_Origin_Lat = this.Projection["Latitude_of_Origin"]; // 0.0 Latitude of origin in radians
            double Merc_Origin_Long = this.Projection["Central_Meridian"]; // 0.0 Longitude of origin in radians
            double Merc_False_Northing = this.Projection["False_Northing"]; // 0.0 False northing in meters
            double Merc_False_Easting = this.Projection["False_Easting"]; // 0.0 False easting in meters
            double Merc_Scale_Factor = this.Projection["Scale_Factor"]; // 1.0 Scale factor

            if ((latitude < -MAX_LAT) || (latitude > MAX_LAT))
            {
                throw new ArgumentOutOfRangeException("latitude");
            }

            if ((longitude < -Math.PI) || (longitude > GeoUtil.TwoPi))
            {
                throw new ArgumentOutOfRangeException("longitude");
            }

            if (longitude > Math.PI)
            {
                longitude -= GeoUtil.TwoPi;
            }
            double e_x_sinlat = Merc_e * Math.Sin(latitude);
            double tan_temp = Math.Tan(Math.PI / 4.0 + latitude / 2.0);
            double pow_temp = Math.Pow(((1.0 - e_x_sinlat) / (1.0 + e_x_sinlat)), (Merc_e / 2.0));
            double ctanz2 = tan_temp * pow_temp;
            double northing = Merc_Scale_Factor * Merc_a * Math.Log(ctanz2) + Merc_False_Northing;

            double Delta_Long = longitude - Merc_Origin_Long;
            if (Delta_Long > Math.PI)
            {
                Delta_Long -= GeoUtil.TwoPi;
            }
            if (Delta_Long < -Math.PI)
            {
                Delta_Long += GeoUtil.TwoPi;
            }
            double easting = Merc_Scale_Factor * Merc_a * Delta_Long + Merc_False_Easting;
            
            double resultAlt = zAlt;

            return new Translations.GenericResult(easting, northing, resultAlt);
        }

        #endregion
    }
}


