using System;

namespace BookInventory.Data.Entities;

public class AuditableBaseEntity: BaseEntity
{
    public DateTime Created { get; } = DateTime.Now;
    
    public DateTime? Updated { get; set; }
    
    public DateTime? Deleted { get; set; }
}