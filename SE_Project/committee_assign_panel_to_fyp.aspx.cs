using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class committee_assign_panel_to_fyp : System.Web.UI.Page
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
                fyp_panel fp ON f.id = fp.fyp_id
            WHERE
                fp.fyp_id IS NULL
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




    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Committee.aspx");
    }


    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        // Retrieve the FYP ID and Panel ID entered by the user
        int fypId, panelId;
        if (!int.TryParse(TextBox1.Text, out fypId) || !int.TryParse(TextBox2.Text, out panelId))
        {
            // Invalid input for FYP ID or Panel ID
            Response.Write("<script>alert('Please enter valid FYP ID and Panel ID');</script>");
            return;
        }

        // Check if the FYP ID exists
        dbhandler dbHandler = dbhandler.Instance;
        string checkFypQuery = "SELECT COUNT(*) FROM fyp WHERE id = @fypId";
        SqlCommand checkFypCommand = new SqlCommand(checkFypQuery, dbHandler.connection);
        checkFypCommand.Parameters.AddWithValue("@fypId", fypId);

        try
        {
            dbHandler.connection.Open();
            int fypCount = (int)checkFypCommand.ExecuteScalar();
            if (fypCount == 0)
            {
                // FYP ID does not exist
                Response.Write("<script>alert('FYP ID does not exist');</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Response.Write("<script>alert('Error checking FYP ID');</script>");
            return;
        }
        finally
        {
            dbHandler.connection.Close();
        }

        // Check if the FYP ID is already assigned to a panel
        string checkAssignmentQuery = "SELECT COUNT(*) FROM fyp_panel WHERE fyp_id = @fypId";
        SqlCommand checkAssignmentCommand = new SqlCommand(checkAssignmentQuery, dbHandler.connection);
        checkAssignmentCommand.Parameters.AddWithValue("@fypId", fypId);

        try
        {
            dbHandler.connection.Open();
            int assignmentCount = (int)checkAssignmentCommand.ExecuteScalar();
            if (assignmentCount > 0)
            {
                // FYP ID is already assigned to a panel
                Response.Write("<script>alert('FYP ID is already assigned to a panel');</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Response.Write("<script>alert('Error checking assignment');</script>");
            return;
        }
        finally
        {
            dbHandler.connection.Close();
        }

        // Check if the Panel ID exists
        string checkPanelQuery = "SELECT COUNT(*) FROM panel WHERE id = @panelId";
        SqlCommand checkPanelCommand = new SqlCommand(checkPanelQuery, dbHandler.connection);
        checkPanelCommand.Parameters.AddWithValue("@panelId", panelId);

        try
        {
            dbHandler.connection.Open();
            int panelCount = (int)checkPanelCommand.ExecuteScalar();
            if (panelCount == 0)
            {
                // Panel ID does not exist
                Response.Write("<script>alert('Panel ID does not exist');</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Response.Write("<script>alert('Error checking Panel ID');</script>");
            return;
        }
        finally
        {
            dbHandler.connection.Close();
        }

        // Insert the FYP ID and Panel ID into the fyp_panel table
        string insertQuery = "INSERT INTO fyp_panel (fyp_id, panel_id) VALUES (@fypId, @panelId)";
        SqlCommand insertCommand = new SqlCommand(insertQuery, dbHandler.connection);
        insertCommand.Parameters.AddWithValue("@fypId", fypId);
        insertCommand.Parameters.AddWithValue("@panelId", panelId);

        try
        {
            dbHandler.connection.Open();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Successful insertion
                Response.Write("<script>alert('FYP assigned to panel successfully'); window.location.href = window.location.href;</script>");
            }
            else
            {
                // Insertion failed
                Response.Write("<script>alert('Failed to assign FYP to panel');</script>");
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Response.Write("<script>alert('Error assigning FYP to panel');</script>");
        }
        finally
        {
            dbHandler.connection.Close();
        }

    }
}