// Note to self
// [FromBody] — means "get this value from the request body"
// [FromQuery] — means "get this value from the URL"
// Rule of thumb: always be explicit.
// It makes the code clearer and avoids surprises.
// IActionResult is an interface that represents any HTTP response
// our controller can return. Instead of returning a raw value, 
// we return an HTTP response with a status code + optional body.


using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? author, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var books = await _bookService.GetAllAsync(author, page, pageSize);
        return Ok(books);
    }

   [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
        catch (BookNotFoundException ex)
        {
            return Problem(ex.Message, statusCode: 404);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookCreateDTO dto)
    {
        await _bookService.CreateAsync(dto);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BookUpdateDTO dto)
    {
        await _bookService.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}
