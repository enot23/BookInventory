using System;

namespace BookInventory.Business.Models;

public class BaseAuditableDto : BaseDto
{
    public DateTime Created { get; } = DateTime.Now;
    
    public DateTime? Updated { get; set; }
    
    public DateTime? Deleted { get; set; }
}