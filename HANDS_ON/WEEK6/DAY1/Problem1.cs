using System;
using System.Threading.Tasks;

namespace AsyncFileLogger
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            // Calling async logging multiple times
            Task t1 = WriteLogAsync("User logged in");
            Task t2 = WriteLogAsync("File uploaded");
            Task t3 = WriteLogAsync("Payment processed");
            Task t4 = WriteLogAsync("User logged out");

            Console.WriteLine("Logging in progress...\n");

            // Wait for all logging tasks to complete
            await Task.WhenAll(t1, t2, t3, t4);

            Console.WriteLine("\nAll logs written successfully!");
            Console.ReadLine();
        }

        // Asynchronous method
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");

            // Simulate file writing delay
            await Task.Delay(2000);

            Console.WriteLine($"Log written: {message}");
        }
    }
}