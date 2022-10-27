using LRP.webapi.Domain.Entities;
using LRP.webapi.Domain.Interfaces;
using LRP.webapi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//New Services
builder.Services.AddTransient<IRepository<User>, UserRepository>();
builder.Services.AddDbContext<LeafContext>(options => options.UseInMemoryDatabase(databaseName: "LeafDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
