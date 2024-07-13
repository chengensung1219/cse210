using System;

class Video{
    private string Title {get; set; }
    private string Author {get; set; }
    private int Length {get; set; }
    private int Count {get; set; }
    private List<Comment> Comments {get; set; }

    public Video(string title, string author, int length){

        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComments(Comment comment){

        Comments.Add(comment);
    }

    public string ConvertTime(){
        int minutes = Length / 60;
        int seconds = Length % 60;
        string timeFormat = $"{minutes}:{seconds}";
        return timeFormat;
    }

    public void DisplayInfo(){

        Console.WriteLine($"\n{Title} - {Author} ({ConvertTime()})");
        Console.WriteLine($"\nNumber of comments: {Count = Comments.Count}");
        for (int i = 0; i < Comments.Count; i++)
        {   
            Comment comment = Comments[i];
            Console.WriteLine($"{i + 1}. {comment.GetName()} - {comment.GetText()}");
        }
    }
}