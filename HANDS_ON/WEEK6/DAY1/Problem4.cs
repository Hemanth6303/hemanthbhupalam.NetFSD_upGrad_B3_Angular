using System;
using System.Threading.Tasks;

namespace OrderProcessingSystem
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Order Processing Started...\n");

            await ProcessOrderAsync();

            Console.WriteLine("\nOrder Processing Completed Successfully!");
            Console.ReadLine();
        }

        static async Task ProcessOrderAsync()
        {
            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();
        }

        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Verifying Payment...");
            await Task.Delay(2000); // Simulate delay
            Console.WriteLine("Payment Verified ✅\n");
        }

        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Checking Inventory...");
            await Task.Delay(3000); // Simulate delay
            Console.WriteLine("Inventory Available ✅\n");
        }

        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Confirming Order...");
            await Task.Delay(1500); // Simulate delay
            Console.WriteLine("Order Confirmed 🎉\n");
        }
    }
}