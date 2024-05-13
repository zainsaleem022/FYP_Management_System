<%@ Page Language="C#" AutoEventWireup="true" CodeFile="supervisor_add_fyp_to_supervision.aspx.cs" Inherits="supervisor_add_fyp_to_supervision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>FYP Committee Profile - Make Panel</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>

</head>
<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Supervisor ➡ Add FYP to Supervision</h2>
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
                <div class="section">
                    <h3><asp:Label runat="server" Text="Available FYPs" ID="supervisor_add_fyp_for_supervision_form_title_label"></asp:Label></h3>
                    <div class="box">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="fyp_id" HeaderText="FYP ID" />
                <asp:BoundField DataField="fyp_title" HeaderText="FYP Title" />
                <asp:BoundField DataField="fyp_description" HeaderText="FYP Description" />
                <asp:BoundField DataField="group_members" HeaderText="Group Members" />
            </Columns>
        </asp:GridView>
                        <div>
                            <br />
                            <br />
                        </div>

                        <table>
                            <tr>
                                <th><asp:Label runat="server" Text="" ID="no_fyps_available_hidden_label"></asp:Label> </th>
                            </tr>
                            <tr>
                                <th>Enter the FYP ID you want to Supervise: </th>
                                <td><asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th><asp:Button runat="server" Text="Submit" OnClick="Unnamed2_Click"></asp:Button> </th>

                            </tr>
                            
                            </table>
                    </div>

                </div>

            </form>
        </div>
    </div>
</body>
</html>

