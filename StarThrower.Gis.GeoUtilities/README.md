# StarThrower.Gis.GeoUtilities

Geographic and coordinate system utilities including shape parsing, spatial calculations, and geometry helpers.

`StarThrower.Gis.GeoUtilities` is a geodesy library: it models coordinate reference systems
(datums, ellipsoids, prime meridians, angular/linear units, map projections, and geoid gravity
models), translates coordinates between them — including datum shifts and geoid/ellipsoid
height conversions — and provides ESRI shapefile-style geometry types (`PointShape`,
`PolylineShape`, `PolygonShape`, etc.) for representing parsed vector features.

---

## Installation

```bash
dotnet add package StarThrower.Gis.GeoUtilities
```

---

## Coordinate Reference System Model

A coordinate reference system is built from several composable pieces, each represented by an
interface and an abstract base class:

| Interface | Abstract Base | Represents |
|---|---|---|
| `ICoordinateSystem` | — | Common contract: `Datum`, `PrimeMeridian`, `AngularUnit`, `HeightType`, `SignificantDigits`, `ToGeodetic`/`FromGeodetic`, `ToXml()`. |
| `IGeographicCoordinateSystem` | `GeographicCoordinateSystem` | A latitude/longitude system tied to a `Datum` (e.g. `GeodeticWgs84`, `GeodeticNad27`). |
| `IProjectedCoordinateSystem` | `ProjectedCoordinateSystem` | A planar (x/y) system built from a geographic CS, an `IProjection`, and an `ILinearUnit` (e.g. UTM, British National Grid). |
| `IZonedCoordinateSystem` | — | A projected CS that is divided into named zones (e.g. UTM zones 1–60, C–X), exposed via `Zone` (`IZone`). |
| `IDatum` | `Datum` | A geodetic datum: an `IEllipsoid` plus the 3- or 7-parameter shift to/from WGS84 (`ToWgs84`/`FromWgs84`), a domain of validity (`GeoRectangle`), and `HeightType`-aware height handling. |
| `IEllipsoid` | `Ellipsoid` | A reference ellipsoid: `EquatorialRadius`, `PolarRadius`, `Flattening`, and derived eccentricity values. |
| `IGeoid` | `Geoid` | A gravity-model height grid (e.g. EGM96) with bilinear (`BlInterpolate`) and natural-spline (`NsInterpolate`) interpolation for geoid undulation. |
| `IAngularUnit` | `AngularUnit` | An angular unit of measure (e.g. `Degree`, `Grad`). |
| `ILinearUnit` | `LinearUnit` | A linear unit of measure (e.g. `Meter`, `FootUs`). |
| `IPrimeMeridian` | `PrimeMeridian` | A prime meridian offset from Greenwich (e.g. `Paris`, `Bern`). |
| `IProjection` | — | A map projection's parameters, accessed via `this[string parameterName]`. |
| `IZone` | `Zone` | A zone within a zoned coordinate system: `Name`, `CentralMeridian`, `ReferenceLatitude`, `IsSouthernHemisphere`, `GeometricCenter`. |

All of these expose a `ToXml()` method that produces a self-describing XML fragment (e.g.
`<datum>`, `<ellipsoid>`, `<geographicCoordinateSystem>`).

### Built-in Reference Data

The library ships with a large catalog of concrete implementations, organized one type per file:

