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
using System.Globalization;
using System.Text;
using StarThrower.Gis.GeoUtilities.Datums;

namespace StarThrower.Gis.GeoUtilities
{
    public abstract class Datum : IDatum
    {
        /// <summary>
        /// The regular expression pattern to which the Datum's Name field must match.
        /// </summary>
        public const string ValidNamePattern = @"^[a-zA-Z_0-9]+$";


        #region Private Instance Variables

        private IEllipsoid _ellipsoid;

        //WGS84 Datum Shift parameters
        private double _deltaX; //m
        private double _deltaY; //m
        private double _deltaZ; //m
        private double _sigmaX; //m (-1 indicates unknown)
        private double _sigmaY; //m (-1 indicates unknown)
        private double _sigmaZ; //m (-1 indicates unknown)
        private double _rotationX;
        private double _rotationY;
        private double _rotationZ;
        private double _rotationScaleFactor;
        private GeoRectangle _domain = new GeoRectangle();

        #endregion


        #region Public Properties
       
        public abstract bool IsSevenParamDatum { get; }

        /// <summary>
        /// Gets the name of the Datum.
        /// This is really only necessary if DatumType == DatumType.UserDefined
        /// as it is intended to distinguish one UserDefined Datum from another.
        /// </summary>
        public virtual string Name
        {
            get { return this.GetType().Name; }
        }

        /// <summary>
        /// Gets the key value of the Datum.
        /// If DatumType == DatumType.UserDefined, the Key will be the DatumType,
        /// otherwise, it will be the DatumType + Name so that UserDefined datums
        /// may be distinguished from one another.
        /// </summary>
        public string Key
        {
            get
            {
                if (this is UserDefined)
                {
                    return this.GetType().Name + this.Name;
                }
                else
                {
                    return this.GetType().Name;
                }
            }
        }

        /// <summary>
        /// Gets the Ellipsoid of the Datum
        /// </summary>
        public IEllipsoid Ellipsoid
        {
            get { return _ellipsoid; }
            protected set { _ellipsoid = value; }
        }

        /// <summary>
        /// Gets the shift in the X direction to convert to WGS 84 (meters)
        /// </summary>
        public double DeltaX
        {
            get { return _deltaX; }
            protected set { _deltaX = value; }
        }

        /// <summary>
        /// Gets the shift in the Y direction to convert to WGS 84 (meters)
        /// </summary>
        public double DeltaY
        {
            get { return _deltaY; }
            protected set { _deltaY = value; }
        }

        /// <summary>
        /// Gets the shift in the Z direction to convert to WGS 84 (meters)
        /// </summary>
        public double DeltaZ
        {
            get { return _deltaZ; }
            protected set { _deltaZ = value; }
        }

        /// <summary>
        /// Gets the standard error in the X direction to convert to WGS 84 (meters).
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        public double SigmaX
        {
            get { return _sigmaX; }
            protected set { _sigmaX = value; }
        }

        /// <summary>
        /// Gets the standard error in the Y direction to convert to WGS 84 (meters)
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        public double SigmaY
        {
            get { return _sigmaY; }
            protected set { _sigmaY = value; }
        }

        /// <summary>
        /// Gets the standard error in the Z direction to convert to WGS 84 (meters)
        /// A value of -1 indicates that the Standard Error (Sigma) is unknown.
        /// </summary>
        public double SigmaZ
        {
            get { return _sigmaZ; }
            protected set { _sigmaZ = value; }
        }

        /// <summary>
        /// Rotation in the X direction.
        /// </summary>
        public double RotationX
        {
            get { return _rotationX; }
            protected set { _rotationX = value; }
        }

        /// <summary>
        /// Rotation in the Y direction.
        /// </summary>
        public double RotationY
        {
            get { return _rotationY; }
            protected set { _rotationY = value; }
        }

        /// <summary>
        /// Rotation in the Z direction.
        /// </summary>
        public double RotationZ
        {
            get { return _rotationZ; }
            protected set { _rotationZ = value; }
        }

        /// <summary>
        /// The Scale Factor for the rotation.
        /// </summary>
        public double RotationScaleFactor
        {
            get { return _rotationScaleFactor; }
            protected set { _rotationScaleFactor = value; }
        }

