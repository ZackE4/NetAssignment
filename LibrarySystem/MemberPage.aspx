<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberPage.aspx.cs" Inherits="Member" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblRentals" runat="server" Text="Current Rentals:"></asp:Label>
    <asp:Label ID="lblRentalMissing" runat="server" Text="There are no Rentals on your account at the moment"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RentalId" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="RentalId" HeaderText="RentalId" InsertVisible="False" ReadOnly="True" SortExpression="RentalId" />
            <asp:BoundField DataField="IssueId" HeaderText="IssueId" SortExpression="IssueId" />
            <asp:BoundField DataField="RentalDate" HeaderText="RentalDate" SortExpression="RentalDate" />
            <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
            <asp:BoundField DataField="Fees" HeaderText="Fees" SortExpression="Fees" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="CoverType" HeaderText="CoverType" SortExpression="CoverType" />
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
    <asp:Label ID="lblHistory" runat="server" Text="History:"></asp:Label>
    <asp:Label ID="lblHistoryMissing" runat="server" Text="There is no Rental History"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="RentalId" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="RentalId" HeaderText="RentalId" InsertVisible="False" ReadOnly="True" SortExpression="RentalId" />
            <asp:BoundField DataField="IssueId" HeaderText="IssueId" SortExpression="IssueId" />
            <asp:BoundField DataField="RentalDate" HeaderText="RentalDate" SortExpression="RentalDate" />
            <asp:BoundField DataField="DueDate" HeaderText="DueDate" SortExpression="DueDate" />
            <asp:BoundField DataField="Fees" HeaderText="Fees" SortExpression="Fees" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="CoverType" HeaderText="CoverType" SortExpression="CoverType" />
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
    <asp:Label ID="lblOwing" runat="server" Text="Amount Owing:  "></asp:Label>
    </asp:Content>

