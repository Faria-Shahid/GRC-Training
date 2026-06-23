// Notes to self
// A record is not a class but it kind of behaves like a class
// You cant do a == b with classes, because class compares with reference
// But record compares with values
// With init, you can only assign values to the attributes during object creation
// You can not assign values after the object has been created.

namespace WebApplication1.DTOs;

public record BookResponseDTO
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public int Year { get; init; }
    public int PageCount { get; init; }
    public int AuthorId { get; init; }
    public string? AuthorName { get; init; }
}
