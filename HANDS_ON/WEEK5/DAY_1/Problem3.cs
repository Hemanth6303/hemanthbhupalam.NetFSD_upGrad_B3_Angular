using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

    class Product
    {
        
        private double price;
        public String Name { get; set; }//Auto implemented properties

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative");
                }
                else
                {
                    price = value;
                }
            }
        }
        public virtual void CalculateDiscount() {
            Console.WriteLine("Final Price = " + price);
        }


    }
    class Electronics : Product
    {
        public override void CalculateDiscount()
        {
            double finalPrice = Price - (Price * 0.05);
            Console.WriteLine("Final price after 5% discount = " + finalPrice);
        }
    }
    class Clothing : Product
    {
        public override void CalculateDiscount()
        {
            double finalPrice = Price - (Price * 0.15);
            Console.WriteLine("Final price after 15% discount = " + finalPrice);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Product electronics = new Electronics();
            electronics.Name = "Desktop";
            electronics.Price = 20000;
            electronics.CalculateDiscount();

            Product clothing = new Clothing();
            clothing.Name = "T-Shirt";
            clothing.Price = 2000;
            clothing.CalculateDiscount();

        }
    }
}
