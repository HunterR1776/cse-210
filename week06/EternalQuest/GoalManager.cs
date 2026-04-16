using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour score: {_score} points");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nGoal types:");
        Console.WriteLine("  1. Simple Goal      (complete once for points)");
        Console.WriteLine("  2. Eternal Goal     (earns points every time)");
        Console.WriteLine("  3. Checklist Goal   (complete N times for bonus)");
        Console.Write("Select type: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points per event: ");
        int.TryParse(Console.ReadLine(), out int pts);

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, pts));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, pts));
                break;
            case "3":
                Console.Write("Required completions: ");
                int.TryParse(Console.ReadLine(), out int req);
                Console.Write("Bonus points on completion: ");
                int.TryParse(Console.ReadLine(), out int bonus);
                _goals.Add(new ChecklistGoal(name, desc, pts, req, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }
        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        ListGoals();
        if (_goals.Count == 0) return;

        Console.Write("Enter goal number: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal goal = _goals[index - 1];
        int earned = goal.RecordEvent();

        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"\nYou earned {earned} points!");
            if (goal.IsComplete())
                Console.WriteLine("Goal complete! Well done!");
        }
        else
        {
            Console.WriteLine("This goal is already complete or gave no points.");
        }
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter writer = new StreamWriter(filename);
        writer.WriteLine(_score);
        foreach (Goal g in _goals)
            writer.WriteLine(g.GetStringRepresentation());
        Console.WriteLine($"Saved to {filename}.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            int pts = int.Parse(parts[3]);

            switch (type)
            {
                case "SimpleGoal":
                    bool done = bool.Parse(parts[4]);
                    _goals.Add(new SimpleGoal(name, desc, pts, done));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, desc, pts));
                    break;
                case "ChecklistGoal":
                    int req = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int times = int.Parse(parts[6]);
                    _goals.Add(new ChecklistGoal(name, desc, pts, req, bonus, times));
                    break;
            }
        }
        Console.WriteLine($"Loaded from {filename}.");
    }
}
