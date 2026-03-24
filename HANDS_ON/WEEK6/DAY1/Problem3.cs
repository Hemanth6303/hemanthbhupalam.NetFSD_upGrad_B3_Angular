using System;
using System.Threading.Tasks;

namespace ReportGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Report Generation Started...\n");

            // Run tasks concurrently
            Task t1 = Task.Run(() => GenerateSalesReport());
            Task t2 = Task.Run(() => GenerateInventoryReport());
            Task t3 = Task.Run(() => GenerateCustomerReport());

            // Wait for all tasks
            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("\nAll Reports Generated Successfully!");
            Console.ReadLine();
        }

        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started...");
            await Task.Delay(3000);
            Console.WriteLine("Sales Report Completed!");
        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started...");
            await Task.Delay(4000);
            Console.WriteLine("Inventory Report Completed!");
        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            await Task.Delay(2000);
            Console.WriteLine("Customer Report Completed!");
        }
    }
}