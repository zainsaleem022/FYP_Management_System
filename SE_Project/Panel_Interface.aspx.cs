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
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
        Panel_Member panel = new Panel_Member(faculty);
        DataTable table = panel.DisplayPanelMembers();
        gridView1.DataSource = table;
        gridView1.DataBind();
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