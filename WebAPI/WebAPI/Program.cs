using BsLayer.maaper;
using BsLayer.Services;
using DTLayer.Services;
using FluentValidation;
using FluentValidation.AspNetCore;


//using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using RepLayer.Services;
using VaildationLayer.ItemsValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddUpdateFindSpecilizesDtoValidator>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile).Assembly);
builder.Services.addBussinesServices();
builder.Services.AddRepoServices();

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
