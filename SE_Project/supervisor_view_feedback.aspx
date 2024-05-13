<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_view_feedback.aspx.cs" Inherits="supervisor_view_feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Supervisor - View Feedback</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>


</head>

<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Supervisor ➡ View Feedback</h2>
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
        <form id="form2" runat="server">
              <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Feedback" />
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        </form>
        </div>
    </div>
</body>
</html>






