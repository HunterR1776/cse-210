using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to hunt turkeys", "HuntingwithDylan", 620);
        video1.AddComment(new Comment("Joe", "Wow, I didnt know that turkeys were actually real!"));
        video1.AddComment(new Comment("Ben", "What type of broadheads do you use?"));
        video1.AddComment(new Comment("jason", "Can you make a part 2?"));
        videos.Add(video1);

        Video video2 = new Video("How to think like a turkey", "turkey Academy", 900);
        video2.AddComment(new Comment("Dan", "Best explanation so far."));
        video2.AddComment(new Comment("Eli", "This helped me understand the turkey mind."));
        video2.AddComment(new Comment("Frank", "Please make one on ducks."));
        videos.Add(video2);

        Video video3 = new Video("How to make turkey finger lickin good", "OutdoorEatz", 600);
        video3.AddComment(new Comment("Greg", "These recipes look amazing."));
        video3.AddComment(new Comment("Henry", "I’m trying the Turkey bowl."));
        video3.AddComment(new Comment("Issac", "Thanks for showing how to remove the turkey shot, I always get lead posioning."));
        videos.Add(video3);

        Video video4 = new Video("How To Get In Shape For Turkey Season", "FitLikeAMoose", 300);
        video4.AddComment(new Comment("Jack", "I cant do that, I quit"));
        video4.AddComment(new Comment("BirdBoy111", "That last exercise was tough!"));
        video4.AddComment(new Comment("Leo", "I liked it"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.VideoTitle}");
            Console.WriteLine($"Author: {video.VideoAuthor}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommentAuthorName}: {comment.CommentContent}");
            }

            Console.WriteLine();
        }
    }
}