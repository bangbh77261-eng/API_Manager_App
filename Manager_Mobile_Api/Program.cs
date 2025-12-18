using Microsoft.EntityFrameworkCore;
using Manager_mobile_Api.Data;

var builder = WebApplication.CreateBuilder(args);

// -------------------------
// ADD CORS
// -------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            .AllowAnyOrigin()      // Cho mọi domain (localhost:3000)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// -------------------------
// USE CORS (phải đặt trước UseAuthorization)
// -------------------------
app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
