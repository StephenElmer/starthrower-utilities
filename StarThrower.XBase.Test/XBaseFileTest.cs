// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using AwesomeAssertions;
using StarThrower.FileUtilities;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class XBaseFileTest
    {
        private readonly string _inputFolder;
        private readonly string _outputFolder;

        public XBaseFileTest()
        {
            _inputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestInput"));
            if (!Directory.Exists(_inputFolder))
            {
                Directory.CreateDirectory(_inputFolder);
            }

            _outputFolder = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "TestOutput"));
            if (!Directory.Exists(_outputFolder))
            {
                Directory.CreateDirectory(_outputFolder);
            }
        }

        #region Private Methods

        /// <summary>
        /// Creates an XBase file with three records
        /// The created file should be equal to ROOT001.DBF
        /// </summary>
        /// <returns></returns>
        private static StarThrower.XBase.XBaseFile CreateRoot001XBaseFile()
        {
            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field1 = new StarThrower.XBase.XBaseField();
            field1.Name = "FIELDONE";
            field1.FieldType = new StarThrower.XBase.StringField();
            field1.Length = 10;
            field1.DecimalCount = 0;
            f.AddField(field1);

            StarThrower.XBase.XBaseField field2 = new StarThrower.XBase.XBaseField();
            field2.Name = "FIELDTWO";
            field2.FieldType = new StarThrower.XBase.StringField();
            field2.Length = 10;
            field2.DecimalCount = 0;
            f.AddField(field2);

            StarThrower.XBase.XBaseField field3 = new StarThrower.XBase.XBaseField();
            field3.Name = "FIELDTHREE";
            field3.FieldType = new StarThrower.XBase.StringField();
            field3.Length = 10;
            field3.DecimalCount = 0;
            f.AddField(field3);

            f.LastUpdate = new DateTime(2007, 1, 1);

            return f;
        }

        /// <summary>
        /// Adds three records to the file created in CreateRoot001XBaseFile()
        /// </summary>
        /// <param name="xbaseFile"></param>
        private static void AddRecordsToRoot001ToMakeRoot002(StarThrower.XBase.XBaseFile xbaseFile)
        {
            StarThrower.XBase.XBaseRecord record1 = xbaseFile.CreateRecord();
            record1.SetData("FIELDONE", "1234567890");
            record1.SetData("FIELDTWO", "1234567890");
            record1.SetData("FIELDTHREE", "1234567890");
            xbaseFile.AddRecord(record1);

            StarThrower.XBase.XBaseRecord record2 = xbaseFile.CreateRecord();
            record2.SetData("FIELDONE", "aaaaaaaaaa");
            record2.SetData("FIELDTWO", "bbbbbbbbbb");
            record2.SetData("FIELDTHREE", "cccccccccc");
            xbaseFile.AddRecord(record2);

            StarThrower.XBase.XBaseRecord record3 = xbaseFile.CreateRecord();
            record3.SetData("FIELDONE", "xxxxxxxxxx");
            record3.SetData("FIELDTWO", "yyyyyyyyyy");
            record3.SetData("FIELDTHREE", "zzzzzzzzzz");
            xbaseFile.AddRecord(record3);
        }

        #endregion


        //File related
        //TEST003:  Open a dBase file, save it, compare the saved file to the opened file
        [Fact]
        public void Test003()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string outputFile = _outputFolder + "\\ROOT002C.DBF";

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(inputFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST004:  Create a dBase file, save it, compare the saved file to a file previously created in dBase IV (ROOT001)
        [Fact]
        public void Test004()
        {
            string inputFile = _inputFolder + "\\ROOT001.DBF";
            string outputFile = _outputFolder + "\\ROOT001B.DBF";
            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST008:  Create a dBase file w/ records, save it, compare the saved file to a file previously created in dBase IV (ROOT002)
        [Fact]
        public void Test008()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string outputFile = _outputFolder + "\\ROOT002B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //Field related
        //TEST001:  Create a dBase file, add a field, save it, compare the saved file to a previous file which has had the same field added via dBase IV
        [Fact]
        public void Test001()
        {
            string inputFile = _inputFolder + "\\TEST001A.DBF";
            string outputFile = _outputFolder + "\\TEST001A.DBF";
            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.Name = "AFIELD";
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.DecimalCount = 0;
            f.AddField(field);
            f.LastUpdate = new DateTime(2007, 1, 1);

            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST016:
        //Create a dBase file w/ records, add a field, save it, compare the saved file to a previous file which has had the same field added via dBase IV
        [Fact]
        public void Test016()
        {
            string intputFile = _inputFolder + "\\TEST015A.DBF";
            string outputFile = _outputFolder + "\\TEST015B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            f.DeleteField(1);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(intputFile, outputFile).Should().BeTrue();
        }

        //TEST017:
        //Open a dBase file w/ records, add a field, save it, compare the saved file to a previous file which has had the same field added via dBase IV
        [Fact]
        public void Test017()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string workingFile = _outputFolder + "\\ROOT002.DBF";
            string controlFile = _inputFolder + "\\TEST017A.DBF";
            string outputFile = _outputFolder + "\\TEST017A.DBF";

            if (File.Exists(workingFile))
            {
                FileInfo fileInfo = new FileInfo(workingFile);
                fileInfo.Attributes = FileAttributes.Normal;
                File.Delete(workingFile);
            }
            File.Copy(inputFile, workingFile, true);
            FileInfo workingFileInfo = new FileInfo(workingFile);
            workingFileInfo.Attributes = FileAttributes.Normal;

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(workingFile, FileMode.Open, FileAccess.ReadWrite);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.Name = "AFIELD";
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.DecimalCount = 0;
            f.AddField(field);
            f.LastUpdate = new DateTime(2007, 1, 1);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(controlFile, outputFile).Should().BeTrue();
        }


        //TEST002:  Open a dBase file, add a field, save it, compare the saved file to a previous file which has had the same field added via dBase IV
        [Fact]
        public void Test002()
        {
            string inputFile = _inputFolder + "\\TEST002A.DBF";
            string controlFile = _inputFolder + "\\TEST002B.DBF";
            string outputFile = _outputFolder + "\\TEST002B.DBF";

            // Delete the file if it exists to ensure clean state (previous test runs may have left it locked or with read-only attributes)
            if (File.Exists(outputFile))
            {
                FileInfo fileInfo = new FileInfo(outputFile);
                fileInfo.Attributes = FileAttributes.Normal;
                File.Delete(outputFile);
            }

            File.Copy(inputFile, outputFile, true);

            // Clear ReadOnly attribute from copied file since the source file may have it set
            FileInfo outputFileInfo = new FileInfo(outputFile);
            outputFileInfo.Attributes = FileAttributes.Normal;

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(outputFile, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.Read);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.Name = "ANOTHER";
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 20;
            field.DecimalCount = 0;
            f.AddField(field);
            f.LastUpdate = new DateTime(2007, 1, 1);

            f.Save();
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(controlFile, outputFile).Should().BeTrue();
        }

        //TEST005:  Open a dBase file, alter a field, save it, compare the saved file to a previous file which has had the same field altered via dBase IV
        [Fact]
        public void Test005()
        {
            string inputFile = _inputFolder + "\\TEST005A.DBF";
            string outputFile = _outputFolder + "\\TEST005B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            StarThrower.XBase.XBaseField field4 = new StarThrower.XBase.XBaseField();
            field4.Name = "FIELDFOUR";
            field4.FieldType = new StarThrower.XBase.StringField();
            field4.Length = 5;
            field4.DecimalCount = 0;
            f.AlterField("FIELDTWO", field4);

            f.LastUpdate = new DateTime(2007, 1, 1);

            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST018:
        //Open a dBase file w/ records, alter a field, save it, compare the saved file to a previous file which has had the same field altered via dBase IV
        //(reduces the length of the second field from 10 characters to 5 characters)
        [Fact]
        public void Test018()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string workingFile = _outputFolder + "\\ROOT002.DBF";
            string controlFile = _inputFolder + "\\TEST018A.DBF";
            string outputFile = _outputFolder + "\\TEST018A.DBF";

            if (File.Exists(workingFile))
            {
                FileInfo fileInfo = new FileInfo(workingFile);
                fileInfo.Attributes = FileAttributes.Normal;
                File.Delete(workingFile);
            }
            File.Copy(inputFile, workingFile, true);
            FileInfo workingFileInfo = new FileInfo(workingFile);
            workingFileInfo.Attributes = FileAttributes.Normal;

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(workingFile, FileMode.Open, FileAccess.ReadWrite);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.Name = "AFIELD";
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 5;
            field.DecimalCount = 0;

            f.AlterField(1, field);

            f.LastUpdate = new DateTime(2007, 1, 1);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(controlFile, outputFile).Should().BeTrue();
        }

        //TEST019:
        //Open a dBase file w/ records, alter a field, save it, compare the saved file to a previous file which has had the same field altered via dBase IV
        //(increases the length of the second field from 10 characters to 15 characters)
        [Fact]
        public void Test019()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string workingFile = _outputFolder + "\\ROOT002.DBF";
            string controlFile = _inputFolder + "\\TEST019A.DBF";
            string outputFile = _outputFolder + "\\TEST019A.DBF";

            if (File.Exists(workingFile))
            {
                FileInfo fileInfo = new FileInfo(workingFile);
                fileInfo.Attributes = FileAttributes.Normal;
                File.Delete(workingFile);
            }
            File.Copy(inputFile, workingFile, true);
            FileInfo workingFileInfo = new FileInfo(workingFile);
            workingFileInfo.Attributes = FileAttributes.Normal;

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(workingFile, FileMode.Open, FileAccess.ReadWrite);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.Name = "AFIELD";
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 15;
            field.DecimalCount = 0;

            f.AlterField(1, field);

            f.LastUpdate = new DateTime(2007, 1, 1);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(controlFile, outputFile).Should().BeTrue();
        }

        //TEST006:  Open a dBase file, remove a field, save it, compare the saved file to a previous file which has had the same field removed via dBase IV
        [Fact]
        public void Test006()
        {
            string inputFile = _inputFolder + "\\TEST006A.DBF";
            string outputFile = _outputFolder + "\\TEST006B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            f.DeleteField("FIELDTWO");

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST015:
        //Open a dBase file w/ records, remove a field, save it, compare the saved file to a previous file which has had the same field removed via dBase IV
        [Fact]
        public void Test015()
        {
            string inputFile = _inputFolder + "\\ROOT002.DBF";
            string workingFile = _outputFolder + "\\ROOT002.DBF";
            string controlFile = _inputFolder + "\\TEST015A.DBF";
            string outputFile = _outputFolder + "\\TEST015A.DBF";

            if (File.Exists(workingFile))
            {
                FileInfo fileInfo = new FileInfo(workingFile);
                fileInfo.Attributes = FileAttributes.Normal;
                File.Delete(workingFile);
            }
            File.Copy(inputFile, workingFile, true);
            FileInfo workingFileInfo = new FileInfo(workingFile);
            workingFileInfo.Attributes = FileAttributes.Normal;

            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);
            f.Open(workingFile, FileMode.Open, FileAccess.ReadWrite);

            f.DeleteField(1);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(controlFile, outputFile).Should().BeTrue();
        }

        //TEST012:  Open a dBase file, retrieve the last (index 2) field descriptor.
        [Fact]
        public void Test012()
        {
            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();
            f.GetField(2).ToString().Should().Be("[XBaseField:  Name='FIELDTHREE', Type=StarThrower.XBase.StringField, Length=10, DecimalCount=0]");
        }

        //TEST014:  Open a dBase file, retrieve the field descriptor for a particular field name ("FIELDTHREE")
        [Fact]
        public void Test014()
        {
            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();
            f.GetField("FIELDTHREE").ToString().Should().Be("[XBaseField:  Name='FIELDTHREE', Type=StarThrower.XBase.StringField, Length=10, DecimalCount=0]");
        }

        //4. Add a field where a field already exists with the same name
        //5. Ensure length, decimalcount, type are all compatible when adding fields
        //6. When adding a new field, ensure that the length of the new field plus the sum of existing lengths does not exceed the maximum data length
        //7. Ensure that the length of fieldName is appropriate (dBase only supports field names up to 11 characters long, I believe)
        //8. Ensure that fieldName consists of valid characters and contains no spaces

        //Record related
        //TEST007:  Open a dBase file, add a record, save it, compare the saved file to a previous file which has had the same record added via dBase IV
        [Fact]
        public void Test007()
        {
            string inputFile = _inputFolder + "\\TEST007A.DBF";
            string outputFile = _outputFolder + "\\TEST007B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            StarThrower.XBase.XBaseRecord record = f.CreateRecord();
            record.SetData("FIELDONE", "1234567890");
            record.SetData("FIELDTWO", "1234567890");
            record.SetData("FIELDTHREE", "1234567890");
            f.AddRecord(record);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST010:  Open a dBase file, remove a record, save it, compare the saved file to a previous file which has had the same record removed via dBase IV
        [Fact]
        public void Test010()
        {
            string inputFile = _inputFolder + "\\TEST010A.DBF";
            string outputFile = _outputFolder + "\\TEST010B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            f.DeleteRecord(0);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST009:  Open a dBase file, alter a record, save it, compare the saved file to a previous file which has had the same record altered via dBase IV
        [Fact]
        public void Test009()
        {
            string inputFile = _inputFolder + "\\TEST009A.DBF";
            string outputFile = _outputFolder + "\\TEST009B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            StarThrower.XBase.XBaseRecord record = f.CreateRecord();
            record.SetData("FIELDONE", "llllllllll");
            record.SetData("FIELDTWO", "mmmmmmmmmm");
            record.SetData("FIELDTHREE", "nnnnnnnnnn");
            f.AlterRecord(0, record);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST011:  Open a dBase file, destroy a record, save it, compare the saved file to a previous file which has had the same record deleted (and PACKed) via dBase IV
        [Fact]
        public void Test011()
        {
            string inputFile = _inputFolder + "\\TEST011A.DBF";
            string outputFile = _outputFolder + "\\TEST011B.DBF";

            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            f.DestroyRecord(0);

            f.LastUpdate = new DateTime(2007, 1, 1);
            f.SaveAs(outputFile);
            f.Close();
            f.Dispose();

            FileSystem.FileCompare(inputFile, outputFile).Should().BeTrue();
        }

        //TEST013:  Open a dBase file, retrieve the first (index 0) record
        [Fact]
        public void Test013()
        {
            StarThrower.XBase.XBaseFile f = CreateRoot001XBaseFile();

            AddRecordsToRoot001ToMakeRoot002(f);

            StarThrower.XBase.XBaseRecord record = f.GetRecord(0);
            record.ToString().Should().Be("[XBaseRecord:  IsDeleted=False, Data='123456789012345678901234567890']");
        }

        //5. Attempt to add / alter a record in which the data length is too long
        //6. Verify data formats are appropriate for added / altered records
        //7. When retrieving data, records flagged as deleted should not be returned in the result set
        //8. When adding a date value, check for leap-years (e.g. Feb 29 is only allowed on leap years) //TODO: need to confirm this on dBase IV
        //9. When a record is deleted, verify that record count is adjusted appropriately. //TODO: confirm this against dBase IV

        //Complex operations
        //1. Create a dBase file, add some fields, add some records, remove/alter some fields, delete/alter some records, save the file, compare to a previously saved dBase IV file
        //2. etc. etc.
    }
}
