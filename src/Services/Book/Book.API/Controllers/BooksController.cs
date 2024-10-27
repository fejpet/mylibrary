namespace Services.Book.API.Controllers;

using Services.Book.API.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Dapr.Client;

[Route("api/v1/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<BooksController> _logger;

    public BooksController(DaprClient daprClient, ILogger<BooksController> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    [Route("{bookNumber}")]
    [HttpGet]
    [ProducesResponseType(typeof(Book), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBookAsync(string bookNumber)
    {
        _logger.LogInformation($"Request book '{bookNumber}'");
        return Ok(new Book(bookNumber, "first book", new[] { "szerzo1" }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(Book[]), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Book>> GetBooksAsync()
    {
        _logger.LogInformation("Request books");
        return Ok(new Book[] { });
    }

    [HttpPost]
    public async Task<ActionResult<Book>> StoreBookAsync()
    {
        var book = new Book(Guid.NewGuid().ToString(), "Title", new[] { "szerzo" });
        _logger.LogInformation("Book stored, notify others");

        var metadata = new Dictionary<string, string>() {
            { "cloudevent.source", "book.api" },
            { "cloudevent.id", Guid.NewGuid().ToString() }
        };


        await _daprClient.PublishEventAsync<Book>("bookpubsub", "books", book, metadata);

        return Ok(book);
    }

}