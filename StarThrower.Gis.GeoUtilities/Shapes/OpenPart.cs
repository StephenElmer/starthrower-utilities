// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.Logging;

namespace StarThrower.Gis.GeoUtilities.Shapes
{
    public class OpenPart : StarThrower.Gis.GeoUtilities.Shapes.Part
    {
        #region Construction

        public OpenPart() : base() { }

        public OpenPart(StarThrower.Gis.GeoUtilities.Shapes.OpenPart other) : this()
        {
            this.ItemCopy(other);
        }

        #endregion


        #region ICloneable Members

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
            try
            {
                ArgumentNullException.ThrowIfNull(value);
                OpenPart other = (OpenPart)value;

                base.ItemCopy(other);
            }
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, this.GetType().Name + ".ItemCopy(object)", ex);
                throw;
            }
        }

        #endregion
    }
}


