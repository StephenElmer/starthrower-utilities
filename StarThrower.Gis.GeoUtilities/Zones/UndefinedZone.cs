// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Zones
{
    public class UndefinedZone : Zone
    {
        public override string Name
        {
            get { return "Undefined"; }
        }

        public override bool IsSouthernHemisphere
        {
            get { return false; }
        }

        public override string ZoneString
        {
            get { return "Undefined"; }
        }

        public override double CentralMeridian
        {
            get { return 0.0; }
        }

        public override double GeometricCenter
        {
            get { return 0.0; }
        }

        public override double ReferenceLatitude
        {
            get { return 0.0; }
        }
    }
}


