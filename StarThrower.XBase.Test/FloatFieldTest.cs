// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

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
    }
}
