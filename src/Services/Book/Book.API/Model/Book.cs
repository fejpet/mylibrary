namespace Services.Book.API.Model;

public class Book
{
    public Book(string isbn, string title, string[] authors)
    {
        Isbn = isbn;
        Title = title;
        Authors = authors;
    }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
}