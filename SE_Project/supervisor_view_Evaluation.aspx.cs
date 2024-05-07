using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class supervisor_view_Evaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = (string)Session["faculty_id"];

        if (!IsPostBack)
        {
            // Establish a database connection
            dbhandler db = dbhandler.Instance;

            string connectionString = db.getConnectionString();

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
    
    private void BindGridView()
    {
        List<evData> data = new List<evData>();
        List<evData> dataWithScores = new List<evData>();
        int selectedFypId = Convert.ToInt32(DropDownList1.SelectedValue);
        dbhandler dbhandler = dbhandler.Instance;
        string connectionString = dbhandler.getConnectionString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT q.question_string, e.panel_member_id, e.score
            FROM question q
            LEFT JOIN evaluation e ON q.question_number = e.question
            WHERE e.fyp_id = @fypId
        ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fypId", selectedFypId);
            SqlDataReader reader = command.ExecuteReader();

            List<string> panelMemberIds = new List<string>();
            while (reader.Read())
            {
                string questionString = reader["question_string"].ToString();
                string panelMemberId = reader["panel_member_id"].ToString();
                int? score = reader["score"] as int?;

                evData evData = data.FirstOrDefault(d => d.QuestionString == questionString);
                if (evData == null)
                {
                    evData = new evData
                    {
                        QuestionString = questionString
                    };
                    data.Add(evData);
                }

                if (!panelMemberIds.Contains(panelMemberId))
                {
                    panelMemberIds.Add(panelMemberId);
                }

                int panelMemberIndex = panelMemberIds.IndexOf(panelMemberId);
                switch (panelMemberIndex)
                {
                    case 0:
                        evData.PanelMember1Score = score;
                        break;
                    case 1:
                        evData.PanelMember2Score = score;
                        break;
                    case 2:
                        evData.PanelMember3Score = score;
                        break;
                    case 3:
                        evData.PanelMember4Score = score;
                        break;
                    case 4:
                        evData.PanelMember5Score = score;
                        break;
                    // Add more cases for other panel member IDs
                    default:
                        break;
                }
            }

            reader.Close();
        }

        if (AllPanelMembersEvaluated(data))
        {
            int maxScore = 150;
            int numPanelMembers = 5;
            int totalScore = CalculateTotalScore(data);
            double percentage = CalculatePercentage(totalScore);
            string grade = GetGrade(percentage);

            foreach (var evData in data)
            {
                evData.Percentage = percentage;
                evData.Grade = grade;

                dataWithScores.Add(evData);
            }
        }
        else
        {
            // Inform the user that not all panel members have evaluated
            Response.Write("<script>alert('Not all panel members have evaluated yet.')</script>");
        }

        GridView1.DataSource = data;
        GridView1.DataBind();
        //int totalColumns = GridView1.Columns.Count;
        //for (int i = totalColumns - 1; i >= totalColumns - 4; i--)
        //{
        //    GridView1.Columns[i].Visible = false;
        //}

        if (AllPanelMembersEvaluated(data))
        {
            PrintDataWithScores(dataWithScores);
        }
    }

    private List<string> GetPanelMemberIds()
    {
        List<string> panelMemberIds = new List<string>();

        int fypId = Convert.ToInt32(Session["fyp_id"]);
        dbhandler db = dbhandler.Instance;

        string connectionString = db.getConnectionString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT DISTINCT panel_member_id
                FROM evaluation
                WHERE fyp_id = @fypId
            ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@fypId", fypId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                panelMemberIds.Add(reader["panel_member_id"].ToString());
            }

            reader.Close();
        }

        return panelMemberIds;
    }

    private bool AllPanelMembersEvaluated(List<evData> data)
    {
        foreach (var evData in data)
        {
            if (evData.PanelMember1Score == null ||
                evData.PanelMember2Score == null ||
                // Add checks for other panel members here
                evData.PanelMember3Score == null || evData.PanelMember4Score == null || evData.PanelMember5Score == null)
            {
                return false;
            }
        }

        return true;
    }
    private int CalculateTotalScore(List<evData> dataList)
    {
        int totalScore = 0;
        foreach (var evData in dataList)
        {
            if (evData.PanelMember1Score.HasValue)
                totalScore += evData.PanelMember1Score.Value;
            if (evData.PanelMember2Score.HasValue)
                totalScore += evData.PanelMember2Score.Value;
            if (evData.PanelMember3Score.HasValue)
                totalScore += evData.PanelMember3Score.Value;
            if (evData.PanelMember4Score.HasValue)
                totalScore += evData.PanelMember4Score.Value;
            if (evData.PanelMember5Score.HasValue)
                totalScore += evData.PanelMember5Score.Value;
            // Add calculations for other panel members here
        }
        return totalScore;
    }

    private double CalculateAverage(int totalScore, int numPanelMembers)
    {
        return (double)totalScore / numPanelMembers;
    }

    private double CalculatePercentage(double myscore)
    {
        return (myscore / 750) * 100;
    }

    private string GetGrade(double percentage)
    {
        if (percentage >= 90)
            return "A+";
        else if (percentage >= 86)
            return "A";
        else if (percentage >= 82)
            return "A-";
        else if (percentage >= 78)
            return "B+";
        else if (percentage >= 74)
            return "B";
        else if (percentage >= 70)
            return "B-";
        else if (percentage >= 66)
            return "C+";
        else if (percentage >= 62)
            return "C";
        else if (percentage >= 58)
            return "C-";
        else if (percentage >= 54)
            return "D+";
        else if (percentage >= 50)
            return "D";
        else
            return "F";
    }
    private void PrintDataWithScores(List<evData> dataWithScores)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='1'>");
        sb.Append("<tr><th>Total Score</th><th>Percentage</th><th>Grade</th></tr>");

        var evData = dataWithScores.FirstOrDefault();
        if (evData != null)
        {
            sb.Append("<tr>");
            sb.Append($"<td>{CalculateTotalScore(dataWithScores)}</td>");
            sb.Append($"<td>{evData.Percentage}%</td>");
            sb.Append($"<td>{evData.Grade}</td>");
            sb.Append("</tr>");
        }

        sb.Append("</table>");
        Response.Write(sb.ToString());
    }

    
}
public class evData
{
    public string QuestionString { get; set; }
    public int? PanelMember1Score { get; set; }
    public int? PanelMember2Score { get; set; }
    public int? PanelMember3Score { get; set; }
    public int? PanelMember4Score { get; set; }
    public int? PanelMember5Score { get; set; }
    public int TotalScore { get; set; }
    public double Average { get; set; }
    public double Percentage { get; set; }
    public string Grade { get; set; }
    // Add more properties for additional panel members
}