<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Panel_Interface.aspx.cs" Inherits="Panel_Interface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 418px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Panel Interface"></asp:Label>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" style="margin-top: 24px" Text="View Panel" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 49px" Text="View FYPs Overseen by Panel" Width="187px" />
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="margin-top: 0px" Text="View Deadlines" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="height: 26px; margin-left: 35px" Text="Fill Evalution Form" Width="161px" />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
