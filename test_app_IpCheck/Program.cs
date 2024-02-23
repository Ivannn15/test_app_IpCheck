using Microsoft.OpenApi.Models;
using test_app_IpCheck.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для работы с контроллерами
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>();

// Добавляем сервис RequestHistoryService в контейнер внедрения зависимостей
builder.Services.AddScoped<RequestHistoryService>();

// Добавляем сервисы для работы с Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Добавляем информацию о Swagger документе
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IpInfo API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Используем Swagger во время разработки
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IpInfo API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();