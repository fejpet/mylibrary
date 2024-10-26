namespace Services.Book.API.Controllers;

using Services.Book.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[Route("api/v1/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{

    [Route("{bookNumber:int}")]
    [HttpGet]
    [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBookAsync(int bookNumber)
    {
        return Ok(new Book("123", "first book", new[] { "szerzo1" }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(Book[]), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBooksAsync(int bookNumber)
    {
        return Ok(new Book[] { });
    }
}