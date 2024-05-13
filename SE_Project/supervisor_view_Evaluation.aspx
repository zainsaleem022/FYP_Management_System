<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_view_Evaluation.aspx.cs" Inherits="supervisor_view_Evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Supervisor - View Evalution</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>

</head>

<body>
   

        <div class="content">
        <form id="form2" runat="server">
       <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Evaluation" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="QuestionString" HeaderText="Question" />
        <asp:BoundField DataField="PanelMember1Score" HeaderText="Panel Member Score" />
        <asp:BoundField DataField="PanelMember2Score" HeaderText="Panel Member Score" />
        <asp:BoundField DataField="PanelMember3Score" HeaderText="Panel Member Score" />
        <asp:BoundField DataField="PanelMember4Score" HeaderText="Panel Member Score" />
        <asp:BoundField DataField="PanelMember5Score" HeaderText="Panel Member Score" />
    </Columns>
</asp:GridView>
        </form>
        </div>
    </div>
</body>
</html>






