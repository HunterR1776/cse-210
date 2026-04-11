/*
 * Mindfulness App - Program.cs
 *
 * Requirements exceeded (extra credit):
 *  1. I added a activity log that tracks what activities are done. use option 4 to view
 *  2. No repeated prompts/questions within a session
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness App ===\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. View Activity Log");
            Console.WriteLine("  5. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    ShowLog();
                    continue;
                case "5":
                    Console.WriteLine("\nGoodbye! Keep taking time for yourself.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }

    static void ShowLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log ===\n");
        string logPath = "activity_log.txt";
        if (File.Exists(logPath))
        {
            Console.WriteLine(File.ReadAllText(logPath));
        }
        else
        {
            Console.WriteLine("No activities logged yet.");
        }
        Console.WriteLine("\nPress enter to return to the menu.");
        Console.ReadLine();
    }
}
