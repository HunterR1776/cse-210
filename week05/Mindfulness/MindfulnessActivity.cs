using System;
using System.Threading;

abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    protected MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        StartMessage();
        DoActivity();
        EndMessage();
    }

    protected abstract void DoActivity();

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How many seconds would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nGood. Prepare to begin...");
        ShowSpinner(3);
    }

    private void EndMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        LogActivity();
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write($"\r{frames[i % frames.Length]} ");
            Thread.Sleep(150);
            i++;
        }
        Console.Write("\r  \r");
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r");
    }

    protected void LogActivity()
    {
        string logPath = "activity_log.txt";
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} | {_name} | {_duration} seconds";
        File.AppendAllText(logPath, entry + Environment.NewLine);
    }
}
