using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Register our JwtService
builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---- JWT Authentication Setup ----
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,          // checks expiry
            ValidateIssuerSigningKey = true,  // verifies signature
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

builder.Services.AddAuthorization();
// ----------------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ORDER MATTERS: Authentication before Authorization!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();




//POST / api / auth / register
//{ "username": "Asad", "password": "pass123", "role": "User" }

//POST / api / auth / register
//{ "username": "superadmin", "password": "admin123", "role": "Admin" }


//POST / api / auth / login
//{ "username": "Asad", "password": "pass123" }
//{ "username": "superadmin", "password": "admin123" }


