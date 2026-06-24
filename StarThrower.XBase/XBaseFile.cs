// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using StarThrower.StringUtilities;

namespace StarThrower.XBase
{
    /// <summary>
    /// Identifies the dBASE/FoxPro/Clipper file format dialect of an XBase (.dbf) file, as
    /// encoded in the first byte of the file header.
    /// </summary>
    /// <remarks>
    /// <see cref="XBaseFile"/> currently only supports opening and creating files of type
    /// <see cref="dBaseIII"/>; constructing an <see cref="XBaseFile"/> with any other value
    /// throws <see cref="NotSupportedException"/>. The remaining values are defined for
    /// completeness when reading the file header's type byte.
    /// </remarks>
    public enum XBaseFileType
    {
        /// <summary>An unrecognized or unset file type.</summary>
        Undefined = 0,

        /// <summary>(Hex 02) FoxBase.</summary>
        FoxBase = 2,

        /// <summary>(Hex 03) File without DBT.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIII = 3,

        /// <summary>(Hex 04) dBase IV w/o memo file.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIV = 4,

        /// <summary>(Hex 05) dBase V w/o memo file.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseV = 5,

        /// <summary>(Hex 30) Visual FoxPro / Visual FoxPro w. DBC.</summary>
        VisualFoxPro = 48,

        /// <summary>(Hex 31) Visual FoxPro w. AutoIncrement field.</summary>
        VisualFoxProWithAutoIncrement = 49,

        /// <summary>(Hex 43) .dbv memo var size (Flagship).</summary>
        FlagshipWithDbv = 67,

        /// <summary>(Hex 7b) dBase IV with memo.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIVWithMemo = 123,

        /// <summary>(Hex 83) File with DBT / dBaseIII with memo file.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIIIWithDBT = 131,

        /// <summary>(Hex 8b) dBase IV w. memo.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIIIWithSQL = 139,

        /// <summary>(Hex 8e) dBase IV w. SQL table.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Member")]
        dBaseIVWithSQL = 142,

        /// <summary>(Hex b3) .dbv and .dbt memo (Flagship).</summary>
        FlagshipWithDbvAndDbt = 179,

        /// <summary>
        /// (Hex e5) Clipper SIX driver w. SMT memo file. Note: the Clipper SIX driver sets the
        /// lowest 3 bits to 110 in the descriptor of encrypted databases, so 3-&gt;6, 83h-&gt;86h,
        /// f5-&gt;f6, e5-&gt;e6, etc.
        /// </summary>
        Clipper6WithSMT = 229,

        /// <summary>(Hex f5) FoxPro w. memo file.</summary>
        FoxProWithMemo = 245,

        /// <summary>(Hex fb) FoxPro.</summary>
        FoxPro = 251
    }

    /// <summary>
    /// Reads and writes an XBase (.dbf) database file: its field (column) definitions and records (rows).
    /// </summary>
    /// <remarks>
    /// Only <see cref="XBaseFileType.dBaseIII"/> is currently supported; all constructors throw
    /// <see cref="NotSupportedException"/> for any other <see cref="XBaseFileType"/>.
    /// </remarks>
    public sealed class XBaseFile : IDisposable
    {
        #region Private Member Variables

        private StarThrower.XBase.Internal.File _file;

        #endregion


        #region Construction

        /// <summary>
        /// Creates a new, unopened XBase file of the specified type, with no fields or records.
        /// </summary>
        /// <param name="fileType">The file format dialect. Must be <see cref="XBaseFileType.dBaseIII"/>.</param>
        /// <exception cref="NotSupportedException">Thrown if fileType is not <see cref="XBaseFileType.dBaseIII"/>.</exception>
        public XBaseFile(XBaseFileType fileType)
        {
            if (fileType != XBaseFileType.dBaseIII) throw new NotSupportedException();
            _file = new StarThrower.XBase.Internal.File();
        }

        /// <summary>
        /// Creates a new XBase file of the specified type and immediately opens it from disk.
        /// </summary>
        /// <param name="fileType">The file format dialect. Must be <see cref="XBaseFileType.dBaseIII"/>.</param>
        /// <param name="fileName">The path of the .dbf file to open.</param>
        /// <param name="fileMode">The mode used to open the file.</param>
        /// <param name="fileAccess">The access permissions used to open the file.</param>
        /// <exception cref="NotSupportedException">Thrown if fileType is not <see cref="XBaseFileType.dBaseIII"/>.</exception>
        public XBaseFile(XBaseFileType fileType, string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            if (fileType != XBaseFileType.dBaseIII) throw new NotSupportedException();
            _file = new StarThrower.XBase.Internal.File(fileName, fileMode, fileAccess);
        }

