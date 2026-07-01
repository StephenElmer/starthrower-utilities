// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// ESRI ArgIMS: 
    /// NGIA GeoTrans: WORLD GEODETIC SYSTEM 1984       ,
    /// Ellipsoid: WGS_1984,  DeltaX: 0,  SigmaX: 0,  DeltaY: 0,  SigmaY: 0,  DeltaZ: 0,  SigmaZ: 0,  RotationX: 0,  RotationY: 0,  RotationZ: 0,  ScaleFactor: 1,  North: 90,  South: -90,  East: 180,  West: -180
    /// </summary>
    public class Wgs1984 : Datum
    {
        /// <inheritdoc/>
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Wgs1984()
        {
            this.Ellipsoid = new Ellipsoids.Wgs1984();
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


        /// <inheritdoc/>
        /// <remarks>
        /// Overridden as a straight pass-through: since this datum already is WGS84, no shift is needed.
        /// </remarks>
        public override void ToWgs84(double xLon, double yLat, double zAlt, ref double wgs84XLon, ref double wgs84YLat, ref double wgs84ZAlt)
        {
            wgs84XLon = xLon;
            wgs84YLat = yLat;
            wgs84ZAlt = zAlt;
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Overridden as a straight pass-through: since this datum already is WGS84, no shift is needed.
        /// </remarks>
        public override void FromWgs84(double wgs84XLon, double wgs84YLat, double wgs84ZAlt, ref double xLon, ref double yLat, ref double zAlt)
        {
            xLon = wgs84XLon;
            yLat = wgs84YLat;
            zAlt = wgs84ZAlt;
        }
 
    }
}


