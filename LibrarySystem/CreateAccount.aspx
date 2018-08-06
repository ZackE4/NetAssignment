<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:silver;">
    <form id="form1" runat="server">
        <div>
            <h1 style="font-family: Arial; color: #000080">New User:</h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Username" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="tbUser" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" ControlToValidate="tbPass" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Confirm Password" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbConfirmPass" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ControlToValidate="tbConfirmPass" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="First Name" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="tbFirstName" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Last Name" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="tbLastName" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Address" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="tbAddress" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Email" Font-Names="Arial" ForeColor="#000066"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="RequiredFieldValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red">*Required</asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="tbEmail" Display="Dynamic" ErrorMessage="RegularExpressionValidator" Font-Bold="True" Font-Names="Arial" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Must Use Valid Email Address</asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#000066" CausesValidation="False" Font-Names="Arial" ForeColor="White" OnClick="Button1_Click" Text="Cancel" />
&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#000066" Font-Names="Arial" ForeColor="White" />
    &nbsp;</form>
</body>
</html>
