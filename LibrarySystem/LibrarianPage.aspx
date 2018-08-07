<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibrarianPage.aspx.cs" Inherits="LibrarianPage" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="btnRequests" runat="server" OnClick="btnRequests_Click" Text="View Book Requests" />
                <asp:Button ID="btnUsers" runat="server" Text="View Users" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Label ID="lblSearch" runat="server" Text="User Name: "/>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <br />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RequestId" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="RequestId" HeaderText="RequestId" InsertVisible="False" ReadOnly="True" SortExpression="RequestId" />
                        <asp:BoundField DataField="DateOfRequest" HeaderText="DateOfRequest" SortExpression="DateOfRequest" />
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                        <asp:BoundField DataField="BookLimit" HeaderText="BookLimit" SortExpression="BookLimit" />
                        <asp:BoundField DataField="ReIssueLimit" HeaderText="ReIssueLimit" SortExpression="ReIssueLimit" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="AmountOwing" HeaderText="AmountOwing" SortExpression="AmountOwing" />
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="CoverType" HeaderText="CoverType" SortExpression="CoverType" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT Request.RequestId, Request.DateOfRequest, [User].Username, [User].BookLimit, [User].ReIssueLimit, [User].FirstName, [User].LastName, [User].AmountOwing, Book.Title, Book.CoverType, Author.FirstName + Author.LastName AS Author FROM Request INNER JOIN [User] ON Request.UserId = [User].UserId INNER JOIN Issue ON Request.IssueId = Issue.IssueId INNER JOIN Book ON Issue.BookId = Book.BookId INNER JOIN Author ON Book.AuthorId = Author.AuthorId"></asp:SqlDataSource>
                <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" Text="Assign Selected Request" />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

