using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private static Random _random = new Random();

    private ScriptureLibrary(List<Scripture> scriptures)
    {
        _scriptures = scriptures;
    }

    public Scripture GetRandom()
    {
        return _scriptures[_random.Next(_scriptures.Count)];
    }

    // File format per line: Book|Chapter|StartVerse|EndVerse|Text
    // EndVerse is optional — leave blank for single verse
    // Example: John|3|16||For God so loved the world...
    // Example: Proverbs|3|5|6|Trust in the Lord...
    public static ScriptureLibrary LoadFromFile(string path)
    {
        var scriptures = new List<Scripture>();

        foreach (string line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            string[] parts = line.Split('|');
            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            string text = parts[4];

            ScriptureReference reference;
            if (!string.IsNullOrEmpty(parts[3]))
                reference = new ScriptureReference(book, chapter, startVerse, int.Parse(parts[3]));
            else
                reference = new ScriptureReference(book, chapter, startVerse);

            scriptures.Add(new Scripture(reference, text));
        }

        return new ScriptureLibrary(scriptures);
    }
}
