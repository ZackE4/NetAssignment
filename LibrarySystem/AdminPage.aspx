<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Administration Page"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSearch" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="Button1_Click" SkinID="btnBlue" Text="Search / Edit" />
    <br />
    <br />
    <asp:Button ID="btnNew" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="Button2_Click" SkinID="btnBlue" Text="Add New" />
    <br />
    <br />
</asp:Content>

