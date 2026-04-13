public class Comment
{
    public string CommentAuthorName {get; set; }
    public string CommentContent {get; set; }

    public Comment(string commentAuthorName, string commentContent)
    {
        CommentAuthorName = commentAuthorName;
        CommentContent = commentContent;
    }

}