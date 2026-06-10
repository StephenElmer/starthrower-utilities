// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal abstract class GeographyFileRecordContent
    {
        #region Private Instance Variables

        private ShapeType _shapeType = ShapeType.NullShape; //bytes 0-3 (int) (Little Endian)

        #endregion


        #region Internal Properties

        public StarThrower.Gis.EsriLibrary.ShapeType ShapeType
        {
            get { return _shapeType; }
            protected set { _shapeType = value; }
        }

        internal abstract StarThrower.Gis.GeoUtilities.GeoRectangle Extent { get; }

        #endregion


        #region Internal Methods

        internal abstract byte[] GetBytes();

        internal abstract Int32 GetLengthInBytes();

        internal abstract string ToXml();

        internal abstract StarThrower.Gis.GeoUtilities.Shapes.Shape GetGeoUtilitiesShape();

        #endregion
    }
}
