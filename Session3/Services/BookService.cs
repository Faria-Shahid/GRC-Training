using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class BookService : IBookService
{
    public Task<IEnumerable<BookResponseDTO>> GetAllAsync(string? author, int page, int pageSize)
    {
        var query = InMemoryStore.Books.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(author))
            query = query.Where(b => b.nav?.Name.Contains(author, StringComparison.OrdinalIgnoreCase) == true);

        var result = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(BookMapper.ToResponse);

        return Task.FromResult(result);
    }

    public Task<BookResponseDTO> GetByIdAsync(int id)
    {
        var book = InMemoryStore.GetBookById(id)
            ?? throw new BookNotFoundException(id);

        return Task.FromResult(BookMapper.ToResponse(book));
    }

    public Task CreateAsync(BookCreateDTO dto)
    {
        var book = BookMapper.ToEntity(dto);
        book.Id = InMemoryStore.Books.Count + 1;
        book.nav = InMemoryStore.GetAuthorById(dto.AuthorId);
        InMemoryStore.Books.Add(book);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(int id, BookUpdateDTO dto)
    {
        BookMapper.ApplyUpdate(dto, id);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var book = InMemoryStore.GetBookById(id)
            ?? throw new BookNotFoundException(id);

        InMemoryStore.Books.Remove(book);
        return Task.CompletedTask;
    }
}
