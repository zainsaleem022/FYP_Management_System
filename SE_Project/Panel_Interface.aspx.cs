using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Panel_Interface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Faculty_class committee = (Faculty_class)Session["faculty_user"];
        lblEmail.Text = committee.Email;
        lblName.Text = committee.Name;
        lblUsername.Text = committee.getId();

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("panel_member_view_currently_assigned_fyps.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        dbhandler dbhandler = dbhandler.Instance;
        if (dbhandler.getStatus() ==1 )
            Response.Redirect("EvaluationForm.aspx");
        else
            Response.Write("<script>alert('Evaluation Forms not yet Generated.');</script>");
    }

    protected void gridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}