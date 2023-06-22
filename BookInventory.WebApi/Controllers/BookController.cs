using System.Collections.Generic;
using System.Threading.Tasks;
using BookInventory.Business.Interfaces;
using BookInventory.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookInventory.WebApi.Controllers;

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
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBook(BookCreateUpdateModel bookDto)
    {
        if (bookDto == null)
        {
            return BadRequest();
        }
        var createdBook = await _bookService.AddAsync(bookDto);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, BookCreateUpdateModel bookDto)
    {
        if (bookDto == null)
        {
            return BadRequest();
        }
        await _bookService.UpdateAsync(bookDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _bookService.DeleteAsync(id);
        return NoContent();
    }
}