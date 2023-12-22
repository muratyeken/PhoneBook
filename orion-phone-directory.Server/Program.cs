using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OrionPhoneDirectory.Repository.Abstract;
using OrionPhoneDirectory.Repository.Concrete;
using OrionPhoneDirectory.Repository.Context;
using OrionPhoneDirectory.Service.Abstract;
using OrionPhoneDirectory.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<OrionPhoneDirectoryContext>(option =>
{
    option.UseSqlServer("Server=BALIM\\MSSQLSERVER2019;Database=PhoneDirectoryDB;Trusted_Connection=True;TrustServerCertificate=True;",b => b.MigrationsAssembly("OrionPhoneDirectory.Server"));
});
builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
AppContext.SetSwitch("System.Globalization.Invariant", false);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();