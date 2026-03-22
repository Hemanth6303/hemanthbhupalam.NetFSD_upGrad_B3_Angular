using System;
using System.IO;

namespace DriveMonitorApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("\n--- Drive Information ---\n");

                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"Drive Name : {drive.Name}");
                    Console.WriteLine($"Drive Type : {drive.DriveType}");

                    // Check if drive is ready
                    if (drive.IsReady)
                    {
                        long totalSize = drive.TotalSize;
                        long freeSpace = drive.AvailableFreeSpace;

                        double freePercentage = (freeSpace * 100.0) / totalSize;

                        Console.WriteLine($"Total Size        : {totalSize / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Available Space   : {freeSpace / (1024 * 1024 * 1024)} GB");
                        Console.WriteLine($"Free Space (%)    : {freePercentage:F2}%");

                        // Warning condition
                        if (freePercentage < 15)
                        {
                            Console.WriteLine("⚠ WARNING: Low disk space!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Drive not ready.");
                    }

                    Console.WriteLine("----------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}