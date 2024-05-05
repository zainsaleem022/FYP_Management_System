<%@ Page Language="C#" AutoEventWireup="true" CodeFile="committee_add_assignment.aspx.cs" Inherits="committee_add_assignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Add New Assignment" ID="add_new_assignment_form_title_label"></asp:Label>
        </div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Assignment ID" ID="assignment_id_static_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
            <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Assignment Title" ID="assignment_title_static_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
            <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox2" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Assignment Description" ID="assignment_description_static_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
                <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox3" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
         <div>
            <asp:Label runat="server" Text="Deadline:" AssociatedControlID="txtDeadline"></asp:Label>
            <asp:Calendar runat="server" ID="txtDeadline" SelectionMode="Day"></asp:Calendar>
        </div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Button runat="server" Text="Submit" OnClick="Unnamed1_Click"></asp:Button>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Button runat="server" Text="Back" OnClick="Unnamed2_Click"></asp:Button>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
    </form>
</body>
</html>
