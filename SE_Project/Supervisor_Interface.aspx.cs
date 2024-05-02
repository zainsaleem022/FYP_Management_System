using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supervisor_Interface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Unnamed4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Faculty.aspx");
    }

    protected void Unnamed3_Click(object sender, EventArgs e)
    {
        Response.Redirect("supervisor_add_fyp_to_supervision.aspx");
    }
}