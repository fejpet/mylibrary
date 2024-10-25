var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/version", () => """{"supervisor": "0.1"}""");

app.Run();
