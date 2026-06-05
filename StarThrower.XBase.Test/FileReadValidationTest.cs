/***********************************************************************************
    StarThrower Utilities / XBase
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarThrower.XBase;

namespace StarThrower.XBase.Test
{
    [TestClass]
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

        [TestMethod]
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
                Assert.ThrowsException<InvalidDataException>(() =>
                    f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [TestMethod]
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
                Assert.ThrowsException<InvalidDataException>(() =>
                    f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [TestMethod]
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
                Assert.ThrowsException<EndOfStreamException>(() =>
                    f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [TestMethod]
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
                Assert.ThrowsException<EndOfStreamException>(() =>
                    f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [TestMethod]
        public void OpenWithNormalVariableHeaderLengthSucceeds()
        {
            string path = CreateValidDbf();
            try
            {
                using XBaseFile f = new XBaseFile(XBaseFileType.dBaseIII);
                f.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

                Assert.AreEqual(1, f.FieldCount);
                Assert.AreEqual(1, f.RecordCount);

                f.Close();
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }
    }
}
