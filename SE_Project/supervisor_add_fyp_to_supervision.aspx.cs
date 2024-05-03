using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class supervisor_add_fyp_to_supervision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Retrieve the data using the query
            string query = @"
            SELECT
                f.id AS fyp_id,
                f.fyp_title,
                f.fyp_description,
                STRING_AGG(s.student_name, ', ') AS group_members
            FROM
                fyp f
            JOIN
                fyp_group fg ON f.id = fg.fyp_id
            JOIN
                Student s ON fg.student_id = s.student_id
            LEFT JOIN
                fyp_supervisor fs ON f.id = fs.fyp_id
            WHERE
                fs.fyp_id IS NULL
            GROUP BY
                f.id, f.fyp_title, f.fyp_description";

            dbhandler dbHandler = dbhandler.Instance;

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(query, dbHandler.connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Check if there are rows returned
                if (table.Rows.Count > 0)
                {
                    // Bind the DataTable to a GridView
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
                else
                {
                    // No FYPs found
                    //Response.Write("<script>alert('No FYPs found');</script>");
                    no_fyps_available_hidden_label.Text = ("No Available FYPs Found for Supervision");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                // You can display an error message or log the exception
                Response.Write("<script>alert('Error fetching FYPs');</script>");
            }
            finally
            {
                // Close the connection after use
                dbHandler.connection.Close();
            }
        }
    }


    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        // Get the fyp_id to supervise from the TextBox
        int fyp_to_supervise = int.Parse(TextBox1.Text);

        // Retrieve the faculty object from the session
        Faculty_class faculty = Session["faculty_user"] as Faculty_class;

        // Get the supervisor ID
        string supervisor_id = faculty.getId();


        if (IsFypAssigned(fyp_to_supervise))
        {
            // If already assigned, show an error alert
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This FYP is already assigned to a supervisor.');", true);
            return; // Exit the function
        }

        // Check if the supervisor is already supervising 6 fyps
        int currentSupervisedFyps = GetCurrentSupervisedFypsCount(supervisor_id);

        if (currentSupervisedFyps >= 6)
        {
            // If the supervisor is already supervising 6 fyps, show an error alert
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are already supervising 6 FYPs. You cannot supervise more.');", true);
        }
        else
        {
            // If the supervisor can supervise more fyps, proceed to assign the new fyp
            AssignFypToSupervisor(fyp_to_supervise, supervisor_id);
            Response.Write("<script>alert('FYP Assigned for your Supervision Successfully'); window.location.href = window.location.href;</script>");
        }
    }




    // Function to get the current count of fyps supervised by a supervisor
    private int GetCurrentSupervisedFypsCount(string supervisor_id)
    {
        int count = 0;

        // Query to count the number of fyps supervised by the given supervisor
        string countQuery = "SELECT COUNT(*) FROM fyp_supervisor WHERE supervisor_id = @supervisor_id";

        // Use the dbhandler instance to execute the query
        using (SqlCommand command = new SqlCommand(countQuery, dbhandler.Instance.connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@supervisor_id", supervisor_id);

            try
            {
                // Open the connection and execute the command
                dbhandler.Instance.connection.Open();
                count = (int)command.ExecuteScalar();
            }
            finally
            {
                // Ensure the connection is closed after use
                dbhandler.Instance.connection.Close();
            }
        }

        return count;
    }


    private bool IsFypAssigned(int fyp_id)
    {
        bool isAssigned = false;

        // Query to check if the FYP ID is already assigned to a supervisor
        string checkQuery = "SELECT COUNT(*) FROM fyp_supervisor WHERE fyp_id = @fyp_id";

        // Use the dbhandler instance to execute the query
        using (SqlCommand command = new SqlCommand(checkQuery, dbhandler.Instance.connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@fyp_id", fyp_id);

            try
            {
                // Open the connection and execute the command
                dbhandler.Instance.connection.Open();
                int count = (int)command.ExecuteScalar();

                // If the count is greater than 0, the FYP is already assigned
                isAssigned = count > 0;
            }
            finally
            {
                // Ensure the connection is closed after use
                dbhandler.Instance.connection.Close();
            }
        }

        return isAssigned;
    }

    // Function to assign a new fyp to a supervisor
    private void AssignFypToSupervisor(int fyp_id, string supervisor_id)
    {
        // Query to insert the fyp-supervisor relationship into the database
        string insertQuery = "INSERT INTO fyp_supervisor (fyp_id, supervisor_id) VALUES (@fyp_id, @supervisor_id)";

        // Use the dbhandler instance to execute the query
        using (SqlCommand command = new SqlCommand(insertQuery, dbhandler.Instance.connection))
        {
            // Add parameters to the command
            command.Parameters.AddWithValue("@fyp_id", fyp_id);
            command.Parameters.AddWithValue("@supervisor_id", supervisor_id);

            try
            {
                // Open the connection and execute the command
                dbhandler.Instance.connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // If the insertion is successful, show a success alert
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('FYP assigned to supervisor successfully.');", true);
                }
                else
                {
                    // If the insertion fails, show an error alert
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed to assign FYP to supervisor.');", true);
                }
            }
            finally
            {
                // Ensure the connection is closed after use
                dbhandler.Instance.connection.Close();
            }
        }
    }



    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Supervisor_Interface.aspx");
    }
}