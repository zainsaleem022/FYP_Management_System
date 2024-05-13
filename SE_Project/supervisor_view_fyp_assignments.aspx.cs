using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class supervisor_view_fyp_assignments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Retrieve the faculty object from the session
        Faculty_class faculty = Session["faculty_user"] as Faculty_class;

        // Get the supervisor ID
        string supervisor_id = faculty.getId();

        // Create the SQL query
        string query = @"
                SELECT 
                    f.fyp_title AS [FYP Title],
                    a.title AS [Assignment Title],
                    a.deadline AS [Assignment Deadline],
                    STRING_AGG(s.student_name, ', ') AS [Student Name]
                FROM 
                    fyp f
                INNER JOIN 
                    fyp_group fg ON f.id = fg.fyp_id
                INNER JOIN 
                    Student s ON fg.student_id = s.student_id
                INNER JOIN 
                    fyp_supervisor fs ON f.id = fs.fyp_id
                LEFT JOIN 
                    Assignment a ON 1 = 1
                WHERE 
                    NOT EXISTS (
                        SELECT 1 
                        FROM Assignment_Submission ass 
                        WHERE ass.assignment_id = a.id AND ass.fyp_group_id = fg.fyp_id
                    )
                    AND fs.supervisor_id = @supervisor_id
                GROUP BY 
                    f.fyp_title, a.title, a.deadline;";


        // Get the dbhandler instance
        dbhandler dbHandler = dbhandler.Instance;

        try
        {
            // Open the database connection
            dbHandler.connection.Open();

            // Create a SqlCommand
            SqlCommand command = new SqlCommand(query, dbHandler.connection);
            command.Parameters.AddWithValue("@supervisor_id", supervisor_id);

            // Execute the query
            SqlDataReader reader = command.ExecuteReader();

            // Check if there are rows returned
            if (reader.HasRows)
            {
                // Create a DataTable to hold the results
                DataTable dataTable = new DataTable();

                // Load the DataTable with the results from the reader
                dataTable.Load(reader);

                // Bind the DataTable to the GridView
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            else
            {
                // No rows returned, show a message or take appropriate action
                supervisor_no_assignments_found_label.Text = "No Assingments are Currently Due";
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
            // For example:
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error Occurred: {ex.Message}');", true);

        }
        finally
        {
            // Close the database connection
            dbHandler.connection.Close();
        }
    }



    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Supervisor_Interface.aspx");
    }
}