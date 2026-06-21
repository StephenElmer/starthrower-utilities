// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class FloatFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new FloatField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Float");
            t.Code.Should().Be('F');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new FloatField();
            t.IsValidLength(20).Should().BeTrue();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new FloatField();
            t.IsValidLength(0).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new FloatField();
            t.IsValidLength(21).Should().BeFalse();
        }

        [Fact]
        public void TestGoodDecimalCount()
        {
            FieldType t = new FloatField();
            t.IsValidDecimalCount(0).Should().BeTrue();
            t.IsValidDecimalCount(1).Should().BeTrue();
            t.IsValidDecimalCount(19).Should().BeTrue();
        }

        [Fact]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new FloatField();
            t.IsValidDecimalCount(-1).Should().BeFalse();
        }

        [Fact]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new FloatField();
            t.IsValidDecimalCount(20).Should().BeFalse();
        }

        [Fact]
        public void TestGoodDecimalCount2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            t.IsValidDecimalCount(0).Should().BeTrue();
            t.IsValidDecimalCount(1).Should().BeTrue();
            t.IsValidDecimalCount(4).Should().BeTrue();
            t.IsValidDecimalCount(19).Should().BeTrue();
        }

        [Fact]
        public void TestDecimalCountBeyondLowerBound2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            t.IsValidDecimalCount(-1).Should().BeFalse();
        }

        [Fact]
        public void TestDecimalCountBeyondUpperBound2()
        {
            FieldType t = new FloatField();
            XBaseField f = new XBaseField();
            f.Length = 5;
            f.FieldType = t;
            t.IsValidDecimalCount(20).Should().BeFalse();
        }


        #region Double Tests

        [Fact]
        public void TestAddDoubleField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 4;
            file.AddField(field);

            double val = 3.14159;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYFLT", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYFLT").Should().BeOfType<double>();
            file.GetRecord(0).GetData("MYFLT").Should().Be(3.1416); //rounded to the field's DecimalCount
        }

        [Fact]
        public void TestAddDoubleFieldNegative()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            double val = -3.14;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYFLT", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYFLT").Should().Be(-3.14);
        }

        [Fact]
        public void TestAddDoubleFieldExceedsLength()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 19; //max allowed DecimalCount - but Length is fixed at 20, so even "0" overflows it ("0." + 19 digits = 21 chars)
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", 0.0);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddDoubleFieldOverflow()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", 1e20);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddDoubleFieldNaN()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", double.NaN);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddDoubleFieldPositiveInfinity()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", double.PositiveInfinity);
            act.Should().Throw<BadDataException>();
        }

        #endregion


        #region Single Tests

        [Fact]
        public void TestAddSingleField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            float val = 3.14f;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYFLT", val);
            file.AddRecord(record);

            //FloatField.Translate always returns Double - even for fields originally set from a Single.
            file.GetRecord(0).GetData("MYFLT").Should().BeOfType<double>();
            file.GetRecord(0).GetData("MYFLT").Should().Be(3.14);
        }

        [Fact]
        public void TestAddSingleFieldExceedsLength()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 19; //max allowed DecimalCount - but Length is fixed at 20, so even "0" overflows it
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", 0.0f);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddSingleFieldNaN()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.FloatField();
            field.Name = "MYFLT";
            field.Length = 20;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYFLT", float.NaN);
            act.Should().Throw<BadDataException>();
        }

        #endregion
    }
}
