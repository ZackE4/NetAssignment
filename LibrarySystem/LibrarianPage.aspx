<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LibrarianPage.aspx.cs" Inherits="LibrarianPage" Theme="MasterSkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            
            <asp:View ID="View1" runat="server">
                <asp:Button ID="btnRequests" runat="server" OnClick="btnRequests_Click" Text="View Book Requests" SkinID="btn" />
                <asp:Button ID="btnUsers" runat="server" Text="Extend Due Date" OnClick="btnUsers_Click" SkinID="btn" />
                <asp:Button ID="btnReturn" runat="server" Text="Return Book" OnClick="btnReturn_Click" SkinID="btn" />
                <asp:Button ID="btnFees" runat="server" Text="Pay Fees" OnClick="btnFees_Click" SkinID="btn" />
                <asp:Button ID="btnReport1" runat="server" SkinID="btn" Text="View Report Books" />
                <asp:Button ID="btnReport2" runat="server" SkinID="btn" Text="View Report OverDue" />
                <asp:Button ID="Button1" runat="server" SkinID="btn" Text="Button" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Label ID="lblSearch" runat="server" Text="User Name: " SkinID="lbl"/>
                <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" SkinID="btn" />
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
                <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" Text="Assign Selected Request" SkinID="btn" />
                <br />
            </asp:View>
              <asp:View ID="View3" runat="server">
                <asp:Label ID="lblSearchRentals" runat="server" Text="Search User ID:"></asp:Label>
                <asp:TextBox ID="txtRentalUserId" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearchUserId" runat="server" Height="23px" Text="Search" OnClick="btnSearchUserId_Click" />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RentalId" ForeColor="#333333" GridLines="None" style="margin-top: 0px" Width="454px" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="RentalId" HeaderText="RentalId" InsertVisible="False" ReadOnly="True" SortExpression="RentalId" />
                        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                        <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                        <asp:BoundField DataField="RentalDate" HeaderText="RentalDate" SortExpression="RentalDate" />
                        <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
                        <asp:BoundField DataField="ReturnDate" HeaderText="ReturnDate" SortExpression="ReturnDate" />
                        <asp:BoundField DataField="Fees" HeaderText="Fees" SortExpression="Fees" />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT Rental.RentalId, Rental.UserId, [User].Username, [User].FirstName, [User].LastName,  Rental.RentalDate, Rental.DueDate, Rental.ReturnDate, Rental.Fees, Rental.Comments FROM Rental INNER JOIN [User] ON Rental.UserId = [User].UserId"></asp:SqlDataSource>
                <asp:Button ID="btnDate" runat="server" Text="Change Selected Due Date" OnClick="btnDate_Click" SkinID="btn" />
                <br />
                <asp:Label ID="lblNewDate" runat="server" Text="New Due Date:" SkinID="lbl"></asp:Label>
                <asp:TextBox ID="txtNewDate" runat="server"></asp:TextBox>
                <asp:Button ID="btnDateChange" runat="server" Text="Change Date" OnClick="btnDateChange_Click" SkinID="btn" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Label ID="lblssueId" runat="server" Text="Issue ID" SkinID="lbl"></asp:Label>
                <asp:TextBox ID="txtIssueId" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearchIssue" runat="server" OnClick="btnSearchIssue_Click" Text="Search" SkinID="btn" />
                <br />
                <asp:Label ID="lblIssueInfo" runat="server" Text="No Issue Found" SkinID="lbl"></asp:Label>
                <br />
                <asp:Button ID="btnReturnBook" runat="server" Text="Return Book" OnClick="btnReturnBook_Click" SkinID="btn" />
            </asp:View>
            <asp:View ID="View5" runat="server">
                <asp:Label ID="lblUserPayment" runat="server" Text="Search UserId Fees:" SkinID="lbl"></asp:Label>
                <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox>
                <asp:Button ID="btnFeesFind" runat="server" Text="Search Fee" OnClick="btnFeesFind_Click" SkinID="btn" />
                <br />
                <asp:Label ID="lblFee" runat="server" Text="fee" SkinID="lbl"></asp:Label>
                <br />
                <asp:Button ID="btnPayFees" runat="server" OnClick="btnPayFees_Click" Text="Pay Fees" SkinID="btn" />
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>

