using System.Text.Json.Serialization;
using AutoMapper;
using Library_Management.Api.Entities;
using Library_Management.Communication.Responses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure AutoMapper.
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure AutoMapper package.
//var config = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<Book, CreatedBookResponseJson>();
//});

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
