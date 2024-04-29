using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_interface : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = (User)Session["User"];

        // Create a Student object using the User object and additional student details
        Student student = new Student(user.getId(), user.getPassword(),user.getRole());
        Console.WriteLine("StudentName: " + student.StudentName);
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {

    }
}