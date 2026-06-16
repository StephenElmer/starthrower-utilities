// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class FindRecordTest
    {
        #region Private Methods

        /// <summary>
        /// Creates a file with one field of each queryable type (String, Numeric, Date, Boolean)
        /// and four records. Records 0 and 3 share the same NAME ("STEVE") so that
        /// deleted-record-skipping can be exercised.
        /// </summary>
        private static StarThrower.XBase.XBaseFile CreateTestFile()
        {
            StarThrower.XBase.XBaseFile f = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField nameField = new StarThrower.XBase.XBaseField();
            nameField.Name = "NAME";
            nameField.FieldType = new StarThrower.XBase.StringField();
            nameField.Length = 10;
            nameField.DecimalCount = 0;
            f.AddField(nameField);

            StarThrower.XBase.XBaseField ageField = new StarThrower.XBase.XBaseField();
            ageField.Name = "AGE";
            ageField.FieldType = new StarThrower.XBase.NumericField();
            ageField.Length = 5;
            ageField.DecimalCount = 0;
            f.AddField(ageField);

            StarThrower.XBase.XBaseField bdateField = new StarThrower.XBase.XBaseField();
            bdateField.Name = "BDATE";
            bdateField.FieldType = new StarThrower.XBase.DateField();
            f.AddField(bdateField);

            StarThrower.XBase.XBaseField activeField = new StarThrower.XBase.XBaseField();
            activeField.Name = "ACTIVE";
            activeField.FieldType = new StarThrower.XBase.BooleanField();
            f.AddField(activeField);

            AddRecord(f, "STEVE", 38L, new DateTime(1968, 5, 18), true);
            AddRecord(f, "JANE", 29L, new DateTime(1995, 1, 1), false);
            AddRecord(f, "BOB", 45L, new DateTime(1980, 12, 25), true);
            AddRecord(f, "STEVE", 22L, new DateTime(2000, 1, 1), false);

            return f;
        }

        private static void AddRecord(StarThrower.XBase.XBaseFile f, string name, long age, DateTime birthDate, bool active)
        {
            StarThrower.XBase.XBaseRecord record = f.CreateRecord();
            record.SetData("NAME", name);
            record.SetData("AGE", age);
            record.SetData("BDATE", birthDate);
            record.SetData("ACTIVE", active);
            f.AddRecord(record);
        }

        #endregion


        #region "=" Operator - Match Found

        [Fact]
        public void TestStringEqualityMatch()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("NAME='BOB'", ref index).Should().BeTrue();
            index.Should().Be(2);
        }

        [Fact]
        public void TestStringEqualityIsCaseInsensitive()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("NAME='bob'", ref index).Should().BeTrue();
            index.Should().Be(2);
        }

        [Fact]
        public void TestNumericEqualityMatch()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("AGE=45", ref index).Should().BeTrue();
            index.Should().Be(2);
        }

        [Fact]
        public void TestDateEqualityMatch()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("BDATE=#05/18/1968#", ref index).Should().BeTrue();
            index.Should().Be(0);
        }

        [Fact]
        public void TestBooleanEqualityMatchTrue()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("ACTIVE=T", ref index).Should().BeTrue();
            index.Should().Be(0);
        }

        [Fact]
        public void TestBooleanEqualityMatchFalse()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("ACTIVE=F", ref index).Should().BeTrue();
            index.Should().Be(1);
        }

        [Fact]
        public void TestBooleanEqualityIsCaseInsensitive()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("ACTIVE=y", ref index).Should().BeTrue();
            index.Should().Be(0);
        }

        [Fact]
        public void TestWhitespaceAroundOperatorIsTolerated()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("AGE = 45", ref index).Should().BeTrue();
            index.Should().Be(2);
        }

        [Fact]
        public void TestSingleArgumentOverloadReturnsTrueOnMatch()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            f.FindRecord("NAME='BOB'").Should().BeTrue();
        }

        #endregion


        #region "=" Operator - No Match

        [Fact]
        public void TestStringEqualityNoMatchReturnsFalse()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("NAME='NOBODY'", ref index).Should().BeFalse();
            index.Should().Be(-1);
        }

        [Fact]
        public void TestNumericEqualityNoMatchReturnsFalse()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            f.FindRecord("AGE=99", ref index).Should().BeFalse();
            index.Should().Be(-1);
        }

        #endregion


        #region Deleted Records

        [Fact]
        public void TestFindRecordSkipsDeletedRecord()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            //Record 0 ("STEVE", age 38) is deleted; record 3 ("STEVE", age 22) is not.
            f.DeleteRecord(0);

            int index = -1;
            f.FindRecord("NAME='STEVE'", ref index).Should().BeTrue();
            index.Should().Be(3);
        }

        [Fact]
        public void TestFindRecordReturnsFalseWhenOnlyMatchIsDeleted()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            f.DeleteRecord(2); //BOB is the only record with this name

            int index = -1;
            f.FindRecord("NAME='BOB'", ref index).Should().BeFalse();
            index.Should().Be(-1);
        }

        #endregion


        #region Unsupported Operators

        [Theory]
        [InlineData("AGE<45")]
        [InlineData("AGE>45")]
        [InlineData("AGE<=45")]
        [InlineData("AGE>=45")]
        [InlineData("NAME<>'BOB'")]
        public void TestUnsupportedOperatorsThrowArgumentException(string queryText)
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord(queryText, ref index);
            act.Should().Throw<ArgumentException>();
        }

        #endregion


        #region Invalid Query Syntax

        [Fact]
        public void TestUnknownFieldNameThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("NOSUCHFIELD='BOB'", ref index);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestMissingOperatorThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("NAMEBOB", ref index);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestStringValueMissingQuotesThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("NAME=BOB", ref index);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestNumericValueWithQuotesThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("AGE='45'", ref index);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestDateValueMissingDelimitersThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("BDATE=05/18/1968", ref index);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void TestBooleanValueInvalidCharacterThrowsArgumentException()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            int index = -1;
            Action act = () => f.FindRecord("ACTIVE=X", ref index);
            act.Should().Throw<ArgumentException>();
        }

        #endregion


        #region Integration With Other XBaseFile Methods

        [Fact]
        public void TestGetRecordByQuery()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            StarThrower.XBase.XBaseRecord record = f.GetRecord("AGE=45");
            record.GetData("NAME").Should().Be("BOB       "); //NAME field is space-padded to its 10-character length
        }

        [Fact]
        public void TestDeleteRecordByQuery()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            f.DeleteRecord("AGE=29");

            f.GetRecord(1).IsDeleted.Should().BeTrue();
        }

        [Fact]
        public void TestDestroyRecordByQuery()
        {
            StarThrower.XBase.XBaseFile f = CreateTestFile();

            f.DestroyRecord("AGE=29");

            f.RecordCount.Should().Be(3);
        }

        #endregion
    }
}
