<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Panel_Interface.aspx.cs" Inherits="Panel_Interface" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Panel - Home</title>
    <link rel="stylesheet" href="mainpage_styles.css"/>

</head>
<body>
    <div class="header-container">
        <header class="header">
            <div class="left-section"></div>
            <div class="center-section">
                <h2>Panel Profile</h2>
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
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/panel_view_panel.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View Panel</span>
                    </button>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/panel_member_view_currently_assigned_fyps.aspx">
                    <button>
                        <img src="images/home_icon.png" alt="Home" />
                        <span>View FYPs Under Panel</span>
                    </button>
                </asp:HyperLink>
            </li>




            </ul>
        </div>
        <div class="content">
            <form id="form2" runat="server">
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" style="height: 26px; margin-left: 35px" Text="Fill Evalution Form" Width="161px" />
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

