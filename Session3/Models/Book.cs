namespace WebApplication1.Models;

//primary constructor — a shorter C# syntax where the
//constructor parameters are declared directly on the class line
public class Book(string title, int pageCount, int authorId, int year)
{
    public int Id { get; set; }
    public int Year { get; set; } = year;
    public string Title { get; set; } = title;
    public int PageCount { get; set; } = pageCount;
    public int AuthorId { get; set; } = authorId;
    public Author? nav { get; set; }
}
