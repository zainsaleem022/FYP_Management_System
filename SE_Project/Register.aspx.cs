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


        string panel = "", supervisor = "", committee="";

        // Loop through the CheckBoxList items

        // Loop through the CheckBoxList items
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            ListItem item = CheckBoxList1.Items[i];

            // Check if the item is selected
            if (item.Selected)
            {
                string value = "";
                value= item.Value;

                // Assign the value to the corresponding variable based on the index
                switch (i)
                {
                    case 0:
                        panel = value;
                        break;
                    case 1:
                        supervisor = value;
                        break;
                    case 2:
                        committee = value;
                        break;
                }
            }
        }
        int p = 0, s= 0, c = 0;
        if (panel == "Panel")
            p = 1;
        if (supervisor == "Supervisor")
            s = 1;
        if ((committee == "Committee"))
            c = 1;
        string id1 = TextBox1.Text;
        string password1 = TextBox2.Text;
        string name1 = TextBox3.Text;
        string email1 = id1 + "@abc.pk";
        dbhandler dbhandler = dbhandler.Instance;
        int status =dbhandler.RegisterFaculty(id1, password1, name1, email1,p,s,c);
        if (status == 0) { Response.Write("<script>alert('Registration failed');</script>"); }
        else if (status == 1) { Response.Write("<script>alert('Faculty Registration Successfull');</script>"); }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");

    }
}