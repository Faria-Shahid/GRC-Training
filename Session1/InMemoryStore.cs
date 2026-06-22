public static class InMemoryStore
{
    public static List<Author> Authors { get; } = new List<Author>();
    public static List<Book> Books { get; } = new List<Book>();
    public static List<Tag> Tags { get; } = new List<Tag>();
    public static List<BookTag> BookTags { get; } = new List<BookTag>();

    public static Author? getAuthorById(int AuthorId)
    {
        for (int i = 0; i < Authors.Count; i++)
        {
            if (Authors[i].Id == AuthorId)
                return Authors[i];
        }
        return null;
    }

    public static void Seed()
    {
        string[] names = ["Jane Doe", "John Doe", "Andrew Lloyd"];

        for (int i = 0; i < names.Length; i++)
        {
            Authors.Add(new Author { Id = i + 1, Name = names[i] });
        }

        // Rather than finding book names, i just named the books as Book 1, Book 2 etc
        for (int i = 0 ; i < 8 ; i++)
        {
           Books.Add(new Book { Id = i + 1, Title = "Book " + i, Year = 2001 + i, PageCount = 433 + i, AuthorId = (i % 3) + 1 });
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
