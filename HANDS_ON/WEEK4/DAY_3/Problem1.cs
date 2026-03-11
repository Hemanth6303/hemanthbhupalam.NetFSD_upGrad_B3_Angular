namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter student name: ");
            String name=Console.ReadLine();

            Console.WriteLine("Enter student marks: ");
            String input = Console.ReadLine();

            int marks; //default value is 0

            if(!int.TryParse(input,out marks))
            {
                Console.WriteLine("Invalid input please enter numeric marks again");
            }
            else if(marks<0||marks>100)
            {
                Console.WriteLine("Invalid marks please enter marks again");
            }
            else
            {
                char grade;

                if (marks >= 90)
                {
                    grade = 'A';
                }
                else if (marks >= 75)
                {
                    grade = 'B';
                }
                else if (marks >= 60)
                {
                    grade = 'C';
                }
                else if (marks >= 40)
                {
                    grade = 'D';
                }
                else
                {
                    grade = 'Fail';   
                }
                Console.WriteLine("name: " + name);
                Console.WriteLine("Grade: " + grade);



            }




        }
    }
}
