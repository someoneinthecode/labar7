class Program
{
    static void Main()
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(
            initializeTask: () => Console.ReadLine(),
            resetTask: task => Console.WriteLine($"Task '{task}' completed.")
        );

        Console.WriteLine("Enter tasks with priority. Press Enter to execute the next task or type 'exit' to quit.");

        while (true)
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();

            if (task.ToLower() == "exit")
            {
                break;
            }

            Console.Write("Enter priority: ");
            if (int.TryParse(Console.ReadLine(), out int priority))
            {
                scheduler.AddTask(task, priority);
            }
            else
            {
                Console.WriteLine("Invalid priority. Please enter a valid integer.");
            }
        }

        Console.WriteLine("Executing tasks:");

        while (true)
        {
            Console.WriteLine("Press Enter to execute the next task or type 'exit' to quit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            scheduler.ExecuteNext(task => Console.WriteLine($"Executing task: {task}"));
        }
    }
}
