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
using StarThrower.Logging;
using StarThrower.StringUtilities;

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// Creates and returns instances of Datums based upon a specified DatumType
    /// </summary>
    /// <remarks>
    /// 
    /// Refer to http://edndoc.esri.com/arcims/9.2/ for cross-reference
    /// 
    /// The following tables of values were derived from the 7_param.dat and 3_param.dat
    /// files, respectively, of the GeoTrans tool.
    /// 
    /// Those records marked with an asterisk (*) appear to have an 
    /// ESRI ArcIMS equivalent and have been implemented in the DatumFactory.
    /// 
    /// Records w/out an asterisk do not appear to have an ESRI ArcIMS equivalent.
    /// 
    ///                                                       deltaX  deltaY  deltaZ  rotationX  rotationY  rotationZ  rotationScaleFactor
    /// code     name                               ellipsoid    p[0]    p[1]    p[2]       p[3]       p[4]       p[5]                 p[6]
    /// EUR-7  * "EUROPEAN 1950, Mean (7 Param)"    IN           -102    -102    -129      0.413     -0.184      0.385         0.0000024664
    /// OGB-7  * "ORDNANCE GB 1936, Mean (7 Para)"  AA            446     -99     544     -0.945     -0.261     -0.435        -0.0000208927


    /// code     name                               ellipsoid    p[0], sigmaX,    p[1],  sigmaY,    p[2],  sigmaZ,  rotationX,  rotationY,  rotationZ,  rotationScaleFactor,    N,    S,    E,    w
    /// ADI-M  * "ADINDAN, Mean"                    CD           -166,      5,     -15,       5,     204,       3,          0,          0,          0,                    1,   31,   -5,   55,   15
    /// ADI-A  * "ADINDAN, Ethiopia"                CD           -165,      3,     -11,       3,     206,       3,          0,          0,          0,                    1,   25,   -3,   50,   26
    /// ADI-B  * "ADINDAN, Sudan"                   CD           -161,      3,     -14,       5,     205,       3,          0,          0,          0,                    1,   31,   -3,   45,   15
    /// ADI-C  * "ADINDAN, Mali"                    CD           -123,     25,     -20,      25,     220,      25,          0,          0,          0,                    1,   31,    3,   11,  -20
    /// ADI-D  * "ADINDAN, Senegal"                 CD           -128,     25,     -18,      25,     224,      25,          0,          0,          0,                    1,   23,    5,   -5,  -24
    /// ADI-E  * "ADINDAN, Burkina Faso"            CD           -118,     25,     -14,      25,     218,      25,          0,          0,          0,                    1,   22,    4,    8,  -12
    /// ADI-F  * "ADINDAN, Cameroon"                CD           -134,     25,      -2,      25,     210,      25,          0,          0,          0,                    1,   19,   -4,   23,    3
    /// AFG    * "AFGOOYE, Somalia"                 KA            -43,     25,    -163,      25,      45,      25,          0,          0,          0,                    1,   19,   -8,   60,   35
    /// AIN-A  * "AIN EL ABD 1970, Bahrain"         IN           -150,     25,    -250,      25,      -1,      25,          0,          0,          0,                    1,   28,   24,   53,   49
    /// AIN-B  * "AIN EL ABD 1970, Saudi Arabia"    IN           -143,     10,    -236,      10,       7,      10,          0,          0,          0,                    1,   38,    8,   62,   28
    /// AMA    * "AMERICAN SAMOA 1962"              CC           -115,     25,     118,      25,     426,      25,          0,          0,          0,                    1,   -9,  -19, -165, -174
    /// ANO      "ANNA 1 ASTRO 1965, Cocos Is."     AN           -491,     25,     -22,      25,     435,      25,          0,          0,          0,                    1,  -10,  -14,   99,   94
    /// AIA    * "ANTIGUA ISLAND ASTRO 1943"        CD           -270,     25,      13,      25,      62,      25,          0,          0,          0,                    1,   20,   16,  -61,  -65
    /// ARF-M  * "ARC 1950, Mean"                   CD           -143,     20,     -90,      33,    -294,      20,          0,          0,          0,                    1,   10,  -36,   42,    4
    /// ARF-A  * "ARC 1950, Botswana"               CD           -138,      3,    -105,       5,    -289,       3,          0,          0,          0,                    1,  -13,  -33,   36,   13
    /// ARF-B  * "ARC 1950, Lesotho"                CD           -125,      3,    -108,       3,    -295,       8,          0,          0,          0,                    1,  -23,  -36,   35,   21
    /// ARF-C  * "ARC 1950, Malawi"                 CD           -161,      9,     -73,      24,    -317,       8,          0,          0,          0,                    1,   -3,  -21,   42,   26
    /// ARF-D  * "ARC 1950, Swaziland"              CD           -134,     15,    -105,      15,    -295,      15,          0,          0,          0,                    1,  -20,  -33,   40,   25
    /// ARF-E  * "ARC 1950, Zaire"                  CD           -169,     25,     -19,      25,    -278,      25,          0,          0,          0,                    1,   10,  -21,   38,    4
    /// ARF-F  * "ARC 1950, Zambia"                 CD           -147,     21,     -74,      21,    -283,      27,          0,          0,          0,                    1,   -1,  -24,   40,   15
    /// ARF-G  * "ARC 1950, Zimbabwe"               CD           -142,      5,     -96,       8,    -293,      11,          0,          0,          0,                    1,   -9,  -29,   39,   19
    /// ARF-H  * "ARC 1950, Burundi"                CD           -153,     20,      -5,      20,    -292,      20,          0,          0,          0,                    1,    4,  -11,   37,   21
    /// ARS-M  * "ARC 1960, Kenya & Tanzania"       CD           -160,     20,      -6,      20,    -302,      20,          0,          0,          0,                    1,    8,  -18,   47,   23
    /// ARS-A  * "ARC 1960, Kenya"                  CD           -157,      4,      -2,       3,    -299,       3,          0,          0,          0,                    1,    8,  -11,   47,   28
    /// ARS-B  * "ARC 1960, Tanzania"               CD           -175,      6,     -23,       9,    -303,      10,          0,          0,          0,                    1,    5,  -18,   47,   23
    /// ASC      "ASCENSION ISLAND 1958"            IN           -205,     25,     107,      25,      53,      25,          0,          0,          0,                    1,   -6,   -9,  -13,  -16
    /// TRN      "ASTRO TERN ISLAND (FRIG) 1961"    IN            114,     25,    -116,      25,    -333,      25,          0,          0,          0,                    1,   26,   22, -164, -168
    /// SHB      "ASTRO DOS 71/4, St. Helena Is."   IN           -320,     25,     550,      25,    -494,      25,          0,          0,          0,                    1,  -14,  -18,   -4,   -7
    /// ASQ      "ASTRO STATION 1952, Marcus Is."   IN            124,     25,    -234,      25,     -25,      25,          0,          0,          0,                    1,   26,   22,  156,  152
    /// ATF      "ASTRO BEACON E 1945, Iwo Jima"    IN            145,     25,      75,      25,    -272,      25,          0,          0,          0,                    1,   26,   22,  144,  140
    /// AUA    * "AUSTRALIAN GEODETIC 1966"         AN           -133,      3,     -48,       3,     148,       3,          0,          0,          0,                    1,   -4,  -46,  161,  109
    /// AUG    * "AUSTRALIAN GEODETIC 1984"         AN           -134,      2,     -48,       2,     149,       2,          0,          0,          0,                    1,   -4,  -46,  161,  109
    /// PHA      "AYABELLE LIGHTHOUSE, Djibouti"    CD            -79,     25,    -129,      25,     145,      25,          0,          0,          0,                    1,   20,    5,   49,   36
    /// IBE      "BELLEVUE (IGN), Efate Is."        IN           -127,     20,    -769,      20,     472,      20,          0,          0,          0,                    1,  -16,  -20,  171,  167
    /// BER    * "BERMUDA 1957, Bermuda Islands"    CC            -73,     20,     213,      20,     296,      20,          0,          0,          0,                    1,   34,   31,  -63,  -66
    /// BID    * "BISSAU, Guinea-Bissau"            IN           -173,     25,     253,      25,      27,      25,          0,          0,          0,                    1,   19,    5,   -7,  -23
    /// BOO    * "BOGOTA OBSERVATORY, Colombia"     IN            307,      6,     304,       5,    -318,       6,          0,          0,          0,                    1,   16,  -10,  -61,  -85
    /// BUR      "BUKIT RIMPAH, Banka & Belitung"   BR           -384,     -1,     664,      -1,     -48,      -1,          0,          0,          0,                    1,    0,   -6,  110,  103
    /// CAI    * "CAMPO INCHAUSPE 1969, Arg."       IN           -148,      5,     136,       5,      90,       5,          0,          0,          0,                    1,  -20,  -62,  -47,  -76
    /// CAZ      "CAMP AREA ASTRO, Camp McMurdo"    IN           -104,     -1,    -129,      -1,     239,      -1,          0,          0,          0,                    1,  -70,  -85,  180,  135
    /// CAC      "CAPE CANAVERAL, Fla & Bahamas"    CC             -2,      3,     151,       3,     181,       3,          0,          0,          0,                    1,   38,   15,  -58,  -94
    /// CAP    * "CAPE, South Africa"               CD           -136,      3,    -108,       6,    -292,       6,          0,          0,          0,                    1,  -15,  -43,   40,   10
    /// CAO      "CANTON ASTRO 1966, Phoenix Is."   IN            298,     15,    -304,      15,    -375,      15,          0,          0,          0,                    1,    3,  -13, -165, -180
    /// CGE    * "CARTHAGE, Tunisia"                CD           -263,      6,       6,       9,     431,       8,          0,          0,          0,                    1,   43,   24,   18,    2
    /// CHI      "CHATHAM ISLAND ASTRO 1971, NZ"    IN            175,     15,     -38,      15,     113,      15,          0,          0,          0,                    1,  -42,  -46, -174, -180
    /// CHU      "CHUA ASTRO, Paraguay"             IN           -134,      6,     229,       9,     -29,       5,          0,          0,          0,                    1,  -14,  -33,  -49,  -69
    /// COA      "CORREGO ALEGRE, Brazil"           IN           -206,      5,     172,       3,      -6,       5,          0,          0,          0,                    1,    9,  -39,  -29,  -80
    /// DAL      "DABOLA, Guinea"                   CD            -83,     15,      37,      15,     124,      15,          0,          0,          0,                    1,   19,    1,   -4,  -18
    /// DID      "DECEPTION ISLAND"                 CD            260,     20,      12,      20,    -147,      20,          0,          0,          0,                    1,  -62,  -65,  -58,  -62
    /// BAT      "DJAKARTA, INDONESIA"              BR           -377,      3,     681,       3,     -50,       3,          0,          0,          0,                    1,   11,  -16,  146,   89
    /// GIZ      "DOS 1968, Gizo Island"            IN            230,     25,    -199,      25,    -752,      25,          0,          0,          0,                    1,   -7,  -10,  158,  155
    /// EAS      "EASTER ISLAND 1967"               IN            211,     25,     147,      25,     111,      25,          0,          0,          0,                    1,  -26,  -29, -108, -111
    /// EST      "ESTONIA, 1937"                    BR            374,      2,     150,       3,     588,       3,          0,          0,          0,                    1,   65,   52,   34,   16
    /// EUR-M    "EUROPEAN 1950, Mean (3 Param)"    IN            -87,      3,     -98,       8,    -121,       5,          0,          0,          0,                    1,   80,   30,   33,    5
    /// EUR-A    "EUROPEAN 1950, Western Europe"    IN            -87,      3,     -96,       3,    -120,       3,          0,          0,          0,                    1,   78,   30,   25,  -15
    /// EUR-B    "EUROPEAN 1950, Greece"            IN            -84,     25,     -95,      25,    -130,      25,          0,          0,          0,                    1,   48,   30,   34,   14
    /// EUR-C    "EUROPEAN 1950, Norway & Finland"  IN            -87,      3,     -95,       5,    -120,       3,          0,          0,          0,                    1,   80,   52,   38,   -2
    /// EUR-D    "EUROPEAN 1950, Portugal & Spain"  IN            -84,      5,    -107,       6,    -120,       3,          0,          0,          0,                    1,   49,   30,   10,  -15
    /// EUR-E    "EUROPEAN 1950, Cyprus"            IN           -104,     15,    -101,      15,    -140,      15,          0,          0,          0,                    1,   37,   33,   36,   31
    /// EUR-F    "EUROPEAN 1950, Egypt"             IN           -130,      6,    -117,       8,    -151,       8,          0,          0,          0,                    1,   38,   16,   42,   19
    /// EUR-G    "EUROPEAN 1950, England, Channel"  IN            -86,      3,     -96,       3,    -120,       3,          0,          0,          0,                    1,   62,   48,    3,  -10
    /// EUR-H    "EUROPEAN 1950, Iran"              IN           -117,      9,    -132,      12,    -164,      11,          0,          0,          0,                    1,   47,   19,   69,   37
    /// EUR-I    "EUROPEAN 1950, Sardinia(Italy)"   IN            -97,     25,    -103,      25,    -120,      25,          0,          0,          0,                    1,   43,   37,   12,    6
    /// EUR-J    "EUROPEAN 1950, Sicily(Italy)"     IN            -97,     20,     -88,      20,    -135,      20,          0,          0,          0,                    1,   40,   35,   17,   10
    /// EUR-K    "EUROPEAN 1950, England, Ireland"  IN            -86,      3,     -96,       3,    -120,       3,          0,          0,          0,                    1,   62,   48,    3,  -12
    /// EUR-L    "EUROPEAN 1950, Malta"             IN           -107,     25,     -88,      25,    -149,      25,          0,          0,          0,                    1,   38,   34,   16,   12
    /// EUR-S    "EUROPEAN 1950, Iraq, Israel"      IN           -103,     -1,    -106,      -1,    -141,      -1,          0,          0,          0,                    1,   48,   20,   60,   24
    /// EUR-T    "EUROPEAN 1950, Tunisia"           IN           -112,     25,     -77,      25,    -145,      25,          0,          0,          0,                    1,   43,   24,   18,    2
    /// EUS      "EUROPEAN 1979"                    IN            -86,      3,     -98,       3,    -119,       3,          0,          0,          0,                    1,   80,   30,   24,  -15
    /// FOT      "FORT THOMAS 1955, Leeward Is."    CD             -7,     25,     215,      25,     225,      25,          0,          0,          0,                    1,   19,   16,  -61,  -64
    /// GAA      "GAN 1970, Rep. of Maldives"       IN           -133,     25,    -321,      25,      50,      25,          0,          0,          0,                    1,    9,   -2,   75,   71
    /// GEO      "GEODETIC DATUM 1949, NZ"          IN             84,      5,     -22,       3,     209,       5,          0,          0,          0,                    1,  -33,  -48,  180,  165
    /// GRA      "GRACIOSA BASE SW 1948, Azores"    IN           -104,      3,     167,       3,     -38,       3,          0,          0,          0,                    1,   41,   37,  -26,  -30
    /// GUA      "GUAM 1963"                        CC           -100,      3,    -248,       3,     259,       3,          0,          0,          0,                    1,   15,   12,  146,  143
    /// GSE      "GUNUNG SEGARA, Indonesia"         BR           -403,     -1,     684,      -1,      41,      -1,          0,          0,          0,                    1,    9,   -6,  121,  106
    /// DOB      "GUX 1 ASTRO, Guadalcanal Is."     IN            252,     25,    -209,      25,    -751,      25,          0,          0,          0,                    1,   -8,  -12,  163,  158
    /// HEN      "HERAT NORTH, Afghanistan"         IN           -333,     -1,    -222,      -1,     114,      -1,          0,          0,          0,                    1,   44,   23,   81,   55
    /// HER      "HERMANNSKOGEL, old Yugoslavia"    BR            682,     -1,    -203,      -1,     480,      -1,          0,          0,          0,                    1,   52,   35,   29,    7
    /// HJO      "HJORSEY 1955, Iceland"            IN            -73,      3,      46,       3,     -86,       6,          0,          0,          0,                    1,   69,   61,  -11,  -27
    /// HKD      "HONG KONG 1963"                   IN           -156,     25,    -271,      25,    -189,      25,          0,          0,          0,                    1,   24,   21,  116,  112
    /// HTN      "HU-TZU-SHAN, Taiwan"              IN           -637,     15,    -549,      15,    -203,      15,          0,          0,          0,                    1,   28,   20,  124,  117
    /// IND-B    "INDIAN, Bangladesh"               EA            282,     10,     726,       8,     254,      12,          0,          0,          0,                    1,   33,   15,  100,   80
    /// IND-I    "INDIAN, India & Nepal"            EC            295,     12,     736,      10,     257,      15,          0,          0,          0,                    1,   44,    2,  105,   62
    /// IND-P    "INDIAN, Pakistan"                 EF            283,     -1,     682,      -1,     231,      -1,          0,          0,          0,                    1,   44,   17,   81,   55
    /// INF-A    "INDIAN 1954, Thailand"            EA            217,     15,     823,       6,     299,      12,          0,          0,          0,                    1,   27,    0,  111,   91
    /// ING-A    "INDIAN 1960, Vietnam 16N"         EA            198,     25,     881,      25,     317,      25,          0,          0,          0,                    1,   30,    2,  115,  101
    /// ING-B    "INDIAN 1960, Con Son Island"      EA            182,     25,     915,      25,     344,      25,          0,          0,          0,                    1,   11,    6,  109,  104
    /// INH-A    "INDIAN 1975, Thailand"            EA            209,     12,     818,      10,     290,      12,          0,          0,          0,                    1,   27,    0,  111,   91
    /// INH-A1   "INDIAN 1975, Thailand"            EA            210,      3,     814,       2,     289,       3,          0,          0,          0,                    1,   27,    0,  111,   91
    /// IDN      "INDONESIAN 1974"                  ID            -24,     25,     -15,      25,       5,      25,          0,          0,          0,                    1,   11,  -16,  146,   89
    /// IRL      "IRELAND 1965"                     AM            506,      3,    -122,       3,     611,       3,          0,          0,          0,                    1,   57,   50,   -4,  -12
    /// ISG      "ISTS 061 ASTRO 1968, S Georgia"   IN           -794,     25,     119,      25,    -298,      25,          0,          0,          0,                    1,  -52,  -56,  -34,  -38
    /// IST      "ISTS 073 ASTRO 1969, Diego Garc"  IN            208,     25,    -435,      25,    -229,      25,          0,          0,          0,                    1,   -4,  -10,   75,   69
    /// JOH      "JOHNSTON ISLAND 1961"             IN            189,     25,     -79,      25,    -202,      25,          0,          0,          0,                    1,   19,   15, -168, -171
    /// KAN      "KANDAWALA, Sri Lanka"             EA            -97,     20,     787,      20,      86,      20,          0,          0,          0,                    1,   12,    4,   85,   77
    /// KEG      "KERGUELEN ISLAND 1949"            IN            145,     25,    -187,      25,     103,      25,          0,          0,          0,                    1,  -47,  -52,   74,   65
    /// KGS      "KOREAN GEO DATUM 1995, S Korea"   WE              0,      1,       0,       1,       0,       1,          0,          0,          0,                    1,   45,   27,  139,  120
    /// KEA      "KERTAU 1948, w Malaysia & Sing."  EE            -11,     10,     851,       8,       5,       6,          0,          0,          0,                    1,   12,   -5,  112,   94
    /// KUS      "KUSAIE ASTRO 1951, Caroline Is."  IN            647,     25,    1777,      25,   -1124,      25,          0,          0,          0,                    1,   12,   -1,  167,  134
    /// LCF      "L.C. 5 ASTRO 1961, Cayman Brac"   CC             42,     25,     124,      25,     147,      25,          0,          0,          0,                    1,   21,   18,  -78,  -83
    /// LEH      "LEIGON, Ghana"                    CD           -130,      2,      29,       3,     364,       2,          0,          0,          0,                    1,   17,   -1,    7,   -9
    /// LIB      "LIBERIA 1964"                     CD            -90,     15,      40,      15,      88,      15,          0,          0,          0,                    1,   14,   -1,   -1,  -17
    /// LUZ-A    "LUZON, Philippines"               CC           -133,      8,     -77,      11,     -51,       9,          0,          0,          0,                    1,   23,    3,  128,  115
    /// LUZ-B    "LUZON, Mindanao Island"           CC           -133,     25,     -79,      25,     -72,      25,          0,          0,          0,                    1,   12,    4,  128,  120
    /// ASM      "MONTSERRAT ISLAND ASTRO 1958"     CD            174,     25,     359,      25,     365,      25,          0,          0,          0,                    1,   18,   15,  -61,  -64
    /// MAS      "MASSAWA, Ethiopia"                BR            639,     25,     405,      25,      60,      25,          0,          0,          0,                    1,   25,    7,   53,   37
    /// MER      "MERCHICH, Morocco"                CD             31,      5,     146,       3,      47,       3,          0,          0,          0,                    1,   42,   22,    5,  -19
    /// MID      "MIDWAY ASTRO 1961, Midway Is."    IN            403,     25,     -81,      25,     277,      25,          0,          0,          0,                    1,   30,   25, -169, -180
    /// MIK      "MAHE 1971, Mahe Is."              CD             41,     25,    -220,      25,    -134,      25,          0,          0,          0,                    1,   -3,   -6,   57,   54
    /// MIN-A    "MINNA, Cameroon"                  CD            -81,     25,     -84,      25,     115,      25,          0,          0,          0,                    1,   19,   -4,   23,    3
    /// MIN-B    "MINNA, Nigeria"                   CD            -92,      3,     -93,       6,     122,       5,          0,          0,          0,                    1,   21,   -1,   20,   -4
    /// MPO      "M'PORALOKO, Gabon"                CD            -74,     25,    -130,      25,      42,      25,          0,          0,          0,                    1,    8,  -10,   20,    3
    /// NAH-A    "NAHRWAN, Masirah Island (Oman)"   CD           -247,     25,    -148,      25,     369,      25,          0,          0,          0,                    1,   22,   19,   60,   57
    /// NAH-B    "NAHRWAN, United Arab Emirates"    CD           -249,     25,    -156,      25,     381,      25,          0,          0,          0,                    1,   32,   17,   62,   45
    /// NAH-C    "NAHRWAN, Saudi Arabia"            CD           -243,     20,    -192,      20,     477,      20,          0,          0,          0,                    1,   38,    8,   62,   28
    /// NAP      "NAPARIMA, Trinidad & Tobago"      IN            -10,     15,     375,      15,     165,      15,          0,          0,          0,                    1,   13,    8,  -59,  -64
    /// NAR-A    "NORTH AMERICAN 1983, Alaska"      RF              0,      2,       0,       2,       0,       2,          0,          0,          0,                    1,   78,   48, -135, -175
    /// NAR-B    "NORTH AMERICAN 1983, Canada"      RF              0,      2,       0,       2,       0,       2,          0,          0,          0,                    1,   90,   36,  -50, -150
    /// NAR-C  * "NORTH AMERICAN 1983, CONUS"       RF              0,      2,       0,       2,       0,       2,          0,          0,          0,                    1,   60,   15,  -60, -135
    /// NAR-D    "NORTH AMERICAN 1983, Mexico"      RF              0,      2,       0,       2,       0,       2,          0,          0,          0,                    1,   35,   11,  -72, -122
    /// NAR-E    "NORTH AMERICAN 1983, Aleutian"    RF             -2,      5,       0,       2,       4,       5,          0,          0,          0,                    1,   74,   51,  180, -180
    /// NAR-H    "NORTH AMERICAN 1983, Hawaii"      RF              1,      2,       1,       2,      -1,       2,          0,          0,          0,                    1,   24,   17, -153, -164
    /// NAS-A    "NORTH AMERICAN 1927, Eastern US"  CC             -9,      5,     161,       5,     179,       8,          0,          0,          0,                    1,   55,   18,  -60, -102
    /// NAS-B    "NORTH AMERICAN 1927, Western US"  CC             -8,      5,     159,       3,     175,       3,          0,          0,          0,                    1,   55,   19,  -87, -132
    /// NAS-C  * "NORTH AMERICAN 1927, CONUS"       CC             -8,      5,     160,       5,     176,       6,          0,          0,          0,                    1,   60,   15,  -60, -135
    /// NAS-D    "NORTH AMERICAN 1927, Alaska"      CC             -5,      5,     135,       9,     172,       5,          0,          0,          0,                    1,   78,   47, -130, -175
    /// NAS-E    "NORTH AMERICAN 1927, Canada"      CC            -10,     15,     158,      11,     187,       6,          0,          0,          0,                    1,   90,   36,  -50, -150
    /// NAS-F    "NORTH AMERICAN 1927, Alberta/BC"  CC             -7,      8,     162,       8,     188,       6,          0,          0,          0,                    1,   65,   43, -105, -145
    /// NAS-G    "NORTH AMERICAN 1927, E. Canada"   CC            -22,      6,     160,       6,     190,       3,          0,          0,          0,                    1,   68,   38,  -45,  -85
    /// NAS-H    "NORTH AMERICAN 1927, Man/Ont"     CC             -9,      9,     157,       5,     184,       5,          0,          0,          0,                    1,   63,   36,  -69, -108
    /// NAS-I    "NORTH AMERICAN 1927, NW Terr."    CC              4,      5,     159,       5,     188,       3,          0,          0,          0,                    1,   90,   43,  -55, -144
    /// NAS-J    "NORTH AMERICAN 1927, Yukon"       CC             -7,      5,     139,       8,     181,       3,          0,          0,          0,                    1,   75,   53, -117, -147
    /// NAS-L    "NORTH AMERICAN 1927, Mexico"      CC            -12,      8,     130,       6,     190,       6,          0,          0,          0,                    1,   38,   10,  -80, -122
    /// NAS-N    "NORTH AMERICAN 1927, C. America"  CC              0,      8,     125,       3,     194,       5,          0,          0,          0,                    1,   25,    3,  -77,  -98
    /// NAS-O    "NORTH AMERICAN 1927, Canal Zone"  CC              0,     20,     125,      20,     201,      20,          0,          0,          0,                    1,   15,    3,  -74,  -86
    /// NAS-P    "NORTH AMERICAN 1927, Caribbean"   CC             -3,      3,     142,       9,     183,      12,          0,          0,          0,                    1,   29,    8,  -58,  -87
    /// NAS-Q    "NORTH AMERICAN 1927, Bahamas"     CC             -4,      5,     154,       3,     178,       5,          0,          0,          0,                    1,   29,   19,  -71,  -83
    /// NAS-R    "NORTH AMERICAN 1927, San Salv."   CC              1,     25,     140,      25,     165,      25,          0,          0,          0,                    1,   26,   23,  -74,  -75
    /// NAS-T    "NORTH AMERICAN 1927, Cuba"        CC             -9,     25,     152,      25,     178,      25,          0,          0,          0,                    1,   25,   18,  -72,  -87
    /// NAS-U    "NORTH AMERICAN 1927, Greenland"   CC             11,     25,     114,      25,     195,      25,          0,          0,          0,                    1,   81,   74,  -56,  -74
    /// NAS-V    "NORTH AMERICAN 1927, Aleutian E"  CC             -2,      6,     152,       8,     149,      10,          0,          0,          0,                    1,   58,   50, -161, -180
    /// NAS-w    "NORTH AMERICAN 1927, Aleutian w"  CC              2,     10,     204,      10,     105,      10,          0,          0,          0,                    1,   58,   50,  180,  169
    /// NSD      "NORTH SAHARA 1959, Algeria"       CD           -186,     25,     -93,      25,     310,      25,          0,          0,          0,                    1,   43,   13,   18,  -15
    /// FAH      "OMAN"                             CD           -346,      3,      -1,       3,     224,       9,          0,          0,          0,                    1,   32,   10,   65,   46
    /// FLO      "OBSERVATORIO MET. 1939, Flores"   IN           -425,     20,    -169,      20,      81,      20,          0,          0,          0,                    1,   41,   38,  -30,  -33
    /// OEG      "OLD EGYPTIAN 1907"                HE           -130,      3,     110,       6,     -13,       8,          0,          0,          0,                    1,   38,   16,   42,   19
    /// OGB-M    "ORDNANCE GB 1936, Mean (3 Para)"  AA            375,     10,    -111,      10,     431,      15,          0,          0,          0,                    1,   66,   44,    7,  -14
    /// OGB-A    "ORDNANCE GB 1936, England"        AA            371,      5,    -112,       5,     434,       6,          0,          0,          0,                    1,   61,   44,    7,  -12
    /// OGB-B    "ORDNANCE GB 1936, Eng., Wales"    AA            371,     10,    -111,      10,     434,      15,          0,          0,          0,                    1,   61,   44,    7,  -12
    /// OGB-C    "ORDNANCE GB 1936, Scotland"       AA            384,     10,    -111,      10,     425,      10,          0,          0,          0,                    1,   66,   49,    4,  -14
    /// OGB-D    "ORDNANCE GB 1936, Wales"          AA            370,     20,    -108,      20,     434,      20,          0,          0,          0,                    1,   59,   46,    3,  -11
    /// OHA-M    "OLD HAWAIIAN (CC), Mean"          CC             61,     25,    -285,      20,    -181,      20,          0,          0,          0,                    1,   24,   17, -153, -164
    /// OHA-A    "OLD HAWAIIAN (CC), Hawaii"        CC             89,     25,    -279,      25,    -183,      25,          0,          0,          0,                    1,   22,   17, -153, -158
    /// OHA-B    "OLD HAWAIIAN (CC), Kauai"         CC             45,     20,    -290,      20,    -172,      20,          0,          0,          0,                    1,   24,   20, -158, -161
    /// OHA-C    "OLD HAWAIIAN (CC), Maui"          CC             65,     25,    -290,      25,    -190,      25,          0,          0,          0,                    1,   23,   19, -154, -158
    /// OHA-D    "OLD HAWAIIAN (CC), Oahu"          CC             58,     10,    -283,       6,    -182,       6,          0,          0,          0,                    1,   23,   20, -156, -160
    /// OHI-M    "OLD HAWAIIAN (IN), Mean"          IN            201,     25,    -228,      20,    -346,      20,          0,          0,          0,                    1,   24,   17, -153, -164
    /// OHI-A    "OLD HAWAIIAN (IN), Hawaii"        IN            229,     25,    -222,      25,    -348,      25,          0,          0,          0,                    1,   22,   17, -153, -158
    /// OHI-B    "OLD HAWAIIAN (IN), Kauai"         IN            185,     20,    -233,      20,    -337,      20,          0,          0,          0,                    1,   24,   20, -158, -161
    /// OHI-C    "OLD HAWAIIAN (IN), Maui"          IN            205,     25,    -233,      25,    -355,      25,          0,          0,          0,                    1,   23,   19, -154, -158
    /// OHI-D    "OLD HAWAIIAN (IN), Oahu"          IN            198,     10,    -226,       6,    -347,       6,          0,          0,          0,                    1,   23,   20, -156, -160
    /// HIT      "PROVISIONAL SOUTH CHILEAN 1963"   IN             16,     25,     196,      25,      93,      25,          0,          0,          0,                    1,  -25,  -64,  -60,  -83
    /// PIT      "PITCAIRN ASTRO 1967"              IN            185,     25,     165,      25,      42,      25,          0,          0,          0,                    1,  -21,  -27, -119, -134
    /// PLN      "PICO DE LAS NIEVES, Canary Is."   IN           -307,     25,     -92,      25,     127,      25,          0,          0,          0,                    1,   31,   26,  -12,  -20
    /// POS      "PORTO SANTO 1936, Madeira Is."    IN           -499,     25,    -249,      25,     314,      25,          0,          0,          0,                    1,   35,   31,  -15,  -18
    /// PRP-A    "PROV. S AMERICAN 1956, Bolivia"   IN           -270,      5,     188,      11,    -388,      14,          0,          0,          0,                    1,   -4,  -28,  -51,  -75
    /// PRP-B    "PROV. S AMERICAN 1956, N Chile"   IN           -270,     25,     183,      25,    -390,      25,          0,          0,          0,                    1,  -12,  -45,  -60,  -83
    /// PRP-C    "PROV. S AMERICAN 1956, S Chile"   IN           -305,     20,     243,      20,    -442,      20,          0,          0,          0,                    1,  -20,  -64,  -60,  -83
    /// PRP-D    "PROV. S AMERICAN 1956, Colombia"  IN           -282,     15,     169,      15,    -371,      15,          0,          0,          0,                    1,   16,  -10,  -61,  -85
    /// PRP-E    "PROV. S AMERICAN 1956, Ecuador"   IN           -278,      3,     171,       5,    -367,       3,          0,          0,          0,                    1,    7,  -11,  -70,  -85
    /// PRP-F    "PROV. S AMERICAN 1956, Guyana"    IN           -298,      6,     159,      14,    -369,       5,          0,          0,          0,                    1,   14,   -4,  -51,  -67
    /// PRP-G    "PROV. S AMERICAN 1956, Peru"      IN           -279,      6,     175,       8,    -379,      12,          0,          0,          0,                    1,    5,  -24,  -63,  -87
    /// PRP-H    "PROV. S AMERICAN 1956, Venez"     IN           -295,      9,     173,      14,    -371,      15,          0,          0,          0,                    1,   18,   -5,  -54,  -79
    /// PRP-M    "PROV. S AMERICAN 1956, Mean"      IN           -288,     17,     175,      27,    -376,      27,          0,          0,          0,                    1,   18,  -64,  -51,  -87
    /// PTB      "POINT 58, Burkina Faso & Niger"   CD           -106,     25,    -129,      25,     165,      25,          0,          0,          0,                    1,   10,    0,   25,  -15
    /// PTN      "POINT NOIRE 1948, Congo"          CD           -148,     25,      51,      25,    -291,      25,          0,          0,          0,                    1,   10,  -11,   25,    5
    /// PUK      "PULKOVO 1942, Russia"             KA             28,     -1,    -130,      -1,     -95,      -1,          0,          0,          0,                    1,   89,   36,  180, -180
    /// PUR      "PUERTO RICO & Virgin Is."         CC             11,      3,      72,       3,    -101,       3,          0,          0,          0,                    1,   20,   16,  -63,  -69
    /// QAT      "QATAR NATIONAL"                   IN           -128,     20,    -283,      20,      22,      20,          0,          0,          0,                    1,   32,   19,   57,   45
    /// QUO      "QORNOQ, South Greenland"          IN            164,     25,     138,      25,    -189,      32,          0,          0,          0,                    1,   85,   57,   -7,  -77
    /// REU      "REUNION, Mascarene Is."           IN             94,     25,    -948,      25,   -1262,      25,          0,          0,          0,                    1,  -12,  -27,   65,   47
    /// MOD      "ROME 1940, Sardinia"              IN           -225,     25,     -65,      25,       9,      25,          0,          0,          0,                    1,   43,   37,   12,    6
    /// SAE      "SANTO (DOS) 1965"                 IN            170,     25,      42,      25,      84,      25,          0,          0,          0,                    1,  -11,  -20,  172,  163
    /// SAO      "SAO BRAZ, Santa Maria Is."        IN           -203,     25,     141,      25,      53,      25,          0,          0,          0,                    1,   39,   35,  -23,  -27
    /// SAP      "SAPPER HILL 1943, E Falkland Is"  IN           -355,      1,      21,       1,      72,       1,          0,          0,          0,                    1,  -50,  -54,  -56,  -61
    /// SAN-M    "SOUTH AMERICAN 1969, Mean"        SA            -57,     15,       1,       6,     -41,       9,          0,          0,          0,                    1,  -50,  -65,  -25,  -90
    /// SAN-A    "SOUTH AMERICAN 1969, Argentina"   SA            -62,      5,      -1,       5,     -37,       5,          0,          0,          0,                    1,  -20,  -62,  -47,  -76
    /// SAN-B    "SOUTH AMERICAN 1969, Bolivia"     SA            -61,     15,       2,      15,     -48,      15,          0,          0,          0,                    1,   -4,  -28,  -51,  -75
    /// SAN-C    "SOUTH AMERICAN 1969, Brazil"      SA            -60,      3,      -2,       5,     -41,       5,          0,          0,          0,                    1,    9,  -39,  -29,  -80
    /// SAN-D    "SOUTH AMERICAN 1969, Chile"       SA            -75,     15,      -1,       8,     -44,      11,          0,          0,          0,                    1,  -12,  -64,  -60,  -83
    /// SAN-E    "SOUTH AMERICAN 1969, Colombia"    SA            -44,      6,       6,       6,     -36,       5,          0,          0,          0,                    1,   16,  -10,  -61,  -85
    /// SAN-F    "SOUTH AMERICAN 1969, Ecuador"     SA            -48,      3,       3,       3,     -44,       3,          0,          0,          0,                    1,    7,  -11,  -70,  -85
    /// SAN-G    "SOUTH AMERICAN 1969, Guyana"      SA            -53,      9,       3,       5,     -47,       5,          0,          0,          0,                    1,   14,   -4,  -51,  -67
    /// SAN-H    "SOUTH AMERICAN 1969, Paraguay"    SA            -61,     15,       2,      15,     -33,      15,          0,          0,          0,                    1,  -14,  -33,  -49,  -69
    /// SAN-I    "SOUTH AMERICAN 1969, Peru"        SA            -58,      5,       0,       5,     -44,       5,          0,          0,          0,                    1,    5,  -24,  -63,  -87
    /// SAN-J    "SOUTH AMERICAN 1969, Baltra"      SA            -47,     25,      26,      25,     -42,      25,          0,          0,          0,                    1,    1,   -2,  -89,  -92
    /// SAN-K    "SOUTH AMERICAN 1969, Trinidad"    SA            -45,     25,      12,      25,     -33,      25,          0,          0,          0,                    1,   17,    4,  -55,  -68
    /// SAN-L    "SOUTH AMERICAN 1969, Venezuela"   SA            -45,      3,       8,       6,     -33,       3,          0,          0,          0,                    1,   18,   -5,  -54,  -79
    /// SCK      "SCHWARZECK, Namibia"              BN            616,     20,      97,      20,    -251,      20,          0,          0,          0,                    1,  -11,  -35,   31,    5
    /// SGM      "SELVAGEM GRANDE 1938, Salvage Is" IN           -289,     25,    -124,      25,      60,      25,          0,          0,          0,                    1,   32,   28,  -14,  -18
    /// CCD      "S-JTSK, Czech Republic"           BR            589,      4,      76,       2,     480,       3,          0,          0,          0,                    1,   56,   43,   28,    6
    /// SOA      "SOUTH ASIA, Singapore"            FA              7,     25,     -10,      25,     -26,      25,          0,          0,          0,                    1,    3,    0,  106,  102
    /// SPK-A    "S-42 (PULKOVO 1942), Hungary"     KA             28,      2,    -121,       2,     -77,       2,          0,          0,          0,                    1,   54,   40,   29,   11
    /// SPK-B    "S-42 (PULKOVO 1942), Poland"      KA             23,      4,    -124,       2,     -82,       4,          0,          0,          0,                    1,   60,   43,   30,    8
    /// SPK-C    "S-42 (PK42) Former Czechoslov."   KA             26,      3,    -121,       3,     -78,       2,          0,          0,          0,                    1,   57,   42,   28,    6
    /// SPK-D    "S-42 (PULKOVO 1942), Latvia"      KA             24,      2,    -124,       2,     -82,       2,          0,          0,          0,                    1,   64,   50,   34,   15
    /// SPK-E    "S-42 (PK 1942), Kazakhstan"       KA             15,     25,    -130,      25,     -84,      25,          0,          0,          0,                    1,   62,   35,   93,   41
    /// SPK-F    "S-42 (PULKOVO 1942), Albania"     KA             24,      3,    -130,       3,     -92,       3,          0,          0,          0,                    1,   48,   34,   26,   14
    /// SPK-G    "S-42 (PULKOVO 1942), Romania"     KA             28,      3,    -121,       5,     -77,       3,          0,          0,          0,                    1,   54,   38,   35,   15
    /// SIR      "SIRGAS, South America"            RF              0,      1,       0,       1,       0,       1,          0,          0,          0,                    1,  -50,  -65,  -25,  -90
    /// SRL      "SIERRA LEONE 1960"                CD            -88,     15,       4,      15,     101,      15,          0,          0,          0,                    1,   16,    1,   -4,  -19
    /// TAN      "TANANARIVE OBSERVATORY 1925"      IN           -189,     -1,    -242,      -1,     -91,      -1,          0,          0,          0,                    1,   -8,  -34,   53,   40
    /// TIL      "TIMBALAI 1948, Brunei & E Malay"  EB           -679,     10,     669,      10,     -48,      12,          0,          0,          0,                    1,   15,   -5,  125,  101
    /// TOY-M    "TOKYO, Mean"                      BR           -148,     20,     507,       5,     685,      20,          0,          0,          0,                    1,   53,   23,  155,  120
    /// TOY-A    "TOKYO, Japan"                     BR           -148,      8,     507,       5,     685,       8,          0,          0,          0,                    1,   51,   19,  156,  119
    /// TOY-B    "TOKYO, South Korea"               BR           -146,      8,     507,       5,     687,       8,          0,          0,          0,                    1,   45,   27,  139,  120
    /// TOY-B1   "TOKYO, South Korea"               BR           -147,      2,     506,       2,     687,       2,          0,          0,          0,                    1,   45,   27,  139,  120
    /// TOY-C    "TOKYO, Okinawa"                   BR           -158,     20,     507,       5,     676,      20,          0,          0,          0,                    1,   31,   19,  134,  119
    /// TDC      "TRISTAN ASTRO 1968"               IN           -632,     25,     438,      25,    -609,      25,          0,          0,          0,                    1,  -36,  -39,  -11,  -14
    /// MVS      "VITI LEVU 1916, Viti Levu Is."    CD             51,     25,     391,      25,     -36,      25,          0,          0,          0,                    1,  -16,  -20,  180,  176
    /// VOI      "VOIROL 1874, Algeria"             CD            -73,     -1,    -247,      -1,     227,      -1,          0,          0,          0,                    1,   43,   13,   18,  -15
    /// VOR      "VOIROL 1960, Algeria"             CD           -123,     25,    -206,      25,     219,      25,          0,          0,          0,                    1,   43,   13,   18,  -15
    /// ENW      "WAKE-ENIWETOK 1960"               HO            102,      3,      52,       3,     -38,       3,          0,          0,          0,                    1,   16,    1,  175,  159
    /// WAK      "WAKE ISLAND ASTRO 1952"           IN            276,     25,     -57,      25,     149,      25,          0,          0,          0,                    1,   21,   17,  168,  164
    /// YAC      "YACARE, Uruguay"                  IN           -155,     -1,     171,      -1,      37,      -1,          0,          0,          0,                    1,  -25,  -40,  -47,  -65
    /// ZAN      "ZANDERIJ, Suriname"               IN           -265,      5,     120,       5,    -358,       8,          0,          0,          0,                    1,   20,  -10,  -47,  -76
    /// </remarks>
    public static class DatumFactory
    {
        //A static Dictionary of Datums keyed by DatumType | DatumType + Name (in the case of user defined datums)
        //such that GetInstanceOfDatum first checks to see if the requested datum already
        //exists and returns that rather than instantiating a new (duplicate) Datum
        private static Dictionary<string, IDatum> _datumList = new Dictionary<string, IDatum>();
        private static object _datumListLock = new object();

        /// <summary>
        /// Gets the instance of the Datum specified by datumType.
        /// If an instance does not exist, one is created.
        /// </summary>
        /// <param name="datumType">The type of datum you want.  Undefined and UserDefined are considered invalid.</param>
        /// <returns>The datum instance associated with datumType.</returns>
        /// <remarks>
        /// If you want retrieve an instance of a UserDefined Datum, use the 
        /// GetInstanceOfNewUserDefinedDatum() or GetInstanceOfExistingUserDefinedDatum() methods, as a Name
        /// must be included with the DatumType to distinguish between various User Defined datums.
        /// </remarks>
        /// <exception cref="Exceptions.InvalidDatumTypeException">Thrown on DatumType.Undefined</exception>
        /// <exception cref="Exceptions.AmbiguousDatumTypeException">Thrown on DatumType.UserDefined.</exception>
        public static IDatum GetInstanceOfDatum(Type datumType)
        {
            ArgumentNullException.ThrowIfNull(datumType);
            if (datumType.Equals(typeof(Datums.UserDefined))) throw new Exceptions.AmbiguousDatumTypeException();
            if (!DatumTypeExists(datumType.Name)) throw new Exceptions.InvalidDatumTypeException();
            if (datumType.GetInterface("IDatum") != typeof(IDatum)) throw new Exceptions.InvalidDatumTypeException();

            if (!_datumList.ContainsKey(datumType.Name))
            {
                IDatum d = (IDatum)(datumType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Array.Empty<Type>(), null) ?? throw new Exceptions.InvalidDatumTypeException()).Invoke(Array.Empty<object>());
                lock (_datumListLock)
                {
                    _datumList.TryAdd(d.Key, d);
                }
            }
            return _datumList[datumType.Name];
        }
        public static IDatum GetInstanceOfDatum(string datumTypeName)
        {
            ArgumentNullException.ThrowIfNull(datumTypeName);

            if (datumTypeName.Equals(typeof(Datums.UserDefined).Name, StringComparison.Ordinal)) throw new Exceptions.AmbiguousDatumTypeException();
            if (!DatumTypeExists(datumTypeName)) throw new Exceptions.InvalidDatumTypeException();

            Type datumType = GetDatumType(datumTypeName);
            return GetInstanceOfDatum(datumType);
        }
        public static bool DatumTypeExists(string datumTypeName)
        {
            ArgumentException.ThrowIfNullOrEmpty(datumTypeName);
            if (datumTypeName.Equals(typeof(Datums.Undefined).Name, StringComparison.Ordinal)) return false;
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Namespace == typeof(Datums.Undefined).Namespace && types[i].Name.Equals(datumTypeName, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }
        public static Type GetDatumType(string datumTypeName)
        {
            ArgumentNullException.ThrowIfNull(datumTypeName);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Equals(datumTypeName, StringComparison.Ordinal))
                {
                    return types[i];
                }
            }
            return typeof(Datums.Undefined);
        }

        /// <summary>
        /// Checks to see if a UserDefined Datum has been intantiated for name.
        /// This version of the function is agnostic of the ellipsoid of the datum.
        /// </summary>
        /// <param name="name">The name of the UserDefined Datum you are looking for.</param>
        /// <returns>True if an Datum has been intantiated with this name; otherwise, false.</returns>
        /// <remarks>
        /// This (agnostic) version of the function should only be used if you have control of the 
        /// UserDefined datums in your application and are certain that the datum you are looking
        /// for will always have the same Ellipsoid values.
        /// 
        /// If, for example, you are reading Datums from an input file or from user input, you should
        /// be using the more precise version of this function.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidDatumException">Thrown if name is incorrectly formatted.</exception>
        public static bool UserDefinedDatumExists(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            if (!StringUtil.IsValid(name, Datum.ValidNamePattern)) throw new Exceptions.InvalidDatumTypeException("Invalid format for datum name.");

            return _datumList.ContainsKey(typeof(Datums.UserDefined).Name + name);
        }

        /// <summary>
        /// Checks to see if a UserDefined Datum has been instantiated for name, ellipsoid, deltaX, sigmaX, deltaY, sigmaY, deltaZ, sigmaZ, rotationX, rotationY, rotationZ, rotationScaleFactor, north, south, east, and west.
        /// </summary>
        /// <param name="name">The Name of the UserDefined Datum you are looking for.</param>
        /// <param name="ellipsoid">The Ellipsoid of the Datum you are looking for.</param>
        /// <param name="deltaX"></param>
        /// <param name="sigmaX"></param>
        /// <param name="deltaY"></param>
        /// <param name="sigmaY"></param>
        /// <param name="deltaZ"></param>
        /// <param name="sigmaZ"></param>
        /// <param name="rotationX"></param>
        /// <param name="rotationY"></param>
        /// <param name="rotationZ"></param>
        /// <param name="rotationScaleFactor"></param>
        /// <param name="north"></param>
        /// <param name="south"></param>
        /// <param name="east"></param>
        /// <param name="west"></param>
        /// <returns>True if a UserDefined Datum has been intantiated with this name and ellipsoid; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidDatumException">Thrown if name is incorrectly formatted.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if west is not less than east or if south is not less than north.</exception>
        public static bool UserDefinedDatumExists(string name, IEllipsoid ellipsoid, double deltaX, double sigmaX, double deltaY, double sigmaY, double deltaZ, double sigmaZ, double rotationX, double rotationY, double rotationZ, double rotationScaleFactor, double north, double south, double east, double west)
        {
            ArgumentNullException.ThrowIfNull(name);
            if (!StringUtil.IsValid(name, Datum.ValidNamePattern)) throw new Exceptions.InvalidDatumTypeException("Invalid format for datum name.");
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(south, north);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(west, east);

            string key = typeof(Datums.UserDefined).Name + name;
            if (!_datumList.ContainsKey(key)) return false;
            IDatum d = _datumList[key];
            if (!((d.Ellipsoid.Equals(ellipsoid)) &&
                   d.DeltaX.Equals(deltaX) &&
                   d.SigmaX.Equals(sigmaX) &&
                   d.DeltaY.Equals(deltaY) &&
                   d.SigmaY.Equals(sigmaY) &&
                   d.DeltaZ.Equals(deltaZ) &&
                   d.SigmaZ.Equals(sigmaZ) &&
                   d.RotationX.Equals(rotationX) &&
                   d.RotationY.Equals(rotationY) &&
                   d.RotationZ.Equals(rotationZ) &&
                   d.RotationScaleFactor.Equals(rotationScaleFactor) &&
                   d.Domain.Top.Equals(north) &&
                   d.Domain.Bottom.Equals(south) &&
                   d.Domain.Right.Equals(east) &&
                   d.Domain.Left.Equals(west))) return false;
            return true;
        }

        /// <summary>
        /// Instantiates a UserDefined Datum.
        /// </summary>
        /// <param name="name">The Name of the new Datum.</param>
        /// <param name="ellipsoid">The Ellipsoid of the new Datum.</param>
        /// <param name="deltaX"></param>
        /// <param name="sigmaX"></param>
        /// <param name="deltaY"></param>
        /// <param name="sigmaY"></param>
        /// <param name="deltaZ"></param>
        /// <param name="sigmaZ"></param>
        /// <param name="rotationX"></param>
        /// <param name="rotationY"></param>
        /// <param name="rotationZ"></param>
        /// <param name="rotationScaleFactor"></param>
        /// <param name="north"></param>
        /// <param name="south"></param>
        /// <param name="east"></param>
        /// <param name="west"></param>
        /// <returns>The instance of the new datum.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidDatumTypeException">Thrown if the name is incorrectly formatted.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if west is not less than east or if south is not less than north.</exception>
        public static IDatum GetInstanceOfNewUserDefinedDatum(string name, IEllipsoid ellipsoid, double deltaX, double sigmaX, double deltaY, double sigmaY, double deltaZ, double sigmaZ, double rotationX, double rotationY, double rotationZ, double rotationScaleFactor, double north, double south, double east, double west)
        {
            ArgumentNullException.ThrowIfNull(name);
            if (!StringUtil.IsValid(name, Datum.ValidNamePattern)) throw new Exceptions.InvalidDatumTypeException("Invalid format for datum name.");
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(south, north);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(west, east);

            try
            {
                string key = typeof(Datums.UserDefined).Name + name;
                if (!_datumList.ContainsKey(key))
                {
                    Datums.UserDefined d = new Datums.UserDefined(name, ellipsoid, deltaX, sigmaX, deltaY, sigmaY, deltaZ, sigmaZ, rotationX, rotationY, rotationZ, rotationScaleFactor, north, south, east, west);
                    lock (_datumListLock)
                    {
                        if (!_datumList.ContainsKey(d.Key))
                        {
                            _datumList.Add(d.Key, d);
                        }
                    }
                    return _datumList[d.Key];
                }
                else
                {
                    Datums.UserDefined d = (Datums.UserDefined)_datumList[key];
                    if (!((d.Ellipsoid.Equals(ellipsoid)) &&
                           d.DeltaX.Equals(deltaX) &&
                           d.SigmaX.Equals(sigmaX) &&
                           d.DeltaY.Equals(deltaY) &&
                           d.SigmaY.Equals(sigmaY) &&
                           d.DeltaZ.Equals(deltaZ) &&
                           d.SigmaZ.Equals(sigmaZ) &&
                           d.RotationX.Equals(rotationX) &&
                           d.RotationY.Equals(rotationY) &&
                           d.RotationZ.Equals(rotationZ) &&
                           d.RotationScaleFactor.Equals(rotationScaleFactor) &&
                           d.Domain.Top.Equals(north) &&
                           d.Domain.Bottom.Equals(south) &&
                           d.Domain.Right.Equals(east) &&
                           d.Domain.Left.Equals(west))) throw new Exceptions.AmbiguousDatumTypeException("Datum for name already exists with different Ellipsoid values.");
                    return d;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DatumFactory.GetInstanceOfNewUserDefinedDatum(string, Ellipsoid)", ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the instance of the specified UserDefined Datum.
        /// </summary>
        /// <param name="name">The Name of the Datum you are looking for.</param>
        /// <returns>The Datum you are looking for.</returns>
        /// <exception cref="ArgumentNullException">Thrown if name is null.</exception>
        /// <exception cref="Exceptions.InvalidDatumTypeException">Thrown if name is incorrectly formatted OR if the instance could not be found.</exception>
        public static IDatum GetInstanceOfExistingUserDefinedDatum(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            if (!StringUtil.IsValid(name, Datum.ValidNamePattern)) throw new Exceptions.InvalidDatumTypeException("Invalid format for datum name.");

            try
            {
                string key = typeof(Datums.UserDefined).Name + name;
                if (!_datumList.ContainsKey(key)) throw new Exceptions.InvalidDatumTypeException("A UserDefined Datum could not be found for name.");
                return _datumList[key];
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "DatumFactory.GetInstanceOfExitingUserDefinedDatum(string)", ex);
                throw;
            }
        }
    }
}


