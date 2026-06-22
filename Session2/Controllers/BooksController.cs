using Microsoft.AspNetCore.Mvc;
using Session2.Services;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    // Constructor for Dependency Injection
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]

    // Ok() wraps the response in Http 200
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }


}