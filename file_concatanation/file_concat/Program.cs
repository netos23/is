using System;
using System.IO;
using System.Text;

namespace file_concat
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConcatFiles("./a.txt","./b.txt","./ab.txt");
        }

        private static void ConcatMultipleFiles(string resFilename, params string[] filenames)
        {
            using (var result = File.Open(resFilename, FileMode.Create))
            {
                using (var writer = new BinaryWriter(result, Encoding.UTF8, false))
                {
                    foreach (var filename in filenames)
                    {
                        CopyFile(filename, writer);
                    }
                }
            }
        }

        private static void CopyFile(string filename, BinaryWriter writer)
        {
            using (var file = File.Open(filename, FileMode.Open))
            {
                using (var reader = new BinaryReader(file, Encoding.UTF8, false))
                {
                    var buffer = new byte[2];
                    var read = 0;
                    
                    do
                    {
                        read = reader.Read(buffer, 0, 2);
                        writer.Write(buffer, 0, read);
                    } while (read != 0);
                }
            }
        }

        private static void ConcatFiles(string fileA, string fileB, string fileAb)
        {
            ConcatMultipleFiles(fileAb, fileA, fileB);
        }
    }
}