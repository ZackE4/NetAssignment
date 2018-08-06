<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchBook.aspx.cs" Inherits="SearchBook" Theme="SkinFile.skin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAuthor" runat="server" Text="Author Last Name:"></asp:Label>
        <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblGenre" runat="server" Text="Genre:"></asp:Label>
        <asp:DropDownList ID="ddlGenre" runat="server" DataSourceID="SqlDataSource2" DataTextField="Title" DataValueField="GenreId">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NetAssignConnectionString %>" SelectCommand="SELECT [Title], [GenreId] FROM [Genre]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <div>
        <asp:ListView ID="ListView1" runat="server">
        </asp:ListView>
    </div>
    <div>

        <asp:Label ID="lblBookInfo" runat="server" Text="filler"></asp:Label>
        <br />
        <asp:Label ID="lblBookSyn" runat="server" Text="filler "></asp:Label>

    </div>
</asp:Content>

