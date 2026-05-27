/***********************************************************************************
    StarThrower Utilities
    Copyright (C) 2005-2007  Steve Elmer

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

namespace StarThrower.Gis.GeoUtilities.Datums
{
    /// <summary>
    /// Used for implementation of the null object design pattern.
    /// </summary>
    public class Undefined : Datum
    {
        public override bool IsSevenParamDatum
        {
            get { return false; }
        }

        internal Undefined()
        {
            this.Ellipsoid = new Ellipsoids.Undefined();
            this.DeltaX = 0.0;
            this.SigmaX = -1.0;
            this.DeltaY = 0.0;
            this.SigmaY = -1.0;
            this.DeltaZ = 0.0;
            this.SigmaZ = 0.0;
            this.RotationX = 0.0;
            this.RotationY = 0.0;
            this.RotationZ = 0.0;
            this.RotationScaleFactor = 1.0;
            this.Domain.Top = 90.0;
            this.Domain.Left = -180.0;
            this.Domain.Bottom = -90.0;
            this.Domain.Right = 180.0;
        }
    }
}
