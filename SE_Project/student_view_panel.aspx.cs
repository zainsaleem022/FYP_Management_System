using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_view_panel : System.Web.UI.Page
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

            // Construct the query
            string query = @"
            SELECT 
                p.id AS panel_id, 
                f.faculty_name,
                f.email 
            FROM 
                fyp_panel fp
            JOIN 
                panel p ON fp.panel_id = p.id
            JOIN 
                faculty f ON 
                    f.id = p.panel_member_1_id OR 
                    f.id = p.panel_member_2_id OR 
                    f.id = p.panel_member_3_id OR 
                    f.id = p.panel_member_4_id OR 
                    f.id = p.panel_member_5_id
            WHERE 
                fp.fyp_id = @fyp_id";

            // Create a new instance of the dbhandler
            dbhandler dbHandler = dbhandler.Instance;

            try
            {
                // Open the database connection if not already open
                if (dbHandler.connection.State != ConnectionState.Open)
                {
                    dbHandler.connection.Open();
                }

                // Execute the query
                using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
                {
                    // Add parameter for fyp_id
                    command.Parameters.AddWithValue("@fyp_id", studentGroupId);

                    // Create a DataTable to store the result
                    DataTable dt = new DataTable();

                    // Fill the DataTable with the query result
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }

                    // Check if there are rows returned
                    if (dt.Rows.Count > 0)
                    {
                        // Bind the DataTable to a GridView (assuming you're using a GridView to display the result)
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        panel_member_exists_label.Text = "Panel is not assigned to your FYP yet";
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                // You can display an error message or log the exception
                Response.Write("<script>alert('Error fetching panel members');</script>");
            }
            finally
            {
                // Close the connection after use
                dbHandler.connection.Close();
            }
        }
        else
        {
            Response.Write("<script>alert('Student user not found');</script>");
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("student_interface.aspx");
    }
}