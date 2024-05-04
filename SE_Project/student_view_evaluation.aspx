<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_view_evaluation.aspx.cs" Inherits="student_view_evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="QuestionString" HeaderText="Question" />
        <asp:BoundField DataField="PanelMember1Score" HeaderText="Panel Member 1" />
        <asp:BoundField DataField="PanelMember2Score" HeaderText="Panel Member 2" />
        <asp:BoundField DataField="PanelMember3Score" HeaderText="Panel Member 3" />
        <asp:BoundField DataField="PanelMember4Score" HeaderText="Panel Member 4" />
        <asp:BoundField DataField="PanelMember5Score" HeaderText="Panel Member 5" />
    </Columns>
</asp:GridView>
        </div>
    </form>
</body>
</html>
