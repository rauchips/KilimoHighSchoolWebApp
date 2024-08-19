using KilimoWebApp.Common;
using KilimoWebApp.Modules.Streams.Repository;
using KilimoWebApp.Modules.Streams.Service;
using KilimoWebApp.Modules.Students.Repository;
using KilimoWebApp.Modules.Students.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add Database Context
var connectionString = builder.Configuration.GetConnectionString("KilimoConnectionString");
builder.Services.AddDbContext<KilimoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IStreamRepository, StreamRepository>();
builder.Services.AddScoped<IStreamService, StreamService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();