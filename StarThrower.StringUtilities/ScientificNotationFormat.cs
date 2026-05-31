/***********************************************************************************
    StarThrower Utilities / StringUtilities
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

namespace StarThrower.StringUtilities
{
    /// <summary>
    /// A set of formats for representing scientific notation
    /// </summary>
    public enum ScientificNotationFormat
    {
        /// <summary>
        /// The standard scientific notation:  123E+4
        /// </summary>
        Exponential = 0,

        /// <summary>
        /// Base ten scientific notation:  123x10^+4
        /// </summary>
        Base10 = 1,

        /// <summary>
        /// Base ten scientific notation w/ spaces:  123 x 10^+4
        /// </summary>
        Base10Spaced = 2,

        /// <summary>
        /// Base ten scientific notation with superscripts:  123x10+4
        /// </summary>
        Base10Superscript = 3,

        /// <summary>
        /// Base ten scientific notation with superscripts and spaces:  123 x 10+4
        /// </summary>
        Base10SuperscriptSpaced = 4
    }
}
