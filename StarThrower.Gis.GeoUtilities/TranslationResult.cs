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

namespace StarThrower.Gis.GeoUtilities
{
    /// <summary>
    /// The abstract base class for TranslationResults.  Translation results
    /// are returned from the various translation methods used for converting
    /// coordinates from one coordinate system to another.
    /// </summary>
    public abstract class TranslationResult : ITranslationResult
    {
        #region Private Instance Variables

        private double _xLon;
        private double _yLat;
        private double _zAlt;

        private double _ce90; //Combined 90% circular horizontal error in meters
        private double _le90; //Combined 90% linear vertical error in meters
        private double _se90; //Combined 90% spherical error in meters

        #endregion


        #region Public Properties

        public virtual double xLon 
        { 
            get { return _xLon; }
            protected set { _xLon = value; }
        }
        
        public virtual double yLat 
        { 
            get { return _yLat; }
            protected set { _yLat = value; }
        }
        
        public virtual double zAlt 
        { 
            get { return _zAlt; }
            protected set { _zAlt = value; }
        }

        public virtual double ce90
        {
            get { return _ce90; }
            protected set { _ce90 = value; }
        }

        public virtual double le90
        {
            get { return _le90; }
            protected set { _le90 = value; }
        }

        public virtual double se90
        {
            get { return _se90; }
            set { _se90 = value; }
        }

        #endregion


        #region Public Methods

        public void SetComputationalError(double ce90, double le90, double se90)
        {
            _ce90 = ce90;
            _le90 = le90;
            _se90 = se90;
        }

        #endregion
    }
}


