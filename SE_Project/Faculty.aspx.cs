﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Faculty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = (User)Session["User"];

        // Create a Student object using the User object and additional student details
        Faculty_class faculty = new Faculty_class(user.getId(), user.getPassword(), user.getRole());
        Session["faculty_user"] = faculty;
        Response.Write("<script>" + faculty.Name + ";</script>");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
        //Response.Write("<script>alert('Name: " + faculty.Name + "\\n" +
        //                      "Email: " + faculty.Email + "\\n" +
        //                      "Supervisor Role: " + faculty.supervisor_role.ToString() + "\\n" +
        //                      "Panel Role: " + faculty.panel_role.ToString() + "\\n" +
        //                      "Committee Role: " + faculty.committee_role.ToString() + "');</script>");



        if (faculty.committee_role == 1)
        {
            Response.Redirect("Committee.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error');</script>");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
        //Response.Write("<script>alert('Name: " + faculty.Name + "\\n" +
        //                      "Email: " + faculty.Email + "\\n" +
        //                      "Supervisor Role: " + faculty.supervisor_role.ToString() + "\\n" +
        //                      "Panel Role: " + faculty.panel_role.ToString() + "\\n" +
        //                      "Committee Role: " + faculty.committee_role.ToString() + "');</script>");



        if (faculty.supervisor_role == 1)
        {
            Response.Redirect("Supervisor.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error');</script>");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Faculty_class faculty = (Faculty_class)Session["faculty_user"];
        //Response.Write("<script>alert('Name: " + faculty.Name + "\\n" +
        //                      "Email: " + faculty.Email + "\\n" +
        //                      "Supervisor Role: " + faculty.supervisor_role.ToString() + "\\n" +
        //                      "Panel Role: " + faculty.panel_role.ToString() + "\\n" +
        //                      "Committee Role: " + faculty.committee_role.ToString() + "');</script>");



        if (faculty.panel_role == 1)
        {
            Response.Redirect("Panel.aspx");
        }
        else
        {
            Response.Write("<script>alert('Error');</script>");
        }
    }
}