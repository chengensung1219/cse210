using System;

class Video{
    private string _title {get; set; }
    private string _author {get; set; }
    private int _length {get; set; }
    private int _count {get; set; }
    private List<Comment> _comments {get; set; }

    public Video(string title, string author, int length){

        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComments(Comment comment){

        _comments.Add(comment);
    }

    public string ConvertTime(){
        int minutes = _length / 60;
        int seconds = _length % 60;
        string timeFormat = $"{minutes}:{seconds}";
        return timeFormat;
    }

    public void DisplayInfo(){

        Console.WriteLine($"\n{_title} - {_author} ({ConvertTime()})");
        Console.WriteLine($"\nNumber of comments: {_count = _comments.Count}");
        for (int i = 0; i < _comments.Count; i++)
        {   
            Comment comment = _comments[i];
            Console.WriteLine($"{i + 1}. {comment.GetName()} - {comment.GetText()}");
        }
    }
}