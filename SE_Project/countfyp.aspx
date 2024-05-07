<%@ Page Language="C#" AutoEventWireup="true" CodeFile="countfyp.aspx.cs" Inherits="countfyp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="supervisor_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="supervisor_id" HeaderText="supervisor_id" ReadOnly="True" SortExpression="supervisor_id" />
                <asp:BoundField DataField="faculty_name" HeaderText="faculty_name" SortExpression="faculty_name" />
                <asp:BoundField DataField="FYPs Supervising" HeaderText="FYPs Supervising" SortExpression="FYPs Supervising" />
                <asp:BoundField DataField="supervised_fyps" HeaderText="supervised_fyps" SortExpression="supervised_fyps" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=IK\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [fyps_supervising]"></asp:SqlDataSource>
    </form>
</body>
</html>
