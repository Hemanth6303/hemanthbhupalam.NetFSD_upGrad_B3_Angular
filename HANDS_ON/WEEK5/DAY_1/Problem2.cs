using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

    class Employee1
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public virtual void CalculateSalary()
        {
            Console.WriteLine(BaseSalary);
        }
       
       


    }
    class Manager : Employee1
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Manager Salary = "+(BaseSalary + (BaseSalary * 0.2)));
        }
    }

    class Developer : Employee1
    {
        public override void CalculateSalary()
        {
            Console.WriteLine("Developer Salary = "+ (BaseSalary + (BaseSalary * 0.1)));
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseSalary = 5000;

            Employee1 manager = new Manager();
            manager.BaseSalary=baseSalary;
            manager.CalculateSalary();  


            Employee1 developer = new Developer();
            developer.BaseSalary = baseSalary;
            developer.CalculateSalary();



        }
    }
}
