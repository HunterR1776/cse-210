using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public void HideRandomWords(int count)
    {
        var visible = _words.Where(w => !w.IsHidden).ToList();
        int toHide = Math.Min(count, visible.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index); // don't pick the same word twice
        }
    }

    public bool IsFullyHidden() => _words.All(w => w.IsHidden);

    public string Display()
    {
        var sb = new StringBuilder();
        sb.AppendLine(_reference.ToString());
        sb.Append(string.Join(" ", _words.Select(w => w.Display())));
        return sb.ToString();
    }
}

