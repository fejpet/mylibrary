namespace Services.Book.API.Controllers;

using Services.Book.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;

[Route("api/v1/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{

    [Route("{bookNumber}")]
    [HttpGet]
    [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBookAsync(string bookNumber)
    {
        return Ok(new Book(bookNumber, "first book", new[] { "szerzo1" }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(Book[]), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBooksAsync(int bookNumber)
    {
        return Ok(new Book[] { });
    }

    [HttpPost]
    public async Task<ActionResult<Book>> StoreBookAsync()
    {
        //read bytes
        //call binding
        return Ok(new Book(Guid.NewGuid().ToString(), "Title", new[] { "szerzo" }));
    }

}