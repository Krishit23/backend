using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using SavorySeasons.Backend;
using SavorySeasons.Backend.Models;
using SavorySeasons.Backend.Validation.ModelValidation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEmailServices(builder.Configuration);
var contactUsConfiguration = configuration.GetSection("ContactUs").Get<ContactUsConfiguration>();
builder.Services.AddSingleton(contactUsConfiguration);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(ContactValidator));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                          policy =>
                          {
                              policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
