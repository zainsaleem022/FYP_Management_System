using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{
    private string _id;
    private string _password;
    private string _role;
    public User()
    {
        _id = "";
        _password = "";
        _role = "";
    }
    public User(string id, string pwd)
    {
        _id = id;
        _password = pwd;
        _role = "";
    }

    public User(string id, string pwd, string r)
    {
        _id = id;
        _password = pwd;
        _role = r;
    }
    public void setRole(string role) { 
        _role = role;
    }

    public string getRole() { return _role; }
    public string getId() { return _id; }
    public string getPassword() { return _password;}

    public int Login(string id, string password)
    {
        _id = id;
        _password = password;
        // Access the singleton instance of dbhandler
        dbhandler dbhandler = dbhandler.Instance;

        // call the login function to validate the user credentials
        int loggedin = dbhandler.login(id, password, ref _role);
        return loggedin;
    }
}