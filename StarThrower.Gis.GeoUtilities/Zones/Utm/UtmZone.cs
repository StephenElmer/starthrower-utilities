/***********************************************************************************
    StarThrower Utilities / Gis.GeoUtilities
    Copyright (C) 2005-2026  Stephen Elmer

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
using System.Globalization;
using System.Text;
using StarThrower.Logging;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.Zones.Utm
{
    /// <summary>
    /// The concrete implementation of the Zone base class for UTM.
    /// This particular variation supports UTM zones 1 thru 60 longitudinally
    /// and zones A thru Z latitudinally.  For usage of North and South
    /// latitudinal zones, use the cref="UtmNsZone" class.
    /// </summary>
    public class UtmZone : Zone
    {
        #region Private Instance Variables

        private LongitudinalZone _longitudinalZone = LongitudinalZone.Undefined;
        private LatitudinalZone _latitudinalZone = LatitudinalZone.Undefined;

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the unique name of the zone.
        /// If either LongitudinalZone or LatitudinalZone are Undefined, 
        /// this property will return "Undefined"; otherwise the name
        /// is normally some combination of the Longitudinal and Latitudinal
        /// Zone names.
        /// </summary>
        public override string Name
        {
            get
            {
                if (_longitudinalZone == LongitudinalZone.Undefined || _latitudinalZone == LatitudinalZone.Undefined)
                {
                    return "Undefined";
                }
                else
                {
                    return _longitudinalZone.ToString() + _latitudinalZone.ToString();
                }
            }
        }

        public override double CentralMeridian
        {
            get { return GetCentralMeridian(); }
        }

        public override double GeometricCenter
        {
            get { return GetGeometricCenter(); }
        }

        /// <summary>
        /// Gets the value of the Reference yLat associated with the zone.
        /// This will be a value that falls between the northern- and southern-most
        /// latitudinal boundaries of the UTM zone.  An attempt to get the 
        /// ReferenceLatitude for Zones A, B, Y, or Z will result in a NotSupportedException
        /// being thrown, as these zones fall outside the boundary of the normal UTM 
        /// projection.
        /// </summary>
        public override double ReferenceLatitude
        {
            get { return GetReferenceLatitude(); }
        }

        /// <summary>
        /// Gets the LongitudinalZone associated with this UTM Zone.
        /// </summary>
        public LongitudinalZone LongitudinalZone
        {
            get { return _longitudinalZone; }
        }

        /// <summary>
        /// Gets the LatitudinalZone associated with this UTM Zone.
        /// </summary>
        public LatitudinalZone LatitudinalZone
        {
            get { return _latitudinalZone; }
        }

        /// <summary>
        /// Gets whether or not the UtmZone lies within the Southern Hemisphere.
        /// Returns true if the LatitudinalZone falls within A thru M inclusive;
        /// false, if otherwise.
        /// </summary>
        public override bool IsSouthernHemisphere
        {
            get 
            {
                switch (_latitudinalZone)
                {
                    case LatitudinalZone.UtmA:
                    case LatitudinalZone.UtmB:
                    case LatitudinalZone.UtmC:
                    case LatitudinalZone.UtmD:
                    case LatitudinalZone.UtmE:
                    case LatitudinalZone.UtmF:
                    case LatitudinalZone.UtmG:
                    case LatitudinalZone.UtmH:
                    case LatitudinalZone.UtmJ:
                    case LatitudinalZone.UtmK:
                    case LatitudinalZone.UtmL:
                    case LatitudinalZone.UtmM:
                        return true;
                    case LatitudinalZone.UtmN:
                    case LatitudinalZone.UtmP:
                    case LatitudinalZone.UtmQ:
                    case LatitudinalZone.UtmR:
                    case LatitudinalZone.UtmS:
                    case LatitudinalZone.UtmT:
                    case LatitudinalZone.UtmU:
                    case LatitudinalZone.UtmV:
                    case LatitudinalZone.UtmW:
                    case LatitudinalZone.UtmX:
                    case LatitudinalZone.UtmY:
                    case LatitudinalZone.UtmZ:
                        return false;
                    default:
                        throw new ArgumentException("Invalid value specified for latitudinalZone.");
                }
            }
        }

        public override string ZoneString
        {
            get
            {
                try
                {
                    string lon = _longitudinalZone.ToString();
                    string lat = _latitudinalZone.ToString();
                    StringBuilder result = new StringBuilder(String.Empty);

                    if (StringUtil.Left(lon, 3) == "Utm")
                    {
                        if (StringUtil.Left(lon, 4) == "Utm0")
                        {
                            result.Append(StringUtil.Right(lon, lon.Length - 4));
                        }
                        else
                        {
                            result.Append(StringUtil.Right(lon, lon.Length - 3));
                        }
                    }
                    else
                    {
                        result.Append(lon);
                    }

                    if (StringUtil.Left(lat, 3) == "Utm")
                    {
                        result.Append(StringUtil.Right(lat, lat.Length - 3));
                    }
                    else
                    {
                        result.Append(lat);
                    }

                    return result.ToString();
                }
                catch (Exception ex)
                {
                    Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetZoneString", ex);
                    throw;
                }
            }
        }

        #endregion


        #region Construction

        public UtmZone(LongitudinalZone longitudinalZone, LatitudinalZone latitudinalZone)
        {
            _longitudinalZone = longitudinalZone;
            _latitudinalZone = latitudinalZone;
        }

        public UtmZone(double longitude, double latitude)
        {
            _longitudinalZone = GetLongitudinalZoneForLongitude(longitude, latitude);
            _latitudinalZone = GetLatitudinalZoneForLatitude(latitude);
        }

        public UtmZone(string zone)
        {
            ArgumentNullException.ThrowIfNull(zone);

            int longitudinalZone = 0;
            if (int.TryParse(zone.Substring(0, 2), out longitudinalZone))
            {
                _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone.ToString(CultureInfo.InvariantCulture));
            }
            else if (int.TryParse(zone.Substring(0, 1), out longitudinalZone))
            {
                _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                throw new FormatException();
            }


            int stub = 0;
            string? latitudinalZone = null;
            if (int.TryParse(zone.Substring(0, 2), out stub))
            {
                latitudinalZone = zone.Substring(2, zone.Length - 2);
                _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
            }
            else if (int.TryParse(zone.Substring(0, 1), out stub))
            {
                latitudinalZone = zone.Substring(1, zone.Length - 1);
                _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
            }
            else
            {
                throw new FormatException();
            }

        }

        public UtmZone(string longitudinalZone, string latitudinalZone)
        {
            _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone);
            _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
        }

        #endregion


        #region Private Methods

        private double GetCentralMeridian()
        {
            try
            {
                switch (_longitudinalZone)
                {
                    case LongitudinalZone.Utm01:
                        return -177.0;
                    case LongitudinalZone.Utm02:
                        return -171.0;
                    case LongitudinalZone.Utm03:
                        return -165.0;
                    case LongitudinalZone.Utm04:
                        return -159.0;
                    case LongitudinalZone.Utm05:
                        return -153.0;
                    case LongitudinalZone.Utm06:
                        return -147.0;
                    case LongitudinalZone.Utm07:
                        return -141.0;
                    case LongitudinalZone.Utm08:
                        return -135.0;
                    case LongitudinalZone.Utm09:
                        return -129.0;
                    case LongitudinalZone.Utm10:
                        return -123.0;
                    case LongitudinalZone.Utm11:
                        return -117.0;
                    case LongitudinalZone.Utm12:
                        return -111.0;
                    case LongitudinalZone.Utm13:
                        return -105.0;
                    case LongitudinalZone.Utm14:
                        return -99.0;
                    case LongitudinalZone.Utm15:
                        return -93.0;
                    case LongitudinalZone.Utm16:
                        return -87.0;
                    case LongitudinalZone.Utm17:
                        return -81.0;
                    case LongitudinalZone.Utm18:
                        return -75.0;
                    case LongitudinalZone.Utm19:
                        return -69.0;
                    case LongitudinalZone.Utm20:
                        return -63.0;
                    case LongitudinalZone.Utm21:
                        return -57.0;
                    case LongitudinalZone.Utm22:
                        return -51.0;
                    case LongitudinalZone.Utm23:
                        return -45.0;
                    case LongitudinalZone.Utm24:
                        return -39.0;
                    case LongitudinalZone.Utm25:
                        return -33.0;
                    case LongitudinalZone.Utm26:
                        return -27.0;
                    case LongitudinalZone.Utm27:
                        return -21.0;
                    case LongitudinalZone.Utm28:
                        return -15.0;
                    case LongitudinalZone.Utm29:
                        return -9.0;
                    case LongitudinalZone.Utm30:
                        return -3.0;
                    case LongitudinalZone.Utm31:
                        /* 
                         * NO: it seems to be that case that standard implementations of UTM do not adjust the central meridian for 31X and 31V, even though they adjust the width of these zones.  This is likely because the central meridian is not used in the actual projection calculations, but is only used as a reference point for calculating easting values.  Since the width of 31X and 31V are adjusted, the easting values will be adjusted accordingly, even if the central meridian remains at 3.0.                
                        switch (_latitudinalZone)
                        {
                            case LatitudinalZone.UtmX:
                                return 4.5; //31X is widened by 3deg to 9deg wide making the central meridian for 31X = 4.5;
                            //Ref: http://www2.geo.uib.no/nav-processing/
                            case LatitudinalZone.UtmV:
                                return 1.5; //31V is narrowed by 3deg to 3deg wide making the central meridian for 31V = 1.5 
                            //Ref: http://www.dba-sql-server.com/sql_server_tips/t_super_sql_304_xp_gis_ll2utm.htm
                            default:
                                return 3.0;
                        }
                        */
                        return 3.0;
                    case LongitudinalZone.Utm32:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 32 for Latitudinal Zone X.");
                        /*
                         * NO: it seems to be that case that standard implementations of UTM do not adjust the central meridian for 31X and 31V, even though they adjust the width of these zones.  This is likely because the central meridian is not used in the actual projection calculations, but is only used as a reference point for calculating easting values.  Since the width of 31X and 31V are adjusted, the easting values will be adjusted accordingly, even if the central meridian remains at 3.0.                
                        if (_latitudinalZone == LatitudinalZone.UtmV)
                        {
                            return 7.5; //31V is narrowed by 3deg to 3deg wide, which makes 32V widened by 3deg making it a total of 9deg wide.  half of 9deg is 4.5deg. add this to the width of 31V (3deg) and you get 7.5 for the central meridian
                            //Ref: http://www.dba-sql-server.com/sql_server_tips/t_super_sql_304_xp_gis_ll2utm.htm
                        }
                        else
                        {
                            return 9.0;
                        }
                        */
                        return 9.0;
                    case LongitudinalZone.Utm33:
                        /*
                         * NO: it seems to be that case that standard implementations of UTM do not adjust the central meridian for 31X and 31V, even though they adjust the width of these zones.  This is likely because the central meridian is not used in the actual projection calculations, but is only used as a reference point for calculating easting values.  Since the width of 31X and 31V are adjusted, the easting values will be adjusted accordingly, even if the central meridian remains at 3.0.                
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 15.0; //33X is widened by 6deg to 12deg. Since 32X is removed and 31X has been widened to 9deg, 9deg + 6deg (half of 12) = 15
                            //Ref: http://www2.geo.uib.no/nav-processing/
                        }
                        */
                        return 15.0;
                    case LongitudinalZone.Utm34:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 34 for Latitudinal Zone X.");
                        return 21.0;
                    case LongitudinalZone.Utm35:
                        /*
                         * NO: it seems to be that case that standard implementations of UTM do not adjust the central meridian for 31X and 31V, even though they adjust the width of these zones.  This is likely because the central meridian is not used in the actual projection calculations, but is only used as a reference point for calculating easting values.  Since the width of 31X and 31V are adjusted, the easting values will be adjusted accordingly, even if the central meridian remains at 3.0.                
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 27.0; //35X is widened by 6deg to 12deg. Since 32X and 33X are removed and 31X and 33X have been widened so that the westmost meridian of 35X = 21, add 6 (half of 12) and you get 27 for the CM of 35X
                            //Ref: http://www2.geo.uib.no/nav-processing/
                        }
                        */
                        return 27.0;
                    case LongitudinalZone.Utm36:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 36 for Latitudinal Zone X.");
                        return 33.0;
                    case LongitudinalZone.Utm37:
                        /*
                         * NO: it seems to be that case that standard implementations of UTM do not adjust the central meridian for 31X and 31V, even though they adjust the width of these zones.  This is likely because the central meridian is not used in the actual projection calculations, but is only used as a reference point for calculating easting values.  Since the width of 31X and 31V are adjusted, the easting values will be adjusted accordingly, even if the central meridian remains at 3.0.                
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 37.5; //37X is widened by 3deg to 12deg making the westmost meridian = 33, the eastmost meridian = 42, and the cm = 37.5
                        }
                        */
                        return 39.0;
                    case LongitudinalZone.Utm38:
                        return 45.0;
                    case LongitudinalZone.Utm39:
                        return 51.0;
                    case LongitudinalZone.Utm40:
                        return 57.0;
                    case LongitudinalZone.Utm41:
                        return 63.0;
                    case LongitudinalZone.Utm42:
                        return 69.0;
                    case LongitudinalZone.Utm43:
                        return 75.0;
                    case LongitudinalZone.Utm44:
                        return 81.0;
                    case LongitudinalZone.Utm45:
                        return 87.0;
                    case LongitudinalZone.Utm46:
                        return 93.0;
                    case LongitudinalZone.Utm47:
                        return 99.0;
                    case LongitudinalZone.Utm48:
                        return 105.0;
                    case LongitudinalZone.Utm49:
                        return 111.0;
                    case LongitudinalZone.Utm50:
                        return 117.0;
                    case LongitudinalZone.Utm51:
                        return 123.0;
                    case LongitudinalZone.Utm52:
                        return 129.0;
                    case LongitudinalZone.Utm53:
                        return 135.0;
                    case LongitudinalZone.Utm54:
                        return 141.0;
                    case LongitudinalZone.Utm55:
                        return 147.0;
                    case LongitudinalZone.Utm56:
                        return 153.0;
                    case LongitudinalZone.Utm57:
                        return 159.0;
                    case LongitudinalZone.Utm58:
                        return 165.0;
                    case LongitudinalZone.Utm59:
                        return 171.0;
                    case LongitudinalZone.Utm60:
                        return 177.0;
                    default:
                        throw new ArgumentException("Invalid value specified for longitudinalZone.");
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetCentralMeridian()", ex);
                throw;
            }
        }

        private double GetGeometricCenter()
        {
            try
            {
                switch (_longitudinalZone)
                {
                    case LongitudinalZone.Utm01:
                        return -177.0;
                    case LongitudinalZone.Utm02:
                        return -171.0;
                    case LongitudinalZone.Utm03:
                        return -165.0;
                    case LongitudinalZone.Utm04:
                        return -159.0;
                    case LongitudinalZone.Utm05:
                        return -153.0;
                    case LongitudinalZone.Utm06:
                        return -147.0;
                    case LongitudinalZone.Utm07:
                        return -141.0;
                    case LongitudinalZone.Utm08:
                        return -135.0;
                    case LongitudinalZone.Utm09:
                        return -129.0;
                    case LongitudinalZone.Utm10:
                        return -123.0;
                    case LongitudinalZone.Utm11:
                        return -117.0;
                    case LongitudinalZone.Utm12:
                        return -111.0;
                    case LongitudinalZone.Utm13:
                        return -105.0;
                    case LongitudinalZone.Utm14:
                        return -99.0;
                    case LongitudinalZone.Utm15:
                        return -93.0;
                    case LongitudinalZone.Utm16:
                        return -87.0;
                    case LongitudinalZone.Utm17:
                        return -81.0;
                    case LongitudinalZone.Utm18:
                        return -75.0;
                    case LongitudinalZone.Utm19:
                        return -69.0;
                    case LongitudinalZone.Utm20:
                        return -63.0;
                    case LongitudinalZone.Utm21:
                        return -57.0;
                    case LongitudinalZone.Utm22:
                        return -51.0;
                    case LongitudinalZone.Utm23:
                        return -45.0;
                    case LongitudinalZone.Utm24:
                        return -39.0;
                    case LongitudinalZone.Utm25:
                        return -33.0;
                    case LongitudinalZone.Utm26:
                        return -27.0;
                    case LongitudinalZone.Utm27:
                        return -21.0;
                    case LongitudinalZone.Utm28:
                        return -15.0;
                    case LongitudinalZone.Utm29:
                        return -9.0;
                    case LongitudinalZone.Utm30:
                        return -3.0;
                    case LongitudinalZone.Utm31:
                        switch (_latitudinalZone)
                        {
                            case LatitudinalZone.UtmX:
                                return 4.5; //31X is widened by 3deg to 9deg wide making the central meridian for 31X = 4.5;
                                //Ref: http://www2.geo.uib.no/nav-processing/
                            case LatitudinalZone.UtmV:
                                return 1.5; //31V is narrowed by 3deg to 3deg wide making the central meridian for 31V = 1.5 
                                //Ref: http://www.dba-sql-server.com/sql_server_tips/t_super_sql_304_xp_gis_ll2utm.htm
                            default:
                                return 3.0;
                        }
                    case LongitudinalZone.Utm32:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 32 for Latitudinal Zone X.");
                        if (_latitudinalZone == LatitudinalZone.UtmV)
                        {
                            return 7.5; //31V is narrowed by 3deg to 3deg wide, which makes 32V widened by 3deg making it a total of 9deg wide.  half of 9deg is 4.5deg. add this to the width of 31V (3deg) and you get 7.5 for the central meridian
                            //Ref: http://www.dba-sql-server.com/sql_server_tips/t_super_sql_304_xp_gis_ll2utm.htm
                        }
                        else
                        {
                            return 9.0;
                        }
                    case LongitudinalZone.Utm33:
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 15.0; //33X is widened by 6deg to 12deg. Since 32X is removed and 31X has been widened to 9deg, 9deg + 6deg (half of 12) = 15
                            //Ref: http://www2.geo.uib.no/nav-processing/
                        }
                        return 15.0;
                    case LongitudinalZone.Utm34:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 34 for Latitudinal Zone X.");
                        return 21.0;
                    case LongitudinalZone.Utm35:
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 27.0; //35X is widened by 6deg to 12deg. Since 32X and 33X are removed and 31X and 33X have been widened so that the westmost meridian of 35X = 21, add 6 (half of 12) and you get 27 for the CM of 35X
                            //Ref: http://www2.geo.uib.no/nav-processing/
                        }
                        return 27.0;
                    case LongitudinalZone.Utm36:
                        if (_latitudinalZone == LatitudinalZone.UtmX) throw new NotSupportedException("UTM does not define a Longitudinal Zone 36 for Latitudinal Zone X.");
                        return 33.0;
                    case LongitudinalZone.Utm37:
                        if (_latitudinalZone == LatitudinalZone.UtmX)
                        {
                            return 37.5; //37X is widened by 3deg to 12deg making the westmost meridian = 33, the eastmost meridian = 42, and the cm = 37.5
                        }
                        return 39.0;
                    case LongitudinalZone.Utm38:
                        return 45.0;
                    case LongitudinalZone.Utm39:
                        return 51.0;
                    case LongitudinalZone.Utm40:
                        return 57.0;
                    case LongitudinalZone.Utm41:
                        return 63.0;
                    case LongitudinalZone.Utm42:
                        return 69.0;
                    case LongitudinalZone.Utm43:
                        return 75.0;
                    case LongitudinalZone.Utm44:
                        return 81.0;
                    case LongitudinalZone.Utm45:
                        return 87.0;
                    case LongitudinalZone.Utm46:
                        return 93.0;
                    case LongitudinalZone.Utm47:
                        return 99.0;
                    case LongitudinalZone.Utm48:
                        return 105.0;
                    case LongitudinalZone.Utm49:
                        return 111.0;
                    case LongitudinalZone.Utm50:
                        return 117.0;
                    case LongitudinalZone.Utm51:
                        return 123.0;
                    case LongitudinalZone.Utm52:
                        return 129.0;
                    case LongitudinalZone.Utm53:
                        return 135.0;
                    case LongitudinalZone.Utm54:
                        return 141.0;
                    case LongitudinalZone.Utm55:
                        return 147.0;
                    case LongitudinalZone.Utm56:
                        return 153.0;
                    case LongitudinalZone.Utm57:
                        return 159.0;
                    case LongitudinalZone.Utm58:
                        return 165.0;
                    case LongitudinalZone.Utm59:
                        return 171.0;
                    case LongitudinalZone.Utm60:
                        return 177.0;
                    default:
                        throw new ArgumentException("Invalid value specified for longitudinalZone.");
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetCentralMeridian()", ex);
                throw;
            }
        }

        private double GetReferenceLatitude()
        {
            try
            {
                switch (_latitudinalZone)
                {
                    case LatitudinalZone.UtmA:
                        throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z.");
                    case LatitudinalZone.UtmB:
                        throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z.");
                    case LatitudinalZone.UtmC:
                        return -76.0;
                    case LatitudinalZone.UtmD:
                        return -68.0;
                    case LatitudinalZone.UtmE:
                        return -60.0;
                    case LatitudinalZone.UtmF:
                        return -52.0;
                    case LatitudinalZone.UtmG:
                        return -44.0;
                    case LatitudinalZone.UtmH:
                        return -36.0;
                    case LatitudinalZone.UtmJ:
                        return -28.0;
                    case LatitudinalZone.UtmK:
                        return -20.0;
                    case LatitudinalZone.UtmL:
                        return -12.0;
                    case LatitudinalZone.UtmM:
                        return -4.0;
                    case LatitudinalZone.UtmN:
                        return 4.0;
                    case LatitudinalZone.UtmP:
                        return 12.0;
                    case LatitudinalZone.UtmQ:
                        return 20.0;
                    case LatitudinalZone.UtmR:
                        return 28.0;
                    case LatitudinalZone.UtmS:
                        return 36.0;
                    case LatitudinalZone.UtmT:
                        return 44.0;
                    case LatitudinalZone.UtmU:
                        return 52.0;
                    case LatitudinalZone.UtmV:
                        return 60.0;
                    case LatitudinalZone.UtmW:
                        return 68.0;
                    case LatitudinalZone.UtmX:
                        return 80.0;
                    case LatitudinalZone.UtmY:
                        throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z.");
                    case LatitudinalZone.UtmZ:
                        throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z.");
                    default:
                        throw new ArgumentException("Invalid value specified for latitudinalZone.");
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetReferenceLatitude()", ex);
                throw;
            }
        }

        private static LongitudinalZone GetLongitudinalZoneForLongitude(double longitude, double latitude)
        {
            try
            {
                if ((longitude >= -180.0 && longitude < -174.0) || (longitude == 180.0))
                {
                    return LongitudinalZone.Utm01;
                }
                else if (longitude >= -174.0 && longitude < -168.0)
                {
                    return LongitudinalZone.Utm02;
                }
                else if (longitude >= -168.0 && longitude < -162.0)
                {
                    return LongitudinalZone.Utm03;
                }
                else if (longitude >= -162.0 && longitude < -156.0)
                {
                    return LongitudinalZone.Utm04;
                }
                else if (longitude >= -156.0 && longitude < -150.0)
                {
                    return LongitudinalZone.Utm05;
                }
                else if (longitude >= -150.0 && longitude < -144.0)
                {
                    return LongitudinalZone.Utm06;
                }

                else if (longitude >= -144.0 && longitude < -138.0)
                {
                    return LongitudinalZone.Utm07;
                }
                else if (longitude >= -138.0 && longitude < -132.0)
                {
                    return LongitudinalZone.Utm08;
                }
                else if (longitude >= -132.0 && longitude < -126.0)
                {
                    return LongitudinalZone.Utm09;
                }
                else if (longitude >= -126.0 && longitude < -120.0)
                {
                    return LongitudinalZone.Utm10;
                }
                else if (longitude >= -120.0 && longitude < -114.0)
                {
                    return LongitudinalZone.Utm11;
                }
                else if (longitude >= -114.0 && longitude < -108.0)
                {
                    return LongitudinalZone.Utm12;
                }
                else if (longitude >= -108.0 && longitude < -102.0)
                {
                    return LongitudinalZone.Utm13;
                }
                else if (longitude >= -102.0 && longitude < -96.0)
                {
                    return LongitudinalZone.Utm14;
                }
                else if (longitude >= -96.0 && longitude < -90.0)
                {
                    return LongitudinalZone.Utm15;
                }
                else if (longitude >= -90.0 && longitude < -84.0)
                {
                    return LongitudinalZone.Utm16;
                }
                else if (longitude >= -84.0 && longitude < -78.0)
                {
                    return LongitudinalZone.Utm17;
                }
                else if (longitude >= -78.0 && longitude < -72.0)
                {
                    return LongitudinalZone.Utm18;
                }
                else if (longitude >= -72.0 && longitude < -66.0)
                {
                    return LongitudinalZone.Utm19;
                }
                else if (longitude >= -66.0 && longitude < -60.0)
                {
                    return LongitudinalZone.Utm20;
                }
                else if (longitude >= -60.0 && longitude < -54.0)
                {
                    return LongitudinalZone.Utm21;
                }
                else if (longitude >= -54.0 && longitude < -48.0)
                {
                    return LongitudinalZone.Utm22;
                }
                else if (longitude >= -48.0 && longitude < -42.0)
                {
                    return LongitudinalZone.Utm23;
                }
                else if (longitude >= -42.0 && longitude < -36.0)
                {
                    return LongitudinalZone.Utm24;
                }
                else if (longitude >= -36.0 && longitude < -30.0)
                {
                    return LongitudinalZone.Utm25;
                }
                else if (longitude >= -30.0 && longitude < -24.0)
                {
                    return LongitudinalZone.Utm26;
                }
                else if (longitude >= -24.0 && longitude < -18.0)
                {
                    return LongitudinalZone.Utm27;
                }
                else if (longitude >= -18.0 && longitude < -12.0)
                {
                    return LongitudinalZone.Utm28;
                }
                else if (longitude >= -12.0 && longitude < -6.0)
                {
                    return LongitudinalZone.Utm29;
                }
                else if (longitude >= -6.0 && longitude < 0.0)
                {
                    return LongitudinalZone.Utm30;
                }
                else if (longitude >= 0.0 && longitude < 6.0)
                {
                    //return LongitudinalZone.Utm31; 
                    // Allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm31; // 31X spans 0°-9°
                    if (latitude >= 56.0 && latitude < 64.0 && longitude >= 3.0)
                        return LongitudinalZone.Utm32; // 32V starts at 3°
                    return LongitudinalZone.Utm31;
                }
                else if (longitude >= 6.0 && longitude < 12.0)
                {
                    //return LongitudinalZone.Utm32;
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm33; // 32X doesn't exist; 33X spans 9°-21°
                    if (latitude >= 56.0 && latitude < 64.0)
                        return LongitudinalZone.Utm32; // 32V spans 3°-12°
                    return LongitudinalZone.Utm32;
                }
                else if (longitude >= 12.0 && longitude < 18.0)
                {
                    //return LongitudinalZone.Utm33; 
                    // Allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm33; // 33X spans 9°-21°
                    return LongitudinalZone.Utm33;
                }
                else if (longitude >= 18.0 && longitude < 24.0)
                {
                    //return LongitudinalZone.Utm34;
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm35; // 34X doesn't exist; 35X spans 21°-33°
                    return LongitudinalZone.Utm34;
                }
                else if (longitude >= 24.0 && longitude < 30.0)
                {
                    //return LongitudinalZone.Utm35; 
                    // Allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm35; // 35X spans 21°-33°
                    return LongitudinalZone.Utm35;
                }
                else if (longitude >= 30.0 && longitude < 36.0)
                {
                    //return LongitudinalZone.Utm36;
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm37; // 36X doesn't exist; 37X spans 33°-42°
                    return LongitudinalZone.Utm36;
                }
                else if (longitude >= 36.0 && longitude < 42.0)
                {
                    //return LongitudinalZone.Utm37; 
                    // Allow for the anomolies at 31X, 33X, 35X, 37X, 31V, & 32V
                    if (latitude >= 72.0 && latitude <= 84.0)
                        return LongitudinalZone.Utm37; // 37X spans 33°-42°
                    return LongitudinalZone.Utm37;
                }
                else if (longitude >= 42.0 && longitude < 48.0)
                {
                    return LongitudinalZone.Utm38;
                }
                else if (longitude >= 48.0 && longitude < 54.0)
                {
                    return LongitudinalZone.Utm39;
                }
                else if (longitude >= 54.0 && longitude < 60.0)
                {
                    return LongitudinalZone.Utm40;
                }
                else if (longitude >= 60.0 && longitude < 66.0)
                {
                    return LongitudinalZone.Utm41;
                }
                else if (longitude >= 66.0 && longitude < 72.0)
                {
                    return LongitudinalZone.Utm42;
                }
                else if (longitude >= 72.0 && longitude < 78.0)
                {
                    return LongitudinalZone.Utm43;
                }
                else if (longitude >= 78.0 && longitude < 84.0)
                {
                    return LongitudinalZone.Utm44;
                }
                else if (longitude >= 84.0 && longitude < 90.0)
                {
                    return LongitudinalZone.Utm45;
                }
                else if (longitude >= 90.0 && longitude < 96.0)
                {
                    return LongitudinalZone.Utm46;
                }
                else if (longitude >= 96.0 && longitude < 102.0)
                {
                    return LongitudinalZone.Utm47;
                }
                else if (longitude >= 102.0 && longitude < 108.0)
                {
                    return LongitudinalZone.Utm48;
                }
                else if (longitude >= 108.0 && longitude < 114.0)
                {
                    return LongitudinalZone.Utm49;
                }
                else if (longitude >= 114.0 && longitude < 120.0)
                {
                    return LongitudinalZone.Utm50;
                }
                else if (longitude >= 120.0 && longitude < 126.0)
                {
                    return LongitudinalZone.Utm51;
                }
                else if (longitude >= 126.0 && longitude < 132.0)
                {
                    return LongitudinalZone.Utm52;
                }
                else if (longitude >= 132 && longitude < 138.0)
                {
                    return LongitudinalZone.Utm53;
                }
                else if (longitude >= 138.0 && longitude < 144.0)
                {
                    return LongitudinalZone.Utm54;
                }
                else if (longitude >= 144 && longitude < 150.0)
                {
                    return LongitudinalZone.Utm55;
                }
                else if (longitude >= 150.0 && longitude < 156.0)
                {
                    return LongitudinalZone.Utm56;
                }
                else if (longitude >= 156.0 && longitude < 162.0)
                {
                    return LongitudinalZone.Utm57;
                }
                else if (longitude >= 162.0 && longitude < 168.0)
                {
                    return LongitudinalZone.Utm58;
                }
                else if (longitude >= 168.0 && longitude < 174.0)
                {
                    return LongitudinalZone.Utm59;
                }
                else if (longitude >= 174.0 && longitude < 180.0)
                {
                    return LongitudinalZone.Utm60;
                }
                else
                {
                    throw new ArgumentException("LongitudinalZone is out of range.");
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetLongitudinalZoneForLongitude(double, double)", ex);
                throw;
            }
        }

        private static LatitudinalZone GetLatitudinalZoneForLatitude(double latitude)
        {
            try
            {
                if (latitude >= -90.0 && latitude < -80.0)
                {
                    throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z (-90 through -80 and 84 through 90 degrees).");
                }
                else if (latitude >= -80.0 && latitude < -72.0)
                {
                    return LatitudinalZone.UtmC;
                }
                else if (latitude >= -72.0 && latitude < -64.0)
                {
                    return LatitudinalZone.UtmD;
                }
                else if (latitude >= -64.0 && latitude < -56.0)
                {
                    return LatitudinalZone.UtmE;
                }
                else if (latitude >= -56.0 && latitude < -48.0)
                {
                    return LatitudinalZone.UtmF;
                }
                else if (latitude >= -48.0 && latitude < -40.0)
                {
                    return LatitudinalZone.UtmG;
                }
                else if (latitude >= -40.0 && latitude < -32.0)
                {
                    return LatitudinalZone.UtmH;
                }
                else if (latitude >= -32.0 && latitude < -24.0)
                {
                    return LatitudinalZone.UtmJ;
                }
                else if (latitude >= -24.0 && latitude < -16.0)
                {
                    return LatitudinalZone.UtmK;
                }
                else if (latitude >= -16.0 && latitude < -8.0)
                {
                    return LatitudinalZone.UtmL;
                }
                else if (latitude >= -8.0 && latitude < 0.0)
                {
                    return LatitudinalZone.UtmM;
                }
                else if (latitude >= 0.0 && latitude < 8.0)
                {
                    return LatitudinalZone.UtmN;
                }
                else if (latitude >= 8.0 && latitude < 16.0)
                {
                    return LatitudinalZone.UtmP;
                }
                else if (latitude >= 16.0 && latitude < 24.0)
                {
                    return LatitudinalZone.UtmQ;
                }
                else if (latitude >= 24.0 && latitude < 32.0)
                {
                    return LatitudinalZone.UtmR;
                }
                else if (latitude >= 32.0 && latitude < 40.0)
                {
                    return LatitudinalZone.UtmS;
                }
                else if (latitude >= 40.0 && latitude < 48.0)
                {
                    return LatitudinalZone.UtmT;
                }
                else if (latitude >= 48.0 && latitude < 56.0)
                {
                    return LatitudinalZone.UtmU;
                }
                else if (latitude >= 56.0 && latitude < 64.0)
                {
                    return LatitudinalZone.UtmV;
                }
                else if (latitude >= 64.0 && latitude < 72.0)
                {
                    return LatitudinalZone.UtmW;
                }
                else if (latitude >= 72.0 && latitude <= 84.0)
                {
                    return LatitudinalZone.UtmX;
                }
                else if (latitude > 84.0 && latitude <= 90.0)
                {
                    throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z (-90 through -80 and 84 through 90 degrees).");
                }
                else
                {
                    throw new ArgumentException(latitude.ToString(CultureInfo.InvariantCulture) + " is an invalid latitudinal value.");
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetLatitudinalZoneForLatitude(double)", ex);
                throw;
            }
        }

        private static LongitudinalZone GetLongitudinalZoneFromLongitudinalZoneString(string lonZone)
        {
            ArgumentNullException.ThrowIfNull(lonZone);

            try
            {
                switch (lonZone)
                {
                    case "1":
                        return LongitudinalZone.Utm01;
                    case "2":
                        return LongitudinalZone.Utm02;
                    case "3":
                        return LongitudinalZone.Utm03;
                    case "4":
                        return LongitudinalZone.Utm04;
                    case "5":
                        return LongitudinalZone.Utm05;
                    case "6":
                        return LongitudinalZone.Utm06;
                    case "7":
                        return LongitudinalZone.Utm07;
                    case "8":
                        return LongitudinalZone.Utm08;
                    case "9":
                        return LongitudinalZone.Utm09;

                    case "10":
                        return LongitudinalZone.Utm10;
                    case "11":
                        return LongitudinalZone.Utm11;
                    case "12":
                        return LongitudinalZone.Utm12;
                    case "13":
                        return LongitudinalZone.Utm13;
                    case "14":
                        return LongitudinalZone.Utm14;
                    case "15":
                        return LongitudinalZone.Utm15;
                    case "16":
                        return LongitudinalZone.Utm16;
                    case "17":
                        return LongitudinalZone.Utm17;
                    case "18":
                        return LongitudinalZone.Utm18;
                    case "19":
                        return LongitudinalZone.Utm19;

                    case "20":
                        return LongitudinalZone.Utm20;
                    case "21":
                        return LongitudinalZone.Utm21;
                    case "22":
                        return LongitudinalZone.Utm22;
                    case "23":
                        return LongitudinalZone.Utm23;
                    case "24":
                        return LongitudinalZone.Utm24;
                    case "25":
                        return LongitudinalZone.Utm25;
                    case "26":
                        return LongitudinalZone.Utm26;
                    case "27":
                        return LongitudinalZone.Utm27;
                    case "28":
                        return LongitudinalZone.Utm28;
                    case "29":
                        return LongitudinalZone.Utm29;

                    case "30":
                        return LongitudinalZone.Utm30;
                    case "31":
                        return LongitudinalZone.Utm31;
                    case "32":
                        return LongitudinalZone.Utm32;
                    case "33":
                        return LongitudinalZone.Utm33;
                    case "34":
                        return LongitudinalZone.Utm34;
                    case "35":
                        return LongitudinalZone.Utm35;
                    case "36":
                        return LongitudinalZone.Utm36;
                    case "37":
                        return LongitudinalZone.Utm37;
                    case "38":
                        return LongitudinalZone.Utm38;
                    case "39":
                        return LongitudinalZone.Utm39;

                    case "40":
                        return LongitudinalZone.Utm40;
                    case "41":
                        return LongitudinalZone.Utm41;
                    case "42":
                        return LongitudinalZone.Utm42;
                    case "43":
                        return LongitudinalZone.Utm43;
                    case "44":
                        return LongitudinalZone.Utm44;
                    case "45":
                        return LongitudinalZone.Utm45;
                    case "46":
                        return LongitudinalZone.Utm46;
                    case "47":
                        return LongitudinalZone.Utm47;
                    case "48":
                        return LongitudinalZone.Utm48;
                    case "49":
                        return LongitudinalZone.Utm49;

                    case "50":
                        return LongitudinalZone.Utm50;
                    case "51":
                        return LongitudinalZone.Utm51;
                    case "52":
                        return LongitudinalZone.Utm52;
                    case "53":
                        return LongitudinalZone.Utm53;
                    case "54":
                        return LongitudinalZone.Utm54;
                    case "55":
                        return LongitudinalZone.Utm55;
                    case "56":
                        return LongitudinalZone.Utm56;
                    case "57":
                        return LongitudinalZone.Utm57;
                    case "58":
                        return LongitudinalZone.Utm58;
                    case "59":
                        return LongitudinalZone.Utm59;

                    case "60":
                        return LongitudinalZone.Utm60;

                    default:
                        throw new FormatException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmNsZone.GetLongitudinalZoneFromLongitudinalZoneString(string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the LatitudinalZone enumeration that matches up with the given string.
        /// </summary>
        /// <param name="latZone">The string representation of the zone.</param>
        /// <returns>The LatitudinalZone enumeration that matches up with the given string.</returns>
        /// <remarks>
        /// latZone shoule be one of {"A" ... "Z"} (excepting "I" and "O").  Case is ignored.
        /// In any other case, a FormatException is thrown.
        /// </remarks>
        /// <exception cref="FormatException">Thrown on an invalid combination of ns and latZone as described in the remarks section.</exception>
        private static LatitudinalZone GetLatitudinalZoneFromLatitudinalZoneString(string latZone)
        {
            ArgumentNullException.ThrowIfNull(latZone);

            try
            {
                switch (latZone.ToUpper(CultureInfo.InvariantCulture))
                {
                    case "A":
                        return LatitudinalZone.UtmA;
                    case "B":
                        return LatitudinalZone.UtmB;
                    case "C":
                        return LatitudinalZone.UtmC;
                    case "D":
                        return LatitudinalZone.UtmD;
                    case "E":
                        return LatitudinalZone.UtmE;
                    case "F":
                        return LatitudinalZone.UtmF;
                    case "G":
                        return LatitudinalZone.UtmG;
                    case "H":
                        return LatitudinalZone.UtmH;
                    case "J":
                        return LatitudinalZone.UtmJ;
                    case "K":
                        return LatitudinalZone.UtmK;
                    case "L":
                        return LatitudinalZone.UtmL;
                    case "M":
                        return LatitudinalZone.UtmM;
                    case "N":
                        return LatitudinalZone.UtmN;
                    case "P":
                        return LatitudinalZone.UtmP;
                    case "Q":
                        return LatitudinalZone.UtmQ;
                    case "R":
                        return LatitudinalZone.UtmR;
                    case "S":
                        return LatitudinalZone.UtmS;
                    case "T":
                        return LatitudinalZone.UtmT;
                    case "U":
                        return LatitudinalZone.UtmU;
                    case "V":
                        return LatitudinalZone.UtmV;
                    case "W":
                        return LatitudinalZone.UtmW;
                    case "X":
                        return LatitudinalZone.UtmX;
                    case "Y":
                        return LatitudinalZone.UtmY;
                    case "Z":
                        return LatitudinalZone.UtmZ;
                    default:
                        throw new FormatException();
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "UtmZone.GetLatitudinalZoneFromLatitudinalZoneString(string)", ex);
                throw;
            }
        }

        #endregion
    }
}


