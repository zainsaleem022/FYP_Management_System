using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_project_details_form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the session variable for Student exists
        if (Session["Student"] != null)
        {
            // Get the student object from the session
            Student student = (Student)Session["Student"];

            // Get the FYP group ID associated with the student
            int studentGroupId = student.GroupId;

            // Retrieve project information from the database based on the FYP group ID
            dbhandler dbHandler = dbhandler.Instance;

            // Query to fetch project information
            string query = "SELECT * FROM fyp WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
            {
                // Add parameters to the command
                command.Parameters.AddWithValue("@id", studentGroupId);

                try
                {
                    // Open the database connection if not already open
                    if (dbHandler.connection.State != ConnectionState.Open)
                    {
                        dbHandler.connection.Open();
                    }

                    // Execute the query
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if any data is retrieved
                    if (reader.Read())
                    {
                        // Display project information in the corresponding labels
                        title_from_db_label.Text = reader["fyp_title"].ToString();
                        description_from_db_label.Text = reader["fyp_description"].ToString();
                        details_from_db_label.Text = reader["details"].ToString();
                    }
                    else
                    {
                        // No project information found for the FYP group ID
                        // You can display a message or handle it as per your requirement
                        Response.Write("<script>alert('No FYP information found');</script>");
                    }

                    // Close the data reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    // You can display an error message or log the exception
                    Response.Write("<script>alert('No FYP information found');</script>");
                }
                finally
                {
                    // Close the connection after use
                    dbHandler.connection.Close();
                }
            }
        }
        else
        {
            // Student session variable not found
            // You can redirect the user or display an error message
            Response.Write("<script>alert('Student user not found');</script>");
        }
    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_interface.aspx");
    }
}