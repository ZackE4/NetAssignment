<%@ Page Theme="SkinFile" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OverdueReport.aspx.cs" Inherits="OverdueReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Overdue Report"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Issue Number" DataSourceID="SqlDataSource1" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:BoundField DataField="Book" HeaderText="Book" SortExpression="Book" />
            <asp:BoundField DataField="Issue Number" HeaderText="Issue Number" InsertVisible="False" ReadOnly="True" SortExpression="Issue Number" />
            <asp:BoundField DataField="Due On" HeaderText="Due On" SortExpression="Due On" />
            <asp:BoundField DataField="Loaned to" HeaderText="Loaned to" SortExpression="Loaned to" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="Select d.Title as 'Book', c.IssueId as 'Issue Number', a.DueDate as 'Due On', b.Username as 'Loaned to' FROM Rental a
INNER JOIN [User] b on a.UserId = b.UserId
INNER JOIN Issue c on a.IssueId = c.IssueId
INNER JOIN Book d on c.BookId = d.BookId
WHERE a.DueDate &lt; GETDATE()"></asp:SqlDataSource>
    <br />
</asp:Content>

