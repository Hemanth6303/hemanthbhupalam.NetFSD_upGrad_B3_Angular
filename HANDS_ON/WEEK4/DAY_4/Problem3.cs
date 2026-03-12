using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace ConsoleApp1
{

    class Student
    {
        public static void calculateAverage(int[] numbers)
        {
            int sum = 0;
            for(int i=0;i<numbers.Length;i++)
            {
                sum = sum + numbers[i];
            }
            double average = (sum / numbers.Length);

            if (average >= 80)
                Console.WriteLine("Average: " + average + " Grade: A");
            else if (average >= 60)
                Console.WriteLine("Average: " + average + " Grade: B");

            else if (average >= 50)
                Console.WriteLine("Average: " + average + " Grade: C");

            else
                Console.WriteLine("Average: " + average + " Grade: F");

        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter size");
            int.TryParse(Console.ReadLine(), out int size);

            int[] numbers= new int[size];

            for(int i=0;i<size;i++)
            {
                Console.WriteLine("Enter the number" + (i+1) + ": ");
                int.TryParse(Console.ReadLine(), out numbers[i]); 
            }

            Student.calculateAverage(numbers);
         

        }
    }
}
