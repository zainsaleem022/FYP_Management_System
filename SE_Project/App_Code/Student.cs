﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student : User
{
    private string _groupId;
    private string _email;
    private string _studentName;

    public Student() : base()
    {
        _groupId = "";
        _email = "";
        _studentName = "";
        // Default constructor
    }

    public Student(string id, string pwd,string role)
        : base(id, pwd, role)
    {
        _groupId = "";
        _email = "";
        _studentName = "";
        dbhandler dbhandler = dbhandler.Instance;
        dbhandler.findStudent(id,ref _groupId,ref _email,ref _studentName);
    }

    public string GroupId
    {
        get { return _groupId; }
        set { _groupId = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string StudentName
    {
        get { return _studentName; }
        set { _studentName = value; }
    }
}