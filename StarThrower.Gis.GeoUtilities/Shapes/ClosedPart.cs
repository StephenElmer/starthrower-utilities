// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Gis.GeoUtilities.Exceptions;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    /// <summary>
    /// A <see cref="Part"/> representing a closed ring, used to build up the rings of a <see cref="PolygonShape"/>.
    /// </summary>
    public class ClosedPart : StarThrower.Gis.GeoUtilities.Shapes.Part
    {
        #region Construction

        /// <summary>
        /// Initializes a new, empty instance of <see cref="ClosedPart"/>.
        /// </summary>
        public ClosedPart() : base() { }

        /// <summary>
        /// Initializes a new instance of <see cref="ClosedPart"/> as a copy of another instance.
        /// </summary>
        /// <param name="other">The instance to copy.</param>
        public ClosedPart(StarThrower.Gis.GeoUtilities.Shapes.ClosedPart other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

        /// <summary>
        /// Creates a deep copy of this part.
        /// </summary>
        /// <returns>A new <see cref="ClosedPart"/> that is a copy of this instance.</returns>
        public override object Clone()
        {
            return new StarThrower.Gis.GeoUtilities.Shapes.ClosedPart(this);
        }

        #endregion


        #region IItemCopyable Members

        /// <summary>
        /// Sets the state of the current instance equal to a copy of the state of some other instance.
        /// </summary>
        /// <param name="value">This instance you wish this to be a copy of.  Must be of type ClosedPart.</param>
        /// <exception cref="FailedItemCopyException"></exception>
        public override void ItemCopy(object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            ClosedPart other = (ClosedPart)value;

            base.ItemCopy(other);
        }

        #endregion
    }
}


