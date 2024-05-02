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
        string id1 = TextBox1.Text;
        string password1 = TextBox2.Text;
        string name1 = TextBox3.Text;
        string email1 = id1 + "@abc.pk";
        dbhandler dbhandler = dbhandler.Instance;
        int status =dbhandler.RegisterFaculty(id1, password1, name1, email1);
        if (status == 0) { Response.Write("<script>alert('Registration failed');</script>"); }
        else if (status == 1) { Response.Write("<script>alert('Faculty Registration Successfull');</script>"); }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");

    }
}