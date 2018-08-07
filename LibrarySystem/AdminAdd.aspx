<%@ Page Theme="SkinFile" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Add New"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="ddSelector" runat="server" Height="16px" Width="141px">
        <asp:ListItem>Book</asp:ListItem>
        <asp:ListItem>Issue</asp:ListItem>
        <asp:ListItem>Author</asp:ListItem>
        <asp:ListItem>Publisher</asp:ListItem>
        <asp:ListItem>Genre</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
</asp:Content>

