<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewalldetails.aspx.cs" Inherits="viewalldetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="faculty_id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="fyp_id" HeaderText="fyp_id" SortExpression="fyp_id" />
                    <asp:BoundField DataField="student_ids" HeaderText="student_ids" SortExpression="student_ids" />
                    <asp:BoundField DataField="student_names" HeaderText="student_names" SortExpression="student_names" />
                    <asp:BoundField DataField="faculty_id" HeaderText="faculty_id" ReadOnly="True" SortExpression="faculty_id" />
                    <asp:BoundField DataField="faculty_name" HeaderText="faculty_name" SortExpression="faculty_name" />
                    <asp:BoundField DataField="fyp_title" HeaderText="fyp_title" SortExpression="fyp_title" />
                    <asp:BoundField DataField="details" HeaderText="details" SortExpression="details" />
                    <asp:BoundField DataField="fyp_description" HeaderText="fyp_description" SortExpression="fyp_description" />
                    <asp:BoundField DataField="final_grade" HeaderText="final_grade" SortExpression="final_grade" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=IK\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [allfypdetails]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
