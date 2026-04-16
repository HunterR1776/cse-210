// I didnt have time to be creative.
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 5), 30, 3.0),
            new Cycling(new DateTime(2023, 12, 6), 45, 15.0),
            new Swimming(new DateTime(2025, 12, 7), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
