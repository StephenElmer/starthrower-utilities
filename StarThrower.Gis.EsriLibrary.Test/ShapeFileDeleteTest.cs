// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using AwesomeAssertions;
using StarThrower.Gis.EsriLibrary;
using StarThrower.Gis.EsriLibrary.Types;
using StarThrower.Gis.GeoUtilities.Shapes;
using Xunit;

namespace StarThrower.Gis.EsriLibrary.Test
{
    /// <summary>
    /// Verifies <see cref="ShapeFile.DeleteRecord(int)"/>: record count, geometry of surviving
    /// records, bounding-extent recomputation, and out-of-range argument handling.
    /// </summary>
    public class ShapeFileDeleteTest
    {
        #region Private Helpers

        private static ShapeFile CreatePointFile(params (double x, double y)[] points)
        {
            ShapeFile sf = new ShapeFile();
            sf.ShapeType = ShapeType.Point;
            sf.AddField(new Field { Name = "ID", Type = new StringField(), Length = 5, DecimalCount = 0 });

            for (int i = 0; i < points.Length; i++)
            {
                Record rec = sf.CreateNewRecord();
                rec.SetData("ID", i.ToString(CultureInfo.InvariantCulture));
                rec.SetShape(new PointShape(xLon: points[i].x, yLat: points[i].y));
                sf.AddRecord(rec);
            }

            return sf;
        }

        private static PointShape GetPoint(ShapeFile sf, int index)
            => (PointShape)sf.GetRecord(index).GetShape();

        #endregion


        #region Record Count

        [Fact]
        public void DeleteReducesRecordCount()
        {
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(1);
            sf.RecordCount.Should().Be(2);
        }

        #endregion


        #region Remaining Record Geometry

        [Fact]
        public void DeleteFirstRecordShiftsRemainingRecordsDown()
        {
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(0);
            sf.RecordCount.Should().Be(2);
            GetPoint(sf, 0).xLon.Should().Be(5.0);
            GetPoint(sf, 0).yLat.Should().Be(5.0);
            GetPoint(sf, 1).xLon.Should().Be(9.0);
            GetPoint(sf, 1).yLat.Should().Be(9.0);
        }

        [Fact]
        public void DeleteMiddleRecordPreservesOuterRecords()
        {
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(1);
            sf.RecordCount.Should().Be(2);
            GetPoint(sf, 0).xLon.Should().Be(1.0);
            GetPoint(sf, 0).yLat.Should().Be(1.0);
            GetPoint(sf, 1).xLon.Should().Be(9.0);
            GetPoint(sf, 1).yLat.Should().Be(9.0);
        }

        [Fact]
        public void DeleteLastRecordPreservesLeadingRecords()
        {
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(2);
            sf.RecordCount.Should().Be(2);
            GetPoint(sf, 0).xLon.Should().Be(1.0);
            GetPoint(sf, 0).yLat.Should().Be(1.0);
            GetPoint(sf, 1).xLon.Should().Be(5.0);
            GetPoint(sf, 1).yLat.Should().Be(5.0);
        }

        #endregion


        #region Bounding Extent Recomputation

        [Fact]
        public void DeleteExtremeBoundaryRecordContractsBoundingExtent()
        {
            // (1,1) defines Left and Top; removing it should contract the extent to (5,5)–(9,9).
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(0);
            sf.Extent.Left.Should().Be(5.0);
            sf.Extent.Top.Should().Be(5.0);
            sf.Extent.Right.Should().Be(9.0);
            sf.Extent.Bottom.Should().Be(9.0);
        }

        [Fact]
        public void DeleteNonExtremeBoundaryRecordRetainsExtent()
        {
            // (5,5) is interior; removing it should leave the extent (1,1)–(9,9) unchanged.
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5), (9, 9));
            sf.DeleteRecord(1);
            sf.Extent.Left.Should().Be(1.0);
            sf.Extent.Top.Should().Be(1.0);
            sf.Extent.Right.Should().Be(9.0);
            sf.Extent.Bottom.Should().Be(9.0);
        }

        [Fact]
        public void DeleteAllRecordsResetsExtentToEmpty()
        {
            using ShapeFile sf = CreatePointFile((2, 3));
            sf.DeleteRecord(0);
            sf.RecordCount.Should().Be(0);
            sf.Extent.IsEmpty.Should().BeTrue();
        }

        #endregion


        #region Out-of-Range Arguments

        [Fact]
        public void DeleteNegativeIndexThrowsArgumentOutOfRange()
        {
            using ShapeFile sf = CreatePointFile((1, 1));
            Action act = () => sf.DeleteRecord(-1);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void DeleteIndexEqualToCountThrowsArgumentOutOfRange()
        {
            using ShapeFile sf = CreatePointFile((1, 1), (5, 5));
            Action act = () => sf.DeleteRecord(2);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}
