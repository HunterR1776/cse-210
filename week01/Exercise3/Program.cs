using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 1110);
        Console.WriteLine("Hello, I have a magic number that I have selected! Make your gues and I will tell you if you are High or Low.");
        int guess = 0;
        while (guess != number) {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());
            if (guess > number) {
                Console.WriteLine("Too high! Try again.");
            }
            else if (guess < number) {
                Console.WriteLine("Too low! Try again.");
                }
            else {
                Console.WriteLine("Congratulations! You guessed the correct number!");
            }
        }
    }
}