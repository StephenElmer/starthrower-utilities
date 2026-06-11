// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class MemoFieldTest
    {
        [Fact]
        public void TestConstructor()
        {
            FieldType t = new MemoField();
            t.Should().NotBeNull();
            t.Text.Should().Be("Memo");
            t.Code.Should().Be('M');
        }

        [Fact]
        public void TestGoodLength()
        {
            FieldType t = new MemoField();
            t.IsValidLength(10).Should().BeTrue();
        }

        [Fact]
        public void TestLengthBeyondLowerBound()
        {
            FieldType t = new MemoField();
            t.IsValidLength(9).Should().BeFalse();
        }

        [Fact]
        public void TestLengthBeyondUpperBound()
        {
            FieldType t = new MemoField();
            t.IsValidLength(11).Should().BeFalse();
        }

        [Fact]
        public void TestIsValidDecimalCount()
        {
            FieldType t = new MemoField();
            t.IsValidDecimalCount(0).Should().BeTrue();
            t.IsValidDecimalCount(-1).Should().BeFalse();
            t.IsValidDecimalCount(1).Should().BeFalse();
        }
    }
}
