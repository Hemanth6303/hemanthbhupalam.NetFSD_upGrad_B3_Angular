using System;
using System.IO;

namespace FileAuditApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path!");
                    return;
                }

                // Get all files
                string[] files = Directory.GetFiles(folderPath);

                if (files.Length == 0)
                {
                    Console.WriteLine("No files found in the directory.");
                    return;
                }

                Console.WriteLine("\n--- File Details ---\n");

                int count = 0;

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    Console.WriteLine($"File Name     : {fileInfo.Name}");
                    Console.WriteLine($"File Size     : {fileInfo.Length} bytes");
                    Console.WriteLine($"Created On    : {fileInfo.CreationTime}");
                    Console.WriteLine("----------------------------------");

                    count++;
                }

                Console.WriteLine($"\nTotal Files: {count}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: Access denied to the folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}