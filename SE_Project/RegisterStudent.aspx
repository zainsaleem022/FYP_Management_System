<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterStudent.aspx.cs" Inherits="RegisterStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Register Student"></asp:Label>
        </div>
        ID<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Password<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        FYP Group ID<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
    </form>
</body>
</html>
