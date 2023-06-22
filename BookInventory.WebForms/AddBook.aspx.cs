using System;
using BookInventory.WebForms.Models;

namespace BookInventory.WebForms
{
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            int publicationYear = int.Parse(txtPublicationYear.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int categoryId = int.Parse(ddlCategory.SelectedValue);

            Book newBook = new Book()
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                PublicationYear = publicationYear,
                Quantity = quantity,
                CategoryId = categoryId
            };

            BooksSuperFancyDatabase.Books.Add(newBook);

            Response.Redirect("Default.aspx");
        }
    }
}