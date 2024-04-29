using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Faculty_class:User
{
    private int supervisor;
    private int panel;
    private int committee;
    private string name;
    private string email;
    public Faculty_class()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Faculty_class(string id, string pwd, string role)
        : base(id, pwd, role)
    {
        supervisor = 0;
        panel = 0;
        committee = 0;
        name = "";
        email = string.Empty;
        dbhandler dbhandler = dbhandler.Instance;
        dbhandler.findFaculty(id,ref committee, ref panel, ref supervisor, ref email, ref name);
    }
    public int supervisor_role
    {
        get { return supervisor; }
        set { supervisor = value; }
    }

    public int panel_role
    {
        get { return panel; }
        set { panel = value; }
    }
    public int committee_role
    {
        get {return committee;}
        set { committee = value;}
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
}