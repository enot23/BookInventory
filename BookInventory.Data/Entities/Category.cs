namespace BookInventory.Data.Entities;

public class Category : AuditableBaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public virtual ICollection<Book> Books { get; set; }
}