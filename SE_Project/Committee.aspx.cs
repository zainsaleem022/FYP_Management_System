using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Faculty_class committee = (Faculty_class)Session["faculty_user"];
        lblEmail.Text = committee.Email;
        lblName.Text = committee.Name;
        lblUsername.Text = committee.getId();

    }

   
    //protected void Button1_Click1(object sender, EventArgs e)
    //{
    //    Response.Redirect("Register.aspx");
    //}

    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("RegisterStudent.aspx");
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        dbhandler dbHandler = dbhandler.Instance;
        int status = dbHandler.getStatus();
        if (status == 1) { Response.Write("<script>alert('Evaluation Forms already Sent.');</script>"); }
        else
        {
            dbHandler.setStatus();
            Response.Write("<script>alert('Evaluation Forms Sent.');</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewalldetails.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("countfyp.aspx");
    }
}