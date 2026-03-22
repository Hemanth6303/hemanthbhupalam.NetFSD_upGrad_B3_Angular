namespace ConsoleApp8
{
    public record Student(int RollNumber, string Name, string Course, int Marks);

    internal class Program
    {
        static List<Student> students = new List<Student>();
        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n   Student Record Management System  ");
                Console.WriteLine("1. add students");
                Console.WriteLine("2.Display all students");
                Console.WriteLine("3.Search student by roll number");
                Console.WriteLine("4.exit");
                Console.WriteLine("Enter your choice: ");

                if(!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }
                switch(choice)
                {
                    case 1: AddStudents();
                            break;

                    case 2: DisplayStudents();
                            break;

                    case 3:
                            SearchStudent();
                             break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;

                }

            }
            while (choice != 4);
            
        }

        static void AddStudents()
        {
            Console.Write("Enter number of students: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Enter details for Student {i + 1} ---");

                int roll;
                while (true)
                {
                    Console.Write("Enter Roll Number: ");
                    if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                        break;
                    Console.WriteLine("Invalid Roll Number!");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                int marks;
                while (true)
                {
                    Console.Write("Enter Marks: ");
                    if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                        break;
                    Console.WriteLine("Marks must be between 0 and 100!");
                }

                students.Add(new Student(roll, name, course, marks));
            }
        }
        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No records found!");
                return;
            }

            Console.WriteLine("\n--- Student Records ---");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }
        static void SearchStudent()
        {
            Console.Write("Enter Roll Number to search: ");
            if (!int.TryParse(Console.ReadLine(), out int roll))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            var student = students.Find(s => s.RollNumber == roll);

            if (student != null)
            {
                Console.WriteLine("\nStudent Found:");
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

    }

}