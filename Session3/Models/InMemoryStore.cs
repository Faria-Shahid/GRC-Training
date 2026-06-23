namespace WebApplication1.Models;

public static class InMemoryStore
{
    public static List<Author> Authors { get; } = new List<Author>();
    public static List<Book> Books { get; } = new List<Book>();
    public static List<Tag> Tags { get; } = new List<Tag>();
    public static List<BookTag> BookTags { get; } = new List<BookTag>();

    public static Author? GetAuthorById(int authorId)
    {
        for (int i = 0; i < Authors.Count; i++)
        {
            if (Authors[i].Id == authorId)
                return Authors[i];
        }
        return null;
    }

    public static Book? GetBookById(int id) =>
        Books.FirstOrDefault(b => b.Id == id);

    public static void Seed()
    {
        string[] names = ["Jane Doe", "John Doe", "Andrew Lloyd"];

        for (int i = 0; i < names.Length; i++)
        {
            Authors.Add(new Author { Id = i + 1, Name = names[i] });
        }

        for (int i = 0; i < 8; i++)
        {
            Books.Add(new Book("Book " + i, 433 + i, (i % 3) + 1, 2001 + i) { Id = i + 1 });
        }

        for (int i = 0; i < Books.Count; i++)
        {
            for (int j = 0; j < Authors.Count; j++)
            {
                if (Authors[j].Id == Books[i].AuthorId)
                {
                    Books[i].nav = Authors[j];
                    break;
                }
            }
        }

        string[] tagNames = ["Fiction", "Science", "History", "Fantasy"];

        for (int i = 0; i < tagNames.Length; i++)
        {
            Tags.Add(new Tag { TagId = i + 1, Name = tagNames[i] });
        }

        for (int i = 0; i < Books.Count; i++)
        {
            Tag tag = Tags[i % Tags.Count];
            BookTags.Add(new BookTag(Books[i], tag));
        }
    }
}
