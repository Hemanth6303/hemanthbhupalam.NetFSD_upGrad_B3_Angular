using System;
using System.Diagnostics;

namespace OrderTracingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Trace Listener (log file)
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("order_log.txt"));
            Trace.AutoFlush = true;

            Trace.WriteLine("Application Started");

            try
            {
                ProcessOrder();
                Trace.TraceInformation("Order processed successfully.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
            }

            Trace.WriteLine("Application Ended");

            Console.WriteLine("Order processing completed. Check log file.");
            Console.ReadLine();
        }

        static void ProcessOrder()
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();
        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Validating Order...");
            // Simulate success
            Trace.TraceInformation("Order validation successful.");
        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Processing Payment...");
            // Simulate delay
            System.Threading.Thread.Sleep(1000);

            // Simulate error (for debugging demo)
            // Uncomment below line to test failure
            // throw new Exception("Payment failed!");

            Trace.TraceInformation("Payment processed successfully.");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Updating Inventory...");
            Trace.TraceInformation("Inventory updated.");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Generating Invoice...");
            Trace.TraceInformation("Invoice generated.");
        }
    }
}