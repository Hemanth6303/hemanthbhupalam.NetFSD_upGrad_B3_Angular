using System;
using System.IO;
using System.Text;

namespace ConsoleApp41
{
    class Program
    {
        static void Main()
        {
            string dirName = "Logs";

            // Create directory if not exists
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            string filePath = Path.Combine(dirName, "log_messages.txt");

            try
            {
                while (true)
                {
                    Console.Write("Enter message (type 'exit' to stop): ");
                    string message = Console.ReadLine();

                    if (message.ToLower() == "exit")
                        break;

                    // Add timestamp
                    string logMessage = $"[{DateTime.Now}] {message}\n";

                    // Convert to bytes
                    byte[] data = Encoding.UTF8.GetBytes(logMessage);

                    // Use Stream (FileStream internally)
                    using (Stream stream = new FileStream(
                        filePath,
                        FileMode.Append,
                        FileAccess.Write))
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    Console.WriteLine("Message written successfully!");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: No permission to access file.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error: File operation failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            Console.WriteLine("Program ended.");
            Console.ReadLine();
        }
    }
}