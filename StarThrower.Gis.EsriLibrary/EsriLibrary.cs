// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.ByteUtilities;

namespace StarThrower.Gis.EsriLibrary
{
    /// <summary>
    /// Identifies the geometry type of a shapefile or an individual shape record, using the
    /// same numeric codes defined by the ESRI shapefile specification.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>No geometry.</summary>
        NullShape = 0,

        /// <summary>A single point.</summary>
        Point = 1,

        /// <summary>An ordered set of vertices forming one or more connected line segments.</summary>
        PolyLine = 3,

        /// <summary>One or more rings forming a closed area.</summary>
        Polygon = 5,

        /// <summary>An unordered collection of points sharing a single set of attributes.</summary>
        MultiPoint = 8,

        /// <summary>A point with an additional Z (elevation) value.</summary>
        PointZ = 11,

        /// <summary>A polyline with additional Z (elevation) values for each vertex.</summary>
        PolyLineZ = 13,

        /// <summary>A polygon with additional Z (elevation) values for each vertex.</summary>
        PolygonZ = 15,

        /// <summary>A multipoint with an additional Z (elevation) value for each point.</summary>
        MultiPointZ = 18,

        /// <summary>A point with an additional measure (M) value.</summary>
        PointM = 21,

        /// <summary>A polyline with additional measure (M) values for each vertex.</summary>
        PolyLineM = 23,

        /// <summary>A polygon with additional measure (M) values for each vertex.</summary>
        PolygonM = 25,

        /// <summary>A multipoint with an additional measure (M) value for each point.</summary>
        MultiPointM = 28,

