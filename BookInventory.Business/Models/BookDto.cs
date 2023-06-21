using System.ComponentModel.DataAnnotations;

namespace BookInventory.Business.Models;

public class BookDto : BaseAuditableDto
{
    [Required]
    public string Title { get; set; }

    public string Author { get; set; } = "Unknown";
    
    [Required]
    public string ISBN { get; set; }
    
    public int? PublicationYear { get; set; }
    
    public int Quantity { get; set; }
    
    public int CategoryId { get; set; } = 1;
    
    public string CategoryName { get; set; }
}