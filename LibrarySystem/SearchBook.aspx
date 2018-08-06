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
        <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
            <AlternatingItemTemplate>
                <li style="background-color: #FFFFFF;color: #284775;">Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <br />
                    SecondName:
                    <asp:Label ID="SecondNameLabel" runat="server" Text='<%# Eval("SecondName") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                    PublishedDate:
                    <asp:Label ID="PublishedDateLabel" runat="server" Text='<%# Eval("PublishedDate") %>' />
                    <br />
                    CoverType:
                    <asp:Label ID="CoverTypeLabel" runat="server" Text='<%# Eval("CoverType") %>' />
                    <br />
                    Genre:
                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                    <br />
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #999999;">Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />
                    FirstName:
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    <br />
                    SecondName:
                    <asp:TextBox ID="SecondNameTextBox" runat="server" Text='<%# Bind("SecondName") %>' />
                    <br />
                    LastName:
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    <br />
                    PublishedDate:
                    <asp:TextBox ID="PublishedDateTextBox" runat="server" Text='<%# Bind("PublishedDate") %>' />
                    <br />
                    CoverType:
                    <asp:TextBox ID="CoverTypeTextBox" runat="server" Text='<%# Bind("CoverType") %>' />
                    <br />
                    Genre:
                    <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# Bind("Genre") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">Title:
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                    <br />FirstName:
                    <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    <br />SecondName:
                    <asp:TextBox ID="SecondNameTextBox" runat="server" Text='<%# Bind("SecondName") %>' />
                    <br />LastName:
                    <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    <br />PublishedDate:
                    <asp:TextBox ID="PublishedDateTextBox" runat="server" Text='<%# Bind("PublishedDate") %>' />
                    <br />CoverType:
                    <asp:TextBox ID="CoverTypeTextBox" runat="server" Text='<%# Bind("CoverType") %>' />
                    <br />Genre:
                    <asp:TextBox ID="GenreTextBox" runat="server" Text='<%# Bind("Genre") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #E0FFFF;color: #333333;">Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <br />
                    SecondName:
                    <asp:Label ID="SecondNameLabel" runat="server" Text='<%# Eval("SecondName") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                    PublishedDate:
                    <asp:Label ID="PublishedDateLabel" runat="server" Text='<%# Eval("PublishedDate") %>' />
                    <br />
                    CoverType:
                    <asp:Label ID="CoverTypeLabel" runat="server" Text='<%# Eval("CoverType") %>' />
                    <br />
                    Genre:
                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                    <br />
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #E2DED6;font-weight: bold;color: #333333;">Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    FirstName:
                    <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    <br />
                    SecondName:
                    <asp:Label ID="SecondNameLabel" runat="server" Text='<%# Eval("SecondName") %>' />
                    <br />
                    LastName:
                    <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    <br />
                    PublishedDate:
                    <asp:Label ID="PublishedDateLabel" runat="server" Text='<%# Eval("PublishedDate") %>' />
                    <br />
                    CoverType:
                    <asp:Label ID="CoverTypeLabel" runat="server" Text='<%# Eval("CoverType") %>' />
                    <br />
                    Genre:
                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                    <br />
                </li>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT Book.Title, Author.FirstName, Author.SecondName, Author.LastName, Book.PublishedDate, Book.CoverType, Genre.Title AS Genre FROM Book INNER JOIN Genre ON Book.GenreId = Genre.GenreId INNER JOIN Author ON Book.AuthorId = Author.AuthorId"></asp:SqlDataSource>
    </div>
    <div>

        <asp:Label ID="lblBookInfo" runat="server" Text="filler"></asp:Label>
        <br />
        <asp:Label ID="lblBookSyn" runat="server" Text="filler "></asp:Label>

    </div>
</asp:Content>

