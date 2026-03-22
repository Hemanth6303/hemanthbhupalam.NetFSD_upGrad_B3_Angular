namespace ConsoleApp8
{

    
    class Program
    {
        static void Main()
        {
            List<string> tasks = new List<string>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;

                    case "2":
                        ViewTasks(tasks);
                        break;

                    case "3":
                        RemoveTask(tasks);
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        // Add Task
        static void AddTask(List<string> tasks)
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Task cannot be empty.");
            }
        }

        // View Tasks
        static void ViewTasks(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Task list is empty.");
                return;
            }

            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        // Remove Task
        static void RemoveTask(List<string> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks to remove.");
                return;
            }

            Console.Write("Enter task number to remove: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int taskNumber))
            {
                if (taskNumber >= 1 && taskNumber <= tasks.Count)
                {
                    string removedTask = tasks[taskNumber - 1];
                    tasks.RemoveAt(taskNumber - 1);
                    Console.WriteLine($"Removed: {removedTask}");
                }
                else
                {
                    Console.WriteLine("Invalid task number.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

}