        #endregion


        #region IDisposable Members

        /// <summary>
        /// Releases the underlying file handle held by this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _file.Dispose();
            }
        }

        #endregion


        #region Field Related

        /// <summary>
        /// Appends a new field definition to this file's schema.
        /// </summary>
        /// <param name="field">The field to add.</param>
        public void AddField(StarThrower.XBase.XBaseField field)
        {
            _file.AddField(XBase.XBaseFieldToInternalField(field));
        }

        /// <summary>
        /// Determines whether this file's schema contains a field with the specified name.
        /// </summary>
        /// <param name="fieldName">The field name to search for.</param>
        /// <returns>True if the field exists; otherwise, false.</returns>
        public bool FindField(string fieldName)
        {
            int index = -1;
            return this.FindField(fieldName, ref index);
        }

        /// <summary>
        /// Searches this file's schema for a field with the specified name. If found, the index is filled in.
        /// </summary>
        /// <param name="fieldName">The field name to search for.</param>
        /// <param name="index">The index of the field, if found.</param>
        /// <returns>True if the field exists; otherwise, false.</returns>
        public bool FindField(string fieldName, ref int index)
        {
            return _file.FindField(StringUtil.ToByteArray(fieldName), ref index);
        }

        /// <summary>
        /// Gets the field definition with the specified name.
        /// </summary>
        /// <param name="fieldName">The name of the field to retrieve.</param>
        /// <returns>The field with the specified name.</returns>
        public StarThrower.XBase.XBaseField GetField(string fieldName)
        {
            return XBase.InternalFieldToXBaseField(_file.GetField(StringUtil.ToByteArray(fieldName)));
        }

        /// <summary>
        /// Gets the field definition at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the field to retrieve.</param>
        /// <returns>The field at the specified index.</returns>
        public StarThrower.XBase.XBaseField GetField(int index)
        {
            return XBase.InternalFieldToXBaseField(_file.GetField(index));
        }

        /// <summary>
        /// Replaces the field definition at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the field to replace.</param>
        /// <param name="field">The new field definition.</param>
        public void AlterField(int index, StarThrower.XBase.XBaseField field)
        {
            _file.AlterField(index, XBase.XBaseFieldToInternalField(field));
        }

        /// <summary>
        /// Replaces the field definition with the specified name.
        /// </summary>
        /// <param name="fieldName">The name of the field to replace.</param>
        /// <param name="field">The new field definition.</param>
        public void AlterField(string fieldName, StarThrower.XBase.XBaseField field)
        {
            _file.AlterField(StringUtil.ToByteArray(fieldName), XBase.XBaseFieldToInternalField(field));
        }

        /// <summary>
        /// Removes the field with the specified name from this file's schema.
        /// </summary>
        /// <param name="fieldName">The name of the field to remove.</param>
        public void DeleteField(string fieldName)
        {
            _file.DeleteField(StringUtil.ToByteArray(fieldName));
        }

        /// <summary>
        /// Removes the field at the specified index from this file's schema.
        /// </summary>
        /// <param name="index">The zero-based index of the field to remove.</param>
        public void DeleteField(int index)
        {
            _file.DeleteField(index);
        }

        /// <summary>
        /// Gets the number of fields defined in this file's schema.
        /// </summary>
        public int FieldCount
        {
            get { return _file.FieldCount; }
        }

        #endregion


        #region Record Related

        /// <summary>
        /// Creates a new, non-deleted record matching this file's current schema, with every
        /// field initialized to empty/default data.
        /// </summary>
        /// <returns>A new record ready to have field values set and be added via <see cref="AddRecord"/>.</returns>
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

        /// <summary>
        /// Appends a record to this file.
        /// </summary>
        /// <param name="record">The record to add.</param>
        public void AddRecord(StarThrower.XBase.XBaseRecord record)
        {
            _file.AddRecord(XBase.XBaseRecordToInternalRecord(record, _file));
        }

        /// <summary>
        /// Determines whether this file contains a record matching the specified query.
        /// </summary>
        /// <param name="queryText">The query text used to match a record.</param>
        /// <returns>True if a matching record exists; otherwise, false.</returns>
        public bool FindRecord(string queryText)
        {
            int index = -1;
            return this.FindRecord(queryText, ref index);
        }

        /// <summary>
        /// Searches this file for a record matching the specified query. If found, the index is filled in.
        /// </summary>
        /// <param name="queryText">The query text used to match a record.</param>
        /// <param name="index">The index of the matching record, if found.</param>
        /// <returns>True if a matching record exists; otherwise, false.</returns>
        public bool FindRecord(string queryText, ref int index)
        {
            return _file.FindRecord(queryText, ref index);
        }

        /// <summary>
        /// Gets the first record matching the specified query.
        /// </summary>
        /// <param name="queryText">The query text used to match a record.</param>
        /// <returns>The matching record.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if no record matches queryText.</exception>
        public StarThrower.XBase.XBaseRecord GetRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException(nameof(queryText));
            return XBase.InternalRecordToXBaseRecord(_file.GetRecord(index));
        }

        /// <summary>
        /// Gets the record at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the record to retrieve.</param>
        /// <returns>The record at the specified index.</returns>
        public StarThrower.XBase.XBaseRecord GetRecord(int index)
        {
            return XBase.InternalRecordToXBaseRecord(_file.GetRecord(index));
        }

        /// <summary>
        /// Replaces the record at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the record to replace.</param>
        /// <param name="record">The new record.</param>
        public void AlterRecord(int index, StarThrower.XBase.XBaseRecord record)
        {
            _file.AlterRecord(index, XBase.XBaseRecordToInternalRecord(record, _file));
        }

        /// <summary>
        /// Marks the record at the specified index as deleted, without physically removing it.
        /// </summary>
        /// <param name="index">The zero-based index of the record to mark as deleted.</param>
        public void DeleteRecord(int index)
        {
            _file.DeleteRecord(index);
        }

        /// <summary>
        /// Marks the first record matching the specified query as deleted, without physically removing it.
        /// </summary>
        /// <param name="queryText">The query text used to match a record.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if no record matches queryText.</exception>
        public void DeleteRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException(nameof(queryText));
            _file.DeleteRecord(index);
        }

        /// <summary>
        /// Physically removes the record at the specified index, regardless of its deleted status.
        /// </summary>
        /// <param name="index">The zero-based index of the record to remove.</param>
        public void DestroyRecord(int index)
        {
            _file.DestroyRecord(index);
        }

        /// <summary>
        /// Physically removes the first record matching the specified query, regardless of its deleted status.
        /// </summary>
        /// <param name="queryText">The query text used to match a record.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if no record matches queryText.</exception>
        public void DestroyRecord(string queryText)
        {
            int index = -1;
            if (!_file.FindRecord(queryText, ref index)) throw new ArgumentOutOfRangeException(nameof(queryText));
            _file.DestroyRecord(index);
        }

        /// <summary>
        /// Gets the number of records in this file, including any marked as deleted but not yet destroyed.
        /// </summary>
        public int RecordCount
        {
            get { return _file.RecordCount; }
        }

        #endregion


        #region File Related

        /// <summary>
        /// Gets or sets the date this file was last updated, as recorded in the file header.
        /// </summary>
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

        /// <summary>
        /// Opens an existing .dbf file from disk with the specified sharing mode.
        /// </summary>
        /// <param name="fileName">The path of the file to open.</param>
        /// <param name="fileMode">The mode used to open the file.</param>
        /// <param name="fileAccess">The access permissions used to open the file.</param>
        /// <param name="fileShare">The sharing permissions used to open the file.</param>
        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess, System.IO.FileShare fileShare)
        {
            _file.Open(fileName, fileMode, fileAccess, fileShare);
        }

        /// <summary>
        /// Opens an existing .dbf file from disk.
        /// </summary>
        /// <param name="fileName">The path of the file to open.</param>
        /// <param name="fileMode">The mode used to open the file.</param>
        /// <param name="fileAccess">The access permissions used to open the file.</param>
        public void Open(string fileName, System.IO.FileMode fileMode, System.IO.FileAccess fileAccess)
        {
            _file.Open(fileName, fileMode, fileAccess);
        }

        /// <summary>
        /// Closes this file without saving any pending changes.
        /// </summary>
        public void Close()
        {
            this.Close(false);
        }

        /// <summary>
        /// Closes this file, optionally saving pending changes first.
        /// </summary>
        /// <param name="save">Whether to save pending changes before closing.</param>
        public void Close(bool save)
        {
            _file.Close(save);
        }

        /// <summary>
        /// Saves pending changes to the currently open file.
        /// </summary>
        public void Save()
        {
            _file.Save();
        }

        /// <summary>
        /// Saves this file's contents to the specified path.
        /// </summary>
        /// <param name="fileName">The path to save the file to.</param>
        public void SaveAs(string fileName)
        {
            _file.SaveAs(fileName);
        }

        /// <summary>
        /// Gets an XML representation of this file's schema and records.
        /// </summary>
        /// <returns>The XML representation of this file.</returns>
        public string ToXml()
        {
            return _file.ToXml();
        }

        #endregion
    }

}
