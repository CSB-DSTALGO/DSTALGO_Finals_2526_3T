using System;

public class Student
{
    public string StudentID { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }

    public Student(string studentID, string name, string course)
    {
        StudentID = studentID;
        Name = name;
        Course = course;
    }

    public override string ToString()
    {
        return "ID: " + StudentID +
               " | Name: " + Name +
               " | Course: " + Course;
    }
}