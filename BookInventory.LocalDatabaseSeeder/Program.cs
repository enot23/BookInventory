using BookInventory.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookInventory.LocalDatabaseSeeder;

public static class Program
{
    public static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("AppConnectionString");
            
        var dbContextOptions = new DbContextOptionsBuilder<Data.AppContext>()
            .UseSqlServer(connectionString)
            .Options;
			
        var context = new Data.AppContext(dbContextOptions);

        Console.WriteLine(@"Dropping Database...");
        context.Database.EnsureDeleted(); // Deletes database if exists  
			
        Console.WriteLine(@"Creating Database structure...");
        context.Database.Migrate(); // Creates database and structure
        
        Console.WriteLine(@"Seeding Database...");
        context.AddRange(new List<Category>
        {
            new Category
            {
                Name = "Other",
                Description = "Other"
            },
            new Category
            {
                Name = "Databases",
                Description = "Databases"
            },
            new Category
            {
                Name = "Web Development",
                Description = "Web Development"
            },
            new Category
            {
                Name = "Mobile Development",
                Description = "Mobile Development"
            },
        });
        context.SaveChanges();
        
        context.AddRange(new List<Book>()
        {
            new Book()
            {
                Title = "Pro ASP.NET Core MVC 2", 
                Author = "Adam Freeman",
                ISBN = "978-1-4842-3197-3",
                PublicationYear = 2017, 
                Quantity = 1,
                CategoryId = 3
            },
        });

        context.SaveChanges();
    }
}