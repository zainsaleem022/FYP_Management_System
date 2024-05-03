using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_member_view_currently_assigned_fyps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get the panel member ID
            Faculty_class faculty = Session["faculty_user"] as Faculty_class;
            string panel_member_id = faculty.getId();

            // Prepare the query
            string query = @"
            SELECT 
                f.id AS fyp_id,
                f.fyp_title,
                f.fyp_description,
                (
                    SELECT STRING_AGG(s.student_name, ', ')
                    FROM fyp_group fg
                    JOIN Student s ON fg.student_id = s.student_id
                    WHERE fg.fyp_id = f.id
                ) AS group_member_names,
                COALESCE(fac.faculty_name, 'Not Assigned') AS supervisor_name,
                (
                    SELECT STRING_AGG(f1.faculty_name, ', ')
                    FROM panel p
                    JOIN faculty f1 ON 
                        f1.id = p.panel_member_1_id OR
                        f1.id = p.panel_member_2_id OR
                        f1.id = p.panel_member_3_id OR
                        f1.id = p.panel_member_4_id OR
                        f1.id = p.panel_member_5_id
                    WHERE 
                        p.id = fp.panel_id
                ) AS panel_member_names
            FROM 
                fyp f
            LEFT JOIN 
                fyp_supervisor fs ON f.id = fs.fyp_id
            LEFT JOIN 
                faculty fac ON fs.supervisor_id = fac.id
            LEFT JOIN 
                fyp_panel fp ON f.id = fp.fyp_id
            WHERE 
                f.id IN (
                    SELECT fyp_id FROM fyp_panel 
                    WHERE panel_id = (
                        SELECT id FROM panel 
                        WHERE panel_member_1_id = @panel_member_id OR 
                              panel_member_2_id = @panel_member_id OR 
                              panel_member_3_id = @panel_member_id OR 
                              panel_member_4_id = @panel_member_id OR 
                              panel_member_5_id = @panel_member_id
                    )
                )";

            // Create a new DB handler instance
            dbhandler dbHandler = dbhandler.Instance;

            try
            {
                // Open the database connection
                dbHandler.connection.Open();

                // Prepare the command
                SqlCommand command = new SqlCommand(query, dbHandler.connection);

                // Add parameter for panel member ID
                command.Parameters.AddWithValue("@panel_member_id", panel_member_id);

                // Execute the query and retrieve the results
                SqlDataReader reader = command.ExecuteReader();

                // Check if there are rows returned
                if (reader.HasRows)
                {
                    // Bind the data to the GridView
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
                else
                {
                    // No data found
                    Response.Write("<script>alert('No FYP information found');</script>");
                }

                // Close the reader
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle the exception
                Response.Write("<script>alert('Error fetching FYP information');</script>");
            }
            finally
            {
                // Close the database connection
                dbHandler.connection.Close();
            }
        }
    }


    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Panel_Interface.aspx");
    }
}