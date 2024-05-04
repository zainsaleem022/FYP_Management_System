using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class student_view_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridView();
        }
    }

    private void BindGridView()
    {
        List<EvaluationData> data = new List<EvaluationData>();
        string studentId = Session["student_id"].ToString();
        string connectionString = "Data Source=IK\\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT ef.panel_member_id, ef.comments
                FROM evaluation_feedback ef
                LEFT JOIN fyp_group fg ON ef.fyp_id = fg.fyp_id
                WHERE fg.student_id = @studentId
            ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                EvaluationData evaluationData = new EvaluationData
                {
                    PanelMemberId = reader.GetString(0),
                    Comment = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                };
                data.Add(evaluationData);
            }
        }

        GridView1.DataSource = data;
        GridView1.DataBind();
    }
}

public class EvaluationData
{
    public string PanelMemberId { get; set; }
    public string Comment { get; set; }
}