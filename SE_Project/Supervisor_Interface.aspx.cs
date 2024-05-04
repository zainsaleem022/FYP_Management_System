﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Supervisor_Interface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Faculty_class committee = (Faculty_class)Session["faculty_user"];
        Label2.Text = committee.Name;
        Label4.Text = committee.Email;
        Label3.Text = committee.getId();
    }


    protected void Unnamed4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Faculty.aspx");
    }

    protected void Unnamed3_Click(object sender, EventArgs e)
    {
        Response.Redirect("supervisor_add_fyp_to_supervision.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("supervisor_view_Evaluation.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("supervisor_view_feedback.aspx");
    }
}