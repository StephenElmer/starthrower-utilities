// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities.Zones.UtmNs
{
    /// <summary>
    /// The concrete implementation of the Zone base class for UTM.
    /// This particular variation supports UTM zones 1 thru 60 longitudinally
    /// and zones North and South latitudinally.  For usage of  latitudinal
    /// zones A thru Z, use the <see cref="Utm.UtmZone"/> class.
    /// </summary>
    public class UtmNsZone : Zone
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

        /// <summary>
        /// Gets the Central Meridian used for the TransverseMercator projection calculation.
        /// </summary>
        public override double CentralMeridian
        {
            get { return GetCentralMeridian(); }
        }

        /// <summary>
        /// Gets the geometric center of the zone's actual boundary extent. Always equal to
        /// <see cref="CentralMeridian"/>, since <see cref="UtmNsZone"/> has no special
        /// (Norway/Svalbard) zones.
        /// </summary>
        // GeometricCenter == CentralMeridian for UtmNsZone since it has no special zones
        public override double GeometricCenter
        {
            get { return GetCentralMeridian(); }
        }

        /// <summary>
        /// Gets the value of the Reference yLat associated with the zone.
        /// In this case of the UtmNsZone which only has North and South
        /// Latitudinal zones, zero (0.0) is always returned.
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
        /// Gets whether or not the UtmNsZone lies within the Southern Hemisphere.
        /// Returns true if the LatitudinalZone is South;
        /// false, if otherwise.
        /// </summary>
        public override bool IsSouthernHemisphere
        {
            get { return _latitudinalZone == LatitudinalZone.South; }
        }

        /// <summary>
        /// Gets the standard string designation of this zone (e.g. "31N"), combining the
        /// numeric longitudinal zone and the "North"/"South" latitudinal zone with their
        /// "Utm" prefixes stripped.
        /// </summary>
        public override string ZoneString
        {
            get
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
        }

        #endregion


        #region Construction

        /// <summary>
        /// Initializes a new instance of <see cref="UtmNsZone"/> from explicit longitudinal and latitudinal zone values.
        /// </summary>
        /// <param name="longitudinalZone">The longitudinal (numeric) zone.</param>
        /// <param name="latitudinalZone">The latitudinal (North/South) zone.</param>
        public UtmNsZone(LongitudinalZone longitudinalZone, LatitudinalZone latitudinalZone)
        {
            _longitudinalZone = longitudinalZone;
            _latitudinalZone = latitudinalZone;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="UtmNsZone"/> by determining the longitudinal
        /// zone and hemisphere that contain the given coordinate.
        /// </summary>
        /// <param name="longitude">The longitude, in degrees, used to determine the longitudinal zone.</param>
        /// <param name="latitude">The latitude, in degrees, used to determine the hemisphere.</param>
        public UtmNsZone(double longitude, double latitude)
        {
            _longitudinalZone = GetLongitudinalZoneForLongitude(longitude, latitude);
            _latitudinalZone = GetLatitudinalZoneForLatitude(latitude);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="UtmNsZone"/> by parsing a combined zone
        /// string (e.g. "31North").
        /// </summary>
        /// <param name="zone">The combined numeric longitudinal zone and North/South designation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="zone"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="zone"/> is shorter than 2 characters.</exception>
        /// <exception cref="FormatException"><paramref name="zone"/> is not a recognized zone designation.</exception>
        public UtmNsZone(string zone)
        {
            ArgumentNullException.ThrowIfNull(zone);
            if (zone.Length < 2) throw new ArgumentException("invalid zone", nameof(zone));

            int longitudinalZone = 0;
            if (int.TryParse(zone.AsSpan(0, 2), out longitudinalZone))
            {
                _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone.ToString(CultureInfo.InvariantCulture));
            }
            else if (int.TryParse(zone.AsSpan(0, 1), out longitudinalZone))
            {
                _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                throw new FormatException();
            }


            int stub = 0;
            string? latitudinalZone = null;
            if (int.TryParse(zone.AsSpan(0, 2), out stub))
            {
                latitudinalZone = zone.Substring(2);
                _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
            }
            else if (int.TryParse(zone.AsSpan(0, 1), out stub))
            {
                latitudinalZone = zone.Substring(1);
                _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
            }
            else
            {
                throw new FormatException();
            }

        }

        /// <summary>
        /// Initializes a new instance of <see cref="UtmNsZone"/> from separate longitudinal and
        /// latitudinal zone strings.
        /// </summary>
        /// <param name="longitudinalZone">The numeric longitudinal zone designation (e.g. "31").</param>
        /// <param name="latitudinalZone">The North/South designation.</param>
        /// <exception cref="ArgumentNullException"><paramref name="longitudinalZone"/> or <paramref name="latitudinalZone"/> is <see langword="null"/>.</exception>
        /// <exception cref="FormatException"><paramref name="longitudinalZone"/> or <paramref name="latitudinalZone"/> is not a recognized zone designation.</exception>
        public UtmNsZone(string longitudinalZone, string latitudinalZone)
        {
            _longitudinalZone = GetLongitudinalZoneFromLongitudinalZoneString(longitudinalZone);
            _latitudinalZone = GetLatitudinalZoneFromLatitudinalZoneString(latitudinalZone);
        }

        #endregion


        #region Private Methods

        private double GetCentralMeridian()
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
                    return 3.0;
                case LongitudinalZone.Utm32:
                    return 9.0;
                case LongitudinalZone.Utm33:
                    return 15.0;
                case LongitudinalZone.Utm34:
                    return 21.0;
                case LongitudinalZone.Utm35:
                    return 27.0;
                case LongitudinalZone.Utm36:
                    return 33.0;
                case LongitudinalZone.Utm37:
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

        private static double GetReferenceLatitude()
        {
            return 0.0;
        }

        private static LongitudinalZone GetLongitudinalZoneForLongitude(double longitude, double latitude)
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
                return LongitudinalZone.Utm31;
            }
            else if (longitude >= 6.0 && longitude < 12.0)
            {
                return LongitudinalZone.Utm32;
            }
            else if (longitude >= 12.0 && longitude < 18.0)
            {
                return LongitudinalZone.Utm33;
            }
            else if (longitude >= 18.0 && longitude < 24.0)
            {
                return LongitudinalZone.Utm34;
            }
            else if (longitude >= 24.0 && longitude < 30.0)
            {
                return LongitudinalZone.Utm35;
            }
            else if (longitude >= 30.0 && longitude < 36.0)
            {
                return LongitudinalZone.Utm36;
            }
            else if (longitude >= 36.0 && longitude < 42.0)
            {
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

        /// <summary>
        /// Gets the LatitudinalZone enumeration value (North or South) that contains the given latitude.
        /// </summary>
        /// <param name="latitude">The latitude, in degrees, to find the LatitudinalZone for.</param>
        /// <returns>The LatitudinalZone that contains <paramref name="latitude"/>.</returns>
        /// <exception cref="NotImplementedException">
        /// Thrown for latitudes in the ranges -90 through -80 and 84 through 90 degrees,
        /// which correspond to UTM Latitudinal Zones A, B, Y, or Z. These fall outside the
        /// boundary of the normal UTM projection and are not yet supported.
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="latitude"/> is outside the valid range of -90 through 90 degrees.</exception>
        //TODO: #39 — UTM Latitudinal Zones A, B, Y, Z are unimplemented
        private static LatitudinalZone GetLatitudinalZoneForLatitude(double latitude)
        {
            if (latitude >= -90.0 && latitude < -80.0)
            {
                throw new NotImplementedException("StarThrower Utilities do not yet support UTM Latitudinal Zones A, B, Y, or Z (-90 through -80 and 84 through 90 degrees).");
            }
            else if (latitude >= -80.0 && latitude < 0.0)
            {
                return LatitudinalZone.South;
            }
            else if (latitude >= 0.0 && latitude <= 84.0)
            {
                return LatitudinalZone.North;
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

        private static LongitudinalZone GetLongitudinalZoneFromLongitudinalZoneString(string lonZone)
        {
            ArgumentNullException.ThrowIfNull(lonZone);

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

        /// <summary>
        /// Gets the LatitudinalZone enumeration that matches up with the given string.
        /// </summary>
        /// <param name="latZone">The string representation of the zone.</param>
        /// <returns>The LatitudinalZone enumeration that matches up with the given string.</returns>
        /// <remarks>
        /// latZone should be one of {"NORTH", "N", "SOUTH", "S"}.  The comparison is case-insensitive.
        /// In any other case, a FormatException is thrown.
        /// </remarks>
        /// <exception cref="FormatException">Thrown on an invalid combination of ns and latZone as described in the remarks section.</exception>
        private static LatitudinalZone GetLatitudinalZoneFromLatitudinalZoneString(string latZone)
        {
            ArgumentNullException.ThrowIfNull(latZone);

            switch (latZone.ToUpper(CultureInfo.InvariantCulture))
            {
                case "NORTH":
                case "N":
                    return LatitudinalZone.North;
                case "SOUTH":
                case "S":
                    return LatitudinalZone.South;
                default:
                    throw new FormatException();
            }
        }

        #endregion
    }
}


