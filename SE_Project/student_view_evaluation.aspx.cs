using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class student_view_evaluation : System.Web.UI.Page
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
        dbhandler dbhandler = dbhandler.Instance;
        string connectionString = dbhandler.getConnectionString();
        List<EvaluationData> data = new List<EvaluationData>();
        List<EvaluationData> dataWithScores = new List<EvaluationData>();
        string studentId = Session["student_id"].ToString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT q.question_string, e.panel_member_id, e.score
                FROM question q
                LEFT JOIN evaluation e ON q.question_number = e.question
                LEFT JOIN fyp_group fg ON e.fyp_id = fg.fyp_id
                WHERE fg.student_id = @studentId
            ";

            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            SqlDataReader reader = command.ExecuteReader();

            List<string> panelMemberIds = new List<string>();
            while (reader.Read())
            {
                string questionString = reader["question_string"].ToString();
                string panelMemberId = reader["panel_member_id"].ToString();
                int? score = reader["score"] as int?;

                EvaluationData evaluationData = data.FirstOrDefault(d => d.QuestionString == questionString);
                if (evaluationData == null)
                {
                    evaluationData = new EvaluationData
                    {
                        QuestionString = questionString
                    };
                    data.Add(evaluationData);
                }

                if (!panelMemberIds.Contains(panelMemberId))
                {
                    panelMemberIds.Add(panelMemberId);
                }

                int panelMemberIndex = panelMemberIds.IndexOf(panelMemberId);
                switch (panelMemberIndex)
                {
                    case 0:
                        evaluationData.PanelMember1Score = score;
                        break;
                    case 1:
                        evaluationData.PanelMember2Score = score;
                        break;
                    case 2:
                        evaluationData.PanelMember3Score = score;
                        break;
                    case 3:
                        evaluationData.PanelMember4Score = score;
                        break;
                    case 4:
                        evaluationData.PanelMember5Score = score;
                        break;
                    // Add more cases for other panel member IDs
                    default:
                        break;
                }
            }

            reader.Close();
        }

        if (AllPanelMembersEvaluated(data))
            if (AllPanelMembersEvaluated(data))
            {
                int maxScore = 150;
                int numPanelMembers = 5;
                int totalScore = CalculateTotalScore(data);
                double percentage = CalculatePercentage(totalScore);
                string grade = GetGrade(percentage);

                foreach (var evaluationData in data)
                {
                    evaluationData.Percentage = percentage;
                    evaluationData.Grade = grade;

                    dataWithScores.Add(evaluationData);
                }
            }
            else
        {
            // Inform the user that not all panel members have evaluated
            Response.Write("<script>alert('Not all panel members have evaluated yet.')</script>");
        }

        GridView1.DataSource = data;
        GridView1.DataBind();
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

    private bool AllPanelMembersEvaluated(List<EvaluationData> data)
    {
        foreach (var evaluationData in data)
        {
            if (evaluationData.PanelMember1Score == null ||
                evaluationData.PanelMember2Score == null ||
                // Add checks for other panel members here
                evaluationData.PanelMember3Score == null || evaluationData.PanelMember4Score == null || evaluationData.PanelMember5Score == null)
            {
                return false;
            }
        }

        return true;
    }
    private int CalculateTotalScore(List<EvaluationData> dataList)
    {
        int totalScore = 0;
        foreach (var evaluationData in dataList)
        {
            if (evaluationData.PanelMember1Score.HasValue)
                totalScore += evaluationData.PanelMember1Score.Value;
            if (evaluationData.PanelMember2Score.HasValue)
                totalScore += evaluationData.PanelMember2Score.Value;
            if (evaluationData.PanelMember3Score.HasValue)
                totalScore += evaluationData.PanelMember3Score.Value;
            if (evaluationData.PanelMember4Score.HasValue)
                totalScore += evaluationData.PanelMember4Score.Value;
            if (evaluationData.PanelMember5Score.HasValue)
                totalScore += evaluationData.PanelMember5Score.Value;
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
    private void PrintDataWithScores(List<EvaluationData> dataWithScores)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='1'>");
        sb.Append("<tr><th>Total Score</th><th>Percentage</th><th>Grade</th></tr>");

        var evaluationData = dataWithScores.FirstOrDefault();
        if (evaluationData != null)
        {
            sb.Append("<tr>");
            sb.Append($"<td>{CalculateTotalScore(dataWithScores)}</td>");
            sb.Append($"<td>{evaluationData.Percentage}%</td>");
            sb.Append($"<td>{evaluationData.Grade}</td>");
            sb.Append("</tr>");
        }

        sb.Append("</table>");
        Response.Write(sb.ToString());
    }

}

public class EvaluationData
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