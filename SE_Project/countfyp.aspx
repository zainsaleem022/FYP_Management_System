﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="countfyp.aspx.cs" Inherits="countfyp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
         <title>FYP Committee View Supervisor Count</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>
</head>


<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>FYP Committee ➡ View Supervisor Count</h2>
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


        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="supervisor_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="supervisor_id" HeaderText="supervisor_id" ReadOnly="True" SortExpression="supervisor_id" />
                <asp:BoundField DataField="faculty_name" HeaderText="faculty_name" SortExpression="faculty_name" />
                <asp:BoundField DataField="FYPs Supervising" HeaderText="FYPs Supervising" SortExpression="FYPs Supervising" />
                <asp:BoundField DataField="supervised_fyps" HeaderText="supervised_fyps" SortExpression="supervised_fyps" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-RU4CV3CE\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [fyps_supervising]"></asp:SqlDataSource>

                
                    
        </form>
        </div>
    </div>
</body>
</html>






