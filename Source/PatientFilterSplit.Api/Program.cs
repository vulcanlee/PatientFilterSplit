using Microsoft.OpenApi.Models;
using PateintFilterSplit.Business.Repositorys;
using PatientFilterSplit.Infrastructure.Sample;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using PatientFilterSplit.Dto;
using System.IO;
using PatientFilterSplit.EntityModel;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sample API",
        Version = "v1",
        Description = "API to demonstrate Swagger integration."
    });
});
// Add AutoMapper
builder.Services.AddAutoMapper(c => c.AddProfile<OrganizationProfile>());
builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddDbContext<ElkDBContext>(ServiceLifetime.Transient);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 設定 DbContext
builder.Services.AddDbContext<ElkDBContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();

//does not work
app.Use(async (context, next) =>
{
    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

    if (exceptionHandlerPathFeature?.Error != null)
    {

        var exception = exceptionHandlerPathFeature?.Error;
        var apiresult = new APIResult();
        apiresult.Success = false;
        apiresult.Message = exception?.Message;
        apiresult.HTTPStatus = StatusCodes.Status500InternalServerError;

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;



        await context.Response.WriteAsJsonAsync(apiresult);

    }

    await next();

});
//app.Use(async (context, next) =>
//{
//    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
//    if (exceptionHandlerPathFeature?.Error != null)
//    {
//        var originalStream = context.Response.Body;
//        StreamWriter streamWriter = null;
//        using (var memoryStream = new MemoryStream())
//        {
//            // 替換原始 Response.Body 為 MemoryStream
//            context.Response.Body = memoryStream;

//            var exception = exceptionHandlerPathFeature?.Error;
//            var apiresult = new APIResult();
//            apiresult.Success = false;
//            apiresult.Message = exception?.Message;
//            apiresult.HTTPStatus = StatusCodes.Status500InternalServerError;

//            context.Response.StatusCode = StatusCodes.Status500InternalServerError;


//            memoryStream.Seek(0, SeekOrigin.Begin);
//            await memoryStream.CopyToAsync(originalStream);
//            streamWriter?.Dispose();
//            await context.Response.WriteAsJsonAsync(apiresult);
//        }


//    }
//    await next();
//});
//app.UseExceptionHandler(errorApp =>
//{
//    errorApp.Run(async context =>
//    {
//        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
//        context.Response.ContentType = "application/json";

//        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

//        if (exceptionHandlerPathFeature?.Error != null)
//        {
//            var exception = exceptionHandlerPathFeature.Error;
//            var path = exceptionHandlerPathFeature.Path;

//            var errorResponse = new
//            {
//                Success = false,
//                Status = StatusCodes.Status500InternalServerError,
//                Message = "An error occurred while processing your request.",
//                Detail = exception.Message,
//                Path = path
//            };

//            await context.Response.WriteAsJsonAsync(errorResponse);
//        }
//    });
//});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<ElkDBContext>();

    dbContext?.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
