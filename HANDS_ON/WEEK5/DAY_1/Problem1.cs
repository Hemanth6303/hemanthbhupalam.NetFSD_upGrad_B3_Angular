using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

    class BankAccount1
    {

        private String _accountNumber;
        private double _balance;
        public String AccountNumber {
            get {
                return _accountNumber;
            }
            set {
                _accountNumber = value;
            }
        }
        // Property for Balance (Read Only outside)
        public double Balanace {

            get
            {
                return _balance;
            }
            private set
            {
                _balance = value;
            }
        
        }

        public void Deposit(double amount)
        {
            if(amount<=0)
            {
                Console.WriteLine("the amount is invalid");
                return;
            }

            _balance += amount;

            Console.WriteLine("Deposi sucessful. " + "current balance= " + _balance);
        }

        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
                return;
            }
            if(amount>_balance)
            {
                Console.WriteLine("Insufficient balance");
                return;
            }
            _balance -= amount;
            Console.WriteLine("withdrawal successful.");
            Console.WriteLine("current balance = " + _balance);
        }


    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount1 account = new BankAccount1();

            account.AccountNumber = "2576BGUPH";
            // account.Balanace = 2000; 
            account.Deposit(5000);
            account.withdraw(3000);



        }
    }
}
