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

        context.Database.ExecuteSqlRaw(
            @"CREATE PROCEDURE GetBooks
              @PageNumber INT,
              @PageSize INT,
              @SearchQuery NVARCHAR(100),
              @SortColumn NVARCHAR(50),
              @SortDirection NVARCHAR(4)
            AS
            BEGIN
              SET NOCOUNT ON;

              DECLARE @Offset INT = (@PageNumber - 1) * @PageSize;
              DECLARE @Limit INT = @PageSize;

              DECLARE @SortDirectionSQL NVARCHAR(10) = CASE WHEN @SortDirection = 'desc' THEN 'DESC' ELSE 'ASC' END;

              DECLARE @SortColumnSQL NVARCHAR(100) = 
                CASE 
                  WHEN @SortColumn = 'Title' THEN 'Title'
                  WHEN @SortColumn = 'Author' THEN 'Author'
                END;

              DECLARE @SearchQuerySQL NVARCHAR(100) = '%' + @SearchQuery + '%';

              SELECT *
              FROM Books
              WHERE (@SearchQuery IS NULL OR Title LIKE @SearchQuerySQL OR Author LIKE @SearchQuerySQL)
              ORDER BY CASE WHEN @SortColumnSQL IS NULL THEN NULL ELSE
                CASE WHEN @SortDirectionSQL = 'DESC' THEN 
                  CASE WHEN @SortColumnSQL = 'Title' THEN Title END
                END
              END DESC,
              CASE WHEN @SortColumnSQL IS NULL THEN NULL ELSE
                CASE WHEN @SortDirectionSQL = 'ASC' THEN 
                  CASE WHEN @SortColumnSQL = 'Title' THEN Title END
                END
              END ASC,
              CASE WHEN @SortColumnSQL IS NULL THEN NULL ELSE
                CASE WHEN @SortDirectionSQL = 'DESC' THEN 
                  CASE WHEN @SortColumnSQL = 'Author' THEN Author END
                END
              END DESC,
              CASE WHEN @SortColumnSQL IS NULL THEN NULL ELSE
                CASE WHEN @SortDirectionSQL = 'ASC' THEN 
                  CASE WHEN @SortColumnSQL = 'Author' THEN Author END
                END
              END ASC
              OFFSET @Offset ROWS
              FETCH NEXT @Limit ROWS ONLY;
            END");

        context.SaveChanges();
    }
}