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
    }
}