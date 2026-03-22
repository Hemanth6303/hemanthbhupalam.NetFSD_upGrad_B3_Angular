namespace ConsoleApp8
{
    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            //even if error occur or not  the finally block always executes
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }


    internal class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();

            Console.Write("Enter Numerator: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("Enter Denominator: ");
            int den = int.Parse(Console.ReadLine());

            calc.Divide(num, den);

           

        }

        

    }

}