<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookInventory.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <form id="form1">
            <div class="container">
            <h1>Books</h1>
                 <asp:HyperLink ID="lnkAddBook" runat="server" CssClass="btn btn-primary" NavigateUrl="~/AddBook.aspx">Add Book</asp:HyperLink>
                <asp:GridView ID="GridViewBooks" runat="server" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Author" HeaderText="Author" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="PublicationYear" HeaderText="Publication Year" ItemStyle-CssClass="col-md-2" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-CssClass="col-md-2" />
                    </Columns>
            </asp:GridView>
        </div>
        </form>
    </main>

</asp:Content>