| Folder | Contents |
|---|---|
| `Datums/` | 230+ geodetic datums (e.g. `Wgs1984`, `Nad27`, `European1950` and its regional variants, `Tokyo`, `Arc1960Kenya`, plus county-adjustment datums for Wisconsin/Minnesota). |
| `Ellipsoids/` | 190+ reference ellipsoids (e.g. `Grs1980`, `Clarke1866`, `Bessel1841`, `International1924`, plus many `Grs1980AdjWiXxx`/`SGrs1980AdjMnXxx` county-specific adjustments). |
| `Geoids/` | `Egm84`, `Egm96` gravity-model height grids, plus `Undefined`/`UserDefined`. |
| `AngularUnits/` | `Degree`, `Grad`, `Undefined`. |
| `LinearUnits/` | `Meter`, `Foot`, `FootUs`, `FootClarke`, `FootGoldCoast`, `FootSears`, `ChainSears`, `ChainBenoit1895B`, `LinkClarke`, `YardIndian`, `YardIndian1937`, `YardSears`, `Kilometers50`, `Kilometers150`, `Undefined`. |
| `PrimeMeridians/` | `Greenwich`, `Paris`, `Bern`, `Brussels`, `Ferro`, `Lisbon`, `Madrid`, `Oslo`, `Rome`, `Stockholm`, `Undefined`. |
| `Projections/` | 26 map projections (e.g. `TransverseMercator`, `LambertConformalConic1`/`2`, `Mercator`, `AlbersEqualAreaConic`, `Polyconic`, `Stereographic`, `VanDerGrinten`, `Undefined`). |
| `CoordinateSystems/Geographic/` | 15 geographic coordinate systems (e.g. `GeodeticWgs84`, `GeodeticNad27`, `GeodeticNad83`, `GeodeticWgs72`, `GeocentricWgs84`, `MgrsWgs84`, `UsngWgs84`, `GarsWgs84`, `Undefined`/`UserDefined`). |
| `CoordinateSystems/Projected/` | 32 projected coordinate systems, including `UtmWgs84`/`UtmWgs84Ns`/`UtmWgs72`/`UtmWgs72Ns`, `Bng` (British National Grid), and one Wgs84-based system per projection (e.g. `MercatorWgs84`, `LambertConformalConic1Wgs84`), plus `Undefined`/`UserDefined`. |
| `Zones/` | `UndefinedZone`, and UTM/UTM-NS latitudinal and longitudinal zone definitions used by the zoned UTM coordinate systems. |

---

## Factories

Every reference-data category has a corresponding static factory class that locates the
concrete type via reflection and returns a singleton instance:

| Factory | Returns |
|---|---|
| `GeographicCoordinateSystemFactory` | `IGeographicCoordinateSystem` |
| `ProjectedCoordinateSystemFactory` | `IProjectedCoordinateSystem` (overload accepts an `IZone` for zoned systems) |
| `DatumFactory` | `IDatum` |
| `EllipsoidFactory` | `IEllipsoid` |
| `GeoidFactory` | `IGeoid` |
| `AngularUnitFactory` | `IAngularUnit` |
| `LinearUnitFactory` | `ILinearUnit` |
| `PrimeMeridianFactory` | `IPrimeMeridian` |
| `ProjectionFactory` (takes `ProjectionParameter[]`) | `IProjection` |

Each factory exposes the same shape of members:

- `GetInstanceOfX(Type)` / `GetInstanceOfX(string typeName)` — returns the singleton instance
  of the requested type, looked up by name via `Assembly.GetExecutingAssembly().GetTypes()`.
- `XTypeExists(string typeName)` — `true` if a matching type was found.
- `GetXType(string typeName)` — the resolved `Type`, or throws if not found/ambiguous.

`DatumFactory`, `EllipsoidFactory`, `GeoidFactory`, `GeographicCoordinateSystemFactory`, and
`ProjectedCoordinateSystemFactory` additionally support **user-defined** instances — datums,
ellipsoids, geoids, and coordinate systems constructed at runtime from caller-supplied
parameters (e.g. `GetInstanceOfNewUserDefinedDatum(name, ellipsoid, deltaX, ..., north, south,
east, west)`), looked up afterwards by name via `GetInstanceOfExistingUserDefinedDatum(name)`.