        /// <summary>
        /// Gets the valid domain for this datum.
        /// (i.e. the geographic region for which this datum is valid.)
        /// </summary>
        public GeoRectangle Domain
        {
            get { return _domain; }
        }

        #endregion


        #region Private Methods

        private static void Convert_Geodetic_To_Geocentric(double xLon, double yLat, double zAlt, ref double localX, ref double localY, ref double localZ)
        {
            localX = xLon;
            localY = yLat;
            localZ = zAlt;
        }

        /// <summary>
        /// The function Convert_Geocentric_To_Geodetic converts geocentric 
        /// coordinates (X, Y, Z) to geodetic coordinates (yLat, xLon, and height), 
        /// according to the current ellipsoid parameters.
        /// </summary>
        /// <param name="wgs84X">Geocentric X coordinate, in meters.</param>
        /// <param name="wgs84Y">Geocentric Y coordinate, in meters.</param>
        /// <param name="wgs84Z">Geocentric Z coordinate, in meters.</param>
        /// <param name="xLon">Calculated xLon value in radians.</param>
        /// <param name="yLat">Calculated yLat value in radians.</param>
        /// <param name="zAlt">Calculated height value, in meters.</param>
        /// <remarks>
        /// The method used here is derived from 'An Improved Algorithm for 
        /// Geocentric to Geodetic Coordinate Conversion', by Ralph Toms, Feb 1996.
        /// </remarks>
        private void Convert_Geocentric_To_Geodetic(double X, double Y, double Z, ref double longitude, ref double latitude, ref double height)
        {
            // Note: Variable names follow the notation used in Toms, Feb 1996

            double Geocent_a = this.Ellipsoid.EquatorialRadius;
            double Geocent_f = this.Ellipsoid.Flattening;
            double Geocent_e2 = this.Ellipsoid.FirstEccentricitySquared;
            double Geocent_ep2 = this.Ellipsoid.SecondEccentricitySquared;

            double W; // distance from Z axis
            double W2; // square of distance from Z axis
            double T0; // initial estimate of vertical component
            double T1; // corrected estimate of vertical component
            double S0; // initial estimate of horizontal component
            double S1; // corrected estimate of horizontal component
            double Sin_B0; // sin(B0), B0 is estimate of Bowring aux variable
            double Sin3_B0; // cube of sin(B0)
            double Cos_B0; // cos(B0)
            double Sin_p1; // sin(phi1), phi1 is estimated yLat
            double Cos_p1; // cos(phi1)
            double Rn; // Earth radius at location
            double Sum; // numerator of cos(phi1)
            bool At_Pole; // indicates location is in polar region
            double Geocent_b = Geocent_a * (1 - Geocent_f); // Semi-minor axis of ellipsoid, in meters

            At_Pole = false;
            if (X != 0.0)
            {
                longitude = Math.Atan2(Y, X);
            }
            else
            {
                if (Y > 0)
                {
                    longitude = GeoUtil.PiOver2;
                }
                else if (Y < 0)
                {
                    longitude = -GeoUtil.PiOver2;
                }
                else
                {
                    At_Pole = true;
                    longitude = 0.0;
                    if (Z > 0.0)
                    {  //north pole
                        latitude = GeoUtil.PiOver2;
                    }
                    else if (Z < 0.0)
                    {  //south pole
                        latitude = -GeoUtil.PiOver2;
                    }
                    else
                    {  //center of earth
                        latitude = GeoUtil.PiOver2;
                        height = -Geocent_b;
                        return;
                    }
                }
            }
            W2 = X * X + Y * Y;
            W = Math.Sqrt(W2);
            T0 = Z * GeoUtil.AD_C;
            S0 = Math.Sqrt(T0 * T0 + W2);
            Sin_B0 = T0 / S0;
            Cos_B0 = W / S0;
            Sin3_B0 = Sin_B0 * Sin_B0 * Sin_B0;
            T1 = Z + Geocent_b * Geocent_ep2 * Sin3_B0;
            Sum = W - Geocent_a * Geocent_e2 * Cos_B0 * Cos_B0 * Cos_B0;
            S1 = Math.Sqrt(T1 * T1 + Sum * Sum);
            Sin_p1 = T1 / S1;
            Cos_p1 = Sum / S1;
            Rn = Geocent_a / Math.Sqrt(1.0 - Geocent_e2 * Sin_p1 * Sin_p1);
            if (Cos_p1 >= GeoUtil.Cos67P5)
            {
                height = W / Cos_p1 - Rn;
            }
            else if (Cos_p1 <= -GeoUtil.Cos67P5)
            {
                height = W / -Cos_p1 - Rn;
            }
            else
            {
                height = Z / Sin_p1 + Rn * (Geocent_e2 - 1.0);
            }
            if (At_Pole == false)
            {
                latitude = Math.Atan(Sin_p1 / Cos_p1);
            }
        }

