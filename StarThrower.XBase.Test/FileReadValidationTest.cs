// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using AwesomeAssertions;
using StarThrower.XBase;
using Xunit;

namespace StarThrower.XBase.Test
{
    public class FileReadValidationTest
    {
        private static string CreateTempDbfPath()
        {
            return Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".dbf");
        }

        private static string CreateValidDbf()
        {
            string path = CreateTempDbfPath();

            using (var f = new XBaseFile(XBaseFileType.dBaseIII))
            {
                XBaseField field = new XBaseField();
                field.Name = "FIELDONE";
                field.FieldType = new StringField();
                field.Length = 10;
                field.DecimalCount = 0;
                f.AddField(field);

                XBaseRecord rec = f.CreateRecord();
                rec.SetData("FIELDONE", "1234567890");
                f.AddRecord(rec);

                f.LastUpdate = new DateTime(2026, 1, 1);
                f.SaveAs(path);
                f.Close();
            }

            return path;
        }

        [Fact]
        public void OpenWhenHeaderLengthIsBelowMinimumThrowsInvalidDataException()
        {
            string path = CreateValidDbf();
            try
            {
                byte[] bytes = File.ReadAllBytes(path);

                // HeaderLength at bytes 8-9, little-endian. Set to 32 (< 33 minimum).
                bytes[8] = 32;
                bytes[9] = 0;

                File.WriteAllBytes(path, bytes);

                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                Action act = () => f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                act.Should().Throw<InvalidDataException>();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [Fact]
        public void OpenWhenHeaderLengthExceedsMaximumThrowsInvalidDataException()
        {
            string path = CreateValidDbf();
            try
            {
                byte[] bytes = File.ReadAllBytes(path);

                // 5000 decimal = 0x1388, little-endian => 0x88, 0x13.
                bytes[8] = 0x88;
                bytes[9] = 0x13;

                File.WriteAllBytes(path, bytes);

                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                Action act = () => f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                act.Should().Throw<InvalidDataException>();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [Fact]
        public void OpenWhenFixedHeaderPrefixIsTruncatedThrowsEndOfStreamException()
        {
            string path = CreateValidDbf();
            try
            {
                byte[] bytes = File.ReadAllBytes(path);

                // Keep fewer than the fixed 32-byte header prefix.
                byte[] truncated = new byte[20];
                Array.Copy(bytes, truncated, truncated.Length);
                File.WriteAllBytes(path, truncated);

                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                Action act = () => f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                act.Should().Throw<EndOfStreamException>();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [Fact]
        public void OpenWhenEofByteIsMissingThrowsEndOfStreamException()
        {
            string path = CreateValidDbf();
            try
            {
                byte[] bytes = File.ReadAllBytes(path);

                // Remove final EOF marker byte.
                byte[] withoutEof = new byte[bytes.Length - 1];
                Array.Copy(bytes, withoutEof, withoutEof.Length);
                File.WriteAllBytes(path, withoutEof);

                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                Action act = () => f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                act.Should().Throw<EndOfStreamException>();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [Fact]
        public void OpenWithNormalVariableHeaderLengthSucceeds()
        {
            string path = CreateValidDbf();
            try
            {
                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                f.FieldCount.Should().Be(1);
                f.RecordCount.Should().Be(1);

                f.Close();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }
    }
}
