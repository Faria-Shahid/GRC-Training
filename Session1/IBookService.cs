public interface IBookService
{
    IEnumerable<Book> GetAll();
    // using nullable type because the book might not exist
    Book? GetById(int id);
    void Create(string title, int pageCount, int authorId);
    void Update(int id, string title, int year, int pageCount);
    void Delete(int id);
}
