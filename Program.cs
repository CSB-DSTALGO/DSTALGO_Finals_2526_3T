using ConsoleApp19;
using System;

class Program
{
    static MyArrayList<Student> students = new MyArrayList<Student>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine();
            Console.WriteLine("===== ENROLLMENT SYSTEM =====");
            Console.WriteLine("1. Enroll Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Remove Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    EnrollStudent();
                    break;

                case 2:
                    ViewStudents();
                    break;

                case 3:
                    SearchStudent();
                    break;

                case 4:
                    RemoveStudent();
                    break;

                case 5:
                    Console.WriteLine("Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 5);
    }

    static void EnrollStudent()
    {
        Console.Write("Student ID: ");
        string id = Console.ReadLine();

        Console.Write("Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Course: ");
        string course = Console.ReadLine();

        students.Add(new Student(id, name, course));

        Console.WriteLine("Student enrolled successfully!");
    }

    static void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students enrolled.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("===== STUDENT LIST =====");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students.Get(i));
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < students.Count; i++)
        {
            Student s = students.Get(i);

            if (s.StudentID == id)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine(s);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void RemoveStudent()
    {
        Console.Write("Enter Student ID: ");
        string id = Console.ReadLine();

        for (int i = 0; i < students.Count; i++)
        {
            if (students.Get(i).StudentID == id)
            {
                students.RemoveAt(i);
                Console.WriteLine("Student removed successfully.");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }
}