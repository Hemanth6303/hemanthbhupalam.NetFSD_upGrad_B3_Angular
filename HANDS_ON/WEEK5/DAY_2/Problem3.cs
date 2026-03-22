using ConsoleApp1;

namespace ConsoleApp8
{

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    // 2. BankAccount Class
    public class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                // Throw custom exception
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal successful!");
            Console.WriteLine("Remaining Balance: " + balance);
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter Balance: ");
            double balance = double.Parse(Console.ReadLine());

            Console.Write("Enter Withdrawal Amount: ");
            double amount = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(balance);

            try
            {
                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed.");
            }

            Console.WriteLine("Program continues safely...");


        }

        

    }

}