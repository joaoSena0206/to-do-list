
using Microsoft.IdentityModel.Tokens;
using System.Text;
using To_do_List.DataAccess;
using To_do_List.Services;
using Scalar.AspNetCore;
using To_do_List.Configurations;

var builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<UserDAL>(provider => new UserDAL(connectionString));
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<AuthService>();

builder.Services.AddOpenApi();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
