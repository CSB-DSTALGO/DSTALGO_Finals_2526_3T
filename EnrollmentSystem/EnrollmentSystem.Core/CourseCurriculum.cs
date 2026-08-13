// CourseCurriculum.cs
// Member 2's module: wraps a CustomSinglyLinkedList<Course> and exposes the
// business-level operations needed by the Enrollment Management System.
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

        /// <summary>
        /// Appends a course to the end of the curriculum chain. O(1) thanks to
        /// the linked list's internal tail pointer.
        /// </summary>
        public void InsertCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _curriculum.AddLast(course);
        }

        /// <summary>
        /// Removes the course whose Code matches courseCode, if any.
        /// Finds the target with a linear search, then removes it. O(n).
        /// </summary>
        public void DeleteCourse(string courseCode)
        {
            Course? target = FindCourseByCode(courseCode);
            if (target != null)
            {
                _curriculum.Remove(target);
            }
        }

        /// <summary>
        /// Linear search through the chain for a course with the given code.
        /// O(n) - a linked list offers no shortcut for random access, so every
        /// node must potentially be visited.
        /// </summary>
        public Course SearchCourse(string courseCode)
        {
            Course? found = FindCourseByCode(courseCode);
            if (found == null)
            {
                throw new InvalidOperationException($"Course with code '{courseCode}' was not found.");
            }

            return found;
        }

        /// <summary>
        /// Traverses the chain from head to tail, printing every course.
        /// </summary>
        public void ShowCurriculum()
        {
            Console.WriteLine("--- Course Curriculum ---");

            Node<Course>? current = _curriculum.Head;
            if (current == null)
            {
                Console.WriteLine("(No courses in the curriculum yet.)");
                return;
            }

            while (current != null)
            {
                Course c = current.Data;
                Console.WriteLine($"Code: {c.Code} | Title: {c.Title} | Units: {c.Units}");
                current = current.Next;
            }
        }

        // ------------------------------------------------------------------
        // Convenience/compatibility helpers used by the provided ConsoleApp
        // and the provided EnrollmentSystem.Tests scaffold.
        // ------------------------------------------------------------------

        /// <summary>
        /// Alias for DeleteCourse that also reports whether a course was
        /// actually removed. O(n).
        /// </summary>
        public bool RemoveCourse(string courseCode)
        {
            Course? target = FindCourseByCode(courseCode);
            if (target == null)
            {
                return false;
            }

            return _curriculum.Remove(target);
        }

        /// <summary>
        /// Sums the Units of every course currently in the curriculum. O(n).
        /// </summary>
        public int GetTotalUnits()
        {
            int total = 0;
            Node<Course>? current = _curriculum.Head;

            while (current != null)
            {
                total += current.Data.Units;
                current = current.Next;
            }

            return total;
        }

        private Course? FindCourseByCode(string courseCode)
        {
            Node<Course>? current = _curriculum.Head;

            while (current != null)
            {
                if (current.Data.Code == courseCode)
                {
                    return current.Data;
                }
                current = current.Next;
            }

            return null;
        }

        // ------------------------------------------------------------------
        // Sorting and Search Algorithm Integration
        //
        // Algorithm chosen: Insertion Sort (linked-list variant) + Linear Search.
        //
        // Mechanism: Random access (jumping straight to "the middle element")
        // is not possible on a singly linked list the way it is on an array,
        // so array-style algorithms like Binary Search or Quick Sort are a
        // poor fit. Insertion Sort, on the other hand, only ever needs to walk
        // forward from a starting point, which matches how a singly linked
        // list can be traversed. SortCurriculumByCode below detaches nodes one
        // at a time from the original chain and re-inserts each one into its
        // correct position in a second, sorted chain, growing that sorted
        // chain node by node until every course has been placed.
        //
        // SearchCourse (above) already implements the Search side of this
        // requirement: a straightforward Linear Search that walks the chain
        // from head to tail comparing course codes.
        //
        // Efficiency / time complexity:
        //  - Insertion Sort on a linked list: O(n^2) worst/average case (for
        //    each of the n nodes, we may walk up to n nodes of the sorted
        //    portion to find its insertion point). O(1) extra space, since we
        //    only rewire existing nodes rather than allocating a new array.
        //  - Linear Search: O(n) worst case, since a singly linked list must
        //    be walked sequentially - there is no way to skip ahead.
        // ------------------------------------------------------------------

        /// <summary>
        /// Sorts the curriculum in place by Course Code (ascending) using an
        /// Insertion Sort adapted for a singly linked list. O(n^2) worst case.
        /// </summary>
        public void SortCurriculumByCode()
        {
            if (_curriculum.Head == null || _curriculum.Head.Next == null)
            {
                // 0 or 1 elements: already sorted.
                return;
            }

            Node<Course>? sortedHead = null;
            Node<Course>? current = _curriculum.Head;

            // Detach each node from the original chain and insert it into the
            // correct position of a new, sorted chain.
            while (current != null)
            {
                Node<Course> nodeToInsert = current;
                current = current.Next;

                sortedHead = InsertInSortedOrder(sortedHead, nodeToInsert);
            }

            RebuildCurriculumFrom(sortedHead);
        }

        /// <summary>
        /// Inserts a single detached node into its correct position within an
        /// already-sorted chain (by Course Code), returning the new head.
        /// </summary>
        private Node<Course> InsertInSortedOrder(Node<Course>? sortedHead, Node<Course> nodeToInsert)
        {
            if (sortedHead == null ||
                string.Compare(nodeToInsert.Data.Code, sortedHead.Data.Code, StringComparison.Ordinal) < 0)
            {
                nodeToInsert.Next = sortedHead;
                return nodeToInsert;
            }

            Node<Course> current = sortedHead;
            while (current.Next != null &&
                   string.Compare(current.Next.Data.Code, nodeToInsert.Data.Code, StringComparison.Ordinal) < 0)
            {
                current = current.Next;
            }

            nodeToInsert.Next = current.Next;
            current.Next = nodeToInsert;
            return sortedHead;
        }

        /// <summary>
        /// Replaces the contents of _curriculum with the courses from the
        /// given sorted chain, preserving order.
        /// </summary>
        private void RebuildCurriculumFrom(Node<Course>? sortedHead)
        {
            while (_curriculum.Head != null)
            {
                _curriculum.Remove(_curriculum.Head.Data);
            }

            Node<Course>? current = sortedHead;
            while (current != null)
            {
                _curriculum.AddLast(current.Data);
                current = current.Next;
            }
        }
    }
}
