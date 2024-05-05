<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student_view_assignments.aspx.cs" Inherits="student_view_assignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Student  - View Assignments</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>

</head>
<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Student ➡ View Assignments</h2>
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
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/view_project_details_form.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Project Details</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/student_view_panel.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/student_view_feedback.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Feedback</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/RegisterStudent.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Grade</span>
                    </button>
                </asp:HyperLink>
            </li>
                 <li>
                <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/get_fyp_details_from_student.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Add FYP Details</span>
                    </button>
                </asp:HyperLink>
            </li>
                                <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/student_view_assignments.aspx">
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
            <asp:Label runat="server" Text="Assignments" ID="Label4"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="assignment_id" HeaderText="Assignment ID" />
                <asp:BoundField DataField="assignment_title" HeaderText="Title" />
                <asp:BoundField DataField="assignment_description" HeaderText="Description" />
                <asp:BoundField DataField="assignment_deadline" HeaderText="Deadline" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            </Columns>
        </asp:GridView>
                        <div>
                            <br />
                            <br />
                        </div>

                        <table>
                            <tr>
                                <th>Submit Assignment </th>
                            </tr>
                            <tr>
                                <th>Assignment ID: </th>
                                <td><asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Add Text: </th>
                                <td><asp:TextBox class ="form-control" ID = "TextBox2" runat="server"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <th>Upload File: </th>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <th><asp:Button runat="server" Text="Submit Assignment" OnClick="Unnamed1_Click"></asp:Button> </th>
                            </tr>
                            </table>
                    </div>

                </div>

            </form>
        </div>
    </div>
</body>
</html>

