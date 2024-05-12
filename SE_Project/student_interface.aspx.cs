using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        Label3.Text = student.Email;
        Label1.Text = student.StudentName;
        Label2.Text = student.getId();
        Session["student_id"] = student.getId();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Student_view_review.aspx");
    }
    protected void HyperLink3_Click(object sender, EventArgs e)
    {
        // Cast the EventArgs object to a CancelEventArgs object
        CancelEventArgs cancelArgs = (CancelEventArgs)e;

        dbhandler dbhandler = dbhandler.Instance;
        int status = dbhandler.getStatus();

        if (status == 1)
        {
            // Navigate to the next page
            Response.Redirect("student_view_evaluation.aspx");
        }
        else
        {
            // Stay on the same page
            Response.Write("<script>alert('Evaluations not yet opened.')</script>");
            // Cancel the navigation
            cancelArgs.Cancel = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        dbhandler dbhandler = dbhandler.Instance;
        if (dbhandler.getStatus() == 0)
        {
            Response.Write("<script>alert('Evaluations not yet opened.')</script>");
        }
        else {
            Response.Redirect("student_view_evaluation.aspx");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        dbhandler dbhandler = dbhandler.Instance;
        if (dbhandler.getStatus() == 0)
        {
            Response.Write("<script>alert('Evaluations not yet opened.')</script>");
        }
        else
        {
            Response.Redirect("student_view_feedback.aspx");
        }
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        dbhandler dbhandler = dbhandler.Instance;
        if (dbhandler.getStatus() == 0)
        {
            Response.Write("<script>alert('Evaluations not yet opened.')</script>");
        }
        else
        {
            Response.Redirect("student_view_evaluation.aspx");
        }
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        dbhandler dbhandler = dbhandler.Instance;
        if (dbhandler.getStatus() == 0)
        {
            Response.Write("<script>alert('Evaluations not yet opened.')</script>");
        }
        else
        {
            Response.Redirect("student_view_feedback.aspx");
        }
    }
}
