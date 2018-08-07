<%@ Page Theme="SkinFile" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminSearch.aspx.cs" Inherits="Admin_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="26pt" ForeColor="#000066" Text="Search / Edit"></asp:Label>
    <br />
<asp:Label ID="Label2" runat="server" Font-Names="Arial" ForeColor="#000066" SkinID="genlbl" Text="Search For: "></asp:Label>
<asp:DropDownList ID="ddSelector" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddSelector_SelectedIndexChanged" Width="127px">
    <asp:ListItem>Genre</asp:ListItem>
    <asp:ListItem>Publisher</asp:ListItem>
    <asp:ListItem>Author</asp:ListItem>
    <asp:ListItem>Book</asp:ListItem>
    <asp:ListItem>User</asp:ListItem>
</asp:DropDownList>
<br />
<br />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="GenreView" runat="server">
        <asp:Label ID="Label33" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Genre Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbGenreName" runat="server" Width="167px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGenreSearch" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnGenreSearch_Click" Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="GenreId" GridLines="Vertical" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="GenreId" HeaderText="GenreId" InsertVisible="False" ReadOnly="True" SortExpression="GenreId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating" />
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
        <br />
        <asp:Label ID="Label34" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#000066" Text="EDIT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label35" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Genre Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditGenreName" runat="server" Width="170px"></asp:TextBox>
        <br />
        <asp:Label ID="Label36" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Rating"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditRating" runat="server" Width="170px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmitEditGenre" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnSubmitEditGenre_Click" Text="Make Changes" />
        &nbsp;
        <asp:Button ID="btnDeleteGenre" runat="server" BackColor="#000066" BorderColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnDeleteGenre_Click" Text="Delete" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </asp:View>
    <asp:View ID="PublisherView" runat="server">
        <asp:Label ID="Label26" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Publisher Name"></asp:Label>
        &nbsp;
        <asp:TextBox ID="tbPubName" runat="server" Width="169px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPublisherSearch" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnPublisherSearch_Click" Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="PublisherId" GridLines="Vertical" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="PublisherId" HeaderText="PublisherId" InsertVisible="False" ReadOnly="True" SortExpression="PublisherId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
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
        <br />
        <asp:Label ID="Label27" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#000066" Text="EDIT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label28" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditPubName" runat="server" Width="221px"></asp:TextBox>
        <br />
        <asp:Label ID="Label29" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Address"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditPubAddress" runat="server" Width="221px"></asp:TextBox>
        <br />
        <asp:Label ID="Label30" runat="server" Font-Names="Arial" ForeColor="#000066" Text="City"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditPubCity" runat="server" Width="221px"></asp:TextBox>
        <br />
        <asp:Label ID="Label31" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Prov/State"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditPubProv" runat="server" Width="221px"></asp:TextBox>
        <br />
        <asp:Label ID="Label32" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Country"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditPubCountry" runat="server" Width="221px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEditPubSubmit" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnEditPubSubmit_Click" Text="Make Changes" />
        &nbsp;
        <asp:Button ID="btnDeletePublisher" runat="server" BackColor="#000066" BorderColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnDeletePublisher_Click" Text="Delete" />
        <br />
    </asp:View>
    <asp:View ID="AuthorView" runat="server">
        <asp:Label ID="Label20" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAuthorLastName" runat="server" Width="138px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAuthorSearch" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnAuthorSearch_Click" Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="AuthorId" GridLines="Vertical" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="AuthorId" HeaderText="AuthorId" InsertVisible="False" ReadOnly="True" SortExpression="AuthorId" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="SecondName" HeaderText="SecondName" SortExpression="SecondName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
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
        <br />
        <asp:Label ID="Label21" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#000066" Text="EDIT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Font-Names="Arial" ForeColor="#000066" Text="First Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditAuthorFirstName" runat="server" Width="183px"></asp:TextBox>
        <br />
        <asp:Label ID="Label23" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Second Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditSecondName" runat="server" Width="184px"></asp:TextBox>
        <br />
        <asp:Label ID="Label24" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Last Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditAuthorLastName" runat="server" Width="184px"></asp:TextBox>
        <br />
        <asp:Label ID="Label25" runat="server" Font-Names="Arial" ForeColor="#000066" Text="DOB"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditDOB" runat="server" Width="184px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnEditAuthorSubmit" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnEditAuthorSubmit_Click" Text="Make Changes" />
        &nbsp;
        <asp:Button ID="btnDeleteAuthor" runat="server" BackColor="#000066" BorderColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnDeleteAuthor_Click" Text="Delete" />
        <br />
    </asp:View>
    <asp:View ID="BookView" runat="server">
        <asp:Label ID="Label15" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbBookTitle" runat="server" Width="140px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearchBook" runat="server" BackColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnSearchBook_Click" style="height: 26px" Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="BookId" GridLines="Vertical" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="Gainsboro" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="BookId" HeaderText="BookId" InsertVisible="False" ReadOnly="True" SortExpression="BookId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="PublishedDate" HeaderText="PublishedDate" SortExpression="PublishedDate" />
                <asp:BoundField DataField="CoverType" HeaderText="CoverType" SortExpression="CoverType" />
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
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="#000066" Text="EDIT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label17" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Title"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEditBookTitle" runat="server" Width="136px"></asp:TextBox>
        <br />
        <asp:Label ID="Label18" runat="server" Font-Names="Arial" ForeColor="#000066" Text="Published Date"></asp:Label>
        &nbsp;
        <asp:TextBox ID="tbEditPublishedDate" runat="server" Width="136px"></asp:TextBox>
        <br />
        <asp:Label ID="Label19" runat="server" Font-Names="Arial" ForeColor="#000066" Text="CoverType"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddCoverType" runat="server" Height="22px" Width="145px">
            <asp:ListItem>Soft</asp:ListItem>
            <asp:ListItem Value="Hard"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnBookEditSubmit" runat="server" BackColor="#000066" ForeColor="White" OnClick="btnBookEditSubmit_Click" Text="Make Changes" />
        &nbsp;
        <asp:Button ID="btnDeleteBook" runat="server" BackColor="#000066" BorderColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnDeleteBook_Click" Text="Delete" />
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
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="UserId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" ReadOnly="True" SortExpression="UserId" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="AccountType" HeaderText="AccountType" SortExpression="AccountType" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle ForeColor="Black" BackColor="#EEEEEE" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
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
        &nbsp;
        <asp:Button ID="btnDeleteUser" runat="server" BackColor="#000066" BorderColor="#000066" Font-Names="Arial" ForeColor="White" OnClick="btnDeleteUser_Click" Text="Delete" />
        <br />
    </asp:View>
</asp:MultiView>
    <br />
</asp:Content>

