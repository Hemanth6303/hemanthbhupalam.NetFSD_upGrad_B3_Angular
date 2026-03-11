namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter Number: ");
            String input=Console.ReadLine();
            int number;

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Invalid input please enter numeric value again");
                return;
            }

            int eCount = 0;
            int oCount = 0;
            int sum = 0;
            for(int i=0;i<=number;i++)
            {
                sum = sum + i;
                if(i%2==0)
                {
                    eCount++;
                }
                else
                {
                    oCount++;
                }

            }

            Console.WriteLine("Event Count " + eCount);
            Console.WriteLine("Odd Count " + oCount);
            Console.WriteLine("Sum: "+sum);


            







        }
    }
}
