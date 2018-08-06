<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchBook.aspx.cs" Inherits="SearchBook" Theme="SkinFile" %>

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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT [Title], [GenreId] FROM [Genre]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT Book.BookID, Book.Title, Author.LastName + ', ' + Author.FirstName AS Author, Genre.Title AS Genre FROM Book INNER JOIN Genre ON Book.GenreId = Genre.GenreId INNER JOIN Author ON Book.AuthorId = Author.AuthorId"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BookID" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="BookID" HeaderText="BookID" InsertVisible="False" ReadOnly="True" SortExpression="BookID" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" ReadOnly="True" SortExpression="Author" />
                <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    <div>

        <asp:Label ID="lblBookInfo" runat="server" Text="filler"></asp:Label>
        <br />
        <asp:Label ID="lblBookSyn" runat="server" Text="filler "></asp:Label>

        <br />
        <asp:Button ID="btnRequest" runat="server" Text="Request This Book" OnClick="btnRequest_Click" />

    </div>
</asp:Content>

