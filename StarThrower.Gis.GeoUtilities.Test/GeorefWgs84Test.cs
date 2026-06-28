// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.Translations;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class GeorefWgs84Test
    {
        private const double DegreesToRadians = Math.PI / 180.0;

        // Latitude/longitude are built from whole degrees plus arc-minutes so each test can
        // target a specific minutes value without disturbing the letter-grid portion of the
        // GEOREF string ("PGFL" for 10 deg N, 20 deg E).
        private static double ToRadians(double wholeDegrees, double minutes) => (wholeDegrees + minutes / 60.0) * DegreesToRadians;


        #region Minutes Formatting (regression for ConvertMinutesToString)

        [Fact]
        public void TestFromGeodeticZeroMinutesPrecision3()
        {
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 0), 0, 3);
            ((StringResult)result).CoordString.Should().Be("PGFL000000");
        }

        [Fact]
        public void TestFromGeodeticLatitudeMinutesAreReflectedInOutputPrecision3()
        {
            // Regression test: ConvertMinutesToString previously called String.Format with a
            // format string containing no "{0}" placeholder, so the rounded minutes value was
            // silently discarded and this field was always "000" regardless of input.
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 0.16), 0, 3);
            ((StringResult)result).CoordString.Should().Be("PGFL000002");
        }

        [Fact]
        public void TestFromGeodeticLongitudeMinutesAreReflectedInOutputPrecision3()
        {
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0.16), ToRadians(10, 0), 0, 3);
            ((StringResult)result).CoordString.Should().Be("PGFL002000");
        }

        #endregion


        #region RoundGEOREF Rounding Direction

        [Fact]
        public void TestFromGeodeticMinutesScaledValueJustBelowHalfRoundsDownPrecision3()
        {
            // latitude minutes = 0.14' -> scaled value (minutes * 10) = 1.4 -> rounds down to 1
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 0.14), 0, 3);
            ((StringResult)result).CoordString.Should().Be("PGFL000001");
        }

        [Fact]
        public void TestFromGeodeticMinutesScaledValueJustAboveHalfRoundsUpPrecision3()
        {
            // latitude minutes = 0.16' -> scaled value (minutes * 10) = 1.6 -> rounds up to 2
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 0.16), 0, 3);
            ((StringResult)result).CoordString.Should().Be("PGFL000002");
        }

        #endregion


        #region Precision Field Widths

        [Fact]
        public void TestFromGeodeticPrecision1PadsToTwoDigits()
        {
            // Precision 1 ("nearest ten minutes") is a special case in ConvertMinutesToString:
            // the normal field width equals precision (1 digit here), with one extra trailing
            // '0' appended to reach the GEOREF-standard 2-digit minimum.
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 20), 0, 1);
            ((StringResult)result).CoordString.Should().Be("PGFL0020");
        }

        [Fact]
        public void TestFromGeodeticPrecision2FieldWidthIsTwoDigits()
        {
            ITranslationResult result = GeorefWgs84.FromGeodetic(ToRadians(20, 0), ToRadians(10, 0), 0, 2);
            ((StringResult)result).CoordString.Should().Be("PGFL0000");
        }

        #endregion
    }
}
