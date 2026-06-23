using WebApplication1.DTOs;
using WebApplication1.Models;

public static class BookMapper
{
    public static Book ToEntity(BookCreateDTO dto) =>
    new Book(dto.Title, dto.PageCount, dto.AuthorId, dto.Year);

    public static BookResponseDTO ToResponse(Book book) =>
    new BookResponseDTO
    {
        Id = book.Id,
        Title = book.Title,
        Year = book.Year,
        PageCount = book.PageCount,
        AuthorId = book.AuthorId,
        AuthorName = book.nav?.Name
    };

    public static void ApplyUpdate(BookUpdateDTO dto, int id)
    {
        Book? book = InMemoryStore.GetBookById(id);

        if (book == null) throw new BookNotFoundException(id);

        book.Title = dto.Title;
        book.Year = dto.Year;
        book.PageCount = dto.PageCount;
    }
       
}