/*
 Task for practice.
Create a new WebAPI project Bookstore. 
Create DTO Book (has Id, Title, Author)
Create DTO Author (has Id, First Name, Last Name)
Create endpoinds:
1) Get all books (with author).
2) Get book by Id (with Author).
3) Get authors
4) Get author by Id.
5) Get books by author Id.
6) Implement REST functionality for books and authors.
7) Create a simple FrontEnd as separate service (use your preffered framework)
Use DB in memory, or external SQL server or a singleton service for storing DBSets. Feed with dummy data on start.

 

Send to General chat the link to the git after completion

 */

using BooksApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace BooksApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LibDBContext>(opt => opt.UseInMemoryDatabase("library-db"));
            var app = builder.Build();


            var scope = app.Services.CreateScope();
            LibDBContext DBcontext = (LibDBContext)scope.ServiceProvider.GetService<LibDBContext>();
            DBSeeder.Seed(DBcontext);


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
        }
    }

}