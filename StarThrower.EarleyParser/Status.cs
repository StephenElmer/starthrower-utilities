/***********************************************************************************
    StarThrower Utilities / EarleyParser
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

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Reflects the status of a parse completed by an Earley parser.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Signals that a string is rejected after parsing.
        /// </summary>
        Reject = 0,

        /// <summary>
        /// Means that a string is a valid string of a given grammar as determined by parsing.
        /// </summary>
        Accept = 1,

        /// <summary>
        /// Used for parses where an error occurs during processing.
        /// </summary>
        Error = 2
    }
}