        /// <summary>A collection of surface patches describing a 3D shape.</summary>
        MultiPatch = 31
    }

    /// <summary>
    /// Provides conversions between the public Esri shape and field types and the internal
    /// XBase and GeoUtilities representations used to read and write shapefiles.
    /// </summary>
    internal static class EsriLibrary
    {
        /// <summary>
        /// Parses the string representation of a <see cref="ShapeType"/> value (as produced by
        /// <see cref="Enum.ToString()"/>) back into its enum value.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="shapeType"/> does not match a known <see cref="ShapeType"/> name.</exception>
        internal static StarThrower.Gis.EsriLibrary.ShapeType GetShapeTypeFromString(string shapeType)
        {
            if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.NullShape.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.NullShape;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.Point.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.Point;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PolyLine.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PolyLine;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.Polygon.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.Polygon;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PointZ.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PointZ;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PointM.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PointM;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.PolygonM.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.PolygonM;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM;
            }
            else if (shapeType.Equals(StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch.ToString(), StringComparison.Ordinal))
            {
                return StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch;
            }
            else
            {
                throw new ArgumentException("Invalid shape type", nameof(shapeType));
            }
        }

        /// <summary>
        /// Converts a <see cref="StarThrower.Gis.GeoUtilities.Shapes.ShapeType"/> to its
        /// equivalent Esri <see cref="ShapeType"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="shapeType"/> is not a recognized shape type.</exception>
        internal static StarThrower.Gis.EsriLibrary.ShapeType GeoToEsriShapeType(StarThrower.Gis.GeoUtilities.Shapes.ShapeType shapeType)
        {
            switch (shapeType)
            {
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.NullShape:
                    return StarThrower.Gis.EsriLibrary.ShapeType.NullShape;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point:
                    return StarThrower.Gis.EsriLibrary.ShapeType.Point;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polyline:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PolyLine;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon:
                    return StarThrower.Gis.EsriLibrary.ShapeType.Polygon;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipoint:
                    return StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointZ:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PointZ;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineZ:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonZ:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ:
                    return StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointM:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PointM;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineM:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonM:
                    return StarThrower.Gis.EsriLibrary.ShapeType.PolygonM;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointM:
                    return StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipatch:
                    return StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch;
                default:
                    throw new ArgumentException("Invalid shape type", nameof(shapeType));
            }
        }

        /// <summary>
        /// Converts an Esri <see cref="ShapeType"/> to its equivalent
        /// <see cref="StarThrower.Gis.GeoUtilities.Shapes.ShapeType"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="shapeType"/> is not a recognized shape type.</exception>
        internal static StarThrower.Gis.GeoUtilities.Shapes.ShapeType EsriToGeoShapeType(StarThrower.Gis.EsriLibrary.ShapeType shapeType)
        {
            switch (shapeType)
            {
                case StarThrower.Gis.EsriLibrary.ShapeType.NullShape:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.NullShape;
                case StarThrower.Gis.EsriLibrary.ShapeType.Point:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLine:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polyline;
                case StarThrower.Gis.EsriLibrary.ShapeType.Polygon:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPoint:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipoint;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointZ:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointZ;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineZ:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineZ;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonZ:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonZ;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointZ:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ;
                case StarThrower.Gis.EsriLibrary.ShapeType.PointM:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointM;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolyLineM:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineM;
                case StarThrower.Gis.EsriLibrary.ShapeType.PolygonM:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonM;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPointM:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointM;
                case StarThrower.Gis.EsriLibrary.ShapeType.MultiPatch:
                    return StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipatch;
                default:
                    throw new ArgumentException("Invalid shape type", nameof(shapeType));
            }
        }

        /// <summary>
        /// Serializes a shape's geometry to its shapefile (.shp) binary record content: a
        /// little-endian shape type code followed by the type-specific coordinate and part
        /// data. Only <see cref="StarThrower.Gis.GeoUtilities.Shapes.ShapeType.NullShape"/>,
        /// <c>Point</c>, <c>Polyline</c>, and <c>Polygon</c> write their full geometry; all
        /// other shape types currently write only the 4-byte shape type code.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="shape"/>'s shape type is not recognized.</exception>
        internal static byte[] ShapeToBytes(StarThrower.Gis.GeoUtilities.Shapes.Shape shape)
        {
            byte[]? result = null;
            int curIdx = 0;
            byte[]? shapeType = null;
            byte[]? x = null;
            byte[]? y = null;
            byte[]? xMin = null;
            byte[]? yMin = null;
            byte[]? xMax = null;
            byte[]? yMax = null;
            byte[]? numParts = null;
            byte[]? numPoints = null;
            byte[]? partBuffer = null;
            StarThrower.Gis.GeoUtilities.GeoRectangle? extent = null;
            int pointIdx = 0;

            switch (shape.ShapeType)
            {
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.NullShape:
                    result = new byte[EsriLibrary.GetShapeLengthInBytes(shape)];

                    curIdx = 0;
                    shapeType = ByteUtil.Int32ToByteArray((Int32)(shape.ShapeType), ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = shapeType[i];
                    }

                    return result;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point:
                    result = new byte[EsriLibrary.GetShapeLengthInBytes(shape)];

                    curIdx = 0;
                    shapeType = ByteUtil.Int32ToByteArray((Int32)(shape.ShapeType), ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = shapeType[i];
                    }

                    x = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PointShape)shape).xLon, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = x[i];
                    }

                    y = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PointShape)shape).yLat, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = y[i];
                    }

                    return result;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polyline:
                    result = new byte[EsriLibrary.GetShapeLengthInBytes(shape)];

                    curIdx = 0;
                    shapeType = ByteUtil.Int32ToByteArray((Int32)(shape.ShapeType), ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = shapeType[i];
                    }

                    extent = ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).Extent;
                    xMin = ByteUtil.DoubleToByteArray(extent.Left, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = xMin[i];
                    }

                    yMin = ByteUtil.DoubleToByteArray(extent.Top, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = yMin[i];
                    }

                    xMax = ByteUtil.DoubleToByteArray(extent.Right, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = xMax[i];
                    }

                    yMax = ByteUtil.DoubleToByteArray(extent.Bottom, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = yMax[i];
                    }

                    numParts = ByteUtil.Int32ToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PartCount, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = numParts[i];
                    }

                    numPoints = ByteUtil.Int32ToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PointCount, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = numPoints[i];
                    }

                    pointIdx = 0;
                    for (int i = 0; i < ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PartCount; i++)
                    {
                        partBuffer = null;
                        partBuffer = ByteUtil.Int32ToByteArray(pointIdx, ByteEndian.Little, BitEndian.Little);
                        pointIdx += ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).GetPart(i).PointCount;
                        for (int j = 0; j < 4; j++)
                        {
                            result[curIdx++] = partBuffer[j];
                        }
                    }

                    for (int i = 0; i < ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PartCount; i++)
                    {
                        for (int j = 0; j < ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).GetPart(i).PointCount; j++)
                        {
                            x = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).GetPart(i).GetPoint(j).xLon, ByteEndian.Little, BitEndian.Little);
                            for (int k = 0; k < 8; k++)
                            {
                                result[curIdx++] = x[k];
                            }

                            y = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).GetPart(i).GetPoint(j).yLat, ByteEndian.Little, BitEndian.Little);
                            for (int k = 0; k < 8; k++)
                            {
                                result[curIdx++] = y[k];
                            }
                        }
                    }


                    return result;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon:
                    result = new byte[EsriLibrary.GetShapeLengthInBytes(shape)];

                    curIdx = 0;
                    shapeType = ByteUtil.Int32ToByteArray((Int32)(shape.ShapeType), ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = shapeType[i];
                    }

                    extent = ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).Extent;
                    xMin = ByteUtil.DoubleToByteArray(extent.Left, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = xMin[i];
                    }

                    yMin = ByteUtil.DoubleToByteArray(extent.Top, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = yMin[i];
                    }

                    xMax = ByteUtil.DoubleToByteArray(extent.Right, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = xMax[i];
                    }

                    yMax = ByteUtil.DoubleToByteArray(extent.Bottom, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 8; i++)
                    {
                        result[curIdx++] = yMax[i];
                    }

                    numParts = ByteUtil.Int32ToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PartCount, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = numParts[i];
                    }

                    numPoints = ByteUtil.Int32ToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PointCount, ByteEndian.Little, BitEndian.Little);
                    for (int i = 0; i < 4; i++)
                    {
                        result[curIdx++] = numPoints[i];
                    }

                    pointIdx = 0;
                    for (int i = 0; i < ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PartCount; i++)
                    {
                        partBuffer = null;
                        partBuffer = ByteUtil.Int32ToByteArray(pointIdx, ByteEndian.Little, BitEndian.Little);
                        pointIdx += ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).GetPart(i).PointCount;
                        for (int j = 0; j < 4; j++)
                        {
                            result[curIdx++] = partBuffer[j];
                        }
                    }

                    for (int i = 0; i < ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PartCount; i++)
                    {
                        for (int j = 0; j < ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).GetPart(i).PointCount; j++)
                        {
                            x = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).GetPart(i).GetPoint(j).xLon, ByteEndian.Little, BitEndian.Little);
                            for (int k = 0; k < 8; k++)
                            {
                                result[curIdx++] = x[k];
                            }

                            y = ByteUtil.DoubleToByteArray(((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).GetPart(i).GetPoint(j).yLat, ByteEndian.Little, BitEndian.Little);
                            for (int k = 0; k < 8; k++)
                            {
                                result[curIdx++] = y[k];
                            }
                        }
                    }

                    return result;
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipoint:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipatch:
                    //TODO: #33 — this stub only writes the 4-byte shape-type code. Once the
                    //corresponding Internal/Records/*.cs class's ParseBytes/GetBytes is
                    //implemented (#17-#26), this case must also be implemented (or refactored
                    //to delegate to that class), or AddRecord will silently write truncated
                    //.shp records instead of throwing NotImplementedException as it does today.
                    result = new byte[EsriLibrary.GetShapeLengthInBytes(shape)];

                    curIdx = 0;
                    shapeType = ByteUtil.Int32ToByteArray((Int32)(shape.ShapeType), ByteEndian.Little, BitEndian.Little);
                    for (Int32 i = 0; i < 4; i++)
                    {
                        result[curIdx++] = shapeType[i];
                    }

                    return result;
                default:
                    throw new ArgumentException("Invalid shape type", nameof(shape));
            }
        }

        /// <summary>
        /// Calculates the length, in bytes, that the shape's binary record content occupies in
        /// a shapefile (.shp), matching the layout produced by <see cref="ShapeToBytes"/>.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="shape"/>'s shape type is not recognized.</exception>
        internal static int GetShapeLengthInBytes(StarThrower.Gis.GeoUtilities.Shapes.Shape shape)
        {
            switch (shape.ShapeType)
            {
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.NullShape:
                    return 4; //length of _shapeType
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Point:
                    return 4 + 8 + 8; //length of _shapeType + two doubles
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polyline:
                    return 4 + 32 + 4 + 4 + ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PartCount * 4 + ((StarThrower.Gis.GeoUtilities.Shapes.PolylineShape)shape).PointCount * 16; //length of _shapeType + four doubles + one int + one int + a list of ints + a list of pairs of doubles
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Polygon:
                    return 4 + 32 + 4 + 4 + ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PartCount * 4 + ((StarThrower.Gis.GeoUtilities.Shapes.PolygonShape)shape).PointCount * 16; //length of _shapeType + four doubles + one int + one int + a list of ints + a list of pairs of doubles
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipoint:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointZ:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PointM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolylineM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.PolygonM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.MultipointM:
                case StarThrower.Gis.GeoUtilities.Shapes.ShapeType.Multipatch:
                    //TODO: #33 — kept in sync with the ShapeToBytes stub above; must be
                    //updated alongside it once full serialization is implemented.
                    return 4; //length of _shapeType
                default:
                    throw new ArgumentException("Invalid shape type", nameof(shape));
            }
        }

        /// <summary>
        /// Converts an XBase field type code to its equivalent Esri <see cref="Types.FieldType"/>.
        /// </summary>
        internal static StarThrower.Gis.EsriLibrary.Types.FieldType XBaseFieldTypeToEsriFieldType(StarThrower.XBase.FieldType fieldType)
        {
            switch (fieldType.Code)
            {
                case 'C':
                    return new StarThrower.Gis.EsriLibrary.Types.StringField();
                case 'F':
                    return new StarThrower.Gis.EsriLibrary.Types.FloatField();
                case 'D':
                    return new StarThrower.Gis.EsriLibrary.Types.DateField();
                case 'N':
                    return new StarThrower.Gis.EsriLibrary.Types.NumericField();
                case 'M':
                    return new StarThrower.Gis.EsriLibrary.Types.MemoField();
                case 'L':
                    return new StarThrower.Gis.EsriLibrary.Types.BooleanField();
                default:
                    return new StarThrower.Gis.EsriLibrary.Types.UndefinedField();
            }
        }

        /// <summary>
        /// Converts an Esri <see cref="Types.FieldType"/> to its equivalent XBase field type.
        /// </summary>
        internal static StarThrower.XBase.FieldType EsriFieldTypeToXBaseFieldType(StarThrower.Gis.EsriLibrary.Types.FieldType fieldType)
        {
            switch (fieldType.Code)
            {
                case 'C':
                    return new StarThrower.XBase.StringField();
                case 'F':
                    return new StarThrower.XBase.FloatField();
                case 'D':
                    return new StarThrower.XBase.DateField();
                case 'N':
                    return new StarThrower.XBase.NumericField();
                case 'M':
                    return new StarThrower.XBase.MemoField();
                case 'L':
                    return new StarThrower.XBase.BooleanField();
                default:
                    return new StarThrower.XBase.UndefinedField();
            }
        }

        /// <summary>
        /// Converts an XBase field descriptor to its equivalent Esri <see cref="Field"/>.
        /// </summary>
        internal static StarThrower.Gis.EsriLibrary.Field XBaseFieldToEsriField(StarThrower.XBase.XBaseField field)
        {
            StarThrower.Gis.EsriLibrary.Field newField = new StarThrower.Gis.EsriLibrary.Field();
            newField.Name = field.Name;
            newField.Length = field.Length;
            newField.Type = StarThrower.Gis.EsriLibrary.EsriLibrary.XBaseFieldTypeToEsriFieldType(field.FieldType);
            newField.DecimalCount = field.DecimalCount;
            return newField;
        }

        /// <summary>
        /// Converts an Esri <see cref="Field"/> to its equivalent XBase field descriptor.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="field"/>.Type is <see langword="null"/>.</exception>
        internal static StarThrower.XBase.XBaseField EsriFieldToXBaseField(StarThrower.Gis.EsriLibrary.Field field)
        {
            StarThrower.XBase.XBaseField newField = new StarThrower.XBase.XBaseField();
            newField.Name = field.Name;
            newField.Length = field.Length;
            newField.FieldType = StarThrower.Gis.EsriLibrary.EsriLibrary.EsriFieldTypeToXBaseFieldType(
                field.Type ?? throw new ArgumentException("Field type must not be null.", nameof(field)));
            newField.DecimalCount = field.DecimalCount;
            return newField;
        }
    }
}
