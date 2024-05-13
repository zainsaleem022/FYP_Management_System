<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_view_currently_supervising_fyps.aspx.cs" Inherits="supervisor_view_currently_supervising_fyps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Supervisor View Panel</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>
<body>

    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Supervisor ➡ View FYPs Currently Supervising</h2>
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
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/supervisor_view_currently_supervising_fyps.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>FYPs Supervising</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/provideReview.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>Provide Review</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/supervisor_view_feedback.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Feedback</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/supervisor_view_Evaluation.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Evaluation</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/supervisor_add_fyp_to_supervision.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Add FPY to Supervision</span>
                    </button>
                </asp:HyperLink>
            </li>

                                <li>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/supervisor_view_fyp_assignments.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Current Assignments</span>
                    </button>
                </asp:HyperLink>
            </li>
            </ul>

        </div>

        <div class="content">
                   <div>
            <br />
            <br />
            <br />
           </div>

            <div>
                       <asp:Label runat="server" Text="" ID="no_fyps_found_as_currently_supervisioning_label"></asp:Label>
            </div>
        <form id="form2" runat="server">


                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                   
                   CellPadding="2" Height="258px" Width="1119px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" style="margin-bottom: 0px">
 
            <Columns>
                <asp:BoundField DataField="fyp_id" HeaderText="FYP ID" />
                <asp:BoundField DataField="fyp_title" HeaderText="FYP Title" />
                <asp:BoundField DataField="fyp_description" HeaderText="FYP Description" />
                <asp:BoundField DataField="group_member_names" HeaderText="Group Members" />
                <asp:BoundField DataField="panel_member_names" HeaderText="Panel Members" />
            </Columns>
        </asp:GridView>
        </form>
        </div>
    </div>
</body>
</html>






