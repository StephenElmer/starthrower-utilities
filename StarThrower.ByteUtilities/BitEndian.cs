/***********************************************************************************
    StarThrower Utilities / ByteUtilities
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

namespace StarThrower.ByteUtilities
{
    /// <summary>
    /// The order of bits in a byte.
    /// </summary>
    public enum BitEndian
    {
        /// <summary>
        /// Little Endian bit order
        /// </summary>
        Little = 0,

        /// <summary>
        /// Big Endian bit order
        /// </summary>
        Big = 1
    };
}
