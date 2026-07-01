// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    /// <summary>
    /// FileHeader
    /// 
    /// NOTE: The index file header is identical in organization to the main file header.
    /// The file length stored in the index file header is the total length of the index file
    /// in 16-bit words (the fifty 16-bit words of the header plus 4 times the number of records).
    /// 
    /// </summary>
    internal sealed class FileHeader
    {
        public const Int32 SIZE = 100; //size in bytes possible for the header


        #region Private Member Variables

        private Int32 _fileCode = 9994; //4 bytes 0-3 (Big Endian)
        private Int32 _reserved1; //4 bytes 4-7 (Big Endian)
        private Int32 _reserved2; //4 bytes 8-11 (Big Endian)
        private Int32 _reserved3; //4 bytes 12-15 (Big Endian)
        private Int32 _reserved4; //4 bytes 16-19 (Big Endian)
        private Int32 _reserved5; //4 bytes 20-23 (Big Endian)
        private Int32 _fileLength = 100; //4 bytes 24-27 (Big Endian)  100 = the length of the file header plus the EOF character - a file with no records should be at least 101 bytes
        private Int32 _version = 1000; //4 bytes 28-31 (Little Endian)
        private ShapeType _shapeType = ShapeType.NullShape; //4 bytes 32-35 (Little Endian)

        //Bounding box (extent)
        private double _xMin; //8 bytes 36-43 (Little Endian)
        private double _yMin; //8 bytes 44-51 (Little Endian)
        private double _xMax; //8 bytes 52-59 (Little Endian)
        private double _yMax; //8 bytes 60-67 (Little Endian)

        //Unused, with value 0.0, if not Measured or Z type
        private double _zMin; //8 bytes 68-75 (Little Endian)
        private double _zMax; //8 bytes 76-83 (Little Endian)
        private double _mMin; //8 bytes 84-91 (Little Endian)
        private double _mMax; //8 bytes 92-99 (Little Endian)

        #endregion


        #region Internal Properties

        /// <summary>
        /// Number of BYTES (not number of 2-byte words as stored on disk)
        /// </summary>
        internal Int32 FileLength
        {
            get { return _fileLength; }
            set { _fileLength = value; }
        }

        /// <summary>
        /// Gets or sets the geometry type of the shapes stored in this file.
        /// </summary>
        internal ShapeType ShapeType
        {
            get { return _shapeType; }
            set { _shapeType = value; }
        }

        /// <summary>
        /// Gets or sets the bounding rectangle that encloses all shapes in the file.
        /// </summary>
        internal StarThrower.Gis.GeoUtilities.GeoRectangle Extent
        {
            get
            {
                return new StarThrower.Gis.GeoUtilities.GeoRectangle(_xMin, _yMin, _xMax, _yMax);
            }
            set
            {
                _xMin = value.Left;
                _yMin = value.Top;
                _xMax = value.Right;
                _yMax = value.Bottom;
            }
        }

        #endregion


        #region Internal Methods

        /// <summary>
        /// Serializes this header to its 100-byte binary representation. Per the ESRI
        /// shapefile format, the file-code/reserved/file-length fields are big-endian while
        /// the version, shape type, and bounding box fields are little-endian.
        /// </summary>
        internal byte[] GetBytes()
        {
            byte[] result = new byte[SIZE];

            Int32 curIdx = 0;

            byte[] fileCode = ByteUtil.Int32ToByteArray(_fileCode, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = fileCode[i];
            }

            byte[] reserved1 = ByteUtil.Int32ToByteArray(_reserved1, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = reserved1[i];
            }

            byte[] reserved2 = ByteUtil.Int32ToByteArray(_reserved2, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = reserved2[i];
            }

            byte[] reserved3 = ByteUtil.Int32ToByteArray(_reserved3, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = reserved3[i];
            }

            byte[] reserved4 = ByteUtil.Int32ToByteArray(_reserved4, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = reserved4[i];
            }

            byte[] reserved5 = ByteUtil.Int32ToByteArray(_reserved5, ByteEndian.Big, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = reserved5[i];
            }

            //Note: _fileLength is in bytes, but is stored in 2-byte words
            byte[] fileLength = ByteUtil.Int32ToByteArray(_fileLength / 2, ByteEndian.Big, BitEndian.Little);

            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = fileLength[i];
            }

            byte[] version = ByteUtil.Int32ToByteArray(_version, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = version[i];
            }

            byte[] shapeType = ByteUtil.Int32ToByteArray((Int32)_shapeType, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 4; i++)
            {
                result[curIdx++] = shapeType[i];
            }

            byte[] xMin = ByteUtil.DoubleToByteArray(_xMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = xMin[i];
            }

            byte[] yMin = ByteUtil.DoubleToByteArray(_yMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = yMin[i];
            }

            byte[] xMax = ByteUtil.DoubleToByteArray(_xMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = xMax[i];
            }

            byte[] yMax = ByteUtil.DoubleToByteArray(_yMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = yMax[i];
            }

            byte[] zMin = ByteUtil.DoubleToByteArray(_zMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = zMin[i];
            }

            byte[] zMax = ByteUtil.DoubleToByteArray(_zMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = zMax[i];
            }

            byte[] mMin = ByteUtil.DoubleToByteArray(_mMin, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = mMin[i];
            }

            byte[] mMax = ByteUtil.DoubleToByteArray(_mMax, ByteEndian.Little, BitEndian.Little);
            for (Int32 i = 0; i < 8; i++)
            {
                result[curIdx++] = mMax[i];
            }

            return result;
        }

        /// <summary>
        /// Parses this header's fields from their 100-byte binary representation. Per the
        /// ESRI shapefile format, the file-code/reserved/file-length fields are big-endian
        /// while the version, shape type, and bounding box fields are little-endian.
        /// </summary>
        internal void ParseBytes(byte[] bytes)
        {
            _fileCode = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 0, 4), ByteEndian.Big, BitEndian.Little);

            _reserved1 = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 4, 4), ByteEndian.Big, BitEndian.Little);
            _reserved2 = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 8, 4), ByteEndian.Big, BitEndian.Little);
            _reserved3 = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 12, 4), ByteEndian.Big, BitEndian.Little);
            _reserved4 = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 16, 4), ByteEndian.Big, BitEndian.Little);
            _reserved5 = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 20, 4), ByteEndian.Big, BitEndian.Little);

            //Note: _fileLength is in bytes, but is stored in 2-byte words
            _fileLength = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 24, 4), ByteEndian.Big, BitEndian.Little) * 2;

            _version = ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 28, 4), ByteEndian.Little, BitEndian.Little);
            _shapeType = (ShapeType)(ByteUtil.ByteArrayToInt32(ByteUtil.ByteSubstring(bytes, 32, 4), ByteEndian.Little, BitEndian.Little));

            _xMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 36, 8), ByteEndian.Little, BitEndian.Little);
            _yMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 44, 8), ByteEndian.Little, BitEndian.Little);
            _xMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 52, 8), ByteEndian.Little, BitEndian.Little);
            _yMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 60, 8), ByteEndian.Little, BitEndian.Little);

            _zMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 68, 8), ByteEndian.Little, BitEndian.Little);
            _zMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 76, 8), ByteEndian.Little, BitEndian.Little);
            _mMin = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 84, 8), ByteEndian.Little, BitEndian.Little);
            _mMax = ByteUtil.ByteArrayToDouble(ByteUtil.ByteSubstring(bytes, 92, 8), ByteEndian.Little, BitEndian.Little);
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            result.AppendLine("<header " +
                          "fileCode=\"" + _fileCode.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "fileLength=\"" + _fileLength.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "version=\"" + _version.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "shapeType=\"" + _shapeType.ToString() + "\" " +
                          "xMin=\"" + _xMin.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "yMin=\"" + _yMin.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "xMax=\"" + _xMax.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "yMax=\"" + _yMax.ToString(CultureInfo.InvariantCulture) + "\" " +
                          "/>");
            return result.ToString();
        }

        #endregion
    }
}
