<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IssuedBooksReport.aspx.cs" Inherits="IssuedBooksReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IssueId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="IssueId" HeaderText="IssueId" InsertVisible="False" ReadOnly="True" SortExpression="IssueId" />
            <asp:BoundField DataField="BookId" HeaderText="BookId" SortExpression="BookId" />
            <asp:BoundField DataField="PrintDate" HeaderText="PrintDate" SortExpression="PrintDate" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="CoverType" HeaderText="CoverType" SortExpression="CoverType" />
            <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
            <asp:BoundField DataField="Author" HeaderText="Author" ReadOnly="True" SortExpression="Author" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT Issue.IssueId, Issue.BookId, Issue.PrintDate, Issue.Status, Issue.Comments, Book.Title, Book.CoverType, Genre.Title AS Genre, Author.FirstName + ', ' + Author.LastName AS Author FROM Issue INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Genre ON Book.GenreId = Genre.GenreId INNER JOIN Author ON Book.AuthorId = Author.AuthorId"></asp:SqlDataSource>
</asp:Content>

