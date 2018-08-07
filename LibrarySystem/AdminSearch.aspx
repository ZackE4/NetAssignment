<%@ Page Theme="SkinFile" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSearch.aspx.cs" Inherits="Admin_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Search / Edit"></asp:Label>
    <br />
<asp:Label ID="Label2" runat="server" Font-Names="Arial" ForeColor="#000066" SkinID="genlbl" Text="Search For: "></asp:Label>
<asp:DropDownList ID="ddSelector" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddSelector_SelectedIndexChanged" Width="127px">
    <asp:ListItem>Issue</asp:ListItem>
    <asp:ListItem>Genre</asp:ListItem>
    <asp:ListItem>Publisher</asp:ListItem>
    <asp:ListItem>Author</asp:ListItem>
    <asp:ListItem>Book</asp:ListItem>
    <asp:ListItem>User</asp:ListItem>
</asp:DropDownList>
<br />
<br />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="IssueView" runat="server">
    </asp:View>
    <asp:View ID="GenreView" runat="server">
    </asp:View>
    <asp:View ID="PublisherView" runat="server">
    </asp:View>
    <asp:View ID="AuthorView" runat="server">
    </asp:View>
    <asp:View ID="BookView" runat="server">
    </asp:View>
    <asp:View ID="UserView" runat="server">
        &nbsp;<asp:Label ID="Label3" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Username"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbUserName" runat="server" Width="142px"></asp:TextBox>
        &nbsp; OR<br />&nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbLastName" runat="server" Width="142px"></asp:TextBox>
        &nbsp;OR<br />&nbsp;<asp:Label ID="Label5" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Email"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="tbEmail" runat="server" Width="142px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearchUser" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnSearchUser_Click" Text="Search" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="UserId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="AccountType" HeaderText="AccountType" SortExpression="AccountType" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#000066" SkinID="genlbl" Text="EDIT"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Font-Names="Arial" ForeColor="#000066" Text="First Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="tbEditFName" runat="server" Width="211px"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="tbEditLastName" runat="server" Width="212px"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Account Type"></asp:Label>
        &nbsp; &nbsp;
        <asp:DropDownList ID="ddEditAccType" runat="server" Height="18px" Width="216px">
            <asp:ListItem>Member</asp:ListItem>
            <asp:ListItem>Librarian</asp:ListItem>
            <asp:ListItem>Administrator</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label10" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Address"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditAddress" runat="server" Width="464px"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Email"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="tbEditEmail" runat="server" Width="212px"></asp:TextBox>
        <br />
        <asp:Label ID="Label12" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Book Limit"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditBookLimit" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Re-Issue Limit"></asp:Label>
        &nbsp;
        <asp:TextBox ID="tbEditReIssue" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label14" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Comments"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditComments" runat="server" Width="753px"></asp:TextBox>
        <br />
        &nbsp;<br />
        <asp:Button ID="btnUserEditSubmit" runat="server" BackColor="#000066" ForeColor="White" OnClick="btnUserEditSubmit_Click" Text="Make Changes" />
        <br />
    </asp:View>
</asp:MultiView>
    <br />
</asp:Content>

