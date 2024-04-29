<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Faculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Committee " />
            <asp:Button ID="Button2" runat="server" Text="Supervisor" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Panel" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
