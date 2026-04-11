using System;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void DoActivity()
    {
        int elapsed = 0;
        bool inhale = true;

        while (elapsed < _duration)
        {
            int pauseSeconds = 4;
            if (elapsed + pauseSeconds > _duration)
                pauseSeconds = _duration - elapsed;

            if (inhale)
            {
                Console.WriteLine("\nBreathe in...");
                ShowCountdown(pauseSeconds);
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
                ShowCountdown(pauseSeconds);
            }

            elapsed += pauseSeconds;
            inhale = !inhale;
        }
    }
}
