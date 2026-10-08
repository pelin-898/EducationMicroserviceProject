using EducationMicroserviceProject.Catalog.API;
using EducationMicroserviceProject.Catalog.API.Features.Categories;
using EducationMicroserviceProject.Catalog.API.Features.Categories.Create;
using EducationMicroserviceProject.Catalog.API.Features.Courses;
using EducationMicroserviceProject.Catalog.API.Options;
using EducationMicroserviceProject.Catalog.API.Repositories;
using EducationMicroserviceProject.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));
builder.Services.AddVersioningExt();


var app = builder.Build();

app.AddSeedDataExt().ContinueWith(x =>
{
   Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully");

});

app.AddCategoryGroupEndpointExt(app.AddVersionSetExt());
app.AddCourseGroupEndpointExt(app.AddVersionSetExt());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.Run();

