using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class get_fyp_details_from_student : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_interface.aspx");
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        // Access the input values from the ASPX page controls
        string projectTitle = Text1.Text.Trim(); // Assuming Text1 is the ID of the input for project title
        string projectDescription = TextArea1.Text.Trim(); // Assuming TextArea1 is the ID of the textarea for project description
        string projectDetails = TextArea2.Text.Trim(); // Assuming TextArea2 is the ID of the textarea for project details

        // Check if any of the input fields are empty
        if (string.IsNullOrEmpty(projectTitle) || string.IsNullOrEmpty(projectDescription) || string.IsNullOrEmpty(projectDetails))
        {
            // Alert the user to fill all the fields
            Response.Write("<script>alert('Please fill all the fields');</script>");
            return; // Exit the function to prevent further execution
        }

        // Get the student's group ID from the session
        Student student = (Student)Session["Student"];
        int studentGroupId = student.GroupId;

        // Get the dbhandler instance
        dbhandler dbHandler = dbhandler.Instance;

        // Check if the project title in the fyp table is null or empty string
        string queryCheck = "SELECT fyp_title FROM fyp WHERE id = @id";

        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, dbHandler.connection))
        {
            cmdCheck.Parameters.AddWithValue("@id", studentGroupId);

            try
            {
                // Open the connection
                dbHandler.connection.Open();

                // Execute the query
                object result = cmdCheck.ExecuteScalar();

                if (result == null || string.IsNullOrEmpty(result.ToString()))
                {
                    // Project title is null or empty, allow the update query to run
                    // Update the existing record in the fyp table in the database
                    string updateQuery = "UPDATE fyp SET fyp_title = @title, fyp_description = @description, details = @details WHERE id = @id";

                    // Execute the query using dbhandler's connection
                    using (SqlCommand command = new SqlCommand(updateQuery, dbHandler.connection))
                    {
                        command.Parameters.AddWithValue("@id", studentGroupId);
                        command.Parameters.AddWithValue("@title", projectTitle);
                        command.Parameters.AddWithValue("@description", projectDescription);
                        command.Parameters.AddWithValue("@details", projectDetails);

                        // Execute the command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the update was successful
                        if (rowsAffected > 0)
                        {
                            // Update successful
                            Response.Write("<script>alert('FYP details updated successfully');</script>");
                        }
                        else
                        {
                            // No record found to update
                            Response.Write("<script>alert('No FYP record found for the given ID');</script>");
                        }
                    }
                }
                else
                {
                    // Project title is not null or empty, display error message
                    Response.Write("<script>alert('Cannot update FYP details because project title already exists');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Response.Write("<script>alert('An error occurred while updating FYP details');</script>");
            }
            finally
            {
                // Close the connection
                dbHandler.connection.Close();
            }
        }
    }




}