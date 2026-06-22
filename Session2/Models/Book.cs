namespace Session2.Models;

public class Book
{
    public int Id { get; set; }
    public int Year { get; set; }
    public required string Title { get; set; }
    public int PageCount { get; set; }
    public int AuthorId { get; set; }
    public Author? nav { get; set; }
}
