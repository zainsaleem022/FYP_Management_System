<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_view_review.aspx.cs" Inherits="Student_view_review" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>Student View Grades</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>


<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Student ➡ View Review</h2>
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

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="student_id" SortExpression="student_id" />
                    <asp:BoundField DataField="review" HeaderText="review" SortExpression="review" />
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-RU4CV3CE\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [student_id], [review] FROM [student_review] WHERE ([student_id] = @student_id)">
                <SelectParameters>
                    <asp:SessionParameter Name="student_id" SessionField="student_id" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>

        </form>
        </div>
    </div>
</body>
</html>







