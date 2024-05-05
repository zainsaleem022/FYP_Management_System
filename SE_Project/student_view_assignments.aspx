<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_view_assignments.aspx.cs" Inherits="student_view_assignments" %>

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
            <asp:Label runat="server" Text="Assignments" ID="student_view_assignments_form_title_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="assignment_id" HeaderText="Assignment ID" />
                <asp:BoundField DataField="assignment_title" HeaderText="Title" />
                <asp:BoundField DataField="assignment_description" HeaderText="Description" />
                <asp:BoundField DataField="assignment_deadline" HeaderText="Deadline" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            </Columns>
        </asp:GridView>

        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>

        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Submit Assignment" ID="assignment_submission_id_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Assignment ID" ID="Label1"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Add Text" ID="Label2"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="form-group">
                <asp:TextBox class ="form-control" ID = "TextBox2" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
            
            <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Upload File" ID="Label3"></asp:Label>&nbsp;</div>

            <asp:FileUpload ID="FileUpload1" runat="server" />
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Button runat="server" Text="Submit Assignment" OnClick="Unnamed1_Click"></asp:Button>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
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
    </form>
</body>
</html>
