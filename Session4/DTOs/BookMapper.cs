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
        AuthorName = book.Author?.Name
    };

}