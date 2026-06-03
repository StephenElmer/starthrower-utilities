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
using System.Reflection;
using System.Collections.Generic;
using StarThrower.StringUtilities;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of Ellipsoids based upon a specified EllipsoidType.
    /// </summary>
    /// <remarks>
    /// The following table of values is taken from the elips.dat file of the GeoTrans tool (http://earth-info.nga.mil/GandG/geotrans/).
    /// 
    ///                                   equatorial  polar
    ///                                   radius /    radius /                    StarThrower
    ///                                   semi-major  semi-minor   inverse        .Utilities
    ///                                   axis        axis         flattening     .EllipsoidType
    /// Airy 1830                      AA 6377563.396 6356256.9090 299.324964600  Airy_1830 
    /// Modified Airy                  AM 6377340.189 6356034.4480 299.324964600  Airy_Modified
    /// Australian National            AN 6378160.000 6356774.7190 298.250000000  Australian
    /// Bessel 1841(Namibia)           BN 6377483.865 6356165.3830 299.152812800  Bessel_Namibia
    /// Bessel 1841                    BR 6377397.155 6356078.9630 299.152812800  Bessel_1841
    /// Clarke 1866                    CC 6378206.400 6356583.8000 294.978698200  Clarke_1866
    /// Clarke 1880                    CD 6378249.145 6356514.8700 293.465000000  Clarke_1880_RGS
    /// Everest (India 1830)           EA 6377276.345 6356075.4130 300.801700000  Everest_Adjustment_1937
    /// Everest (E. Malasia, Brunei)   EB 6377298.556 6356097.5500 300.801700000  Everest_Definition_1967
    /// Everest 1956 (India)           EC 6377301.243 6356100.2280 300.801700000  Everest_1956_India
    /// Everest 1969 (West Malasia)    ED 6377295.664 6356094.6680 300.801700000  Everest_Modified_1969 
    /// Everest 1948(w.Mals. & Sing.)  EE 6377304.063 6356103.0390 300.801700000  Everest_1830_Modified
    /// Everest (Pakistan)             EF 6377309.613 6356109.5710 300.801700000  Everest_Pakistan
    /// Mod. Fischer 1960(South Asia)  FA 6378155.000 6356773.3200 298.300000000  Fischer_1960_Modified
    /// Helmert 1906                   HE 6378200.000 6356818.1700 298.300000000  Helmert_1906
    /// Hough 1960                     HO 6378270.000 6356794.3430 297.000000000  Hough_1960
    /// Indonesian 1974                ID 6378160.000 6356774.5040 298.247000000  Indonesian
    /// International 1924             IN 6378388.000 6356911.9460 297.000000000  International_1924
    /// Krassovsky 1940                KA 6378245.000 6356863.0190 298.300000000  Krasovsky_1940
    /// GRS 80                         RF 6378137.000 6356752.3141 298.257222101  GRS_1980
    /// South American 1969            SA 6378160.000 6356774.7190 298.250000000  South_American_1969
    /// WGS 72                         WD 6378135.000 6356750.5200 298.260000000  WGS_1972
    /// WGS 84                         WE 6378137.000 6356752.3142 298.257223563  WGS_1984
    /// 
    /// The original list of EllipsoidTypes and values was obtained be examining some ESRI data (http://edndoc.esri.com/arcims/9.1/elements/pcs.htm).
    /// There appears to be some indiscrepancies between the ESRI data and the National Geospatial Intelligency Agency data.
    /// Indiscrepancies were as follows:
    /// Everest_1956_India, Everest_Pakistan, Fischer_1960_Modified, Hough_1969, & South_American_1969 did not appear to have any matches
    /// NGIA's Clarke 1880 mapped to ESRI's Clarke_1880_RGS [it was NOT consistent with ESRI's Clarke_1880]
    /// NGIA's Everest 1948(w.Mals. & Sing.) mapped to ESRI's Everest_1830_Modified
    /// NGIA's Everest (India 1830) mapped to ESRI's Everest_Adjustment_1937
    /// NGIA's Everest (E. Malasia, Brunei) mapped to ESRI's Everest_Definition_1967
    /// NGIA's Everest 1969 (West Malasia) mapped to ESRI's Everest_Modified_1969
    /// there was no NGIA match to ESRI's Everest_1830
    /// </remarks>
    public static class EllipsoidFactory
    {
        //A static Dictionary of Ellipsoids keyed by EllipsoidType | EllipsoidType + Name (in the case of user defined ellipsoids)
        //such that GetInstanceOfEllipsoid first checks to see if the requested Ellipsoid already
        //exists and returns that rather than instantiating a new (duplicate) Ellipsoid
        private static Dictionary<string, IEllipsoid> _ellipsoidList = new Dictionary<string, IEllipsoid>();
        private static object _ellipsoidListLock = new object();

        /// <summary>
        /// Gets the instance of the Ellipsoid specified by ellipsoidType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="ellipsoidType">The type of ellipsoid you want.  Undefined and UserDefined are considered invalid.</param>
        /// <returns>The ellipsoid instance associated with ellipsoidType.</returns>
        /// <remarks>
        /// If you want retrieve an instance of a UserDefined Ellipsoid, use the 
        /// GetInstanceOfNewUserDefinedEllipsoid() or GetInstanceOfExistingUserDefinedEllipsoid() methods, as a Name
        /// must be included with the EllipsoidType to distinguish between various User Defined ellipsoids.
        /// </remarks>
        /// <exception cref="Exceptions.InvalidEllipsoidTypeException">Thrown on EllipsoidType.Undefined</exception>
        /// <exception cref="Exceptions.AmbiguousEllipsoidTypeException">Thrown on EllipsoidType.UserDefined.</exception>
        public static IEllipsoid GetInstanceOfEllipsoid(Type ellipsoidType)
        {
            ArgumentNullException.ThrowIfNull(ellipsoidType);
            if (ellipsoidType.Equals(typeof(Ellipsoids.UserDefined))) throw new Exceptions.AmbiguousEllipsoidTypeException();
            if (!EllipsoidTypeExists(ellipsoidType.Name)) throw new Exceptions.InvalidEllipsoidTypeException();
            if (ellipsoidType.GetInterface("IEllipsoid") != typeof(IEllipsoid)) throw new Exceptions.InvalidEllipsoidTypeException();

            if (!_ellipsoidList.ContainsKey(ellipsoidType.Name))
            {
                IEllipsoid e = (IEllipsoid)(ellipsoidType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null) ?? throw new Exceptions.InvalidEllipsoidTypeException()).Invoke(new object[] { });
                lock (_ellipsoidListLock)
                {
                    _ellipsoidList.TryAdd(e.Key, e);
                }
            }
            return _ellipsoidList[ellipsoidType.Name];
        }
        public static IEllipsoid GetInstanceOfEllipsoid(string ellipsoidTypeName)
        {
            ArgumentNullException.ThrowIfNull(ellipsoidTypeName);            
            if (ellipsoidTypeName.Equals(typeof(Ellipsoids.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousEllipsoidTypeException();
            if (!EllipsoidTypeExists(ellipsoidTypeName)) throw new Exceptions.InvalidEllipsoidTypeException();

            Type ellipsoidType = GetEllipsoidType(ellipsoidTypeName);
            return GetInstanceOfEllipsoid(ellipsoidType);
        }
        public static bool EllipsoidTypeExists(string ellipsoidTypeName)
        {
            ArgumentNullException.ThrowIfNull(ellipsoidTypeName);
            if (ellipsoidTypeName.Equals(typeof(Ellipsoids.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(Ellipsoids.Undefined).Namespace && types[i].Name.Equals(ellipsoidTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetEllipsoidType(string ellipsoidTypeName)
        {
            ArgumentNullException.ThrowIfNull(ellipsoidTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(ellipsoidTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(Ellipsoids.Undefined);
        }

        /// <summary>
        /// Checks to see if a UserDefined Ellipsoid has been intantiated for name.
        /// This version of the function is agnostic of the equatorialRadius and flatting of the ellipsoid.
        /// </summary>
        /// <param name="name">The name of the UserDefined Ellipoid you are looking for.</param>
        /// <returns>True if an Ellipsoid has been intantiated with this name; otherwise, false.</returns>
        /// <remarks>
        /// This (agnostic) version of the function should only be used if you have control of the 
        /// UserDefined ellipsoids in your application and are certain that the ellipsoid you are looking
        /// for will always have the same EquatorialRadius and Flattening values.
        /// 
        /// If, for example, you are reading Ellipsoids from an input file or from user input, you should
        /// be using the more precise version of this function.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidEllipsoidException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedEllipsoidExists(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, Ellipsoid.ValidNamePattern)) throw new Exceptions.InvalidEllipsoidTypeException("Invalid format for ellipsoid name.");

            return _ellipsoidList.ContainsKey(typeof(Ellipsoids.UserDefined).Name + name);
        }

        /// <summary>
        /// Checks to see if a UserDefined Ellipsoid has been instantiated for name, equatorialRadius, and flattening.
        /// </summary>
        /// <param name="name">The Name of the UserDefined Ellipsoid you are looking for.</param>
        /// <param name="equatorialRadius">The EquatorialRadius of the Ellipsoid you are looking for.</param>
        /// <param name="flattening">The Flattening of the Ellipsoid you are looking for.</param>
        /// <returns>True if a UserDefined Ellipsoid has been intantiated with this name, equatorialRadius, and flattening; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidEllipsoidException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedEllipsoidExists(string name, double equatorialRadius, double flattening)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, Ellipsoid.ValidNamePattern)) throw new Exceptions.InvalidEllipsoidTypeException("Invalid format for ellipsoid name.");

            string key = typeof(Ellipsoids.UserDefined).Name + name;
            if (!_ellipsoidList.ContainsKey(key)) return false;
            IEllipsoid e = _ellipsoidList[key];
            if (!(e.EquatorialRadius == equatorialRadius && e.Flattening == flattening)) return false;
            return true;
        }

        /// <summary>
        /// Instantiates a UserDefined Ellipsoid.
        /// </summary>
        /// <param name="name">The Name of the new Ellipsoid.</param>
        /// <param name="equatorialRadius">The EquatorialRadius of the new Ellipsoid.</param>
        /// <param name="flattening">The Flattening of the new Ellipsoid.</param>
        /// <returns>The instance of the new ellipsoid.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidEllipsoidTypeException">Thrown if the name is incorrectly formatted.</exception>
        public static IEllipsoid GetInstanceOfNewUserDefinedEllipsoid(string? name, double equatorialRadius, double flattening)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, Ellipsoid.ValidNamePattern)) throw new Exceptions.InvalidEllipsoidTypeException("Invalid format for ellipsoid name.");

            try
            {
                string key = typeof(Ellipsoids.UserDefined).Name + name;
                if (!_ellipsoidList.ContainsKey(key))
                {
                    Ellipsoids.UserDefined e = new Ellipsoids.UserDefined(name, equatorialRadius, flattening, EllipsoidParamOrder.EquatorialRadiusFlattening);
                    lock (_ellipsoidListLock)
                    {
                        if (!_ellipsoidList.ContainsKey(e.Key))
                        {
                            _ellipsoidList.Add(e.Key, e);
                        }
                    }
                    return _ellipsoidList[e.Key];
                }
                else
                {
                    IEllipsoid e = _ellipsoidList[key];
                    if (!(e.EquatorialRadius == equatorialRadius && e.Flattening == flattening)) throw new Exceptions.AmbiguousEllipsoidTypeException("Ellipsoid for name already exists with different EquatorialRadius and Flattening values.");
                    return e;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "EllipsoidFactory.GetInstanceOfNewUserDefinedEllipsoid(string, double, double)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the instance of the specified UserDefined Ellipsoid.
        /// </summary>
        /// <param name="name">The Name of the Ellipsoid you are looking for.</param>
        /// <returns>The Ellipsoid you are looking for.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidEllipsoidTypeException">Thrown if name is incorrectly formatted OR if the instance could not be found.</exception>
        public static IEllipsoid GetInstanceOfExistingUserDefinedEllipsoid(string? name)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (!StringUtil.IsValid(name, Ellipsoid.ValidNamePattern)) throw new Exceptions.InvalidEllipsoidTypeException("Invalid format for ellipsoid name.");

            try
            {
                string key = typeof(Ellipsoids.UserDefined).Name + name;
                if (!_ellipsoidList.ContainsKey(key)) throw new Exceptions.InvalidEllipsoidTypeException("A UserDefined Ellipsoid could not be found for name.");
                return _ellipsoidList[key];
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "EllipsoidFactory.GetInstanceOfExitingUserDefinedEllipsoid(string)", ex);
                throw;
            }
        }
    }
}


