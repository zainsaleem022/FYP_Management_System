using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class RegisterStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int group;
        if (int.TryParse(TextBox3.Text, out group))
        {
            dbhandler dbhandler = dbhandler.Instance;
            List<(string id, string password, string name, string email)> students = new List<(string id, string password, string name, string email)>();

            // Add Student 1
            string id1 = TextBox1.Text;
            string password1 = TextBox2.Text;
            string name1 = TextBox4.Text;

            string validationErrorMessage = ValidateInput(id1, password1, name1);
            if (validationErrorMessage == string.Empty)
            {
                string email1 = id1 + "@abc.pk";
                students.Add((id1, password1, name1, email1));
            }
            else
            {
                Response.Write("<script>alert('" + validationErrorMessage + "');</script>");
                return; // Stop further processing if input for Student 1 is invalid
            }

            // Add Student 2
            string id2 = TextBox5.Text;
            string password2 = TextBox6.Text;
            string name2 = TextBox7.Text;

            validationErrorMessage = ValidateInput(id2, password2, name2);
            if (validationErrorMessage == string.Empty)
            {
                string email2 = id2 + "@abc.pk";
                students.Add((id2, password2, name2, email2));
            }
            else
            {
                Response.Write("<script>alert('" + validationErrorMessage + "');</script>");
            }

            // Add Student 3 if the textboxes are not empty
            if (!string.IsNullOrEmpty(TextBox8.Text) && !string.IsNullOrEmpty(TextBox9.Text) && !string.IsNullOrEmpty(TextBox10.Text))
            {
                string id3 = TextBox8.Text;
                string password3 = TextBox9.Text;
                string name3 = TextBox10.Text;

                validationErrorMessage = ValidateInput(id3, password3, name3);
                if (validationErrorMessage == string.Empty)
                {
                    string email3 = id3 + "@abc.pk";
                    students.Add((id3, password3, name3, email3));
                }
                else
                {
                    Response.Write("<script>alert('" + validationErrorMessage + "');</script>");
                }
            }

            // Check if no student data is entered
            if (students.Count == 0)
            {
                Response.Write("<script>alert('Please enter data for at least one student.');</script>");
                return;
            }

            // Check for minimum and maximum number of members
            int memberCount = students.Count;
            if (memberCount < 2)
            {
                Response.Write("<script>alert('A group must have at least 2 members');</script>");
                return;
            }
            else if (memberCount > 3)
            {
                Response.Write("<script>alert('A group cannot have more than 3 members');</script>");
                return;
            }

            // Perform validations and registration
            int registeredCount = dbhandler.RegisterStudents(group, students);

            // Handle the registration result
            if (registeredCount == students.Count)
            {
                Response.Write("<script>alert('Students Registered');</script>");
            }
            else
            {
                Response.Write("<script>alert('Registration failed');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid group ID');</script>");
        }
    }

    string ValidateInput(string id, string password, string name)
    {
        // Validate ID
        if (id.Length != 7)
        {
            return "Invalid ID length. ID should be exactly 7 characters.";
        }
        else if (!Regex.IsMatch(id, @"^[a-zA-Z0-9]+$"))
        {
            return "ID should contain only alphanumeric characters.";
        }

        // Validate Password
        if (password.Length <= 7)
        {
            return "Invalid password length. Password should be greater than 7 characters.";
        }
        else if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
        {
            return "Password should contain only alphanumeric characters.";
        }

        // Validate Name
        if (name.Length <= 4)
        {
            return "Invalid name length. Name should be greater than 4 characters.";
        }
        else if (!Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
        {
            return "Name should contain only alphabetic characters and spaces.";
        }

        return string.Empty; // Input is valid
    }
}