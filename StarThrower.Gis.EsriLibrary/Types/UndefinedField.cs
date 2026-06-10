// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

namespace StarThrower.Gis.EsriLibrary.Types
{
    public class UndefinedField : StarThrower.Gis.EsriLibrary.Types.FieldType
    {
        #region Private Member Variables

        private StarThrower.XBase.UndefinedField _field = new StarThrower.XBase.UndefinedField();

        #endregion


        #region Construction

        public UndefinedField()
        {
            this.Code = _field.Code;
            this.Text = _field.Text;
        }

        #endregion


        #region Public Methods

        public override int MinLength
        {
            get { return _field.MinLength; }
        }

        public override int MaxLength
        {
            get { return _field.MaxLength; }
        }

        public override int MinDecimalCount
        {
            get { return _field.MinDecimalCount; }
        }

        public override int MaxDecimalCount
        {
            get { return _field.MaxDecimalCount; }
        }

        public override bool IsValidLength(int length)
        {
            return _field.IsValidLength(length);
        }

        public override bool IsValidDecimalCount(int decimalCount)
        {
            return _field.IsValidDecimalCount(decimalCount);
        }

        public override bool IsValidData(object data, out string result)
        {
            return _field.IsValidData(data, out result);
        }

        public override object Translate(string data)
        {
            return _field.Translate(data);
        }

        #endregion
    }
}
