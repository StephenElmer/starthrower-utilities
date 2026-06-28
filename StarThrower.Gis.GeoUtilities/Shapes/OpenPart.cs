// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// A <see cref="Part"/> representing an open line, used to build up the parts of a <see cref="PolylineShape"/>.
    /// </summary>
    public class OpenPart : StarThrower.Gis.GeoUtilities.Shapes.Part
    {
        #region Construction

        /// <summary>
        /// Initializes a new, empty instance of <see cref="OpenPart"/>.
        /// </summary>
        public OpenPart() : base() { }

        /// <summary>
        /// Initializes a new instance of <see cref="OpenPart"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public OpenPart(StarThrower.Gis.GeoUtilities.Shapes.OpenPart other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this part.
        /// </summary>
        /// <returns>A new <see cref="OpenPart"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.OpenPart(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type OpenPart.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            OpenPart other = (OpenPart)value;

            base.ItemCopy(other);
        }

        #endregion
    }
}


