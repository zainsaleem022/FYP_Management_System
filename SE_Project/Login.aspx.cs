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

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string password = TextBox2.Text;

        // Access the singleton instance of dbhandler

        User myUser = new User(id, password);
        

        // call the login function to validate the user credentials
        int loggedin = myUser.Login(id, password);

        if (loggedin == 1)
        {
            // redirect the user to the dashboard upon successful login
            Session["User"] = myUser;
            Response.Redirect("Faculty.aspx");
        }
        else if (loggedin == 2)
        {
            Session["User"] = myUser;
            Response.Redirect("student_interface.aspx");
        }

        else
        {
            // display an error message if the login is unsuccessful
            Response.Write("<script>alert('invalid username or password');</script>");
        }
    }




}