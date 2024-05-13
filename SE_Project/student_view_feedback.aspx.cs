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
        List<EvaluationData1> data = new List<EvaluationData1>();
        string studentId = Session["student_id"].ToString();
        dbhandler dbhandler = dbhandler.Instance;
        string connectionString = dbhandler.getConnectionString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT ef.comments
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
                EvaluationData1 evaluationData = new EvaluationData1
                {
                    Comment = reader.IsDBNull(0) ? string.Empty : reader.GetString(0)
                };

                data.Add(evaluationData);
            }
        }

        GridView1.DataSource = data;
        GridView1.DataBind();
    }
}

public class EvaluationData1
{
    public string Comment { get; set; }
}