        /// <summary>
        /// This function shifts geodetic coordinates using the Molodensky method.
        /// </summary>
        /// <param name="a">Semi-major axis of source ellipsoid in meters</param>
        /// <param name="da">Destination a minus source a</param>
        /// <param name="f">Flattening of source ellipsoid</param>
        /// <param name="df">Destination f minus source f</param>
        /// <param name="dx">X coordinate shift in meters</param>
        /// <param name="dy">Y coordinate shift in meters</param>
        /// <param name="dz">Z coordinate shift in meters</param>
        /// <param name="xLon">xLon in radians.</param>
        /// <param name="yLat">yLat in radians.</param>
        /// <param name="zAlt">Height in meters.</param>
        /// <param name="xLon">Calculated xLon in radians.</param>
        /// <param name="yLat">Calculated yLat in radians.</param>
        /// <param name="zAlt">Calculated height in meters.</param>
        private static void Molodensky_Shift(double a, double da, double f, double df, double dx, double dy, double dz, double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt)
        {
            double tLon_in; // temp xLon
            double e2; // Intermediate calculations for dp, dl
            double ep2; // Intermediate calculations for dp, dl
            double sin_Lat; // sin(Latitude_1)
            double sin2_Lat; // (sin(Latitude_1))^2
            double sin_Lon; // sin(Longitude_1)
            double cos_Lat; // cos(Latitude_1)
            double cos_Lon; // cos(Longitude_1)
            double w2; // Intermediate calculations for dp, dl
            double w; // Intermediate calculations for dp, dl
            double w3; // Intermediate calculations for dp, dl
            double m; // Intermediate calculations for dp, dl
            double n; // Intermediate calculations for dp, dl
            double dp; // Delta phi
            double dp1; // Delta phi calculations
            double dp2; // Delta phi calculations
            double dp3; // Delta phi calculations
            double dl; // Delta lambda
            double dh; // Delta height
            double dh1; // Delta height calculations
            double dh2; // Delta height calculations

            if (xLon > Math.PI)
            {
                tLon_in = xLon - (2 * Math.PI);
            }
            else
            {
                tLon_in = xLon;
            }
            e2 = 2 * f - f * f;
            ep2 = e2 / (1 - e2);
            sin_Lat = Math.Sin(yLat);
            cos_Lat = Math.Cos(yLat);
            sin_Lon = Math.Sin(tLon_in);
            cos_Lon = Math.Cos(tLon_in);
            sin2_Lat = sin_Lat * sin_Lat;
            w2 = 1.0 - e2 * sin2_Lat;
            w = Math.Sqrt(w2);
            w3 = w * w2;
            m = (a * (1.0 - e2)) / w3;
            n = a / w;
            dp1 = cos_Lat * dz - sin_Lat * cos_Lon * dx - sin_Lat * sin_Lon * dy;
            dp2 = ((e2 * sin_Lat * cos_Lat) / w) * da;
            dp3 = sin_Lat * cos_Lat * (2.0 * n + ep2 * m * sin2_Lat) * (1.0 - f) * df;
            dp = (dp1 + dp2 + dp3) / (m + zAlt);
            dl = (-sin_Lon * dx + cos_Lon * dy) / ((n + zAlt) * cos_Lat);
            dh1 = (cos_Lat * cos_Lon * dx) + (cos_Lat * sin_Lon * dy) + (sin_Lat * dz);
            dh2 = -(w * da) + ((a * (1 - f)) / w) * sin2_Lat * df;
            dh = dh1 + dh2;
            wgs84YLat = yLat + dp;
            wgs84XLon = xLon + dl;
            wgs84ZAlt = zAlt + dh;
            if (wgs84XLon > (Math.PI * 2))
            {
                wgs84XLon -= 2 * Math.PI;
            }
            if (wgs84XLon < (-Math.PI))
            {
                wgs84XLon += 2 * Math.PI;
            }
        }

