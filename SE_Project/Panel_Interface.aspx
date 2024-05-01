<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Panel_Interface.aspx.cs" Inherits="Panel_Interface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 418px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Panel Interface"></asp:Label>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" style="margin-top: 24px" Text="View Panel" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left: 49px" Text="View FYPs Overseen by Panel" Width="187px" />
        </p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="margin-top: 0px" Text="View Deadlines" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="height: 26px; margin-left: 35px" Text="Fill Evalution Form" Width="161px" />
        <br />
        <br />
        <br />



                    <div class="content">

            <div>
                Panel Information<br />
                <br />
                <br />
            </div>
            <asp:GridView ID="gridView1" runat="server" AutoGenerateColumns="False" 
                    OnSelectedIndexChanged="gridView1_SelectedIndexChanged"
                    DataKeyNames="panel_id" OnRowCommand="gridView1_RowCommand" CellPadding="4" Height="258px" Width="1119px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" style="margin-bottom: 0px">
                    <Columns>
                        <asp:BoundField DataField="panel_id" HeaderText="Panel ID" />
                        <asp:BoundField DataField="faculty_name" HeaderText="Name" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="id" HeaderText="Faculty ID" />
                
                    
                    
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

        </div>

    </form>


</body>
</html>
