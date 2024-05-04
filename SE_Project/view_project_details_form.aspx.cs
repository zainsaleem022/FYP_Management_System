using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

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

            // Query to fetch project information along with group members' names
            string query = @"
            SELECT fyp.*, Student.student_name AS group_member_name 
            FROM fyp 
            INNER JOIN fyp_group ON fyp.id = fyp_group.fyp_id 
            INNER JOIN Student ON fyp_group.student_id = Student.student_id 
            WHERE fyp.id = @id";

            using (SqlCommand command = new SqlCommand(query, dbHandler.connection))
            {
                // Add parameter for FYP group ID
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
                    if (reader.HasRows)
                    {
                        // Loop through the results
                        while (reader.Read())
                        {
                            // Display project information in the corresponding labels
                            title_from_db_label.Text = reader["fyp_title"].ToString();
                            description_from_db_label.Text = reader["fyp_description"].ToString();
                            details_from_db_label.Text = reader["details"].ToString();

                            // Append group members' names to the label
                            group_members_from_db_label.Text += reader["group_member_name"].ToString() + ", ";
                        }

                        // Trim the trailing comma and space
                        group_members_from_db_label.Text = group_members_from_db_label.Text.TrimEnd(',', ' ');
                        reader.Close();
                        // Check if a supervisor is assigned to this FYP
                        string supervisorQuery = "SELECT supervisor_id FROM fyp_supervisor WHERE fyp_id = @id";
                        using (SqlCommand supervisorCommand = new SqlCommand(supervisorQuery, dbHandler.connection))
                        {
                            supervisorCommand.Parameters.AddWithValue("@id", studentGroupId);
                            object supervisorId = supervisorCommand.ExecuteScalar();

                            if (supervisorId != null)
                            {
                                // Supervisor is assigned
                                string supervisorInfoQuery = "SELECT faculty_name, email FROM faculty WHERE id = @supervisorId";
                                using (SqlCommand supervisorInfoCommand = new SqlCommand(supervisorInfoQuery, dbHandler.connection))
                                {
                                    supervisorInfoCommand.Parameters.AddWithValue("@supervisorId", supervisorId.ToString());
                                    SqlDataReader supervisorInfoReader = supervisorInfoCommand.ExecuteReader();

                                    if (supervisorInfoReader.Read())
                                    {
                                        // Supervisor name and email
                                        string supervisorName = supervisorInfoReader["faculty_name"].ToString();
                                        string supervisorEmail = supervisorInfoReader["email"].ToString();

                                        // Display supervisor information
                                        supervisor_name_from_db_label.Text = $" {supervisorName}";
                                        supervisor_email_from_db_label.Text = $" {supervisorEmail}";
                                    }
                                    else
                                    {
                                        supervisor_name_from_db_label.Text = "Supervisor information not available";
                                    }

                                    supervisorInfoReader.Close();
                                }
                            }
                            else
                            {
                                // No supervisor assigned
                                supervisor_name_from_db_label.Text = "Not Assigned";
                            }
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('No FYP information found');</script>");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error fetching FYP information');</script>");
                }
                finally
                {
                    dbHandler.connection.Close();
                }
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