<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_view_panel.aspx.cs" Inherits="student_view_panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Panel Information" ID="student_view_panel_form_title_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <asp:Label runat="server" Text="" ID="panel_member_exists_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="panel_id" HeaderText="Panel ID" />
                <asp:BoundField DataField="faculty_name" HeaderText="Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Button runat="server" Text="Back" OnClick="Unnamed1_Click"></asp:Button>&nbsp;</div>
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
