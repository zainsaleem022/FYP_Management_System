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
        string role = DropDownList1.Text;
        User myUser = new User(id,password,role);


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");

    }
}