<%@ Page Language="C#" AutoEventWireup="true" CodeFile="panel_view_panel.aspx.cs" Inherits="panel_view_panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Panel View Panel</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>


<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Panel ➡ View Panel</h2>
            </div>
            <div class="right-section">
                <a href="Login.aspx" class="back-button">Log Out</a>
            </div>
        </header>
    </div>

   <div class="container main-container">
        <div class="sidebar">
            <ul>
                            <li>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/panel_view_panel.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/panel_member_view_currently_assigned_fyps.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View FYPs Under Panel</span>
                    </button>
                </asp:HyperLink>
            </li>




            </ul>
        </div>

        <div class="content">
        <form id="form2" runat="server">
            <div>
                <asp:Label runat="server" Text="Panel Information" ID="panel_member_exists_label"></asp:Label>
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
        </form>
        </div>
    </div>
</body>
</html>






