namespace Services.Book.Processor.Controllers;
using Services.Book.Processor.Model;
using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using Dapr;

[Route("api/v1/[controller]")]
[ApiController]
public class BookProcessorController : ControllerBase
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<BookProcessorController> _logger;

    public BookProcessorController(DaprClient daprClient, ILogger<BookProcessorController> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    [Topic("bookpubsub", "books")]
    [HttpPost("bookreceived")]
    public async Task<IActionResult> BookReceived([FromBody] CloudEvent<Book> cloudEvent)
    {
        Book book = cloudEvent.Data;
        if (book is not null)
        {
            _logger.LogInformation($"Received Book: {book.Isbn}: {book.Title} ");
            return Ok();
        }

        return BadRequest();
    }
}