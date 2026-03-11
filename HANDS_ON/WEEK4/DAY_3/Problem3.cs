namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter name: ");
            String name=Console.ReadLine();

            Console.WriteLine("Enter salary: ");
            double salary=double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience: ");
            int experience=int.Parse(Console.ReadLine());

            double bonusPercantage=(experience<2)?0.05:
                                   (experience <= 5) ? 0.10 : 0.15;

            double bonus = salary * bonusPercantage;
            double finalsalary = salary + bonus;

            Console.WriteLine("Employee name:" + name);
            Console.WriteLine("Bonus:" + bonus);
            Console.WriteLine("Final Salary " + finalsalary);









        }
    }
}
