using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

   
   
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Employee emp = new Employee("Marko Horvat", 4500m, 35);

                Console.WriteLine("Employee ID: " + emp.EmployeeId);
                Console.WriteLine("Name: " + emp.FullName);
                Console.WriteLine("Age: " + emp.Age);
                Console.WriteLine("Salary: " + emp.Salary);

                emp.GiveRaise(15);

                emp.DeductPenalty(200);

                // emp.Salary = 500; ❌ Not allowed (private set)

                emp.FullName = "Marko Horvat Jr."; //We are setting the full name

                Console.WriteLine("Updated Name: " + emp.FullName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
