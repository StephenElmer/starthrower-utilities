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

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: WORLD GEODETIC SYSTEM 1972       ,
    /// Ellipsoid: WGS_1972,  DeltaX: 0,  SigmaX: 0,  DeltaY: 0,  SigmaY: 0,  DeltaZ: 0,  SigmaZ: 0,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 90,  South: -90,  East: 180,  West: -180
    /// </summary>
    public class Wgs1972 : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Wgs1972()
        {
            this.Ellipsoid = new Ellipsoids.Wgs1972();
            this.DeltaX = 0;
            this.SigmaX = 0;
            this.DeltaY = 0;
            this.SigmaY = 0;
            this.DeltaZ = 0;
            this.SigmaZ = 0;
            this.RotationX = 0;
            this.RotationY = 0;
            this.RotationZ = 0;
            this.RotationScaleFactor = 1;
            this.Domain.Top = 90;
            this.Domain.Left = -180;
            this.Domain.Bottom = -90;
            this.Domain.Right = 180;
        }

        public override void ToWgs84(double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt)
        {
            IEllipsoid wgs84 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));

            double Delta_Lat;
            double Delta_Lon;
            double Delta_Hgt;
            double WGS84_a = wgs84.EquatorialRadius; // Semi-major axis of WGS84 ellipsoid
            double WGS84_f = wgs84.Flattening; // Flattening of WGS84 ellipsoid
            double WGS72_a = this.Ellipsoid.EquatorialRadius; // Semi-major axis of WGS72 ellipsoid
            double WGS72_f = this.Ellipsoid.Flattening; // Flattening of WGS72 ellipsoid
            double da; //WGS84_a - WGS72_a
            double df; // WGS84_f - WGS72_f
            double Q;
            double sin_Lat;
            double sin2_Lat;

            da = WGS84_a - WGS72_a;
            df = WGS84_f - WGS72_f;
            Q = Math.PI / 648000;
            sin_Lat = Math.Sin(yLat);
            sin2_Lat = sin_Lat * sin_Lat;

            Delta_Lat = (4.5 * Math.Cos(yLat)) / (WGS72_a * Q) + (df * Math.Sin(2 * yLat)) / Q;
            Delta_Lat /= GeoUtil.SecondsPerRadian;
            Delta_Lon = 0.554 / GeoUtil.SecondsPerRadian;
            Delta_Hgt = 4.5 * sin_Lat + WGS72_a * df * sin2_Lat - da + 1.4;

            wgs84YLat = yLat + Delta_Lat;
            wgs84XLon = xLon + Delta_Lon;
            wgs84ZAlt = zAlt + Delta_Hgt;

            if (wgs84YLat > GeoUtil.PiOver2)
            {
                wgs84YLat = GeoUtil.PiOver2 - (wgs84YLat - GeoUtil.PiOver2);
            }
            else if (wgs84YLat < -GeoUtil.PiOver2)
            {
                wgs84YLat = -GeoUtil.PiOver2 - (wgs84YLat + GeoUtil.PiOver2);
            }

            if (wgs84XLon > Math.PI)
            {
                wgs84XLon -= GeoUtil.TwoPi;
            }
            if (wgs84XLon < -Math.PI)
            {
                wgs84XLon += GeoUtil.TwoPi;
            }
        }

        public override void FromWgs84(double wgs84XLon, double wgs84YLat, double wgs84ZAlt, ref double xLon, ref double yLat, ref double zAlt)
        {
            IEllipsoid wgs84 = EllipsoidFactory.GetInstanceOfEllipsoid(typeof(Ellipsoids.Wgs1984));

            double Delta_Lat;
            double Delta_Lon;
            double Delta_Hgt;
            double WGS84_a = wgs84.EquatorialRadius; // Semi-major axis of WGS84 ellipsoid
            double WGS84_f = wgs84.Flattening; // Flattening of WGS84 ellipsoid
            double WGS72_a = this.Ellipsoid.EquatorialRadius; // Semi-major axis of WGS72 ellipsoid
            double WGS72_f = this.Ellipsoid.Flattening; // Flattening of WGS72 ellipsoid
            double da; // WGS72_a - WGS84_a
            double df; // WGS72_f - WGS84_f
            double Q;
            double sin_Lat;
            double sin2_Lat;

            da = WGS72_a - WGS84_a;
            df = WGS72_f - WGS84_f;
            Q = Math.PI / 648000;
            sin_Lat = Math.Sin(wgs84YLat);
            sin2_Lat = sin_Lat * sin_Lat;

            Delta_Lat = (-4.5 * Math.Cos(wgs84YLat)) / (WGS84_a * Q) + (df * Math.Sin(2 * wgs84YLat)) / Q;
            Delta_Lat /= GeoUtil.SecondsPerRadian;
            Delta_Lon = -0.554 / GeoUtil.SecondsPerRadian;
            Delta_Hgt = -4.5 * sin_Lat + WGS84_a * df * sin2_Lat - da - 1.4;

            yLat = wgs84YLat + Delta_Lat;
            xLon = wgs84XLon + Delta_Lon;
            zAlt = wgs84ZAlt + Delta_Hgt;

            if (yLat > GeoUtil.PiOver2)
            {
                yLat = GeoUtil.PiOver2 - (yLat - GeoUtil.PiOver2);
            }
            else if (yLat < -GeoUtil.PiOver2)
            {
                yLat = -GeoUtil.PiOver2 - (yLat + GeoUtil.PiOver2);
            }

            if (xLon > Math.PI)
            {
                xLon -= GeoUtil.TwoPi;
            }
            if (xLon < -Math.PI)
            {
                xLon += GeoUtil.TwoPi;
            }
        }
    }
}
