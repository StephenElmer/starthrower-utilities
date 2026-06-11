// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class BooleanFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new BooleanField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Boolean");
            t.Code.Should().Be('L');
        }

        [Fact]
        public void TestIsValidLength()
        {
            FieldType t = new BooleanField();
            t.IsValidLength(1).Should().BeTrue();
            t.IsValidLength(0).Should().BeFalse();
            t.IsValidLength(2).Should().BeFalse();
        }

        [Fact]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new BooleanField();
            t.IsValidDecimalCount(0).Should().BeTrue();
            t.IsValidDecimalCount(-1).Should().BeFalse();
            t.IsValidDecimalCount(1).Should().BeFalse();
        }

        [Fact]
        public void TestAddBooleanField()
        {
            StarThrower.XBase.XBaseFile file = new StarThrower.XBase.XBaseFile(StarThrower.XBase.XBaseFileType.dBaseIII);

            StarThrower.XBase.XBaseField field = new StarThrower.XBase.XBaseField();
            field.FieldType = new StarThrower.XBase.BooleanField();
            field.Name = "MYBOOL";
            file.AddField(field);

            StarThrower.XBase.XBaseRecord record = file.CreateRecord();
            record.SetData("MYBOOL", true);
            file.AddRecord(record);

            record = file.CreateRecord();
            record.SetData("MYBOOL", false);
            file.AddRecord(record);

            file.GetRecord(0).GetData("MYBOOL").Should().BeOfType<bool>();
            file.GetRecord(0).GetData("MYBOOL").Should().Be(true);

            file.GetRecord(1).GetData("MYBOOL").Should().BeOfType<bool>();
            file.GetRecord(1).GetData("MYBOOL").Should().Be(false);
        }
    }
}
