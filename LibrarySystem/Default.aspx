<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;">
            <h1>Library Management System</h1>
            <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Images/lib1.jpg" Width="400px" />
            <h3>Login</h3>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
&nbsp;
                <asp:TextBox ID="tbUser" runat="server" Width="141px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;
                <asp:TextBox ID="tbPass" runat="server" TextMode="Password" Width="139px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </p>
            <br />
            <a href="">Don't have an account? Click Here</a>
        </div>
    </form>
</body>
</html>
