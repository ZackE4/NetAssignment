<%@ Page Theme="SkinFile" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="AdminAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Add New"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="ddSelector" runat="server" Height="16px" Width="141px" AutoPostBack="True" OnSelectedIndexChanged="ddSelector_SelectedIndexChanged">
        <asp:ListItem>Book</asp:ListItem>
        <asp:ListItem>Issue</asp:ListItem>
        <asp:ListItem>Author</asp:ListItem>
        <asp:ListItem>Publisher</asp:ListItem>
        <asp:ListItem>Genre</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="BookView" runat="server">
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="16pt" ForeColor="#000066" Text="New Book"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label21" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Author Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddBookAuthorId" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label22" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Genre Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddBookGenreId" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label26" runat="server" Font-Names="Arial" ForeColor="#000066" Text="PublisherId"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddBookPubId" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label23" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Title"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddBookTitle" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label24" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Published Date"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="tbAddBookPubDate" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label25" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Cover Type"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddCoverType" runat="server" Height="16px" Width="190px">
                <asp:ListItem>Soft</asp:ListItem>
                <asp:ListItem>Hard</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnAddBook" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAddBook_Click" Text="Add" />
        </asp:View>
        <asp:View ID="IssueView" runat="server">
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="16pt" ForeColor="#000066" Text="New Issue"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label18" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Book Id"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddIssueBookId" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label19" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Print Date"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddIssuePrintDate" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label20" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Comments"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddIssueComments" runat="server" Width="183px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddIssue" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAddIssue_Click" Text="Add" />
        </asp:View>
        <asp:View ID="AuthorView" runat="server">
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="16pt" ForeColor="#000066" Text="New Author"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label14" runat="server" Font-Names="Arial" ForeColor="#000066" Text="First Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddAuthorFname" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label15" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Second Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddAuthorSname" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label16" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddAuthorLname" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label17" runat="server" Font-Names="Arial" ForeColor="#000066" Text="DOB"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddAuthorDOB" runat="server" Width="183px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddAuthor" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAddAuthor_Click" Text="Add" />
        </asp:View>
        <asp:View ID="PublisherView" runat="server">
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="16pt" ForeColor="#000066" Text="New Publisher"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Name"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddPubName" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Address "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddPubAddr" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Font-Names="Arial" ForeColor="#000066" Text="City"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddPubCity" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label12" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Prov/State"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="tbAddPubProv" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label13" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Country"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddPubCountry" runat="server" Width="183px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddPub" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAddPub_Click" Text="Add" />
        </asp:View>
        <asp:View ID="GenreView" runat="server">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="16pt" ForeColor="#000066" Text="New Genre"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Genre Title"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="tbAddGenreTitle" runat="server" Width="183px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Rating"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbAddGenreRating" runat="server" Width="181px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAddGenre" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAddGenre_Click" Text="Add" />
        </asp:View>
    </asp:MultiView>
    <br />
</asp:Content>

