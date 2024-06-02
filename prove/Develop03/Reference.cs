using System;
class Reference
{
    private string Book;
    private int Chapter;
    private int StartVerse;
    private int EndVerse;
    private bool isSingleVerse;

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
        isSingleVerse = true;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
        isSingleVerse = false;
    }

    public override string ToString()
    {
        if (isSingleVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
