<%@ Page Language="C#" AutoEventWireup="true" CodeFile="provideReview.aspx.cs" Inherits="provideReview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Missing Reviews<br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            Review:</div>
        <asp:TextBox ID="TextBox1" runat="server" Height="97px" Width="387px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit Review" />
    </form>
</body>
</html>
