public class BookService : IBookService
{
    public IEnumerable<Book> GetAll()
    {
        return InMemoryStore.Books;
    }

    public Book? GetById(int id)
    {
        for (int i = 0; i < InMemoryStore.Books.Count; i++)
        {
            if (InMemoryStore.Books[i].Id == id)
                return InMemoryStore.Books[i];
        }
        return null;
    }

    public void Create(string title, int pageCount, int authorId)
    {
        int nextId = InMemoryStore.Books.Count + 1;

        Book newBook = new()
        {
            Id = nextId,
            Title = title,
            PageCount = pageCount,
            AuthorId = authorId
        };

        InMemoryStore.Books.Add(newBook);
    }

    public void Update(int id, string title, int year, int pageCount)
    {
        for (int i = 0; i < InMemoryStore.Books.Count; i++)
        {
            if (InMemoryStore.Books[i].Id == id)
            {
                InMemoryStore.Books[i].Title = title;
                InMemoryStore.Books[i].Year = year;
                InMemoryStore.Books[i].PageCount = pageCount;
                return;
            }
        }
    }

    public void Delete(int id)
    {
        for (int i = 0; i < InMemoryStore.Books.Count; i++)
        {
            if (InMemoryStore.Books[i].Id == id)
            {
                InMemoryStore.Books.RemoveAt(i);
                return;
            }
        }
    }
}
