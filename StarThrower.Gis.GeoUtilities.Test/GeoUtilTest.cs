// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.Gis.GeoUtilities;
using Xunit;

namespace StarThrower.Gis.GeoUtilities.Test
{
    public class GeoUtilTest
    {
        [Fact]
        public void TestIsValidLat()
        {
            GeoUtil.IsValidLat(0).Should().BeTrue();
            GeoUtil.IsValidLat(0.0).Should().BeTrue();
            GeoUtil.IsValidLat(0.000001).Should().BeTrue();
            GeoUtil.IsValidLat(-0.000001).Should().BeTrue();
            GeoUtil.IsValidLat(1).Should().BeTrue();
            GeoUtil.IsValidLat(-1).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MaxLat).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MinLat).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MaxLat - 1).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MinLat + 1).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MaxLat - 0.000001).Should().BeTrue();
            GeoUtil.IsValidLat(GeoUtil.MinLat + 0.000001).Should().BeTrue();

            GeoUtil.IsValidLat(GeoUtil.MaxLat + 0.000001).Should().BeFalse();
            GeoUtil.IsValidLat(GeoUtil.MinLat - 0.000001).Should().BeFalse();
        }

        [Fact]
        public void TestIsValidLon()
        {
            GeoUtil.IsValidLon(0).Should().BeTrue();
            GeoUtil.IsValidLon(0.0).Should().BeTrue();
            GeoUtil.IsValidLon(0.000001).Should().BeTrue();
            GeoUtil.IsValidLon(-0.000001).Should().BeTrue();
            GeoUtil.IsValidLon(1).Should().BeTrue();
            GeoUtil.IsValidLon(-1).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MaxLon).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MinLon).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MaxLon - 1).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MinLon + 1).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MaxLon - 0.000001).Should().BeTrue();
            GeoUtil.IsValidLon(GeoUtil.MinLon + 0.000001).Should().BeTrue();

            GeoUtil.IsValidLon(GeoUtil.MaxLon + 0.000001).Should().BeFalse();
            GeoUtil.IsValidLon(GeoUtil.MinLon - 0.000001).Should().BeFalse();
        }


        #region Original Tests

        //GeoCoordSys _wgs84LatLon;
        //GeoCoordSys _wgs84Utm;
        //GeoCoordSys _nad27LatLon;
        //GeoCoordSys _nad27Utm;

        //[SetUp]
        //public void MySetup()
        //{
        //    _wgs84LatLon = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.LatLon, DatumTypeConst.WGS84);
        //    _nad27LatLon = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.LatLon, DatumTypeConst.NAD27);
        //    _wgs84Utm = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.UTM, DatumTypeConst.WGS84);
        //    _nad27Utm = GeoCoordSysFactory.CreateGeoCoordSys(GeoCoordSysTypeConst.UTM, DatumTypeConst.NAD27);
        //}

        //[TearDown]
        //public void MyTearDown()
        //{
        //    _wgs84LatLon = null;
        //    _nad27LatLon = null;
        //    _wgs84Utm = null;
        //    _nad27Utm = null;
        //}



        #endregion
    }
}


