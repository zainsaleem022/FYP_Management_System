<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_view_evaluation.aspx.cs" Inherits="student_view_evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Student View Grades</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>

<body>

        <div class="content">
        <form id="form2" runat="server">
            <div>

            </div>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="QuestionString" HeaderText="Question" />
        <asp:BoundField DataField="PanelMember1Score" HeaderText="Panel Member 1" />
        <asp:BoundField DataField="PanelMember2Score" HeaderText="Panel Member 2" />
        <asp:BoundField DataField="PanelMember3Score" HeaderText="Panel Member 3" />
        <asp:BoundField DataField="PanelMember4Score" HeaderText="Panel Member 4" />
        <asp:BoundField DataField="PanelMember5Score" HeaderText="Panel Member 5" />
    </Columns>

                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        </form>
        </div>
    </div>
</body>
</html>






