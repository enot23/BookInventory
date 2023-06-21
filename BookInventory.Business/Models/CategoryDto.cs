namespace BookInventory.Business.Models;

public class CategoryDto : BaseAuditableDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}