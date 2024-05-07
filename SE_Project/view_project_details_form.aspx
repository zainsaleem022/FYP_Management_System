<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_project_details_form.aspx.cs" Inherits="view_project_details_form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Student View Details</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>
<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Student ➡ View Project Details</h2>
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
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/RegisterStudent.aspx">
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
            <form id="form2" runat="server">
                <div class="section">
                    <h3>Informationn</h3>
                    <div class="box">
                        <table>
                            <tr>
                                <th>Group Members: </th>
                                <td><asp:Label runat="server" ID="group_members_from_db_label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Supervisor:</th>
                                <td><asp:Label runat="server" ID="supervisor_name_from_db_label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Supervisor's Email:</th>
                                <td><asp:Label runat="server" ID="supervisor_email_from_db_label"></asp:Label></td>
                            </tr>
                             <tr>
                                <th>Title: </th>
                                <td><asp:Label runat="server" ID="title_from_db_label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Description:</th>
                                <td><asp:Label runat="server" ID="description_from_db_label"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Details:</th>
                                <td><asp:Label runat="server" ID="details_from_db_label"></asp:Label></td>
                            </tr>
                        </table>
                    </div>

                </div>

            </form>
        </div>
    </div>
</body>
</html>






