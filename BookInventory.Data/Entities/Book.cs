using System.ComponentModel.DataAnnotations;

namespace BookInventory.Data.Entities;

public class Book : AuditableBaseEntity
{
    [Required]
    public string Title { get; set; }

    public string Author { get; set; } = "Unknown";
    
    [Required]
    public string ISBN { get; set; }
    
    public int? PublicationYear { get; set; }
    
    public int Quantity { get; set; }
    
    public int? CategoryId { get; set; }
    
    public virtual Category Category { get; set; }
}