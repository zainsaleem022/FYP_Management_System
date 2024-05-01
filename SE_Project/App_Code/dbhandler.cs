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
        connectionstring = "Data Source=IK\\SQLEXPRESS;Initial Catalog=fyp;Integrated Security=True";
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

    public int register(string id, string pass, string userrole)
    {
        int _role = -1;

        string query = "SELECT * FROM users WHERE id = @id";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            // Add parameters to the command
            cmd.Parameters.AddWithValue("@id", id);

            // Open connection to the database
            connection.Open();

            // Execute the query
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check if any rows are returned (i.e., user exists)
                if (reader.HasRows)
                {
                    return 0;
                }
                else
                {
                    string query1 = "INSERT INTO Users (id, pwd,user_role) VALUES (@id, @pass, @userrole);";
                    using (SqlCommand cmd1 = new SqlCommand(query1, connection))
                    {
                        // Add parameters to the command
                        cmd1.Parameters.AddWithValue("@id", id);
                        cmd1.Parameters.AddWithValue("@pass", pass);
                        cmd1.Parameters.AddWithValue("@userrole", userrole);

                        // Execute the insert query
                        int rowsAffected = cmd1.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // User registered successfully
                            return 1;
                        }
                        else
                        {
                            // Failed to register user
                            return -1;
                        }
                    }
                }
            }
        }

        // Close the connection
        connection.Close();

        return _role;

    }

    // Public method to register student
    public int RegisterStudents(int group, List<(string id, string password, string name, string email)> students)
    {
        int registeredCount = 0;

        // Check if the number of students is 2 or 3
        if (students.Count == 2 || students.Count == 3)
        {
            // Check the number of students already in the group
           
            
                bool areAllValidated = true;

                foreach (var student in students)
                {
                    // Check if the student ID already exists
                    if (IsStudentIdExists(student.id))
                    {
                        areAllValidated = false;
                        break;
                    }

                    

                }

                // If all validations pass, register the students
                if (areAllValidated)
                {
                    using (SqlConnection connection = new SqlConnection(connectionstring))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction();

                        
                    try
                        {
                        string registerfypQuery = "Insert into fyp(id) values (@group)";
                        using (SqlCommand cmdf = new SqlCommand(registerfypQuery, transaction.Connection, transaction))
                        {
                            cmdf.Parameters.AddWithValue("@group", group);
                            int fypAffected = cmdf.ExecuteNonQuery();
                        }
                        foreach (var student in students)
                            {
                                int regVal = RegisterStudent(student.id, student.password, group, student.name, student.email, transaction);
                                if (regVal != 1)
                                {
                                    // If any registration fails, rollback the transaction
                                    transaction.Rollback();
                                    return 0;
                                }
                            }

                            // If all registrations succeed, commit the transaction
                            transaction.Commit();
                            registeredCount = students.Count;
                        }
                        catch (Exception ex)
                        {
                            // Handle the exception appropriately
                            transaction.Rollback();
                            // Log the exception or take appropriate action
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            
        }

        return registeredCount;
    }

    // Modified RegisterStudent method to use a transaction
    private int RegisterStudent(string id, string password, int group, string name, string email, SqlTransaction transaction)
    {
        // Perform the student registration
        string registerStudentQuery = "INSERT INTO student (student_id, student_name, email) VALUES (@id, @name, @email)";
        string registerUserQuery = "INSERT INTO users (id, pwd, user_role) VALUES (@id, @password, 'student')";
        //string registerfypQuery = "Insert into fyp(id) values (@group)";
        string registerFypQuery = "INSERT INTO fyp_group (student_id, fyp_id) VALUES (@id, @group)";

        using (SqlCommand cmdUser = new SqlCommand(registerUserQuery, transaction.Connection, transaction))
        using (SqlCommand cmdStudent = new SqlCommand(registerStudentQuery, transaction.Connection, transaction))
        
        using (SqlCommand cmdFyp = new SqlCommand(registerFypQuery, transaction.Connection, transaction))
        {
            // Add parameters for student registration
            cmdStudent.Parameters.AddWithValue("@id", id);
            cmdStudent.Parameters.AddWithValue("@name", name);
            cmdStudent.Parameters.AddWithValue("@email", email);

            // Add parameters for user registration
            cmdUser.Parameters.AddWithValue("@id", id);
            cmdUser.Parameters.AddWithValue("@password", password);

            

            // Add parameters for FYP group registration
            cmdFyp.Parameters.AddWithValue("@id", id);
            cmdFyp.Parameters.AddWithValue("@group", group);

            // Execute the registration queries within the transaction
            int userRowsAffected = cmdUser.ExecuteNonQuery();
            int studentRowsAffected = cmdStudent.ExecuteNonQuery();

            
            int fypRowsAffected = cmdFyp.ExecuteNonQuery();
            int test = 0;
            // Check if all registrations were successful
            
                // Registration failed, return 0 indicating failure
            return 1;
            
        }
    }

    // Private method to check if the student ID already exists
    private bool IsStudentIdExists(string id)
    {
        string query = "SELECT COUNT(*) FROM student WHERE student_id = @id";

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
    private int CountStudentsInGroup(int group)
    {
        string query = "SELECT COUNT(*) FROM fyp_group WHERE fyp_id = @group";

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

        string query = "SELECT group_id, email, student_name FROM student WHERE student_id = @id";

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

    public void findFaculty(string id, ref int committee, ref int panel, ref int supervisor, ref string email, ref string facultyName)
    {
        //committee = 0;
        //panel = 0;
        //supervisor = 0;
        //email = string.Empty;
        //facultyName = string.Empty;

        string query = "SELECT committee, panel,supervisor, email, faculty_name FROM faculty WHERE id = @id";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    committee = reader.GetInt32(0);
                    panel = reader.GetInt32(1);
                    supervisor = reader.GetInt32(2);
                    email = reader.GetString(3);
                    facultyName = reader.GetString(4);
                }
            }

            connection.Close();
        }
    }


}
