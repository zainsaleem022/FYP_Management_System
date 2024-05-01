<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Faculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Main Login Page</title>
    <link rel="stylesheet" href="main_login_styles.css">
</head>
<body>
    <div class = "center">
        <form id="form1" runat="server">
            <div>
            </div>
            <div class="box">
                <h3>
                    To access the FYP Committee Interface&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Committee " />
                    &nbsp;
                </h3>
            </div>
            <div class="box">
                <h3>
                    To access the Supervisor Interface&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Supervisor" OnClick="Button2_Click" />
                </h3>
            </div>
            <div class="box">
                <h3>
                   To access the Panel Interface
                     <asp:Button ID="Button3" runat="server" Text="Panel" OnClick="Button3_Click" />
                </h3>
            </div>
        </form>
    </div>
</body>
</html>


