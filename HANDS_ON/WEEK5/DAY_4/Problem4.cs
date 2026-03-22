using System;
using System.IO;

namespace DirectoryAnalysisApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter root directory path: ");
                string rootPath = Console.ReadLine();

                // Validate directory
                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path!");
                    return;
                }

                DirectoryInfo rootDir = new DirectoryInfo(rootPath);

                // Get subdirectories
                DirectoryInfo[] subDirs = rootDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    Console.WriteLine("No subdirectories found.");
                    return;
                }

                Console.WriteLine("\n--- Directory Analysis ---\n");

                foreach (DirectoryInfo dir in subDirs)
                {
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine($"Folder Name : {dir.Name}");
                    Console.WriteLine($"Full Path   : {dir.FullName}");
                    Console.WriteLine($"File Count  : {files.Length}");
                    Console.WriteLine("----------------------------------");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access denied to some folders.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}