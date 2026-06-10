// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic
{
    /// <summary>
    /// This class is used to provide conversions betweeen Geodetic coordinates
    /// (yLat, xLon in radians and height in meters) and Geocentric
    /// coordinates (X, Y, Z) in meters.
    /// </summary>
    /// <remarks>
    /// REFERENCES:
    /// 
    ///    An Improved Algorithm for Geocentric to Geodetic Coordinate Conversion,
    ///    Ralph Toms, February 1996  UCRL-JC-123138.
    /// 
    ///    Further information on GEOCENTRIC can be found in the Reuse Manual.
    /// 
    ///    GEOCENTRIC originated from : U.S. Army Topographic Engineering Center
    ///                                 Geospatial Information Division
    ///                                 7701 Telegraph Road
    ///                                 Alexandria, VA  22310-3864
    /// </remarks>
    public class GeocentricWgs84 : GeographicCoordinateSystem
    {
        #region Public Methods

        public override HeightType HeightType
        {
            get { return HeightType.EllipsoidHeight; }
        }

        #endregion


        #region Construction

        internal GeocentricWgs84() : base()
        {
            this.Datum = DatumFactory.GetInstanceOfDatum(typeof(Datums.Wgs1984));
            this.PrimeMeridian = PrimeMeridianFactory.GetInstanceOfPrimeMeridian(typeof(PrimeMeridians.Greenwich));
            this.AngularUnit = AngularUnitFactory.GetInstanceOfAngularUnit(typeof(AngularUnits.Degree));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts geocentric coordinates (X, Y, Z) to geodetic coordinates (yLat, xLon,  and height), according to the current ellipsoid parameters.
        /// </summary>
        /// <param name="xLon">Geocentric X coordinate, in meters.</param>
        /// <param name="yLat">Geocentric Y coordinate, in meters.</param>
        /// <param name="zAlt">Geocentric Z coordinate, in meters.</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Geodetic coordinates (yLat, xLon in radians; height, in meters).</returns>
        /// <remarks>
        /// The method used here is derived from 'An Improved Algorithm for
        /// Geocentric to Geodetic Coordinate Conversion', by Ralph Toms, Feb 1996
        /// </remarks>
        /// <exception cref="ValueOutOfRangeException">Thrown if Semi-major axis is less than or equal to zero or Inverlse flatting is outside of valid range (250 to 350).</exception>
        public override ITranslationResult ToGeodetic(double xLon, double yLat, double zAlt)
        {
            double resultX = 0.0;
            double resultY = 0.0;
            double resultZ = 0.0;


            double a = this.Datum.Ellipsoid.EquatorialRadius;
            if (a <= 0.0)
            {
                throw new Exceptions.ValueOutOfRangeException("Semi-major axis less than or equal to zero.");
            }
            
            double f = this.Datum.Ellipsoid.Flattening;
            double inv_f = this.Datum.Ellipsoid.InverseFlattening;
            if (inv_f < 250 || inv_f > 350)
            {
                throw new Exceptions.ValueOutOfRangeException("Inverse flattening outside of valid range (250 to 350).");
            }

            double e2 = this.Datum.Ellipsoid.FirstEccentricitySquared;
            double ep2 = this.Datum.Ellipsoid.SecondEccentricitySquared;



            //Note: Variable names follow the notation used in Toms, Feb 1996
            double w; //distance from Z axis
            double w2; //square of distance from Z axis
            double t0; //initial estimate of vertical component
            double t1; //corrected estimate of vertical component
            double s0; //initial estimate of horizontal component
            double s1; //corrected estimate of horizontal component
            double sin_b0; //sin(b0), b0 is estimate of Bowring aux variable
            double sin3_b0; //cube of sin(b0)
            double cos_b0; //cos(b0)
            double sin_p1; //sin(phi1), phi1 is estimated yLat
            double cos_p1; //cos(phi1)
            double rn; //Earth radius at location
            double sum; //numerator of cos(phi1)
            bool atPole; //indicates location is in polar region
            double b = this.Datum.Ellipsoid.PolarRadius; // Semi-minor axis of ellipsoid, in meters  (a * (1 - f))

            atPole = false;
            if (xLon != 0.0)
            {
                resultX = Math.Atan2(yLat, xLon);
            }
            else
            {
                if (yLat > 0)
                {
                    resultX = GeoUtil.PiOver2;
                }
                else if (yLat < 0)
                {
                    resultX = -(GeoUtil.PiOver2);
                }
                else
                {
                    atPole = true;
                    resultX = 0.0;
                    if (zAlt > 0.0) //north pole
                    { 
                        resultY = GeoUtil.PiOver2;
                    }
                    else if (zAlt < 0.0) //south pole
                    { 
                        resultY = -(GeoUtil.PiOver2);
                    }
                    else //center of earth
                    {  
                        resultY = (GeoUtil.PiOver2);
                        resultZ = -b;
                        return new Translations.GenericResult(resultX, resultY, resultZ);
                    }
                }
            }
            w2 = xLon * xLon + yLat * yLat;
            w = Math.Sqrt(w2);
            t0 = zAlt * GeoUtil.ADC;
            s0 = Math.Sqrt(t0 * t0 + w2);
            sin_b0 = t0 / s0;
            cos_b0 = w / s0;
            sin3_b0 = sin_b0 * sin_b0 * sin_b0;
            t1 = zAlt + b * ep2 * sin3_b0;
            sum = w - a * e2 * cos_b0 * cos_b0 * cos_b0;
            s1 = Math.Sqrt(t1 * t1 + sum * sum);
            sin_p1 = t1 / s1;
            cos_p1 = sum / s1;
            rn = a / Math.Sqrt(1.0 - e2 * sin_p1 * sin_p1);
            if (cos_p1 >= GeoUtil.Cos67P5)
            {
                resultZ = w / cos_p1 - rn;
            }
            else if (cos_p1 <= -GeoUtil.Cos67P5)
            {
                resultZ = w / -cos_p1 - rn;
            }
            else
            {
                resultZ = zAlt / sin_p1 + rn * (e2 - 1.0);
            }
            if (atPole == false)
            {
                resultY = Math.Atan(sin_p1 / cos_p1);
            }


            return new Translations.GenericResult(resultX, resultY, resultZ);
        }

        /// <summary>
        /// Converts geodetic coordinates (yLat, xLon, and height) to geocentric coordinates (X, Y, Z), according to the current ellipsoid parameters.
        /// </summary>
        /// <param name="xLon">Geodetic xLon in radians.</param>
        /// <param name="yLat">Geodetic yLat in radians.</param>
        /// <param name="zAlt">Geodetic height, in meters.</param>
        /// <returns>A GenericResult implementation of the ITranslationResult, containing Geocentric coordinates (X, Y, Z, in meters).</returns>
        /// <exception cref="ValueOutOfRangeException">Thrown if Semi-major axis is less than or equal to zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if Latitude (-90 to 90 degrees) or Longitude (-180 to 360 degrees) is out of range.</exception>
        public override ITranslationResult FromGeodetic(double xLon, double yLat, double zAlt)
        {
            double resultX = 0.0;
            double resultY = 0.0;
            double resultZ = 0.0;


            double a = this.Datum.Ellipsoid.EquatorialRadius;
            if (a <= 0.0)
            {
                throw new Exceptions.ValueOutOfRangeException("Semi-major axis less than or equal to zero.");
            }

            double e2 = this.Datum.Ellipsoid.FirstEccentricitySquared;


            double rn; //Earth radius at location
            double sin_yLat; //sin(yLat)
            double sin2_yLat; //Square of sin(yLat)
            double cos_yLat; //cos(yLat)

            if ((yLat < -GeoUtil.PiOver2) || (yLat > GeoUtil.PiOver2))
            {
                throw new ArgumentOutOfRangeException(nameof(yLat), "Latitude out of valid range (-90 to 90 degrees).");
            }

            if ((xLon < -Math.PI) || (xLon > (2 * Math.PI)))
            {
                throw new ArgumentOutOfRangeException(nameof(xLon), "Longitude out of valid range (-180 to 360 degrees).");
            }

            if (xLon > Math.PI)
            {
                xLon -= (2 * Math.PI);
            }
            sin_yLat = Math.Sin(yLat);
            cos_yLat = Math.Cos(yLat);
            sin2_yLat = sin_yLat * sin_yLat;
            rn = a / (Math.Sqrt(1.0e0 - e2 * sin2_yLat));
            resultX = (rn + zAlt) * cos_yLat * Math.Cos(xLon);
            resultY = (rn + zAlt) * cos_yLat * Math.Sin(xLon);
            resultZ = ((rn * (1 - e2)) + zAlt) * sin_yLat;


            return new Translations.GenericResult(resultX, resultY, resultZ);
        }

        #endregion
    }
}


