using FACL_Locker_Room_API.Core.DTOs;
using FACL_Locker_Room_API.Core.Helper;
using FACL_Locker_Room_API.Core.Interfaces;
using FACL_Locker_Room_API.Core.Services;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IReadWritetoJson, ReadWritetoJson>();

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
