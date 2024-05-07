using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EvaluationForm : System.Web.UI.Page
{
    // Code-behind file (e.g., YourPage.aspx.cs)
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
                string query = "SELECT fyp_id from panel_fyp where (panel_member_1_id = @id or  panel_member_2_id = @id or panel_member_3_id = @id or panel_member_4_id = @id or panel_member_5_id = @id) and fyp_id not in (select fyp_id from evaluation where panel_member_id = @id)";
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

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        // Check if FYP ID is selected
        if (string.IsNullOrEmpty(DropDownList1.SelectedValue))
        {
            Response.Write("<script>alert('Please select a FYP ID.');</script>");
            return;
        }

        // Check if additional comments are provided
        string additionalComments = TextBox1.Text.Trim();
        if (string.IsNullOrEmpty(additionalComments))
        {
            Response.Write("<script>alert('Please provide additional comments.');</script>");
            return;
        }

        // Check if all radio buttons are filled
        if (!AreAllRadioButtonsFilled())
        {
            Response.Write("<script>alert('Please fill out all the ratings.');</script>");
            return;
        }

        // Get the selected FYP ID from the DropDownList
        int fypId = int.Parse(DropDownList1.SelectedValue);

        // Establish a database connection
        dbhandler db = dbhandler.Instance;

        string connectionString = db.getConnectionString();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // Start a transaction
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Define the INSERT query for evaluation
                string queryEvaluation = @"
                INSERT INTO evaluation (fyp_id, panel_member_id, question, score)
                SELECT @fypId, @pmemberid, question_number, score
                FROM (
                    VALUES
                        (1, @score1), (2, @score2), (3, @score3), (4, @score4), (5, @score5),
                        (6, @score6), (7, @score7), (8, @score8), (9, @score9), (10, @score10),
                        (11, @score11), (12, @score12), (13, @score13), (14, @score14), (15, @score15)
                ) AS scores (question_number, score)
            ";

                SqlCommand cmdEvaluation = new SqlCommand(queryEvaluation, con, transaction);

                // Add parameters for the FYP ID and panel member ID
                cmdEvaluation.Parameters.AddWithValue("@fypId", fypId);
                cmdEvaluation.Parameters.AddWithValue("@pmemberid", (string)Session["faculty_id"]);

                // Add parameters for the scores
                cmdEvaluation.Parameters.AddWithValue("@score1", int.Parse(RadioButtonList1.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score2", int.Parse(RadioButtonList2.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score3", int.Parse(RadioButtonList3.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score4", int.Parse(RadioButtonList4.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score5", int.Parse(RadioButtonList5.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score6", int.Parse(RadioButtonList6.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score7", int.Parse(RadioButtonList7.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score8", int.Parse(RadioButtonList8.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score9", int.Parse(RadioButtonList9.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score10", int.Parse(RadioButtonList10.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score11", int.Parse(RadioButtonList11.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score12", int.Parse(RadioButtonList12.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score13", int.Parse(RadioButtonList13.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score14", int.Parse(RadioButtonList14.SelectedValue));
                cmdEvaluation.Parameters.AddWithValue("@score15", int.Parse(RadioButtonList15.SelectedValue));

                // Execute the query
                cmdEvaluation.ExecuteNonQuery();

                // Define the INSERT query for evaluation_feedback
                string queryFeedback = "INSERT INTO evaluation_feedback (fyp_id, panel_member_id, comments) VALUES (@fypId, @pmemberid, @comments)";
                SqlCommand cmdFeedback = new SqlCommand(queryFeedback, con, transaction);
                cmdFeedback.Parameters.AddWithValue("@fypId", fypId);
                cmdFeedback.Parameters.AddWithValue("@pmemberid", (string)Session["faculty_id"]);
                cmdFeedback.Parameters.AddWithValue("@comments", additionalComments);

                // Execute the query for evaluation_feedback
                cmdFeedback.ExecuteNonQuery();

                // Commit the transaction if everything is successful
                transaction.Commit();

                // Display a success message
                Response.Write("<script>alert('Evaluation submitted successfully!');</script>");
            }
            catch (Exception ex)
            {
                // Roll back the transaction if an exception occurs
                transaction.Rollback();
                Response.Write("<script>alert('Failed to submit evaluation: " + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
    private bool AreAllRadioButtonsFilled()
    {
        // Get all radio button lists
        List<RadioButtonList> radioLists = new List<RadioButtonList>
    {
        RadioButtonList1, RadioButtonList2, RadioButtonList3, RadioButtonList4,
        RadioButtonList5, RadioButtonList6, RadioButtonList7, RadioButtonList8,
        RadioButtonList9, RadioButtonList10, RadioButtonList11, RadioButtonList12,
        RadioButtonList13, RadioButtonList14, RadioButtonList15
    };

        // Check if any radio buttons are not selected
        foreach (var radioList in radioLists)
        {
            if (string.IsNullOrEmpty(radioList.SelectedValue))
            {
                return false;
            }
        }
        return true;
    }

}