using System.Collections.Generic;
using BookInventory.WebForms.Models;

namespace BookInventory.WebForms
{
    public static class BooksSuperFancyDatabase
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                ISBN = "9780743273565",
                PublicationYear = 1925,
                Quantity = 5
            },
            new Book
            {
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                ISBN = "9780061120084",
                PublicationYear = 1960,
                Quantity = 3
            },
            new Book
            {
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                ISBN = "9780141439518",
                PublicationYear = 1813,
                Quantity = 7
            }
        };
    }
}