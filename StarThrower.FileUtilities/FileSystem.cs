// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StarThrower.FileUtilities
{
    public static class FileSystem
    {
        /// <summary>
        /// Compares the contents of two files byte-for-byte.
        /// </summary>
        /// <param name="file1">The path of the first file.</param>
        /// <param name="file2">The path of the second file.</param>
        /// <returns><see langword="true"/> if the two files have identical length and contents, or refer to the same path; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// Adapted from https://support.microsoft.com/kb/320348.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown if file1 or file2 is null.</exception>
        public static bool FileCompare(string? file1, string? file2)
        {
            ArgumentNullException.ThrowIfNull(file1);
            ArgumentNullException.ThrowIfNull(file2);

            // Determine if the same file was referenced two times.
            if (file1.Equals(file2, StringComparison.Ordinal))
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            bool lengthsMatch = false;
            int file1byte = 0;
            int file2byte = 0;

            using (FileStream fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (FileStream fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    // Check the file sizes. If they are not the same, the files
                    // are not the same.
                    lengthsMatch = (fs1.Length == fs2.Length);
                    if (lengthsMatch)
                    {

                        // Read and compare a byte from each file until either a
                        // non-matching set of bytes is found or until the end of
                        // file1 is reached.
                        do
                        {
                            // Read one byte from each file.
                            file1byte = fs1.ReadByte();
                            file2byte = fs2.ReadByte();
                        }
                        while ((file1byte == file2byte) && (file1byte != -1));
                    }
                }
            }

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return (lengthsMatch && ((file1byte - file2byte) == 0));
        }

        /// <summary>
        /// Writes the content of "text" out to the file specified by fileName.
        /// If the file already exists, it is deleted and rewritten.
        /// </summary>
        /// <param name="fileName">The name of the file to be written</param>
        /// <param name="text">The content to write out to the file</param>
        /// <remarks>
        /// The text is encoded as ASCII, so any character outside the 7-bit ASCII range is
        /// replaced with "?" rather than preserved.
        /// </remarks>
        public static void WriteTextFile(string fileName, string text)
        {
            if (File.Exists(fileName)) File.Delete(fileName);
            using (FileStream fs = File.Create(fileName))
            {
                byte[] entry = new ASCIIEncoding().GetBytes(text);
                fs.Write(entry, 0, entry.Length);
            }
        }


        /// <summary>
        /// Deletes all files contained in the folder specified by "directory"
        ///
        /// NOTE: Only child files of the specified folder are removed.  Subfolders and their contents are not removed.
        /// </summary>
        /// <param name="directory">The directory from which all files should be deleted</param>
        /// <exception cref="AggregateException">
        /// Thrown after all files have been attempted if one or more files could not be deleted.
        /// Each inner exception corresponds to one file that failed to delete.
        /// </exception>
        /// <remarks>
        /// This is a change from the original behavior of this method, which stopped immediately
        /// on the first file that failed to delete, leaving any remaining files untouched. This
        /// method now attempts to delete every file in the directory on a best-effort basis —
        /// a single locked or inaccessible file no longer prevents the rest from being deleted —
        /// and reports any failures together via <see cref="AggregateException"/> once all files
        /// have been attempted.
        /// </remarks>
        public static void DeleteFiles(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            List<Exception>? failures = null;

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
                {
                    (failures ??= []).Add(new IOException($"Failed to delete file: {file}", ex));
                }
            }

            if (failures is not null)
            {
                throw new AggregateException($"Failed to delete {failures.Count} of {files.Length} file(s) in directory: {directory}", failures);
            }
        }
    }
}
