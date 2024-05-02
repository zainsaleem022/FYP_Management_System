<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_add_fyp_to_supervision.aspx.cs" Inherits="supervisor_add_fyp_to_supervision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Available FYPs" ID="supervisor_add_fyp_for_supervision_form_title_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="" ID="no_fyps_available_hidden_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="fyp_id" HeaderText="FYP ID" />
                <asp:BoundField DataField="fyp_title" HeaderText="FYP Title" />
                <asp:BoundField DataField="fyp_description" HeaderText="FYP Description" />
                <asp:BoundField DataField="group_members" HeaderText="Group Members" />
            </Columns>
        </asp:GridView>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
            <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Enter the FYP ID you want to Supervise" ID="ask_supervisor_to_enter_fyp_id_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
            <div class="wlp-whitespace-only-element-expansion">
                <asp:Button runat="server" Text="Submit" OnClick="Unnamed2_Click"></asp:Button>&nbsp;</div>
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
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
    </form>
</body>
</html>
