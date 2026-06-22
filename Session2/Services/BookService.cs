// Notes to self
// Task.CompletedTask        // = Task       — no value, just "done"
// Task.FromResult(someValue) // = Task<T>   — "done, and here's the value"

using Session2.Models;

namespace Session2.Services;

public class BookService : IBookService
{
    public Task<IEnumerable<Book>> GetAllAsync()
    {
    return Task.FromResult(InMemoryStore.Books.AsEnumerable());
    }

    public Task<Book> GetByIdAsync(int id)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        
        if (book is null)
            throw new BookNotFoundException(id);

        return Task.FromResult(book);
    }


    public Task CreateAsync(string title, int pageCount, int authorId)
    {
        var book = new Book { Title = title, PageCount = pageCount, AuthorId = authorId };
        InMemoryStore.Books.Add(book);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(int id, string title, int year, int pageCount)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        if (book is null) throw new BookNotFoundException(id);

        book.Title = title;
        book.PageCount = pageCount;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var book = InMemoryStore.Books.FirstOrDefault(b => b.Id == id);
        if (book is null) throw new BookNotFoundException(id);
        InMemoryStore.Books.Remove(book);
        return Task.CompletedTask;
    }

}
