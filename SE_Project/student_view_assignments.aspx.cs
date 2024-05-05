using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class student_view_assignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the student object from the session
        Student student = (Student)Session["Student"];

        // Get the FYP group ID associated with the student
        int studentGroupId = student.GroupId;

        // SQL query to fetch assignments not submitted by the student's group
        string query = @"
        SELECT 
            a.id AS assignment_id,
            a.title AS assignment_title,
            a.description AS assignment_description,
            a.deadline AS assignment_deadline
        FROM 
            Assignment a
        LEFT JOIN 
            Assignment_Submission s ON a.id = s.assignment_id AND s.fyp_group_id = @studentGroupId
        WHERE 
            s.assignment_id IS NULL";

        // Instantiate the DBHandler
        dbhandler dbHandler = dbhandler.Instance;

        // Create the command object
        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            // Add parameter for student group ID
            command.Parameters.AddWithValue("@studentGroupId", studentGroupId);

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query and get the result into a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Bind the DataTable to a GridView
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Handle the exception
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
            finally
            {
                // Close the connection
                dbHandler.connection.Close();
            }
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        int assignmentId;
        if (!int.TryParse(TextBox1.Text, out assignmentId))
        {
            // Invalid assignment ID
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid assignment ID.');", true);
            return;
        }

        // Check if assignment ID exists in the Assignment table
        if (!IsAssignmentValid(assignmentId))
        {
            // Assignment ID does not exist
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Assignment ID does not exist.');", true);
            return;
        }

        // Check if assignment ID is already submitted by the student
        Student student = (Student)Session["Student"];
        int fypGroupId = student.GroupId;
        if (IsAssignmentSubmitted(assignmentId, fypGroupId))
        {
            // Assignment already submitted
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Assignment already submitted.');", true);
            return;
        }

        // Check if submission text or file is provided
        string submissionText = TextBox2.Text; // Assuming TextBox2 contains submission text
        if (string.IsNullOrEmpty(submissionText) && !FileUpload1.HasFile)
        {
            // Neither submission text nor file is provided
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please provide submission text or upload a file.');", true);
            return;
        }

        // Proceed with submission

        // Get the file details
        string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
        string fileUploadPath = "Uploads/"; // Specify the upload directory

        // Check if file is uploaded
        if (FileUpload1.HasFile)
        {
            // Save the file to the server
            string filePath = Server.MapPath(fileUploadPath) + fileName;
            FileUpload1.SaveAs(filePath);
            fileUploadPath += fileName; // Save the file path
        }
        else
        {
            fileUploadPath = "Not File Attached";
        }

        // Insert into the submission table
        string query = @"INSERT INTO Assignment_Submission (assignment_id, fyp_group_id, submission_text, submission_file_path, submission_date)
                 VALUES (@assignmentId, @fypGroupId, @submissionText, @submissionFilePath, GETDATE())";

        dbhandler dbHandler = dbhandler.Instance;
        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            // Add parameters
            command.Parameters.AddWithValue("@assignmentId", assignmentId);
            command.Parameters.AddWithValue("@fypGroupId", fypGroupId);
            command.Parameters.AddWithValue("@submissionText", submissionText);
            command.Parameters.AddWithValue("@submissionFilePath", fileUploadPath);

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if insertion was successful
                if (rowsAffected > 0)
                {
                    // Show success message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Assignment submitted successfully.'); window.location.href = window.location.href;", true);
                }
                else
                {
                    // Show error message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to submit assignment.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error submitting assignment.');", true);
            }
            finally
            {
                // Close the connection after use
                dbHandler.connection.Close();
            }
        }
    }



    // Function to check if the assignment ID exists in the Assignment table
    private bool IsAssignmentValid(int assignmentId)
    {
        string query = "SELECT COUNT(*) FROM Assignment WHERE id = @assignmentId";
        dbhandler dbHandler = dbhandler.Instance;

        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            command.Parameters.AddWithValue("@assignmentId", assignmentId);

            try
            {
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                int count = (int)command.ExecuteScalar();
                return count > 0; // If count is greater than 0, assignment ID exists
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
            finally
            {
                dbHandler.connection.Close();
            }
        }
    }

    // Function to check if the assignment ID is already submitted by the student
    private bool IsAssignmentSubmitted(int assignmentId, int fypGroupId)
    {
        string query = "SELECT COUNT(*) FROM Assignment_Submission WHERE assignment_id = @assignmentId AND fyp_group_id = @fypGroupId";
        dbhandler dbHandler = dbhandler.Instance;

        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            command.Parameters.AddWithValue("@assignmentId", assignmentId);
            command.Parameters.AddWithValue("@fypGroupId", fypGroupId);

            try
            {
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                int count = (int)command.ExecuteScalar();
                return count > 0; // If count is greater than 0, assignment is already submitted
            }
            catch (Exception ex)
            {
                // Handle exception
                return false;
            }
            finally
            {
                dbHandler.connection.Close();
            }
        }
    }




    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_interface.aspx");
    }
}