using BookInventory.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookInventory.Data;

public class AppContext : DbContext
{
    public virtual DbSet<Book> Books { get; set; }
    
    public virtual DbSet<Category> Categories { get; set; }

    public AppContext()
    {
    }
    
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookInventory;Integrated Security=True;");
        }
    }
}