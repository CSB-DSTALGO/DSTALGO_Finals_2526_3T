// CourseCurriculum.cs
using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class CourseCurriculum
    {
        private readonly CustomSinglyLinkedList<Course> _curriculum;

        public CourseCurriculum()
        {
            _curriculum = new CustomSinglyLinkedList<Course>();
        }

        public void InsertCourse(Course course)
        {
            _curriculum.AddLast(course);
            throw new NotImplementedException();

        }

        public bool RemoveCourse (string courseCode)
        {
            Course? Delete = SearchCourse(courseCode);
            if ( Delete != null)
            {
                _curriculum.Remove(Delete);
                return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public Course SearchCourse(string courseCode)
        {
            Node<Course>? current = _curriculum.Head;
            while ( current != null )
            {
                if (current.Data.Code.Equals (courseCode))
                {
                    return current.Data;
                }
                current = current.Next;
            }
            return null;
            throw new NotImplementedException();
        }

        public void ShowCurriculum()
        {
            SortCurriculum();
            Node<Course>? current = _curriculum.Head;
            if ( current == null )
            {
                Console.WriteLine("The curriculum is empty.");
                return;
            }
            while ( current != null )
            {
                Console.WriteLine($"Code: {current.Data.Code} | Title: {current.Data.Title} | Units: {current.Data.Units}");
                current = current.Next;
            }
            
            throw new NotImplementedException();
        }
        public int GetTotalUnits()
        {
            int total = 0;
            Node<Course>? current = _curriculum.Head;
            while ( current != null )
            {
                total += current.Data.Units;
                current = current.Next;
            }
            return total;
            throw new NotImplementedException();
        }

       public void SortCurriculum()
        {
            if (_curriculum.Head == null)
            {
                return;
            }
            Node<Course>? head = null;
            Node<Course>? current = _curriculum.Head;
            while (current!= null)
            {

                Node <Course>? next = current.Next;
                if (head == null || current.Data.Code.CompareTo(head.Data.Code) < 0)
                {
                    current.Next = head;
                    head = current;
                }
                else
                {
                    Node<Course> search = head;
                    while (search.Next != null && search.Next.Data.Code.CompareTo(current.Data.Code) < 0)
                    {
                        search = search.Next;
                    }
                    current.Next = search.Next;
                    search.Next = current;
                }
                current = next;
            }
            _curriculum.Head = head;
        }
    }
}