<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Welcome to FYP Management</div>
        <p>
            ID:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Password<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="31px" OnClick="Button1_Click" Text="Login" Width="174px" />
        </p>
    </form>
</body>
</html>
