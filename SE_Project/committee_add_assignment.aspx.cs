using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class committee_add_assignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Committee.aspx");
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        // Get the input values
        string assignmentId = TextBox1.Text;
        string title = TextBox2.Text;
        string description = TextBox3.Text;
        DateTime deadline = txtDeadline.SelectedDate;

        // Check if any field is empty
        if (string.IsNullOrEmpty(assignmentId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || deadline == DateTime.MinValue)
        {
            // Show alert for empty fields
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please fill in all fields.');", true);
            return;
        }

        // Check if assignment ID already exists
        if (IsAssignmentIdExists(assignmentId))
        {
            // Show alert for duplicate assignment ID
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Assignment ID already exists.');", true);
            return;
        }

        // Create the SQL query
        string query = "INSERT INTO Assignment (id, title, description, deadline) VALUES (@id, @title, @description, @deadline)";

        // Instantiate the DBHandler
        dbhandler dbHandler = dbhandler.Instance;

        // Create the command object
        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            // Add parameters
            command.Parameters.AddWithValue("@id", assignmentId);
            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@description", description);
            command.Parameters.AddWithValue("@deadline", deadline);

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if the insertion was successful
                if (rowsAffected > 0)
                {
                    // Show success message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Assignment inserted successfully.');", true);

                    // Clear the input fields
                    TextBox1.Text = string.Empty;
                    TextBox2.Text = string.Empty;
                    TextBox3.Text = string.Empty;
                    txtDeadline.SelectedDate = DateTime.Today;
                }
                else
                {
                    // Show error message
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to insert assignment.');", true);
                }
            }
            catch (Exception ex)
            {
                // Show error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
            }
            finally
            {
                // Close the connection
                dbHandler.connection.Close();
            }
        }
    }



    // Function to check if assignment ID already exists in the table
    private bool IsAssignmentIdExists(string assignmentId)
    {
        // SQL query to check if assignment ID exists
        string query = "SELECT COUNT(*) FROM Assignment WHERE id = @id";

        // Instantiate the DBHandler
        dbhandler dbHandler = dbhandler.Instance;

        // Create the command object
        using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
        {
            // Add parameter
            command.Parameters.AddWithValue("@id", assignmentId);

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query and get the count
                int count = Convert.ToInt32(command.ExecuteScalar());

                // Return true if count > 0 (assignment ID exists), otherwise false
                return count > 0;
            }
            catch (Exception ex)
            {
                // Show error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error: " + ex.Message + "');", true);
                return false; // Return false in case of error
            }
            finally
            {
                // Close the connection
                dbHandler.connection.Close();
            }
        }
    }
}