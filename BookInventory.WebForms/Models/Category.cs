using System.Collections.Generic;

namespace BookInventory.WebForms.Models
{
    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }
    }
}