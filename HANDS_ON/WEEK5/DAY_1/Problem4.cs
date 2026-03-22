using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

   
    class Vehicle
    {
        public String Brand { get; set; }


        private int rentalRatePerDay;

        public int RentalRatePerDay
        {
            get {  return rentalRatePerDay; }
            set
            {
                if(value<0)
                {
                    Console.WriteLine("Rental rate cannot be negative");
                }
                else
                {
                    rentalRatePerDay = value;
                }
            }
        }
        public virtual void CalculateRental(int days)
        {
            Console.WriteLine("Total Rental = " + (RentalRatePerDay * days));
        }

    }
    class Car : Vehicle
    {
        public override void CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of rental days.");
                return;
            }
            double total = (RentalRatePerDay * days) + 500;
            Console.WriteLine("Total Rental = " + total);
        }
    }
    class Bike : Vehicle
    {
        public override void CalculateRental(int days)
        {
            if(days<=0)
            {
                Console.WriteLine("Invalid number of rental days.");
                return;
            }
            double total = (RentalRatePerDay * days);
            double discount = total * 0.05;
            double finalAmount = total - discount;
            Console.WriteLine("Total Rental after 5% discount = "+finalAmount);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car();
            car.Brand = "Toyota";
            car.RentalRatePerDay = 2000;
            car.CalculateRental(3);

            Vehicle bike = new Bike();
            bike.Brand = "Yamaha";
            bike.RentalRatePerDay = 500;
            bike.CalculateRental(3);

        }
    }
}
