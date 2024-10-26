namespace Services.Book.API.Model;

public record Book(string isbn, string title, string[] authors);