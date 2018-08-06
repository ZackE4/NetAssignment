<%@ Page Title="" Theme="SkinFile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:Label ID="lblWelcome" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="30pt" ForeColor="#000066" Text="Welcome"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:Button ID="btnMemberPage" runat="server" SkinID="btnBlue" Text="Go To Member Page" BackColor="#000066" ForeColor="White" Visible="False" />
    <br />
    <asp:Button ID="btnLibrarianPage" runat="server" SkinID="btnBlue" Text="Go To Librarian Page" BackColor="#000066" Font-Names="Arial" ForeColor="White" Visible="False" Width="185px" />
    <br />
    <asp:Button ID="btnAdminPage" runat="server" SkinID="btnBlue" Text="Go To Admin Page" BackColor="#000066" ForeColor="White" Visible="False" Width="186px" />
    <br />
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/CatinHatLibrary.jpg" Width="800px" />
    <br />
</asp:Content>

