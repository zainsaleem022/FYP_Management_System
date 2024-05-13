<%@ Page Language="C#" AutoEventWireup="true" CodeFile="committee_assign_panel_to_fyp.aspx.cs" Inherits="committee_assign_panel_to_fyp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>FYP Committee - Assign Panel</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>

<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>FYP Committee ➡ Assign Panel</h2>
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
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Register.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>Register</span>
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
                               <li>
                <%-- Dummy Hyperlinks --%>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/committee_makes_new_panel.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Create Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
                                <li>
                <%-- Dummy Hyperlinks --%>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/committee_add_assignment.aspx">
                    <button>
                        <img src="images/form_icon.png" alt="Attendance" />
                        <span>Add New Assignment</span>
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
                   <asp:Label runat="server" Text="Available FYPs" ID="supervisor_add_fyp_for_supervision_form_title_label" ></asp:Label>



            <asp:Label runat="server" Text="" ID="no_fyps_available_hidden_label"></asp:Label>
        <div class="content">
        <form id="form2" runat="server">
            <div>
                <asp:Label runat="server" Text="Panel Information" ID="panel_member_exists_label"></asp:Label>
            </div>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="fyp_id" HeaderText="FYP ID" />
                <asp:BoundField DataField="fyp_title" HeaderText="FYP Title" />
                <asp:BoundField DataField="fyp_description" HeaderText="FYP Description" />
                <asp:BoundField DataField="group_members" HeaderText="Group Members" />
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

            <div>
                <br />
                <br />
            </div>
               <div>
                    <div>
                        <table>
                            <tr>
                                <th>Enter the FYP ID you want to Assign Panel to: </th>
                                <td><asp:TextBox class ="form-control" ID = "TextBox1" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <th>Enter the Panel ID you want to Assign FYP to:</th>
                                <td> <asp:TextBox class ="form-control" ID = "TextBox2" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td> <asp:Button runat="server" Text="Submit" OnClick="Unnamed2_Click"></asp:Button></td>
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






