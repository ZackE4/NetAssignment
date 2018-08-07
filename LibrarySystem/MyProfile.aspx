<%@ Page Title="" Theme="SkinFile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" Text="My Profile"></asp:Label>
    <br />
    <br />
    <asp:Image ID="imgProfilePic" runat="server" Height="170px" Width="193px" />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Names="Arial" ForeColor="#000066" Text="First Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbFName" runat="server" Width="248px"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tblName" runat="server" Width="248px"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Address"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbAddress" runat="server" Width="248px"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbEmail" runat="server" Width="248px"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Profile Picture"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="ddProfilePic" runat="server" Height="19px" OnSelectedIndexChanged="ddProfilePic_SelectedIndexChanged" Width="258px" AutoPostBack="True">
        <asp:ListItem Value="0">Rhino</asp:ListItem>
        <asp:ListItem Value="1">Zebra</asp:ListItem>
        <asp:ListItem Value="2">Giraffe</asp:ListItem>
        <asp:ListItem Value="3">Monkey</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnUpdate" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnUpdate_Click" Text="Update Profile" />
    <br />
</asp:Content>

