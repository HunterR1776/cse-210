public class ScriptureReference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    // Single verse: "John 3:16"
    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    // Verse range: "Proverbs 3:5-6"
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        return $"{Book} {Chapter}:{StartVerse}";
    }
}
