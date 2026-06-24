using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public class BookService : IBookService
{

    private readonly AppDbContext _db;


    public BookService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<BookResponseDTO>> GetAllAsync(string? author, int page, int pageSize)
    {
        var books = await _db.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .Where(b => string.IsNullOrWhiteSpace(author) || b.Author!.Name.Contains(author))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return books.Select(BookMapper.ToResponse);
    }

    public async Task<BookResponseDTO> GetByIdAsync(int id)
    {
        var book = await _db.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) throw new BookNotFoundException(id);

        return BookMapper.ToResponse(book);
    }

    public async Task CreateAsync(BookCreateDTO dto)
    {
        var book = BookMapper.ToEntity(dto);
        await _db.Books.AddAsync(book);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, BookUpdateDTO dto)
    {
        var book = await _db.Books.FindAsync(id);

        if (book == null) throw new BookNotFoundException(id);

        book.Title = dto.Title;
        book.Year = dto.Year;
        book.PageCount = dto.PageCount;
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _db.Books.FindAsync(id);

        if (book == null) throw new BookNotFoundException(id);

        _db.Books.Remove(book);
        await _db.SaveChangesAsync();
    }
    
}
