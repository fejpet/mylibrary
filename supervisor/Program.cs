var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/version", () => """{"supervisor": "0.3"}""");

app.Run();
