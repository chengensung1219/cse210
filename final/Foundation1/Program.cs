using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Captain America: Brave New World", "Marvel Entertainment", 108);
        Video video2 = new Video("Are you an ideal team player?", "Patrick Lencioni", 878);
        Video video3 = new Video("Rebuilding A Wrecked Tesla Cyber Truck", "BoostedBoiz", 2400);

        video1.AddComments(new Comment("Christy", "I can’t lie, this is probably the best edited marvel trailer I’ve seen."));
        video1.AddComments(new Comment("Simon", "They FINALLY got the red hulk! HELL YESSSSSS!!!!!!"));
        video1.AddComments(new Comment("John", "Sam’s new Captain America suit looks very cool!"));
        video1.AddComments(new Comment("Tyrael", "A Flying Captain America! Looks Good!"));

        video2.AddComments(new Comment("Alan", "I've read all his books except this one - always so easy to understand and apply!  This talk was so powerfully delivered in a few minutes.  Love it!"));
        video2.AddComments(new Comment("Seth", "This is one of my favourite Tedx talks ever!!"));
        video2.AddComments(new Comment("Frank", "The principles of Servant Leadership will embrace HHS.  Thank you for the lesson Patrick!"));
        video2.AddComments(new Comment("Alex", "Such a great message delivered by such a great speaker."));

        video3.AddComments(new Comment("David", "Love that he embrace the comments and makes it positive!!"));
        video3.AddComments(new Comment("Linda", "Don't listen to haters. This is amazing content right here! It's not ICE or EV. You can do both!!!"));
        video3.AddComments(new Comment("Tina", "Kyle, I appreciate your attention to detail and focus on electrical safety in this video."));
        video3.AddComments(new Comment("Tiffiny", "lad to see you posting more of both EV and Honda content."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        for (int i = 0; i < videos.Count; i++)
        {   
            Video video = videos[i];
            video.DisplayInfo();
        }

        }
}