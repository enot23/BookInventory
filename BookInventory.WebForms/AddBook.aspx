<%@ Page Title="Add Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookInventory.WebForms.AddBook" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add Book</h1>

    <form >
        <div class="form-group">
            <label for="txtTitle">Title:</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtAuthor">Author:</label>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtISBN">ISBN:</label>
            <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPublicationYear">Publication Year:</label>
            <asp:TextBox ID="txtPublicationYear" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtQuantity">Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlCategory">Category:</label>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                <asp:ListItem Text="Category 1" Value="1"></asp:ListItem>
                <asp:ListItem Text="Category 2" Value="2"></asp:ListItem>
                <asp:ListItem Text="Category 3" Value="3"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnAddBook" runat="server" Text="Add Book" CssClass="btn btn-primary" OnClick="btnAddBook_Click" />
    </form>

</asp:Content>