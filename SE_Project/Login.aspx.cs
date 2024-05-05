using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = TextBox1.Text;
        string password = TextBox2.Text;

        // Validate user ID
        bool isValidId = true;
        if (id.Length != 7)
        {
            isValidId = false;
            Response.Write("<script>alert('Invalid ID length. ID should be exactly 7 characters.');</script>");
        }
        else
        {
            // Check if all characters are alphanumeric
            if (!Regex.IsMatch(id, @"^[a-zA-Z0-9]+$"))
            {
                isValidId = false;
                Response.Write("<script>alert('ID should contain only alphanumeric characters.');</script>");
            }
        }

        // Validate password
        bool isValidPassword = true;
        if (password.Length <= 7)
        {
            isValidPassword = false;
            Response.Write("<script>alert('Invalid password length. Password should be greater than 7 characters.');</script>");
        }
        else
        {
            // Check if all characters are alphanumeric
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                isValidPassword = false;
                Response.Write("<script>alert('Password should contain only alphanumeric characters.');</script>");
            }
        }

        // Proceed with login only if both ID and password are valid
        if (isValidId && isValidPassword)
        {
            User myUser = new User(id, password);

            // Call the login function to validate the user credentials
            int loggedIn = myUser.Login(id, password);

            if (loggedIn == 1)
            {
                // Redirect the user to the dashboard upon successful login
                Session["User"] = myUser;
                Response.Redirect("Faculty.aspx");
            }
            else if (loggedIn == 2)
            {
                Session["User"] = myUser;
                Response.Redirect("student_interface.aspx");
            }
            else
            {
                // Display an error message if the login is unsuccessful
                Response.Write("<script>alert('Invalid username or password');</script>");
            }
        }
    }
}