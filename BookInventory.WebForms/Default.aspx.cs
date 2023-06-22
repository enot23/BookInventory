using System;
using System.Web.UI;

namespace BookInventory.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind the books data to the GridView
                GridViewBooks.DataSource = BooksSuperFancyDatabase.Books;
                GridViewBooks.DataBind();
            }
        }
    }
}