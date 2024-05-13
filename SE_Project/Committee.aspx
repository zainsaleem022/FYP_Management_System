<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Committee.aspx.cs" Inherits="_Default" %>

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
                <h2>FYP Committee Profile</h2>
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
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Register.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>Register Faculty</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/RegisterStudent.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Register Student</span>
                    </button>
                </asp:HyperLink>
            </li>
                <li>
                <%-- Dummy Hyperlinks --%>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/committee_assign_panel_to_fyp.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Assign FYP to Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
                </li>
                <li>
                <%-- Dummy Hyperlinks --%>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/committee_add_assignment.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Add New Assignment</span>
                    </button>
                </asp:HyperLink>
            </li>
                <li>
               <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/committee_makes_new_panel.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Create Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
                            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/viewalldetails.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View FYP Details</span>
                    </button>
                </asp:HyperLink>
            </li>
                            <li>
                <%-- Dummy Hyperlinks --%>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/countfyp.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>View Supervisor's FYP</span>
                    </button>
                </asp:HyperLink>
            </li>
            </ul>
            
        </div>
        <div class="content">
            <form id="form2" runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Evaluation Forms" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="section">
                    <h3>Informationn</h3>
                    <div class="box">
                        <table>
                            <tr>
                                <th>Name:</th>
                                <td><asp:Label runat="server" ID="lblName"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Username:</th>
                                <td><asp:Label runat="server" ID="lblUsername"></asp:Label></td>
                            </tr>
                            <tr>
                                <th>Email:</th>
                                <td><asp:Label runat="server" ID="lblEmail"></asp:Label></td>
                            </tr>
                            </table>
                    </div>

                </div>

            </form>
        </div>
    </div>
</body>
</html>

