using System;
using System.Collections.Generic;

namespace EnrollmentSystem
{
    public class StudentRegistry
    {
        private MyArrayList<Student> enrolledStudents;
        private MyLinkedList<Student> waitList;
        private int capacity;

        public StudentRegistry(int capacity)
        {
            this.capacity = capacity;
            enrolledStudents = new MyArrayList<Student>();
            waitList = new MyLinkedList<Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (enrolledStudents.Count < capacity)
            {
                enrolledStudents.Add(student);
                Console.WriteLine("Student enrolled successfully.");
            }
            else
            {
                waitList.Add(student);
                Console.WriteLine("Class is full. Student added to waitlist.");
            }
        }

        public void DropStudent(int index)
        {
            if (index < 0 || index >= enrolledStudents.Count)
            {
                Console.WriteLine("Invalid student number.");
                return;
            }

            Student removed = enrolledStudents.Get(index);
            enrolledStudents.RemoveAt(index);

            Console.WriteLine($"{removed.Name} removed.");

            if (waitList.Count > 0)
            {
                Student promoted = waitList.Get(0);
                waitList.RemoveAt(0);
                enrolledStudents.Add(promoted);

                Console.WriteLine($"{promoted.Name} moved from waitlist.");
            }
        }

        public void DisplayEnrolledStudents()
        {
            Console.WriteLine("\n===== ENROLLED STUDENTS =====");

            if (enrolledStudents.Count == 0)
            {
                Console.WriteLine("No students enrolled.");
                return;
            }

            for (int i = 0; i < enrolledStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {enrolledStudents.Get(i)}");
            }
        }

        public void DisplayWaitList()
        {
            Console.WriteLine("\n===== WAITLIST =====");

            if (waitList.Count == 0)
            {
                Console.WriteLine("Waitlist is empty.");
                return;
            }

            for (int i = 0; i < waitList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {waitList.Get(i)}");
            }
        }
    }
}