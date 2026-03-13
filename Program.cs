using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();

// Serve `/docs` folder
var docsPath = Path.Combine(Directory.GetCurrentDirectory(), "docs");
if (Directory.Exists(docsPath))
{
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(docsPath),
        RequestPath = "/docs"
    });
}

// Enable CORS
app.UseCors("AllowAll");

// Swagger
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1");
    options.RoutePrefix = "api-docs";
});

// Authorization
app.UseAuthorization();

app.MapControllers();

// Custom landing page at "/"
app.MapGet("/", (HttpContext context) =>
{
    var swaggerUrl = $"{context.Request.Scheme}://{context.Request.Host}/api-docs";
    var docsUrl = $"{context.Request.Scheme}://{context.Request.Host}/docs/index.html";

    return Results.Text(
        $"""
        <h1>TodoAPI</h1>
        <p>See the <a href='{swaggerUrl}'>Swagger UI</a>.</p>
        <p>Test the <a href='{docsUrl}'>Frontend</a>.</p>
    
        """,
        "text/html"
    );
});

app.Run("http://0.0.0.0:" + (Environment.GetEnvironmentVariable("PORT") ?? "5065"));