        #endregion




        protected virtual void GeocentricShiftToWgs84(double localX, double localY, double localZ, ref double wgs84X, ref double wgs84Y, ref double wgs84Z)
        {
            wgs84X = localX;
            wgs84Y = localY;
            wgs84Z = localZ;
        }

        #region Public Methods

        public virtual void ToWgs84(double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt)
        {
            IEllipsoid wgs84 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));

            double WGS84_a = wgs84.EquatorialRadius; // Semi-major axis of WGS84 ellipsoid in meters
            double WGS84_f = wgs84.Flattening; // Flattening of WGS84 ellisoid
            double a = this.Ellipsoid.EquatorialRadius; // Semi-major axis of ellipsoid in meters
            double da; // Difference in semi-major axes
            double f = this.Ellipsoid.Flattening; // Flattening of ellipsoid
            double df; // Difference in flattening
            double dx;
            double dy;
            double dz;

            if (this.IsSevenParamDatum || (yLat < (-GeoUtil.MolodenskyMax)) || (yLat > GeoUtil.MolodenskyMax))
            { /* Use 3-step method */
                double local_X = 0.0;
                double local_Y = 0.0;
                double local_Z = 0.0;
                double WGS84_X = 0.0;
                double WGS84_Y = 0.0;
                double WGS84_Z = 0.0;
                Convert_Geodetic_To_Geocentric(xLon, yLat, zAlt, ref local_X, ref local_Y, ref local_Z);
                GeocentricShiftToWgs84(local_X, local_Y, local_Z, ref WGS84_X, ref WGS84_Y, ref WGS84_Z);
                Convert_Geocentric_To_Geodetic(WGS84_X, WGS84_Y, WGS84_Z, ref wgs84XLon, ref wgs84YLat, ref wgs84ZAlt);
            }
            else
            { /* Use Molodensky's method */
                da = WGS84_a - a;
                df = WGS84_f - f;
                dx = this.DeltaX; // local->Parameters[0];
                dy = this.DeltaY; // local->Parameters[1];
                dz = this.DeltaZ; // local->Parameters[2];
                Molodensky_Shift(a, da, f, df, dx, dy, dz, xLon, yLat, zAlt, ref wgs84XLon, ref wgs84YLat, ref wgs84ZAlt);
            }
        }

        public virtual void FromWgs84(double wgs84XLon, double wgs84YLat, double wgs84ZAlt, ref double xLon, ref double yLat, ref double zAlt)
        {
            xLon = wgs84XLon;
            yLat = wgs84YLat;
            zAlt = wgs84ZAlt;
        }

        public virtual bool Validate(double xLon, double yLat)
        {
            //TODO: implement Datum.Validate(double, double)
            return true;
        }

        /// <summary>
        /// Gets an XML representation of the Datum.
        /// </summary>
        /// <returns></returns>
        public virtual string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);

            result.Append("<datum datumType=\"" + this.GetType().Name + "\" deltaX=\"" + _deltaX.ToString(CultureInfo.InvariantCulture) + "\" sigmaX=\"" + _sigmaX.ToString(CultureInfo.InvariantCulture) + "\" deltaY=\"" + _deltaY.ToString(CultureInfo.InvariantCulture) + "\" sigmaY=\"" + _sigmaY.ToString(CultureInfo.InvariantCulture) + "\" deltaZ=\"" + _deltaZ.ToString(CultureInfo.InvariantCulture) + "\" sigmaZ=\"" + _sigmaZ.ToString(CultureInfo.InvariantCulture) + "\" rotationX=\"" + _rotationX.ToString(CultureInfo.InvariantCulture) + "\" rotationY=\"" + _rotationY.ToString(CultureInfo.InvariantCulture) + "\" rotationZ=\"" + _rotationZ.ToString(CultureInfo.InvariantCulture) + "\" rotationScaleFactor=\"" + _rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + "\" north=\"" + _domain.Top.ToString(CultureInfo.InvariantCulture) + "\" south=\"" + _domain.Bottom.ToString(CultureInfo.InvariantCulture) + "\" east=\"" + _domain.Right.ToString(CultureInfo.InvariantCulture) + "\" west=\"" + _domain.Left.ToString(CultureInfo.InvariantCulture) + "\">\n");
            result.Append(_ellipsoid.ToXml());
            result.Append("</datum>\n");

            return result.ToString();
        }

        #endregion


        #region Object Overrides

        /// <summary>
        /// Tests whether the given object is equal to this object.
        /// </summary>
        /// <param name="obj">The object to compare to this object.</param>
        /// <returns>true if other is an instance of the same class as this object and has reference or value equality with this object; otherwise, false.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null)) return false;
            if (Object.ReferenceEquals(obj, this)) return true;
            if (!(obj.GetType().Equals(this.GetType()))) return false;
            Datum other = (Datum)obj;
            return _ellipsoid.Equals(other._ellipsoid) &&
                   _deltaX.Equals(other._deltaX) &&
                   _sigmaX.Equals(other._sigmaX) &&
                   _deltaY.Equals(other._deltaY) &&
                   _sigmaY.Equals(other._sigmaY) &&
                   _deltaZ.Equals(other._deltaZ) &&
                   _sigmaZ.Equals(other._sigmaZ) &&
                   _rotationX.Equals(other._rotationX) &&
                   _rotationY.Equals(other._rotationY) &&
                   _rotationZ.Equals(other._rotationZ) &&
                   _rotationScaleFactor.Equals(other._rotationScaleFactor) &&
                   _domain.Equals(other._domain);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode is suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current Datum.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + _ellipsoid.GetHashCode();
            result = 31 * result + _deltaX.GetHashCode();
            result = 31 * result + _sigmaX.GetHashCode();
            result = 31 * result + _deltaY.GetHashCode();
            result = 31 * result + _sigmaY.GetHashCode();
            result = 31 * result + _deltaZ.GetHashCode();
            result = 31 * result + _sigmaZ.GetHashCode();
            result = 31 * result + _rotationX.GetHashCode();
            result = 31 * result + _rotationY.GetHashCode();
            result = 31 * result + _rotationZ.GetHashCode();
            result = 31 * result + _rotationScaleFactor.GetHashCode();
            result = 31 * result + _domain.GetHashCode();
            return result;
        }

        /// <summary>
        /// Returns the string representation of this Datum.
        /// </summary>
        /// <returns>A string describing this object.</returns>
        /// <remarks>
        /// Returns a string formatted as "[{type}:  {name}={value}[,{name}={value}]]"
        /// </remarks>
        public override string ToString()
        {
            return "[" + this.GetType().Name + ":  Ellipsoid=" + _ellipsoid.GetType().Name + ", DeltaX=" + _deltaX.ToString(CultureInfo.InvariantCulture) + ", SigmaX=" + _sigmaX.ToString(CultureInfo.InvariantCulture) + ", DeltaY=" + _deltaY.ToString(CultureInfo.InvariantCulture) + ", SigmaY=" + _sigmaY.ToString(CultureInfo.InvariantCulture) + ", DeltaZ=" + _deltaZ.ToString(CultureInfo.InvariantCulture) + ", SigmaZ=" + _sigmaZ.ToString(CultureInfo.InvariantCulture) + ", RotationX=" + _rotationX.ToString(CultureInfo.InvariantCulture) + ", RotationY=" + _rotationY.ToString(CultureInfo.InvariantCulture) + ", RotationZ=" + _rotationZ.ToString(CultureInfo.InvariantCulture) + ", RotationScaleFactor=" + _rotationScaleFactor.ToString(CultureInfo.InvariantCulture) + ", " + _domain.ToString() + "]";
        }

        #endregion
    }
}
