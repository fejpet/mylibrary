namespace Services.Book.Processor.Model;

public class Book
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
}