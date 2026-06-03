/***********************************************************************************
    StarThrower Utilities / Gis.EsriLibrary
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
using System.IO;
using System.Text;
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;
using UtmZones = StarThrower.Gis.GeoUtilities.Zones.Utm;
using UtmNsZones = StarThrower.Gis.GeoUtilities.Zones.UtmNs;

namespace StarThrower.Gis.EsriLibrary.Internal
{
    internal sealed class ProjectionFile : IDisposable
    {
        #region Private Member Variables

        private FileStream? _stream;
        private IProjectedCoordinateSystem? _cs;

        #endregion


        #region Internal Properties

        internal ICoordinateSystem? CoordinateSystem
        {
            get { return _cs; }
        }

        #endregion


        #region Construction

        internal ProjectionFile() { }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }
        }

        #endregion


        #region Private Methods

        private static void GetEsriNamesFromCoordinateSystem(IProjectedCoordinateSystem pcs, ref string projcs, ref string geogcs, ref string datum, ref double equatorialRadius, ref double inverseFlattening, ref string spheroid, ref string primeem, ref double primeemValue, ref string angularUnit, ref double angularUnitValue, ref string linearUnit, ref double linearUnitValue, ref string projection, ref string[] parameters, ref double[] parameterValues)
        {
            string pcsType = pcs.GetType().Name;
            if (pcsType.CompareTo(typeof(Bng).Name) == 0)
            {
                throw new NotImplementedException();
            }
            //TODO: 
            //else if (String.Compare(pcsType, typeof(UTM_WGS72).Name) == 0)
            //{
            //    throw new NotImplementedException();
            //}
            //else if (String.Compare(pcsType, typeof(UTM_WGS84).Name) == 0)
            //{
            //    throw new NotImplementedException();
            //}
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static IProjectedCoordinateSystem GetCoordinateSystemFromEsriName(string esriName)
        {
            switch (esriName)
            {
                case ProjectedCoordinateSystems.British_National_Grid:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(Bng));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_1N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_1S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_2N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_2S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_3N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_3S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_4N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_4S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_5N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_5S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_6N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_6S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_7N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_7S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_8N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_8S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_9N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_9S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_10N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_10S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_11N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_11S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_12N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_12S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_13N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_13S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_14N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_14S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_15N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_15S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_16N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_16S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_17N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_17S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_18N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_18S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_19N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_19S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_20N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_20S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_21N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_21S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_22N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_22S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_23N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_23S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_24N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_24S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_25N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_25S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_26N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_26S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_27N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_27S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_28N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_28S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_29N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_29S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_30N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_30S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_31N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_31S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_32N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_32S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_33N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_33S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_34N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_34S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_35N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_35S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_36N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_36S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_37N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_37S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_38N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_38S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_39N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm39, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_39S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm39, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_40N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm40, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_40S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm40, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_41N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_41S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_42N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_42S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_43N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_43S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_44N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_44S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_45N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_45S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_46N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_46S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_47N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_47S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_48N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_48S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_49N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_49S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_50N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_50S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_51N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_51S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_52N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_52S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_53N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_53S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_54N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_54S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_55N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_55S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_56N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_56S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_57N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_57S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_58N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_58S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_59N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_59S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_60N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1972_UTM_Zone_60S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs72Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_1N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_1S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm01, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_2N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_2S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm02, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_3N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_3S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm03, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_4N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_4S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm04, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_5N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_5S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm05, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_6N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_6S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm06, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_7N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_7S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm07, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_8N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_8S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm08, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_9N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_9S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm09, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_10N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_10S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm10, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_11N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_11S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm11, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_12N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_12S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm12, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_13N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_13S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm13, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_14N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_14S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm14, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_15N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_15S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm15, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_16N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_16S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm16, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_17N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_17S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm17, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_18N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_18S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm18, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_19N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_19S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm19, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_20N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_20S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm20, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_21N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_21S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm21, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_22N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_22S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm22, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_23N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_23S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm23, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_24N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_24S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm24, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_25N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_25S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm25, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_26N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_26S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm26, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_27N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_27S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm27, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_28N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_28S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm28, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_29N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_29S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm29, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_30N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_30S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm30, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_31N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_31S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm31, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_32N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_32S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm32, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_33N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_33S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm33, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_34N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_34S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm34, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_35N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_35S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm35, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_36N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_36S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm36, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_37N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_37S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm37, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_38N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_38S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm38, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_39N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm39, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_39S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm39, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_40N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm40, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_40S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm40, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_41N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_41S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm41, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_42N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_42S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm42, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_43N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_43S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm43, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_44N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_44S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm44, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_45N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_45S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm45, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_46N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_46S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm46, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_47N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_47S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm47, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_48N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_48S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm48, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_49N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_49S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm49, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_50N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_50S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm50, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_51N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_51S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm51, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_52N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_52S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm52, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_53N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_53S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm53, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_54N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_54S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm54, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_55N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_55S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm55, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_56N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_56S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm56, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_57N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_57S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm57, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_58N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_58S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm58, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_59N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_59S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm59, UtmNsZones.LatitudinalZone.South));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_60N:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.North));
                case ProjectedCoordinateSystems.WGS_1984_UTM_Zone_60S:
                    return ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84Ns), new UtmNsZones.UtmNsZone(UtmNsZones.LongitudinalZone.Utm60, UtmNsZones.LatitudinalZone.South));
                default:
                    throw new NotSupportedException();
            }
        }

        private void ParseDataString(string data)
        {
            if (!data.Contains("PROJCS[\"")) throw new Exception("Invalid Projection File: could not find PROJCS tag.");
            if (!data.Contains("\"GEOGCS[")) throw new Exception("Invalid Projection File: could not find GEOGCS tag.");
            int startIndex = 8; //index of first character after PROJCS"
            int stopIndex = data.IndexOf("\"GEOGCS[", StringComparison.Ordinal);
            string projectedCoordinateSystemName = data.Substring(startIndex, stopIndex - startIndex);
            _cs = GetCoordinateSystemFromEsriName(projectedCoordinateSystemName);
        }

        private string CreateDataString()
        {
            string projcs = string.Empty;
            string geogcs = string.Empty;
            string datum = string.Empty;
            double equatorialRadius = 0.0;
            double inverseFlattening = 0.0;
            string spheroid = string.Empty;
            string primeem = string.Empty;
            double primeemValue = 0.0;
            string angularUnit = string.Empty;
            double angularUnitValue = 0.0;
            string linearUnit = string.Empty;
            double linearUnitValue = 0.0;
            string projection = string.Empty;
            string[] parameters = [];
            double[] parameterValues = [];

            GetEsriNamesFromCoordinateSystem(_cs ?? throw new InvalidOperationException("Coordinate system not set."), ref projcs, ref geogcs, ref datum, ref equatorialRadius, ref inverseFlattening, ref spheroid, ref primeem, ref primeemValue, ref angularUnit, ref angularUnitValue, ref linearUnit, ref linearUnitValue, ref projection, ref parameters, ref parameterValues);

            StringBuilder result = new StringBuilder(String.Empty);
            result.Append("PROJCS");
            result.Append('[');
            result.Append("\"" + projcs + "\",");
            result.Append("GEOGCS");
            result.Append('[');
            result.Append("\"" + geogcs + "\",");
            result.Append("DATUM");
            result.Append('[');
            result.Append("\"" + datum + "\",");
            result.Append("SPHEROID");
            result.Append('[');
            result.Append("\"" + datum + "\",");
            result.Append(equatorialRadius.ToString(CultureInfo.InvariantCulture) + ",");
            result.Append(inverseFlattening.ToString(CultureInfo.InvariantCulture) + ",");
            result.Append(']');
            result.Append("],");
            result.Append("PRIMEEM");
            result.Append('[');
            result.Append("\"" + primeem + "\",");
            result.Append(primeemValue.ToString(CultureInfo.InvariantCulture));
            result.Append("],");
            result.Append("UNIT");
            result.Append('[');
            result.Append("\"" + angularUnit + "\",");
            result.Append(angularUnitValue.ToString(CultureInfo.InvariantCulture));
            result.Append("],");
            result.Append("],");

            result.Append("PROJECTION");
            result.Append('[');
            result.Append("\"" + projection + "\",");
            result.Append("],");

            for (int i = 0; i < parameters.Length; i++)
            {
                result.Append("PARAMETER");
                result.Append('[');
                result.Append("\"" + parameters[i] + "\",");
                result.Append(parameterValues[i].ToString(CultureInfo.InvariantCulture));
                result.Append("],");
            }

            result.Append("UNIT");
            result.Append('[');
            result.Append("\"" + linearUnit + "\",");
            result.Append(linearUnitValue.ToString(CultureInfo.InvariantCulture));
            result.Append("],");

            result.Append(']');

            return result.ToString();
        }

        private void Read()
        {
            if (_stream == null) throw new InvalidOperationException("Stream has not been opened.");
            if (!_stream.CanRead) throw new IOException("Stream is not in a readable mode.");

            _stream.Seek(0, SeekOrigin.Begin);
            StringBuilder data = new StringBuilder(String.Empty);
            using (StreamReader sr = new StreamReader(_stream))
            {
                string? buf;
                while ((buf = sr.ReadLine()) != null)
                {
                    data.Append(buf);
                }
            }

            ParseDataString(data.ToString());
        }

        #endregion


        #region Internal Methods

        internal void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            _stream = new FileStream(fileName, fileMode, fileAccess);
            Read();
        }

        internal void Open(string fileName, FileMode fileMode, FileAccess fileAccess, FileShare fileShare)
        {
            _stream = new FileStream(fileName, fileMode, fileAccess, fileShare);
            Read();
        }

        /// <summary>
        /// Closes the file without saving
        /// </summary>
        internal void Close()
        {
            if (_stream != null)
            {
                _stream.Close();
            }
        }

        /// <summary>
        /// Closes the file taking a boolean parameter
        /// which indicates whether the file should be saved or not
        /// </summary>
        /// <param name="save"></param>
        internal void Close(bool save)
        {
            if (save)
            {
                Save();
            }
            _stream?.Close();
        }

        internal void Save()
        {
            if (_stream == null) throw new InvalidOperationException("FileStream has not yet been assigned.");

            //using (StreamWriter sw = new StreamWriter(_stream, false))
            //{
            //    sw.WriteLine(CreateDataString());
            //}
        }

        internal void SaveAs(string fileName)
        {
            if (_stream != null)
            {
                if (_stream.Name.Equals(fileName, StringComparison.Ordinal))
                {
                    this.Save();
                }
                else
                {
                    //Close the current stream
                    if (_stream != null)
                    {
                        _stream.Close();
                        _stream.Dispose();
                        _stream = null;
                    }

                    //Create a new stream
                    if (File.Exists(fileName)) File.Delete(fileName);
                    _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                    //Write the contents of this data structure to the new stream
                    this.Save();
                }
            }
            else
            {
                //Create a new stream
                if (File.Exists(fileName)) File.Delete(fileName);
                _stream = new FileStream(fileName, FileMode.CreateNew, FileAccess.ReadWrite);

                //Write the contents of this data structure to the new stream
                this.Save();
            }
        }

        internal string ToXml()
        {
            StringBuilder result = new StringBuilder(String.Empty);
            if (_cs != null)
            {
                result.AppendLine("<projectionFile>");
                result.Append(_cs.ToXml());
                result.AppendLine("</projectionFile>");
            }
            else
            {
                result.AppendLine("<projectionFile/>");
            }
            return result.ToString();
        }

        #endregion
    }
}
