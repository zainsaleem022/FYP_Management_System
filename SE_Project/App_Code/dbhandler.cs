using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

public class dbhandler
{
    private static readonly dbhandler instance = new dbhandler();
    private dbhandler()
    {
        connectionstring = "Data Source=DESKTOP-1AGR8OG\\SQLEXPRESS;Initial Catalog=se_project;Integrated Security=True";
        // Initialize the SqlConnection
        connection = new SqlConnection(connectionstring);
    }

    // Public static property to access the singleton instance
    public static dbhandler Instance
    {
        get { return instance; }
    }

    // Private fields
    private string connectionstring;
    private SqlConnection connection;

    // Public method to perform login
    public int login(string id, string password,ref string userrole)
    {
        int _role = -1;

        // SQL query to select user based on provided ID and password
        string query = "SELECT * FROM users WHERE id = @id AND pwd = @password";

        // Using statement ensures proper disposal of resources
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@password", password);

            // Open connection to the database
            connection.Open();

            // Execute the query
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if any rows are returned (i.e., user exists)
                if (reader.HasRows)
                {
                    // User found
                    reader.Read();

                    // Get the value of the third column (as string)
                    string role = reader.GetString(2);
                    if (role == "faculty")
                    {
                        _role = 1;
                        userrole = role;
                    }
                    if (role == "student")
                    {
                        _role = 2;
                        userrole = role;
                    }
                }
            }
        }

        // Close the connection
        connection.Close();

        return _role;
    }

    // Public method to register student
    public int RegisterStudent(string id, string password, string group,string name, string email)
    {
        // Check if the student ID already exists
        if (IsStudentIdExists(id))
        {
            // If the ID already exists, return -1 indicating failure
            return -1;
        }

        // Check the number of students in the same group
        int studentsInGroup = CountStudentsInGroup(group);

        // If the number of students in the group is less than 3, register the student
        if (studentsInGroup < 3)
        {
            // Perform the student registration
            string registerStudentQuery = "INSERT INTO student (id, group_id,student_name,email) VALUES (@id, @group,@name,@email)";
            string registerUserQuery = "INSERT INTO users (id, pwd, user_role) VALUES (@id, @password, 'student')";

            // Using statement ensures proper disposal of resources
            using (SqlCommand cmdStudent = new SqlCommand(registerStudentQuery, connection))
            using (SqlCommand cmdUser = new SqlCommand(registerUserQuery, connection))
            {
                // Add parameters for student registration
                cmdStudent.Parameters.AddWithValue("@id", id);
                cmdStudent.Parameters.AddWithValue("@password", password);
                cmdStudent.Parameters.AddWithValue("@group", group);
                cmdStudent.Parameters.AddWithValue("@name", name);
                cmdStudent.Parameters.AddWithValue("@email", email);
                // Add parameters for user registration
                cmdUser.Parameters.AddWithValue("@id", id);
                cmdUser.Parameters.AddWithValue("@password", password);

                // Open connection to the database
                connection.Open();

                // Execute the registration queries
                int studentRowsAffected = cmdStudent.ExecuteNonQuery();
                int userRowsAffected = cmdUser.ExecuteNonQuery();

                // Close the connection
                connection.Close();

                // Check if both registrations were successful
                if (studentRowsAffected > 0 && userRowsAffected > 0)
                {
                    // Both registrations successful, return 1 indicating success
                    return 1;
                }
                else
                {
                    // Registration failed, return 0 indicating failure
                    return 0;
                }
            }
        }
        else
        {
            // If the number of students in the group is 3 or more, return 2 indicating failure
            return 2;
        }
    }

    // Private method to check if the student ID already exists
    private bool IsStudentIdExists(string id)
    {
        string query = "SELECT COUNT(*) FROM student WHERE id = @id";

        // Using statement ensures proper disposal of resources
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            cmd.Parameters.AddWithValue("@id", id);

            // Open connection to the database
            connection.Open();

            int count = (int)cmd.ExecuteScalar();

            // Close the connection
            connection.Close();

            // If count is greater than 0, ID exists
            return count > 0;
        }
    }

    // Private method to count the number of students in a group
    private int CountStudentsInGroup(string group)
    {
        string query = "SELECT COUNT(*) FROM student WHERE group_id = @group";

        // Using statement ensures proper disposal of resources
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            cmd.Parameters.AddWithValue("@group", group);

            // Open connection to the database
            connection.Open();

            int count = (int)cmd.ExecuteScalar();

            // Close the connection
            connection.Close();

            // Return the count of students in the group
            return count;
        }
    }

    public void findStudent(string id, ref string groupId, ref string email, ref string studentName)
    {
        groupId = string.Empty;
        email = string.Empty;
        studentName = string.Empty;

        string query = "SELECT group_id, email, student_name FROM student WHERE id = @id";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    groupId = reader.GetString(0);
                    email = reader.GetString(1);
                    studentName = reader.GetString(2);
                }
            }

            connection.Close();
        }
    }


}
