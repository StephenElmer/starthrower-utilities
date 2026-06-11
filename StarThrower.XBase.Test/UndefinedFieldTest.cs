// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class UndefinedFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new UndefinedField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Undefined");
            t.Code.Should().Be('U');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new UndefinedField();
            t.IsValidLength(1).Should().BeTrue();
            t.IsValidLength(253).Should().BeTrue();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new UndefinedField();
            t.IsValidLength(-1).Should().BeFalse();
        }

        [Fact]
        public void TestGoodDecimalCount()
        {
            FieldType t = new UndefinedField();
            t.IsValidDecimalCount(0).Should().BeTrue();
        }

        [Fact]
        public void TestDecimalCountBeyondLowerBound()
        {
            FieldType t = new UndefinedField();
            t.IsValidDecimalCount(-1).Should().BeFalse();
        }
    }
}
