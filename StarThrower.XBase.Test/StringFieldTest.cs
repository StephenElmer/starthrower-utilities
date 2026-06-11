// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class StringFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new StringField();
            t.Should().NotBeNull();
            t.Text.Should().Be("String");
            t.Code.Should().Be('C');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new StringField();
            t.IsValidLength(1).Should().BeTrue();
            t.IsValidLength(253).Should().BeTrue();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new StringField();
            t.IsValidLength(0).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new StringField();
            t.IsValidLength(254).Should().BeFalse();
        }

        [Fact]
        public void TestGoodDecimalCount()
        {
            FieldType t = new StringField();
            t.IsValidDecimalCount(0).Should().BeTrue();
        }

        [Fact]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new StringField();
            t.IsValidDecimalCount(-1).Should().BeFalse();
        }

        [Fact]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new StringField();
            t.IsValidDecimalCount(1).Should().BeFalse();
        }

        [Fact]
        public void TestAddStringField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "1234567890");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "abcdefghij");
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(0).GetData("MYSTRING").Should().Be("1234567890");

            file.GetRecord(1).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(1).GetData("MYSTRING").Should().Be("abcdefghij");
        }

        [Fact]
        public void TestAddStringField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYSTRING", "");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "1");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "123456789");
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYSTRING", "         0");
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(0).GetData("MYSTRING").Should().Be("          ");

            file.GetRecord(1).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(1).GetData("MYSTRING").Should().Be("1         ");

            file.GetRecord(2).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(2).GetData("MYSTRING").Should().Be("123456789 ");

            file.GetRecord(3).GetData("MYSTRING").Should().BeOfType<string>();
            file.GetRecord(3).GetData("MYSTRING").Should().Be("         0");
        }

        [Fact]
        public void TestAddStringField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYSTRING", "          0");
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddStringField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.StringField();
            field.Length = 10;
            field.Name = "MYSTRING";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYSTRING", "12345678901");
            act.Should().Throw<BadDataException>();
        }
    }
}
