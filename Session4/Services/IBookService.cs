using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IBookService
{
    Task<IEnumerable<BookResponseDTO>> GetAllAsync(string? author, int page, int pageSize);
    Task<BookResponseDTO> GetByIdAsync(int id);
    Task CreateAsync(BookCreateDTO dto);
    Task UpdateAsync(int id, BookUpdateDTO dto);
    Task DeleteAsync(int id);
}
