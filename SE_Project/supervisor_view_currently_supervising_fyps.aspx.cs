using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class supervisor_view_currently_supervising_fyps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the session variable for Faculty exists
        if (Session["faculty_user"] != null)
        {
            // Get the Faculty object from the session
            Faculty_class faculty = Session["faculty_user"] as Faculty_class;

            // Get the supervisor ID
            string supervisor_id = faculty.getId();

            // Retrieve project information from the database based on the supervisor ID
            string query = @"
            SELECT 
                f.id AS fyp_id,
                f.fyp_title,
                f.fyp_description,
                (
                    SELECT STRING_AGG(s.student_name, ', ')
                    FROM (
                        SELECT DISTINCT student_name
                        FROM fyp_group fg
                        JOIN Student s ON fg.student_id = s.student_id
                        WHERE fg.fyp_id = f.id
                    ) s
                ) AS group_member_names,
                (
                    SELECT 
                        CASE 
                            WHEN EXISTS (
                                SELECT 1 
                                FROM fyp_panel fp 
                                JOIN panel p ON fp.panel_id = p.id 
                                WHERE fp.fyp_id = f.id
                            ) 
                            THEN STRING_AGG(f1.faculty_name, ', ')
                            ELSE 'PANEL NOT ASSIGNED YET'
                        END
                    FROM (
                        SELECT DISTINCT faculty_name
                        FROM fyp_panel fp
                        JOIN panel p ON fp.panel_id = p.id
                        JOIN faculty f1 ON p.panel_member_1_id = f1.id OR p.panel_member_2_id = f1.id OR p.panel_member_3_id = f1.id OR p.panel_member_4_id = f1.id OR p.panel_member_5_id = f1.id
                        WHERE fp.fyp_id = f.id
                    ) f1
                ) AS panel_member_names
            FROM 
                fyp f
            WHERE 
                f.id IN (SELECT fyp_id FROM fyp_supervisor WHERE supervisor_id = @supervisor_id)";


            // Use the dbhandler instance to execute the query
            dbhandler dbHandler = dbhandler.Instance;
            

            using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
            {
                // Add parameter for supervisor ID
                command.Parameters.AddWithValue("@supervisor_id", supervisor_id);

                try
                {
                    // Open the database connection if not already open
                    if (dbHandler.connection.State != ConnectionState.Open)
                    {
                        dbHandler.connection.Open();
                    }

                    // Execute the query
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
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
                        no_fyps_found_as_currently_supervisioning_label.Text = "Currently, No FYPs are under your Supervision";
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
        else
        {
            // Faculty session variable not found
            // You can redirect the user or display an error message
            Response.Write("<script>alert('Faculty user not found');</script>");
        }
    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Supervisor_Interface.aspx");
    }
}