using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class committee_makes_new_panel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dbhandler db = dbhandler.Instance;
            string connectionString = db.getConnectionString();
            string query = "SELECT f.id, f.faculty_name " +
                           "FROM faculty f " +
                           "LEFT JOIN panel p ON f.id = p.panel_member_1_id OR f.id = p.panel_member_2_id OR f.id = p.panel_member_3_id OR f.id = p.panel_member_4_id OR f.id = p.panel_member_5_id " +
                           "WHERE p.id IS NULL and f.panel = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Load data into a DataTable
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        // Check the count of rows returned by the query
                        if (dataTable.Rows.Count < 5)
                        {
                            // Show alert if less than 5 rows are returned
                            Response.Write("<script>alert('Not enough faculty to make a panel.');</script>");
                            // Hide or clear the GridView
                            GridView1.Visible = false;
                        }
                        else
                        {
                            // Bind data to GridView
                            GridView1.DataSource = dataTable;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id1 = TextBox1.Text;
        string id2 = TextBox2.Text;
        string id3 = TextBox3.Text;
        string id4 = TextBox4.Text;
        string id5 = TextBox5.Text;

        int rowCount = 0;
        dbhandler db = dbhandler.Instance;
        string connectionString1 = db.getConnectionString();

        using (SqlConnection connection = new SqlConnection(connectionString1))
        {
            string query = "SELECT COUNT(*) AS row_count FROM panel";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                rowCount = (int)command.ExecuteScalar();
                connection.Close();
            }
        }



        if (string.IsNullOrWhiteSpace(id1) || string.IsNullOrWhiteSpace(id2) || string.IsNullOrWhiteSpace(id3) || string.IsNullOrWhiteSpace(id4) || string.IsNullOrWhiteSpace(id5))
        {
            Response.Write("<script>alert('Invalid entry: One or more fields are empty.');</script>");
        }
        else
        {
            HashSet<string> idsSet = new HashSet<string> { id1, id2, id3, id4, id5 };
            if (idsSet.Count < 5)
            {
                Response.Write("<script>alert('Invalid entry: There are repeating entries.');</script>");
            }
            else
            {
                try
                {
                    // Insert values into the panel table
                    dbhandler db1 = dbhandler.Instance;
                    string connectionString = db1.getConnectionString();
                    string query = "INSERT INTO panel (id,panel_member_1_id, panel_member_2_id, panel_member_3_id, panel_member_4_id, panel_member_5_id) " +
                                   "VALUES (@row,@id1, @id2, @id3, @id4, @id5)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@row", rowCount + 1);
                            command.Parameters.AddWithValue("@id1", id1);
                            command.Parameters.AddWithValue("@id2", id2);
                            command.Parameters.AddWithValue("@id3", id3);
                            command.Parameters.AddWithValue("@id4", id4);
                            command.Parameters.AddWithValue("@id5", id5);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Response.Write("<script>alert('Values inserted successfully.');</script>");
                                TextBox1.Text = string.Empty;
                                Response.Write("<script>setTimeout(function(){ window.location.href = window.location.href; }, 2000);</script>");
                                TextBox1.Text = string.Empty;
                                TextBox2.Text = string.Empty;
                                TextBox3.Text = string.Empty;
                                TextBox4.Text = string.Empty;
                                TextBox5.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('Failed to insert values.');</script>");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Response.Write("<script>alert('An error occurred');</script>");
                }
            }
        }
    }
}





