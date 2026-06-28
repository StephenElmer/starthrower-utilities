// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;

namespace StarThrower.Gis.GeoUtilities.Zones.Utm
{
    /// <summary>
    /// An enumeration of Longitudinal UTM Zones 1 thru 60. Each zone is 6 degrees of
    /// longitude wide, except for the Norway/Svalbard anomaly zones (31V, 32V, 31X, 33X,
    /// 35X, 37X), whose effective widths are adjusted as described on <see cref="UtmZone"/>.
    /// </summary>
    public enum LongitudinalZone
    {
        /// <summary>No longitudinal zone has been assigned.</summary>
        Undefined = 0,
        /// <summary>Spans 180°W to 174°W.</summary>
        Utm01 = 1,
        /// <summary>Spans 174°W to 168°W.</summary>
        Utm02 = 2,
        /// <summary>Spans 168°W to 162°W.</summary>
        Utm03 = 3,
        /// <summary>Spans 162°W to 156°W.</summary>
        Utm04 = 4,
        /// <summary>Spans 156°W to 150°W.</summary>
        Utm05 = 5,
        /// <summary>Spans 150°W to 144°W.</summary>
        Utm06 = 6,
        /// <summary>Spans 144°W to 138°W.</summary>
        Utm07 = 7,
        /// <summary>Spans 138°W to 132°W.</summary>
        Utm08 = 8,
        /// <summary>Spans 132°W to 126°W.</summary>
        Utm09 = 9,
        /// <summary>Spans 126°W to 120°W.</summary>
        Utm10 = 10,
        /// <summary>Spans 120°W to 114°W.</summary>
        Utm11 = 11,
        /// <summary>Spans 114°W to 108°W.</summary>
        Utm12 = 12,
        /// <summary>Spans 108°W to 102°W.</summary>
        Utm13 = 13,
        /// <summary>Spans 102°W to 96°W.</summary>
        Utm14 = 14,
        /// <summary>Spans 96°W to 90°W.</summary>
        Utm15 = 15,
        /// <summary>Spans 90°W to 84°W.</summary>
        Utm16 = 16,
        /// <summary>Spans 84°W to 78°W.</summary>
        Utm17 = 17,
        /// <summary>Spans 78°W to 72°W.</summary>
        Utm18 = 18,
        /// <summary>Spans 72°W to 66°W.</summary>
        Utm19 = 19,
        /// <summary>Spans 66°W to 60°W.</summary>
        Utm20 = 20,
        /// <summary>Spans 60°W to 54°W.</summary>
        Utm21 = 21,
        /// <summary>Spans 54°W to 48°W.</summary>
        Utm22 = 22,
        /// <summary>Spans 48°W to 42°W.</summary>
        Utm23 = 23,
        /// <summary>Spans 42°W to 36°W.</summary>
        Utm24 = 24,
        /// <summary>Spans 36°W to 30°W.</summary>
        Utm25 = 25,
        /// <summary>Spans 30°W to 24°W.</summary>
        Utm26 = 26,
        /// <summary>Spans 24°W to 18°W.</summary>
        Utm27 = 27,
        /// <summary>Spans 18°W to 12°W.</summary>
        Utm28 = 28,
        /// <summary>Spans 12°W to 6°W.</summary>
        Utm29 = 29,
        /// <summary>Spans 6°W to 0°.</summary>
        Utm30 = 30,
        /// <summary>
        /// Spans 0° to 6°E. Narrowed to 0°-3°E within Latitudinal Zone V (Norway anomaly);
        /// widened to 0°-9°E within Latitudinal Zone X (Svalbard anomaly, replacing 32X).
        /// </summary>
        Utm31 = 31,
        /// <summary>
        /// Spans 6°E to 12°E. Widened to 3°-12°E within Latitudinal Zone V (Norway anomaly).
        /// Does not exist within Latitudinal Zone X (Svalbard anomaly; absorbed into 31X).
        /// </summary>
        Utm32 = 32,
        /// <summary>
        /// Spans 12°E to 18°E. Widened to 9°-21°E within Latitudinal Zone X (Svalbard
        /// anomaly, replacing 32X).
        /// </summary>
        Utm33 = 33,
        /// <summary>
        /// Spans 18°E to 24°E. Does not exist within Latitudinal Zone X (Svalbard anomaly;
        /// absorbed into 33X).
        /// </summary>
        Utm34 = 34,
        /// <summary>
        /// Spans 24°E to 30°E. Widened to 21°-33°E within Latitudinal Zone X (Svalbard
        /// anomaly, replacing 34X).
        /// </summary>
        Utm35 = 35,
        /// <summary>
        /// Spans 30°E to 36°E. Does not exist within Latitudinal Zone X (Svalbard anomaly;
        /// absorbed into 35X).
        /// </summary>
        Utm36 = 36,
        /// <summary>
        /// Spans 36°E to 42°E. Widened to 33°-42°E within Latitudinal Zone X (Svalbard
        /// anomaly, replacing 36X).
        /// </summary>
        Utm37 = 37,
        /// <summary>Spans 42°E to 48°E.</summary>
        Utm38 = 38,
        /// <summary>Spans 48°E to 54°E.</summary>
        Utm39 = 39,
        /// <summary>Spans 54°E to 60°E.</summary>
        Utm40 = 40,
        /// <summary>Spans 60°E to 66°E.</summary>
        Utm41 = 41,
        /// <summary>Spans 66°E to 72°E.</summary>
        Utm42 = 42,
        /// <summary>Spans 72°E to 78°E.</summary>
        Utm43 = 43,
        /// <summary>Spans 78°E to 84°E.</summary>
        Utm44 = 44,
        /// <summary>Spans 84°E to 90°E.</summary>
        Utm45 = 45,
        /// <summary>Spans 90°E to 96°E.</summary>
        Utm46 = 46,
        /// <summary>Spans 96°E to 102°E.</summary>
        Utm47 = 47,
        /// <summary>Spans 102°E to 108°E.</summary>
        Utm48 = 48,
        /// <summary>Spans 108°E to 114°E.</summary>
        Utm49 = 49,
        /// <summary>Spans 114°E to 120°E.</summary>
        Utm50 = 50,
        /// <summary>Spans 120°E to 126°E.</summary>
        Utm51 = 51,
        /// <summary>Spans 126°E to 132°E.</summary>
        Utm52 = 52,
        /// <summary>Spans 132°E to 138°E.</summary>
        Utm53 = 53,
        /// <summary>Spans 138°E to 144°E.</summary>
        Utm54 = 54,
        /// <summary>Spans 144°E to 150°E.</summary>
        Utm55 = 55,
        /// <summary>Spans 150°E to 156°E.</summary>
        Utm56 = 56,
        /// <summary>Spans 156°E to 162°E.</summary>
        Utm57 = 57,
        /// <summary>Spans 162°E to 168°E.</summary>
        Utm58 = 58,
        /// <summary>Spans 168°E to 174°E.</summary>
        Utm59 = 59,
        /// <summary>Spans 174°E to 180°E.</summary>
        Utm60 = 60
    }
}


