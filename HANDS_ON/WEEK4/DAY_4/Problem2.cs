namespace ConsoleApp1
{

    class Calculator
    {
        public double Add(double a,double b)
        {
            return a + b;
        }
        public double Sub(double a,double b)
        {
            return a - b;   
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the first number: ");
            String input1 = Console.ReadLine();
            double.TryParse(input1, out double number1);

            Console.WriteLine("Enter the Second number: ");
            String input2 = Console.ReadLine();
            double.TryParse(input2, out double number2);


            Calculator c = new Calculator();
            Console.WriteLine("Addition " + c.Add(number1, number2));

            Console.WriteLine("Subtraction " + c.Sub(number1, number2));





        }
    }
}