Invalid or ambiguous type names throw `InvalidXTypeException` / `AmbiguousXTypeException`
(see [Exceptions](#exceptions)).

---

## `GeoUtil`

`GeoUtil` is the static entry point for coordinate translation and validation.

| Member | Description |
|---|---|
| `MaxLat` / `MinLat` / `MaxLon` / `MinLon` | `90`, `-90`, `180`, `-180`. |
| `IsValidLat(double)` / `IsValidLon(double)` | Range checks against the constants above. |
| `Translate(ICoordinateSystem csFrom, ICoordinateSystem csTo, double xLon, double yLat, double zAlt)` | Converts a coordinate from `csFrom` to `csTo`, returning an `ITranslationResult`. |
| `AngularUnitTypes` / `AngularUnitTypeNames`, `DatumTypes` / `DatumTypeNames`, `EllipsoidTypes` / `EllipsoidTypeNames`, `LinearUnitTypes` / `LinearUnitTypeNames`, `PrimeMeridianTypes` / `PrimeMeridianTypeNames`, `ProjectionTypes` / `ProjectionTypeNames`, `GeographicCoordinateSystemTypes` / `GeographicCoordinateSystemTypeNames`, `ProjectedCoordinateSystemTypes` / `ProjectedCoordinateSystemTypeNames` | Reflection-based catalogs of every concrete type/name available in each category. |

### `Translate` Pipeline

`Translate` converts a coordinate in any supported coordinate system to any other:

1. Convert from `csFrom` to geodetic coordinates in `csFrom`'s datum (`csFrom.ToGeodetic`).
2. If `csFrom.Datum` and `csTo.Datum` differ, shift to WGS84 via `csFrom.Datum.ToWgs84` —
   using a Molodensky shift for 3-parameter datums within range, or a 3-step geocentric
   conversion (Toms 1996) for 7-parameter datums or out-of-range latitudes — then shift from
   WGS84 to `csTo`'s datum via `csTo.Datum.FromWgs84`.
3. Adjust the vertical (`zAlt`) component according to `csFrom.HeightType` and
   `csTo.HeightType`, using the EGM96 or EGM84 geoid models where a geoid/ellipsoid height
   conversion is required.
4. Convert from geodetic coordinates in `csTo`'s datum to `csTo` (`csTo.FromGeodetic`).
5. Compute combined error-propagation statistics for the conversion and attach them to the
   result via `ITranslationResult.SetComputationalError(ce90, le90, se90)`.

### `ITranslationResult`

```csharp
public interface ITranslationResult
{
    double xLon { get; }
    double yLat { get; }
    double zAlt { get; }
    double ce90 { get; }
    double le90 { get; }
    double se90 { get; }
    void SetComputationalError(double ce90, double le90, double se90);
}
```

`ce90`/`le90`/`se90` are the 90% circular, linear, and spherical error estimates accumulated
across the datum shift and height conversion steps.

### `HeightType`

```csharp
public enum HeightType
{
    NoHeight = 0,
    EllipsoidHeight = 1,
    GeoidOrMslHeight = 2,
    MslEgm96VgNsHeight = 3,
    MslEgm8410dBlHeight = 4,
    MslEgm8410dNsHeight = 5
}
```

Determines whether, and how, `Translate` converts the `zAlt` component between ellipsoid
height and mean-sea-level (geoid) height using the EGM96 or EGM84 grids and natural-spline
(`Ns`) or bilinear (`Bl`) interpolation.

---

## Usage

### Translating Between Coordinate Systems

```csharp
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Geographic;
using StarThrower.Gis.GeoUtilities.CoordinateSystems.Projected;

IGeographicCoordinateSystem wgs84 =
    GeographicCoordinateSystemFactory.GetInstanceOfGeographicCoordinateSystem(typeof(GeodeticWgs84));

IProjectedCoordinateSystem utm =
    ProjectedCoordinateSystemFactory.GetInstanceOfProjectedCoordinateSystem(typeof(UtmWgs84));

// Geographic (lon/lat, decimal degrees) -> UTM (easting/northing, meters)
ITranslationResult utmResult = GeoUtil.Translate(wgs84, utm, -77.0365, 38.8977, 0.0);

if (utmResult is StarThrower.Gis.GeoUtilities.IZone)
{
    // UTM results carry their zone via Translations.ZonedResult, which implements IZone
}

// Round trip back to geographic
ITranslationResult geoResult = GeoUtil.Translate(utm, wgs84, utmResult.xLon, utmResult.yLat, utmResult.zAlt);
```

### Working with Points

```csharp
using StarThrower.Gis.GeoUtilities;
using StarThrower.Gis.GeoUtilities.Formatting;

GeoPoint point = new GeoPoint(-77.0365, 38.8977);

IDmsFormatter dms = DmsFormatterFactory.Create(DmsFormat.Dms1);
string lonDms = dms.DdToDmsEw(point.xLon); // e.g. "77° 02' 11.40\" W"
string latDms = dms.DdToDmsNs(point.yLat); // e.g. "38° 53' 51.72\" N"
```

### Shapes

The `Shapes` namespace models ESRI shapefile geometry types, used to represent parsed vector
features:

| Type | Description |
|---|---|
| `Shape` | Abstract base; exposes `ShapeType` (`ShapeType` enum: `NullShape`, `Point`, `Polyline`, `Polygon`, `Multipoint`, and their `Z`/`M` variants, and `Multipatch`). |
| `PointShape`, `PointZShape`, `PointMShape` | A single point, implementing `IGeoPoint`. |
| `MultipointShape`, `MultipointZShape`, `MultipointMShape` | A collection of `PointShape`s. |
| `PolylineShape`, `PolylineZShape`, `PolylineMShape` | One or more `OpenPart`s (open point sequences). |
| `PolygonShape`, `PolygonZShape`, `PolygonMShape` | One or more `ClosedPart`s (closed rings), with an `Extent` (`GeoRectangle`) computed from all parts. |
| `MultipatchShape` | A collection of parts representing a 3D surface. |
| `Part` (abstract), `OpenPart`, `ClosedPart` | A sequence of `PointShape`s making up one ring or line of a multi-part shape; exposes `PointCount` and `Extent`. |
| `NullShape` | An empty shape (`ShapeType.NullShape`). |

All shape types implement `ICloneable` and the library's `ItemCopy(object)` convention
(throwing `FailedItemCopyException` on failure).

```csharp
using StarThrower.Gis.GeoUtilities.Shapes;

PolygonShape polygon = new PolygonShape();
polygon.AddPart();

ClosedPart ring = polygon.GetPart(0);
ring.AddPoint(new PointShape(-77.05, 38.90));
ring.AddPoint(new PointShape(-77.00, 38.90));
ring.AddPoint(new PointShape(-77.00, 38.85));
ring.AddPoint(new PointShape(-77.05, 38.85));

GeoRectangle extent = polygon.Extent;
int totalPoints = polygon.PointCount;
```

---

## Exceptions

| Exception | Thrown When |
|---|---|
| `InvalidCoordinateSystemException`, `AmbiguousCoordinateSystemException` | A requested coordinate system type name is not found, or matches more than one type. |
| `InvalidDatumTypeException`, `AmbiguousDatumTypeException` | As above, for `IDatum`. |
| `InvalidEllipsoidTypeException`, `AmbiguousEllipsoidTypeException` | As above, for `IEllipsoid`. |
| `InvalidGeoidTypeException`, `AmbiguousGeoidTypeException` | As above, for `IGeoid`. |
| `InvalidAngularUnitTypeException` | An `IAngularUnit` type name is not found. |
| `InvalidLinearUnitTypeException` | An `ILinearUnit` type name is not found. |
| `InvalidPrimeMeridianTypeException` | An `IPrimeMeridian` type name is not found. |
| `InvalidProjectionTypeException`, `InvalidProjectionParametersException` | An `IProjection` type name is not found, or its required parameters are missing/invalid. |
| `FailedGeoTranslationException` | Defined for use when `GeoUtil.Translate` cannot complete a coordinate conversion; not currently thrown anywhere in the library ([#14](https://github.com/StephenElmer/starthrower-utilities/issues/14)). |
| `FailedItemCopyException` | `ItemCopy(object)` is called with an incompatible or null source object. |
| `PrecisionException` | A computed value exceeds the precision supported by a coordinate system or unit. |
| `ValueOutOfRangeException` | A coordinate or parameter value falls outside its valid domain (e.g. latitude/longitude out of range). |

---

## Usage Notes

- **Singletons.** Factory-returned instances (datums, ellipsoids, geoids, units, prime
  meridians, and built-in coordinate systems) are singletons per concrete type — do not
  assume each call to `GetInstanceOfX` returns a distinct object, except for
  `UserDefined`/zoned instances which are cached by name/zone.
- **`Geoid.NsInterpolate`/`BlInterpolate`** throw `ArgumentOutOfRangeException` for
  latitude/longitude values outside the geoid grid's coverage; `ToEllipsoidHeightNs`,
  `FromEllipsoidHeightNs`, `ToEllipsoidHeightBl`, and `FromEllipsoidHeightBl` are virtual and
  throw `NotSupportedException` unless overridden (only `Egm84` and `Egm96` implement them).
- **UTM zoning.** `UtmWgs84`/`UtmWgs84Ns`/`UtmWgs72`/`UtmWgs72Ns` are `IZonedCoordinateSystem`s;
  `FromGeodetic` determines the correct `IZone` from the input coordinates and delegates to
  the zone-specific singleton instance via `ProjectedCoordinateSystemFactory`. The `Ns`
  variants use a 10,000,000 m false northing for the southern hemisphere.
- **DMS formatting.** `DmsFormatterFactory.Create(DmsFormat)` returns a singleton
  `IDmsFormatter`: `DmsFormat.Default`/`Dms1` produces `[°][d][d]d° [m]m' ss.ss"`-style strings;
  `Dms2` produces `{N|S|E|W}[d]d{D}[m]m{M}[s]s[.ss]{S}`-style strings.
- **Datum domain validation.** `GeoUtil.Translate` throws `InvalidOperationException` if the
  translated coordinate falls outside the destination datum's valid region (`Datum.Domain`,
  checked via `Datum.Validate`).

---

## Known Limitations

- **Most non-UTM projected coordinate systems do not yet project.** Of the 32 types in
  `CoordinateSystems/Projected/`, only `MercatorWgs84` and the four UTM variants
  (`UtmWgs84`/`UtmWgs84Ns`/`UtmWgs72`/`UtmWgs72Ns`) have working `ToGeodetic`/`FromGeodetic`
  implementations. The other 26 (e.g. `LambertConformalConic1Wgs84`, `MollweideWgs84`,
  `TransverseMercatorWgs84`) currently pass the input coordinate through unchanged. The
  underlying projection math for all of these already exists in `Projections/` — the
  coordinate-system wrapper classes just don't call into it yet. See
  [#11](https://github.com/StephenElmer/starthrower-utilities/issues/11).
- **`Datum.FromWgs84` is a no-op for almost every datum.** Converting a coordinate from WGS84
  into any datum other than `Wgs1972`/`Wgs1984` currently returns the input unchanged. The
  seven-parameter/geocentric shift path (`GeocentricShiftToWgs84`) is similarly unimplemented,
  affecting `Osgb1936`, `European1950`, and `UserDefined` datums specifically. See
  [#12](https://github.com/StephenElmer/starthrower-utilities/issues/12).

---

## Dependencies

- [`StarThrower.ByteUtilities`](../StarThrower.ByteUtilities/README.md) — endian-aware byte conversions used by `Egm84`/`Egm96` to read binary geoid grid files.
- [`StarThrower.MathUtilities`](../StarThrower.MathUtilities/README.md)
- [`StarThrower.StringUtilities`](../StarThrower.StringUtilities/README.md)

---

## License

Copyright © 2026 Stephen Elmer. Licensed under the [MIT License](../LICENSE.md).
