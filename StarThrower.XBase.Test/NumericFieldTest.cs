// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class NumericFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new NumericField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Numeric");
            t.Code.Should().Be('N');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new NumericField();
            t.IsValidLength(1).Should().BeTrue();
            t.IsValidLength(17).Should().BeTrue();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new NumericField();
            t.IsValidLength(0).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new NumericField();
            t.IsValidLength(18).Should().BeFalse();
        }

        [Fact]
        public void TestGoodDecimalCountLowEnd()
        {
            FieldType t = new NumericField();
            t.IsValidDecimalCount(0).Should().BeTrue();
        }

        [Fact]
        public void TestGoodDecimalCountHighEnd()
        {
            FieldType t = new NumericField();
            t.IsValidDecimalCount(15).Should().BeTrue();
        }

        [Fact]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new NumericField();
            t.IsValidDecimalCount(-1).Should().BeFalse();
        }

        [Fact]
        public void TestDecimalCountBeyondUpperBound()
        {
            FieldType t = new NumericField();
            t.IsValidDecimalCount(16).Should().BeFalse();
        }


        #region Short Tests

        [Fact]
        public void TestAddShortField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(7L);
        }

        [Fact]
        public void TestAddShortField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddShortField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be((long)(short.MinValue));
        }

        [Fact]
        public void TestAddShortField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be((long)(short.MaxValue));
        }

        [Fact]
        public void TestAddShortField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 5;
            field.DecimalCount = 0;
            file.AddField(field);

            short val = short.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        #endregion


        #region Int Tests

        [Fact]
        public void TestAddIntField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(7L);
        }

        [Fact]
        public void TestAddIntField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddIntField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 11;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be((long)(int.MinValue));
        }

        [Fact]
        public void TestAddIntField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be((long)(int.MaxValue));
        }

        [Fact]
        public void TestAddIntField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 0;
            file.AddField(field);

            int val = int.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        #endregion


        #region Long Tests

        [Fact]
        public void TestAddLongField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 7;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(7L);
        }

        [Fact]
        public void TestAddLongField2()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 32767;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddLongField3()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = -9999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(-9999999999999999);
        }

        [Fact]
        public void TestAddLongField4()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = 99999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<long>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(99999999999999999);
        }

        [Fact]
        public void TestAddLongField5()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 16;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = -9999999999999999;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddLongField6()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = long.MinValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddLongField7()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 17;
            field.DecimalCount = 0;
            file.AddField(field);

            long val = long.MaxValue;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        #endregion


        #region Double Tests

        [Fact]
        public void TestAddDoubleField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 2;
            file.AddField(field);

            double val = 3.14;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<double>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(3.14);
        }

        [Fact]
        public void TestAddDoubleFieldExactFit()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 4; //exactly fits "3.14"
            field.DecimalCount = 2;
            file.AddField(field);

            double val = 3.14;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().Be(3.14);
        }

        [Fact]
        public void TestAddDoubleFieldNegative()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 7; //sign takes one of the available characters
            field.DecimalCount = 2;
            file.AddField(field);

            double val = -3.14;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().Be(-3.14);
        }

        [Fact]
        public void TestAddDoubleFieldRoundsToDecimalCount()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 2;
            file.AddField(field);

            double val = 3.14159;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYNUM").Should().Be(3.14);
        }

        [Fact]
        public void TestAddDoubleFieldExceedsLength()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 3; //too short for "3.14"
            field.DecimalCount = 2;
            file.AddField(field);

            double val = 3.14;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddDoubleFieldNaN()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", double.NaN);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddDoubleFieldPositiveInfinity()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", double.PositiveInfinity);
            act.Should().Throw<BadDataException>();
        }

        #endregion


        #region Single Tests

        [Fact]
        public void TestAddSingleField1()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 6;
            field.DecimalCount = 2;
            file.AddField(field);

            float val = 3.14f;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYNUM", val);
            file.AddRecord(record);

            //NumericField.Translate always returns Double - even for fields originally set from a Single.
            file.GetRecord(0).GetData("MYNUM").Should().BeOfType<double>();
            file.GetRecord(0).GetData("MYNUM").Should().Be(3.14);
        }

        [Fact]
        public void TestAddSingleFieldExceedsLength()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 3; //too short for "3.14"
            field.DecimalCount = 2;
            file.AddField(field);

            float val = 3.14f;
            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", val);
            act.Should().Throw<BadDataException>();
        }

        [Fact]
        public void TestAddSingleFieldNaN()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.NumericField();
            field.Name = "MYNUM";
            field.Length = 10;
            field.DecimalCount = 2;
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            Action act = () => record.SetData("MYNUM", float.NaN);
            act.Should().Throw<BadDataException>();
        }

        #endregion
    }
}
