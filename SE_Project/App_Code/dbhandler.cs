using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Net.WebRequestMethods;

public class dbhandler
{
    private static readonly dbhandler instance = new dbhandler();
    private dbhandler()
    {
        connectionstring = "Data Source=LAPTOP-RU4CV3CE\\SQLEXPRESS;Initial Catalog=fyp1;Integrated Security=True";
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
    public SqlConnection connection;
    public string getConnectionString() { return connectionstring; }
    // Public method to perform login
    public int login(string id, string password, ref string userrole)
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

            if (connection.State == ConnectionState.Open)
                connection.Close();

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

    public void findStudent(string id, ref string email, ref string studentName)
    {
        email = string.Empty;
        studentName = string.Empty;

        string query = "SELECT email, student_name FROM student WHERE student_id = @id";

        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    email = reader.GetString(0);
                    studentName = reader.GetString(1);
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



    public int GetPanelIdForFaculty(string facultyId)
    {
        int panelId = 0;

        using (SqlConnection connection = new SqlConnection(connectionstring))
        {
            string query = @"
                SELECT p.id AS panel_id
                FROM panel p
                JOIN faculty f ON p.panel_member_1_id = f.id
                                OR p.panel_member_2_id = f.id
                                OR p.panel_member_3_id = f.id
                                OR p.panel_member_4_id = f.id
                                OR p.panel_member_5_id = f.id
                WHERE f.id = @facultyId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@facultyId", facultyId);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                panelId = Convert.ToInt32(reader["panel_id"]);
            }
            else
            {
                // If no panel ID is found, set panelId to 0
                panelId = 0;
            }

            reader.Close();
        }

        return panelId;
    }

    public DataTable DisplayPanel(int id)
    {
        string query = @"SELECT
                        p.id AS panel_id,
                        f.faculty_name,
                        f.email,
                        f.id
                    FROM
                        faculty f
                    JOIN
                        panel p ON p.panel_member_1_id = f.id
                            OR p.panel_member_2_id = f.id
                            OR p.panel_member_3_id = f.id
                            OR p.panel_member_4_id = f.id
                            OR p.panel_member_5_id = f.id
                    WHERE
                        p.id = @id
                    GROUP BY
                        f.faculty_name,
                        f.email,
                        f.id,
                        p.id;";

        using (SqlConnection conn = new SqlConnection(connectionstring))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }


    public int get_student_fyp_group_id(string studentId)
    {
        int groupId = 0;

        // Define your SQL query
        string query = "SELECT fyp_id FROM fyp_group WHERE student_id = @studentId";

        // Use SqlConnection and SqlCommand to execute the query
        using (SqlConnection connection = new SqlConnection(connectionstring))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameter for student_id
                command.Parameters.AddWithValue("@studentId", studentId);

                // Execute the query and get the result
                object result = command.ExecuteScalar();

                // Check if the result is not null and convert it to integer
                if (result != null && result != DBNull.Value)
                {
                    groupId = Convert.ToInt32(result);
                }
            }
        }

        return groupId;
    }

    public int RegisterFaculty(string id, string password, string name, string email,int p, int s, int c)
    {
        // Perform the student registration
        string registerFacultyQuery = "INSERT INTO faculty (id, supervisor,panel,committee,faculty_name, email) VALUES (@id, @p,@s,@c, @name, @email)";
        string registerUserQuery = "INSERT INTO users (id, pwd, user_role) VALUES (@id, @password, 'faculty')";
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();
        using (SqlCommand cmdUser = new SqlCommand(registerUserQuery, transaction.Connection, transaction))
        using (SqlCommand cmdFaculty = new SqlCommand(registerFacultyQuery, transaction.Connection, transaction))

        {


            // Add parameters for student registration
            cmdFaculty.Parameters.AddWithValue("@p", p);
            cmdFaculty.Parameters.AddWithValue("@s", s);
            cmdFaculty.Parameters.AddWithValue("@c", c);
            cmdFaculty.Parameters.AddWithValue("@id", id);
            cmdFaculty.Parameters.AddWithValue("@name", name);
            cmdFaculty.Parameters.AddWithValue("@email", email);

            // Add parameters for user registration
            cmdUser.Parameters.AddWithValue("@id", id);
            cmdUser.Parameters.AddWithValue("@password", password);




            // Execute the registration queries within the transaction
            try
            {
                int userRowsAffected = cmdUser.ExecuteNonQuery();
                int FacultyRowsAffected = cmdFaculty.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                int test = 0;
                // Check if all registrations were successful

                // Registration failed, return 0 indicating failure
                return 1;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return 0;
            }

        }
    }
    public int getStatus()
    {
        string query = "Select * from evaluation_status";
        connection.Open();
        int status = 0;
        using (SqlCommand command = new SqlCommand(query, connection))
        {


            // Execute the query and get the result
            object result = command.ExecuteScalar();

            // Check if the result is not null and convert it to integer
            if (result != null && result != DBNull.Value)
            {
                status = Convert.ToInt32(result);
                connection.Close();
                return status;
            }
        }
        return status;
    }
    public void setStatus()
    {
        string query = "UPDATE Evaluation_status SET status = 1; ";
        connection.Open();
        int status = 0;
        using (SqlCommand command = new SqlCommand(query, connection))
        {


            // Execute the query and get the result
            status = command.ExecuteNonQuery();

        }
        connection.Close();
    }
}
