using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class provideReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get the supervisor ID from the session or other sources
            string supervisorId = Session["faculty_id"].ToString();

            // Load FYPs that the supervisor is part of
            using (SqlConnection connection = new SqlConnection("Data Source = IK\\SQLEXPRESS; Initial Catalog = fyp1; Integrated Security = True"))
            {
                connection.Open();

                string query = @"SELECT fyp.id
                             FROM fyp
                             INNER JOIN fyp_supervisor ON fyp.id = fyp_supervisor.fyp_id
                             WHERE fyp_supervisor.supervisor_id = @SupervisorId
                             AND NOT EXISTS (
                                 SELECT 1
                                 FROM supervisor_review
                                 WHERE supervisor_review.fyp_id = fyp.id
                                   AND supervisor_review.supervisor_id = @SupervisorId
                             )";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupervisorId", supervisorId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DropDownList1.DataSource = dataTable;
                DropDownList1.DataTextField = "id";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Get the selected FYP ID from the dropdown list
        int selectedFYPId = Convert.ToInt32(DropDownList1.SelectedValue);

        // Get the supervisor ID from the session or other sources
        string supervisorId = Session["faculty_id"].ToString();

        // Get the review text from a TextBox control or any other source
        string reviewText = TextBox1.Text;

        // Create a SQL connection
        using (SqlConnection connection = new SqlConnection("Data Source = IK\\SQLEXPRESS; Initial Catalog = fyp1; Integrated Security = True"))
        {
            connection.Open();

            // SQL query to insert data into the supervisor_review table
            string query = "INSERT INTO supervisor_review (supervisor_id, fyp_id, review) VALUES (@SupervisorId, @FYPId, @Review)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SupervisorId", supervisorId);
            command.Parameters.AddWithValue("@FYPId", selectedFYPId);
            command.Parameters.AddWithValue("@Review", reviewText);

            // Execute the query
            command.ExecuteNonQuery();
            Response.Write("<script>alert('Review Submitted');</script>");
            connection.Close();
        }
        Response.Redirect(Request.Path + "?afterButtonClick=true");
    }

}