using System;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    public enum XBaseFileType
    {
        Undefined = 0,
        FoxBase = 2, //(Hex 02) FoxBase
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIII = 3, //(Hex 03) File without DBT
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIV = 4, //(Hex 04) dBase IV w/o memo file
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseV = 5, //(Hex 05) dBase V w/o memo file
        VisualFoxPro = 48, //(Hex 30) Visual FoxPro / Visual FoxPro w. DBC
        VisualFoxProWithAutoIncrement = 49, //(Hex 31) Visual FoxPro w. AutoIncrement field
        FlagshipWithDbv = 67, //(Hex 43) .dbv memo var size (Flagship)
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIVWithMemo = 123, //(Hex 7b) dBase IV with memo
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIIIWithDBT = 131, //(Hex 83) File with DBT / dBaseIII with memo file
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIIIWithSQL = 139, //(Hex 8b) dBase IV w. memo
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIVWithSQL = 142, //(Hex 8e) dBase IV w. SQL table
        FlagshipWithDbvAndDbt = 179, //(Hex b3) .dbv and .dbt memo (Flagship)
        Clipper6WithSMT = 229, //(Hex e5) Clipper SIX driver w. SMT memo file.  NOTE: Clipper SIX driver sets lowest 3 bytes to 110 in descriptor of crypted databases. So, 3->6, 83h->86h, f5->f6, e5->e6 etc.
        FoxProWithMemo = 245, //(Hex f5) FoxPro w. memo file
        FoxPro = 251 //(Hex fb) FoxPro ???
    }

    public sealed class XBaseFile : IDisposable
    {
        #region Private Member Variables

        private StarThrower.XBase.Internal.File _file;

        #endregion


        #region Construction

        public XBaseFile(XBaseFileType fileType)
        {
            if (fileType != XBaseFileType.dBaseIII) throw new NotSupportedException();
            _file = new StarThrower.XBase.Internal.File();
        }

        public XBaseFile(XBaseFileType fileType, string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            if (fileType != XBaseFileType.dBaseIII) throw new NotSupportedException();
            _file = new StarThrower.XBase.Internal.File(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_file != null)
                {
                    _file.Dispose();
                    _file = null;
                }
            }
        }

        #endregion


        #region Field Related

        public void AddField(StarThrower.XBase.XBaseField field)
        {
            _file.AddField(XBase.XBaseFieldToInternalField(field));
        }

        public bool FindField(string fieldName)
        {
            int index = -1;
            return this.FindField(fieldName, ref index);
        }

        public bool FindField(string fieldName, ref int index)
        {
            return _file.FindField(StringUtil.ToByteArray(fieldName), ref index);
        }

        public StarThrower.XBase.XBaseField GetField(string fieldName)
        {
            return XBase.InternalFieldToXBaseField(_file.GetField(StringUtil.ToByteArray(fieldName)));
        }

        public StarThrower.XBase.XBaseField GetField(int index)
        {
            return XBase.InternalFieldToXBaseField(_file.GetField(index));
        }

        public void AlterField(int index, StarThrower.XBase.XBaseField field)
        {
            _file.AlterField(index, XBase.XBaseFieldToInternalField(field));
        }

        public void AlterField(string fieldName, StarThrower.XBase.XBaseField field)
        {
            _file.AlterField(StringUtil.ToByteArray(fieldName), XBase.XBaseFieldToInternalField(field));
        }

        public void DeleteField(string fieldName)
        {
            _file.DeleteField(StringUtil.ToByteArray(fieldName));
        }

        public void DeleteField(int index)
        {
            _file.DeleteField(index);
        }

        public int FieldCount
        {
            get { return _file.FieldCount; }
        }

        #endregion


        #region Record Related

        public StarThrower.XBase.XBaseRecord CreateRecord()
        {
            string data = "";
            StarThrower.XBase.XBaseRecord result = new StarThrower.XBase.XBaseRecord();
            result.IsDeleted = false;
            for (int i = 0; i < _file.FieldCount; i++)
            {
                StarThrower.XBase.XBaseField field = XBase.InternalFieldToXBaseField(_file.GetField(i));
                result.Fields.Add(field);
                data = new string(new char[data.Length + field.Length]);
            }
            result.Data = data;

            return result;
        }

        public void AddRecord(StarThrower.XBase.XBaseRecord record)
        {
            _file.AddRecord(XBase.XBaseRecordToInternalRecord(record, _file));
        }

        public bool FindRecord(string queryText)
        {
            int index = -1;
            return this.FindRecord(queryText, ref index);
        }

        public bool FindRecord(string queryText, ref int index)
        {
            return _file.FindRecord(queryText, ref index);
        }

        public StarThrower.XBase.XBaseRecord GetRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException("queryText");
            return XBase.InternalRecordToXBaseRecord(_file.GetRecord(index));
        }

        public StarThrower.XBase.XBaseRecord GetRecord(int index)
        {
            return XBase.InternalRecordToXBaseRecord(_file.GetRecord(index));
        }

        public void AlterRecord(int index, StarThrower.XBase.XBaseRecord record)
        {
            _file.AlterRecord(index, XBase.XBaseRecordToInternalRecord(record, _file));
        }

        public void DeleteRecord(int index)
        {
            _file.DeleteRecord(index);
        }

        public void DeleteRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException("queryText");
            _file.DeleteRecord(index);
        }

        public void DestroyRecord(int index)
        {
            _file.DestroyRecord(index);
        }

        public void DestroyRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException("queryText");
            _file.DestroyRecord(index);
        }

        public int RecordCount
        {
            get { return _file.RecordCount; }
        }

        #endregion


        #region File Related

        public DateTime LastUpdate
        {
            get
            {
                return XBase.ThreeByteArrayToDateTime(_file.Header.LastUpdate);
            }
            set
            {
                _file.Header.LastUpdate = XBase.DateTimeToThreeByteArray(value);
            }
        }

        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            _file.Open(fileName, fileMode, fileAccess, fileShare);
        }

        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            _file.Open(fileName, fileMode, fileAccess);
        }

        public void Close()
        {
            this.Close(false);
        }

        public void Close(bool save)
        {
            _file.Close(save);
        }

        public void Save()
        {
            _file.Save();
        }

        public void SaveAs(string fileName)
        {
            _file.SaveAs(fileName);
        }

        public string ToXml()
        {
            return _file.ToXml();
        }

        #endregion
    }

}
