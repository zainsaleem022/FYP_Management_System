<%@ Page Language="C#" AutoEventWireup="true" CodeFile="get_fyp_details_from_student.aspx.cs" Inherits="get_fyp_details_from_student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>FYP Committee Profile - Home</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>
<body>
    <form id="form1" runat="server">
                <div>
        </div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Add FYP Details" ID="get_fyp_details_form_title_label"></asp:Label>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Project Title" ID="project_title_label"></asp:Label>&nbsp;</div>
        <asp:TextBox ID = "Text1" runat="server"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">
        <div class="wlp-whitespace-only-element-expansion">
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Label runat="server" Text="Project Description" ID="project_description_label"></asp:Label>&nbsp;</div>
            <asp:TextBox ID="TextArea1" runat="server" TextMode="MultiLine" Rows="2" Columns="50"></asp:TextBox>
            

            
        <div class="wlp-whitespace-only-element-expansion">&nbsp;        
            <asp:Label runat="server" Text="Project Details" ID="project_details_label"></asp:Label></div>&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:TextBox ID="TextArea2" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
        <div class="wlp-whitespace-only-element-expansion">&nbsp;</div>
        <div class="wlp-whitespace-only-element-expansion">
            <asp:Button runat="server" Text="Submit Details" OnClick="Unnamed1_Click"></asp:Button>&nbsp;</div>
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
    </form>
</body>
</html>



