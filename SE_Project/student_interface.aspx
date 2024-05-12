
            <%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_interface.aspx.cs" Inherits="student_interface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>FYP Committee Profile - Home</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>
<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Student Profile</h2>
            </div>
            <div class="right-section">
                <a href="Login.aspx" class="back-button">Log Out</a
            </div>
        </header>
    </div>

    <div class="container main-container">
        <div class="sidebar">
            <ul>
                            <li>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/view_project_details_form.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Project Details</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/student_view_panel.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/student_view_feedback.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Feedback</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/student_view_evaluation.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Grade</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/get_fyp_details_from_student.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Add FYP Details</span>
                    </button>
                </asp:HyperLink>
            </li>
                <li>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/student_view_assignments.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Assignments</span>
                    </button>
                </asp:HyperLink>
            </li>

            </ul>
        </div>
        <div class="content">
            <form id="form1" runat="server">
                <div class="section">
                    <h3>Informationn<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="View Supervisor Review" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="View Grade" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text="View Feedback" />
                    </h3>
                    <div class="box">
                        <table>
                            <tr>
                                <th>Name:</th>
                                <td><asp:Label runat="server" ID="Label1"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Username:</th>
                                <td><asp:Label runat="server" ID="Label2"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Email:</th>
                                <td><asp:Label runat="server" ID="Label3"></asp:Label></td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </div>

                </div>

            </form>
        </div>
    </div>
</body>
</html>


