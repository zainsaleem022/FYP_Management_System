using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class supervisor_view_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = (string)Session["faculty_id"];

        if (!IsPostBack)
        {
            // Establish a database connection
            dbhandler dbhandler = dbhandler.Instance;
            string connectionString = dbhandler.getConnectionString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT f.id AS fyp_id " +
                               "FROM fyp f " +
                               "INNER JOIN fyp_supervisor fs ON f.id = fs.fyp_id " +
                               "WHERE fs.supervisor_id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                DropDownList1.DataSource = cmd.ExecuteReader();
                DropDownList1.DataTextField = "fyp_id";
                DropDownList1.DataValueField = "fyp_id";
                DropDownList1.DataBind();

                con.Close();
            }
        }
    }

    private void BindGridView()
    {
        List<EData> data = new List<EData>();
        string selectedFypId = DropDownList1.SelectedValue; // Get the selected FYP ID from the dropdown

        dbhandler db = dbhandler.Instance;

        string connectionString = db.getConnectionString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT ef.panel_member_id, ef.comments
            FROM evaluation_feedback ef
            INNER JOIN fyp_supervisor fg ON ef.fyp_id = fg.fyp_id
            WHERE ef.fyp_id = @fypId
        ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fypId", selectedFypId); // Use the selected FYP ID as a parameter

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                EData EData = new EData
                {
                    PanelMemberId = reader.GetString(0),
                    Comment = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                };
                data.Add(EData);
            }
        }

        GridView1.DataSource = data;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}

public class EData
{
    public string PanelMemberId { get; set; }
    public string Comment { get; set; }
}