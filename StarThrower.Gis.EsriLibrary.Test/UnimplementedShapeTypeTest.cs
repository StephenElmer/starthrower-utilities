// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.Gis.EsriLibrary;
using Xunit;

namespace StarThrower.Gis.EsriLibrary.Test
{
    /// <summary>
    /// Pins down the current (pre-Phase-B) behavior of the shape types whose
    /// Internal.Records.*Record.ParseBytes is still an unimplemented stub: adding a record
    /// of one of these types throws NotImplementedException, because ShapeFile.AddRecord
    /// round-trips the freshly-written bytes straight back through the same record type's
    /// constructor (which calls ParseBytes) to build the internal GeographyFileRecord.
    ///
    /// As each shape type gets a real ParseBytes implementation in Phase B, its case here
    /// should be removed and replaced with real read/write coverage in its own test class
    /// (mirroring ShapeFileReadTest/ShapeFileWriteTest) — this list is a checklist as much
    /// as a regression guard.
    /// </summary>
    public class UnimplementedShapeTypeTest
    {
        [Theory]
        [InlineData(ShapeType.MultiPoint)]
        [InlineData(ShapeType.PointZ)]
        [InlineData(ShapeType.PointM)]
        [InlineData(ShapeType.MultiPointZ)]
        [InlineData(ShapeType.MultiPointM)]
        [InlineData(ShapeType.PolyLineZ)]
        [InlineData(ShapeType.PolyLineM)]
        [InlineData(ShapeType.PolygonZ)]
        [InlineData(ShapeType.PolygonM)]
        [InlineData(ShapeType.MultiPatch)]
        public void AddRecordOfUnimplementedShapeTypeThrowsNotImplementedException(ShapeType shapeType)
        {
            ShapeFile shapeFile = new ShapeFile();
            shapeFile.ShapeType = shapeType;
            Record record = shapeFile.CreateNewRecord();

            Action act = () => shapeFile.AddRecord(record);

            act.Should().Throw<NotImplementedException>();
        }
    }
}
