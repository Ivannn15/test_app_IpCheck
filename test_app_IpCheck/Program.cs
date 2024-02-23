using Microsoft.OpenApi.Models;
using test_app_IpCheck.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ������� ��� ������ � �������������
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>();

// ��������� ������ RequestHistoryService � ��������� ��������� ������������
builder.Services.AddScoped<RequestHistoryService>();

// ��������� ������� ��� ������ � Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ��������� ���������� � Swagger ���������
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "IpInfo API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // ���������� Swagger �� ����� ����������
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