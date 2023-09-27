using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniCrud.Products.Application.Queries;
using MiniCrud.Products.Infrastructure.Data;
using MiniCrud.Products.Presentation.Config;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
ConfigServices.Config(builder.Services, builder.Configuration);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<MiniCrudDbContext>();

    await dbContext.Database.MigrateAsync();
}

app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json";
    await next();
});

app.MapGet("/products/get/all", async (IMediator _mediator) => {
    return JsonConvert.SerializeObject(await _mediator.Send(new GetProductsQuery()));
});


app.MapGet("/", () => {
    return "Hello, World!";
});

app.Run();
