var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => {
    return "Hello, World!";
});

app.MapGet("/product/get", async (int productId) => {
    
});

app.Run();
