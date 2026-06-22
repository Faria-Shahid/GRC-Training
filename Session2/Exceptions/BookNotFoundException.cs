// Notes to self
// : base(...) — passes the message up to the parent Exception class

public class BookNotFoundException : Exception
{
    public BookNotFoundException(int id) 
        : base($"Book with id {id} was not found.")
    {
    }
}
