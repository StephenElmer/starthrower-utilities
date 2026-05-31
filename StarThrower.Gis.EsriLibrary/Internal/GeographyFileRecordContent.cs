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
