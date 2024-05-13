<%@ Page Language="C#" AutoEventWireup="true" CodeFile="panel_member_view_currently_assigned_fyps.aspx.cs" Inherits="panel_member_view_currently_assigned_fyps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Panel View Assigned FYPs</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>



<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Panel ➡ View Assigned FYPs</h2>
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
        <form id="form1" runat="server">
            <div>
                <asp:Label runat="server" Text="" ID="no_currently_assigned_fyp_found_label"></asp:Label>
            </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="fyp_id" HeaderText="FYP ID" />
                <asp:BoundField DataField="fyp_title" HeaderText="FYP Title" />
                <asp:BoundField DataField="fyp_description" HeaderText="FYP Description" />
                <asp:BoundField DataField="group_member_names" HeaderText="Group Members" />
                <asp:BoundField DataField="supervisor_name" HeaderText="Supervisor Name" />
                <asp:BoundField DataField="panel_member_names" HeaderText="Panel Members" />
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






