<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Log In</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
        body {
            background: url("images/bg1.jpg") no-repeat center center fixed;
            background-size: cover;
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }
    
        .container {
            max-width: 400px;
            margin: 0 100px; /* Add some margin to create space */
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }
    
        .welcome-container {
            max-width: 400px;
            margin: 0 100px; /* Add some margin to create space */
            padding: 20px;
            background-color: rgba(20, 20, 20, 0.766);
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0,0 , 0, 0.1);
            color: #ffffff; /* Change font color */
        }
    </style>    
</head>
<body>

        <div class="welcome-container">
        <h3>Welcome to FYP Management System!</h3>
    </div>
        <form runat="server">
        <div class="container">


            <h2 class="text-center">Log In</h2>
            <div class="form-group">
                <asp:TextBox class ="form-control" placeholder="User ID" ID = "TextBox1" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox class ="form-control" placeholder="Password" ID ="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="login" Width="61px" />

        </div>

    </form>







</body>
</html>
