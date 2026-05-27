using System;
using System.IO;
using System.Text;
using StarThrower.Logging;

namespace StarThrower.FileUtilities
{
    public static class FileSystem
    {
        /// <summary>
        /// This method accepts two strings the represent two files to 
        /// compare. A return value of 0 indicates that the contents of the files
        /// are the same. A return value of any other value indicates that the 
        /// files are not the same.
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns></returns>
        /// <see>http://support.microsoft.com/kb/320348</see>
        /// <exception cref="ArgumentNullException">Thrown if file1 or file2 is null.</exception>
        public static bool FileCompare(string file1, string file2)
        {
            if (file1 == null) throw new ArgumentNullException("file1");
            if (file2 == null) throw new ArgumentNullException("file2");

            try
            {
                // Determine if the same file was referenced two times.
                if (file1.Equals(file2))
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
            catch (Exception ex)
            {
                Logger.ReportError(ErrorPolicy.Internal, "FileSystem.FileCompare(string, string)", ex);
                throw;
            }
        }

        /// <summary>
        /// Writes the content of "text" out to the file specified by fileName.
        /// If the file already exists, it is deleted and rewritten.
        /// </summary>
        /// <param name="fileName">The name of the file to be written</param>
        /// <param name="text">The content to write out to the file</param>
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
        public static void DeleteFiles(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            for (int i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }
    }
}
