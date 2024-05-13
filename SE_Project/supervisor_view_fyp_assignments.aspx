<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_view_fyp_assignments.aspx.cs" Inherits="supervisor_view_fyp_assignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Supervisor View Assignments</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>

<body>

    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Supervisor ➡ View Assignments</h2>
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
                       <asp:Label runat="server" Text="" ID="supervisor_no_assignments_found_label"></asp:Label>
            </div>
        <form id="form2" runat="server">


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="FYP Title" HeaderText="FYP Title" />
                <asp:BoundField DataField="Assignment Title" HeaderText="Assignment Title" />
                <asp:BoundField DataField="Assignment Deadline" HeaderText="Assignment Deadline" />
                <asp:BoundField DataField="Student Name" HeaderText="Student Name" />
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






