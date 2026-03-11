namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter First Number :");
            String a=Console.ReadLine();
            Console.WriteLine("Enter Secong Number :");
            String b = Console.ReadLine();


            double number1, number2;

            if(!double.TryParse(a,out number1) || !double.TryParse(b,out number2))
            {
                Console.WriteLine("invalid input please enter numberic marks again");

                return;
            }

            Console.Write("Enter the operator (+,-,/,*): ");

            char op = Char.Parse(Console.ReadLine());
            double result;

            switch (op)
            {
                case '+': 
                    result = number1 + number2;
                    Console.WriteLine("result is : " + result);
                    break;

                case '-': 
                    result =number1 - number2;
                    Console.WriteLine("result is : " + result);
                    break;
                case '/':
                    if (number2 == 0)
                    {
                        Console.WriteLine("Arithematic exception occurs");
                    }
                    else
                    {
                        result = number1 / number2;

                        Console.WriteLine("result is : " + result);
                    }

                    break;

                case '*': 
                    result = number1 * number2;
                    Console.WriteLine("result is : " + result);
                    break;

                default: Console.WriteLine("Invalid operator");
                    break;

            }
           









        }
    }
}
