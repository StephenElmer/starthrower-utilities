// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class DateFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new DateField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Date");
            t.Code.Should().Be('D');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new DateField();
            t.IsValidLength(8).Should().BeTrue();
            t.IsValidLength(7).Should().BeFalse();
            t.IsValidLength(9).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new DateField();
            t.IsValidLength(7).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new DateField();
            t.IsValidLength(9).Should().BeFalse();
        }

        [Fact]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new DateField();
            t.IsValidDecimalCount(0).Should().BeTrue();
            t.IsValidDecimalCount(-1).Should().BeFalse();
            t.IsValidDecimalCount(1).Should().BeFalse();
        }

        [Fact]
        public void TestAddDateTimeField()
        {
            DateTime dtNow = DateTime.Now;
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.DateField();
            field.Name = "MYDATE";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYDATE", dtNow);
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYDATE", new DateTime(1968, 5, 18));
            file.AddRecord(record);


            file.GetRecord(0).GetData("MYDATE").Should().BeOfType<DateTime>();
            file.GetRecord(0).GetData("MYDATE").Should().Be(dtNow.Date);

            file.GetRecord(1).GetData("MYDATE").Should().BeOfType<DateTime>();
            file.GetRecord(1).GetData("MYDATE").Should().Be(new DateTime(1968, 5, 18));
        }
    }
}
