using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string password = TextBox2.Text;
        string group = TextBox3.Text;
        string name = TextBox4.Text;
        string email = id + "@abc.pk";
        // Access the singleton instance of dbhandler
        dbhandler dbhandler = dbhandler.Instance;

        // Call the RegisterStudent method using the singleton instance
        int regVal = dbhandler.RegisterStudent(id, password, group,name,email);

        // Handle the registration result
        if (regVal == 1)
        {
            Response.Write("<script>alert('Student Registered');</script>");
        }
        else if (regVal == -1)
        {
            Response.Write("<script>alert('ID exists');</script>");
        }
        else if (regVal == 2)
        {
            Response.Write("<script>alert('3 members already in group');</script>");
        }
    }

}