using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Panel_Member
/// </summary>
public class Panel_Member:Faculty_class
{

    private int panel;

    private string name;
    private string email;
    public Panel_Member()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Panel_Member(Faculty_class f)
    {

         panel = f.panel_role;
         name = f.Name;
        email = f.Email;

       
    }

    public int panel_role
    {
        get { return panel; }
        set { panel = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DataTable DisplayPanelMembers(int panels)
    {

       dbhandler dbhandler = dbhandler.Instance;
       return dbhandler.DisplayPanel(panels);
    }
}