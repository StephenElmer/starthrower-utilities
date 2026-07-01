// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// Base type for the binary content of a single geography (.shp) file record. Each
    /// concrete subclass under <c>Internal/Records/</c> represents one <see cref="ShapeType"/>
    /// and knows how to parse itself from, and serialize itself back to, the record's raw bytes.
    /// </summary>
    internal abstract class GeographyFileRecordContent
    {
        #region Private Instance Variables

        private ShapeType _shapeType = ShapeType.NullShape; //bytes 0-3 (int) (Little Endian)

        #endregion


        #region Internal Properties

        /// <summary>
        /// Gets the shape type this record content represents.
        /// </summary>
        public StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _shapeType; }
            protected set { _shapeType = value; }
        }

        /// <summary>
        /// Gets the bounding rectangle of this record's geometry, as parsed from its bytes.
        /// </summary>
        internal abstract StarThrower.Gis.GeoUtilities.GeoRectangle Extent { get; }

        #endregion


        #region Internal Methods

        /// <summary>
        /// Serializes this record's geometry to its shapefile (.shp) binary record content.
        /// </summary>
        internal abstract byte[] GetBytes();

        /// <summary>
        /// Gets the length, in bytes, of this record's serialized binary content.
        /// </summary>
        internal abstract Int32 GetLengthInBytes();

        /// <summary>
        /// Serializes this record's geometry to XML.
        /// </summary>
        internal abstract string ToXml();

        /// <summary>
        /// Converts this record's parsed geometry into a
        /// <see cref="StarThrower.Gis.GeoUtilities.Shapes.Shape"/>.
        /// </summary>
        internal abstract StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape();

        #endregion
    }
}
