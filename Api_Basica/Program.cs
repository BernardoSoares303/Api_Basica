var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Basica V1");
    c.RoutePrefix = string.Empty; // abre direto na raiz
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();