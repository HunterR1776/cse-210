// I didnt have time to be creative.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            manager.DisplayScore();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("  1. Create new goal");
            Console.WriteLine("  2. List goals");
            Console.WriteLine("  3. Record an event");
            Console.WriteLine("  4. Save goals");
            Console.WriteLine("  5. Load goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": manager.CreateGoal(); break;
                case "2": manager.ListGoals(); break;
                case "3": manager.RecordEvent(); break;
                case "4":
                    Console.Write("Filename: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Filename: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
