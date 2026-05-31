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
    /// A set of comparison "modes" for use within the StarThrower Utilities.
    /// </summary>
    public enum ComparisonType
    {
        /// <summary>
        /// Case Sensitive comparison
        /// </summary>
        CaseSensitive = 0,

        /// <summary>
        /// Case In-Sensitive comparision
        /// </summary>
        CaseInsensitive = 1,

        /// <summary>
        /// Comparison using the invariant culture 
        /// </summary>
        Database = 2
    }
}
