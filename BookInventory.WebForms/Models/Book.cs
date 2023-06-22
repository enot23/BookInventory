using System.ComponentModel.DataAnnotations;

namespace BookInventory.WebForms.Models
{
    public class Book
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
}