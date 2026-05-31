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

namespace StarThrower.Gis.GeoUtilities.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a UserDefined CoordinateSystem is encountered w/out a qualifying Name for the Ellipsoid.
    /// </summary>
    public class AmbiguousCoordinateSystemException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the AmbiguousCoordinateSystemException class.
        /// </summary>
        public AmbiguousCoordinateSystemException() : base() { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousCoordinateSystemException class with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public AmbiguousCoordinateSystemException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the AmbiguousCoordinateSystemException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public AmbiguousCoordinateSystemException(string message, Exception innerException) : base(message, innerException) { }
    }
}


