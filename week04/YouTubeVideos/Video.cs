using System.Collections.Generic;

public class Video
{
    public string VideoTitle { get; set; }
    public string VideoAuthor { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> _comments = new List<Comment>();

    public Video(string videoTitle, string videoAuthor, int lengthInSeconds)
    {
        VideoTitle = videoTitle;
        VideoAuthor = videoAuthor;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}