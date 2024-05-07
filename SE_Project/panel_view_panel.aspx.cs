using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_view_panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
        // Panel_Member panel = new Panel_Member(faculty);
        dbhandler db = dbhandler.Instance;
        int pan = db.GetPanelIdForFaculty(faculty.getId());
        if (pan == 0)
        {
            Response.Write("<script>alert('Not Part of a Panel');</script>");
        }
        DataTable table = db.DisplayPanel(pan);
        gridView1.DataSource = table;
        gridView1.DataBind();
    }

    protected void gridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}