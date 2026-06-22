namespace Session2.Models;

public class BookTag
{
    public int BookId { get; }
    public int TagId { get; set; }
    public Book book { get; set; }
    public Tag tag { get; set; }

    public BookTag(Book book, Tag tag)
    {
        this.book = book;
        this.tag = tag;
    }
}
