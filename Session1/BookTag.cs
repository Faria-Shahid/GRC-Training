
// This class is basically a bridge or a join table between Book and Tag
// So we dont have to maintain duplicate data in books and tags nor do we have to do expensive lookups.

public class BookTag
{
    public int BookId {get;}
    public int TagId {set; get;}
    public Book book {set; get;}
    public Tag tag {set; get;}

    public BookTag(Book book, Tag tag)
    {
        this.book = book;
        this.tag = tag;
    }

}