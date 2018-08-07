<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchPublisher.aspx.cs" Inherits="SearchPublisher" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblPublisher" runat="server" Text="Publisher Name:"></asp:Label>
<asp:TextBox ID="txtPublisher" runat="server"></asp:TextBox>
<br />
<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PublisherId" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="PublisherId" HeaderText="PublisherId" InsertVisible="False" ReadOnly="True" SortExpression="PublisherId" />
        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
        <asp:BoundField DataField="Province/State" HeaderText="Province/State" SortExpression="Province/State" />
        <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
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
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NetClassConnectionString %>" SelectCommand="SELECT * FROM [Publisher]"></asp:SqlDataSource>
</asp:Content>

