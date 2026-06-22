// Interfaces do not have async markers

using Session2.Models;

namespace Session2.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task CreateAsync(string title, int pageCount, int authorId);
    Task UpdateAsync(int id, string title, int year, int pageCount);
    Task DeleteAsync(int id);
}