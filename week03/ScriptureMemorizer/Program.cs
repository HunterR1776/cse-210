// Scripture Memorizer
// I exceded requirements by using the suggested options by Im loading scriptures from a scriptures.txt files and Im randomly selecting a scripture each time the program runs
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = ScriptureLibrary.LoadFromFile("scriptures.txt");
        Scripture scripture = library.GetRandom();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());
            Console.WriteLine();

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("All words are hidden. Great work!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}