var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    //describe restful apis
    app.UseSwagger();
    app.UseSwaggerUI();
}

//middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();