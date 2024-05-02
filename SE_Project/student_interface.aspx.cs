using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_interface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = (User)Session["User"];

        // Create a Student object using the User object and additional student details
        Student student = new Student(user.getId(), user.getPassword(),user.getRole());

        // Store the Student object in the session
        Session["Student"] = student;
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_project_details_form.aspx");
    }

    protected void Unnamed7_Click(object sender, EventArgs e)
    {
        Response.Redirect("get_fyp_details_from_student.aspx");
    }

    protected void Unnamed2_Click1(object sender, EventArgs e)
    {
        Response.Redirect("student_view_panel.aspx");
    }

    protected void Unnamed6_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}