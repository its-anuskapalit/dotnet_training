using Microsoft.EntityFrameworkCore;
using WebApiCRUD.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config=provider.GetRequiredService<IConfiguration>();
//or builder.Configuration
builder.Services.AddDbContext<StudentDBContext>(item=>item.UseSqlServer(config.GetConnectionString("DefaultConnection")));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();