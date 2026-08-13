// StudentRegistry.cs
// Member 1's module: wraps a CustomArrayList<Student> and exposes the
// business-level operations needed by the Enrollment Management System.
using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    public class StudentRegistry
    {
        private readonly CustomArrayList<Student> _registry;

        public StudentRegistry()
        {
            _registry = new CustomArrayList<Student>();
        }

        /// <summary>
        /// Inserts a new student record at the end of the registry.
        /// Delegates directly to CustomArrayList.Add -> amortized O(1).
        /// </summary>
        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _registry.Add(student);
        }

        /// <summary>
        /// Removes the student record stored at the given index.
        /// Delegates to CustomArrayList.RemoveAt -> O(n) worst case (element shift).
        /// </summary>
        public void UnregisterStudent(int index)
        {
            _registry.RemoveAt(index);
        }

        /// <summary>
        /// Returns the student record stored at the given index. O(1).
        /// </summary>
        public Student GetStudentDetails(int index)
        {
            return _registry.Get(index);
        }

        /// <summary>
        /// Prints every currently registered student to the console.
        /// </summary>
        public void ShowAllStudents()
        {
            Console.WriteLine("--- Student Registry ---");
            if (_registry.Count == 0)
            {
                Console.WriteLine("(No students registered yet.)");
                return;
            }

            for (int i = 0; i < _registry.Count; i++)
            {
                Student s = _registry.Get(i);
                Console.WriteLine($"[{i}] ID: {s.Id} | Name: {s.Name} | Course: {s.CourseCode}");
            }
        }

        // ------------------------------------------------------------------
        // Convenience/compatibility helpers used by the provided ConsoleApp
        // and the provided EnrollmentSystem.Tests scaffold. These sit on top
        // of the same underlying CustomArrayList and don't duplicate storage.
        // ------------------------------------------------------------------

        /// <summary>Total number of students currently registered. O(1).</summary>
        public int GetStudentCount()
        {
            return _registry.Count;
        }

        /// <summary>Alias of GetStudentDetails for the console/test scaffold. O(1).</summary>
        public Student GetStudentAt(int index)
        {
            return _registry.Get(index);
        }

        /// <summary>
        /// Finds and removes a student by their Id rather than by index.
        /// Uses a linear search (see SearchStudentById) followed by RemoveAt.
        /// Returns true if a matching student was found and removed.
        /// </summary>
        public bool RemoveStudent(string id)
        {
            int index = LinearSearchIndexById(id);
            if (index == -1)
            {
                return false;
            }

            _registry.RemoveAt(index);
            return true;
        }

        // ------------------------------------------------------------------
        // Sorting and Search Algorithm Integration
        //
        // Algorithm chosen: Bubble Sort + Binary Search.
        //
        // Mechanism: Bubble Sort repeatedly walks the array comparing each pair
        // of neighboring elements, swapping them whenever they are out of
        // order, and "bubbling" the largest remaining unsorted element towards
        // the end of the array on every pass. It stops early if a full pass
        // completes with no swaps, meaning the array is already sorted.
        //
        // Once the registry is sorted by Student Id, Binary Search can be used
        // to locate a specific Id: it repeatedly halves the search range by
        // comparing the target against the middle element, discarding the half
        // of the array that cannot contain the target.
        //
        // Efficiency / time complexity:
        //  - Bubble Sort: O(n^2) average/worst case, O(n) best case (already
        //    sorted, thanks to the early-exit "swapped" flag). O(1) extra space
        //    since it sorts in place.
        //  - Binary Search: O(log n) time because the search space is halved
        //    on every comparison. Requires the data to already be sorted,
        //    which is why SearchStudentById sorts first.
        // ------------------------------------------------------------------

        /// <summary>
        /// Sorts the registry in place by Student Id (ascending) using Bubble
        /// Sort. O(n^2) worst case, O(n) if the list is already sorted.
        /// </summary>
        public void SortStudentsById()
        {
            int n = _registry.Count;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    Student current = _registry.Get(j);
                    Student next = _registry.Get(j + 1);

                    if (string.Compare(current.Id, next.Id, StringComparison.Ordinal) > 0)
                    {
                        _registry.Set(j, next);
                        _registry.Set(j + 1, current);
                        swapped = true;
                    }
                }

                // If nothing was swapped in a full pass, the list is already sorted.
                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Locates a student by Id using Binary Search. Sorts the registry
        /// first (Bubble Sort) since Binary Search requires sorted data.
        /// Returns the index of the match, or -1 if not found. O(n log n)
        /// overall for an unsorted registry (dominated by the sort), O(log n)
        /// if the registry is already sorted.
        /// </summary>
        public int SearchStudentById(string id)
        {
            SortStudentsById();

            int low = 0;
            int high = _registry.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                Student midStudent = _registry.Get(mid);
                int comparison = string.Compare(midStudent.Id, id, StringComparison.Ordinal);

                if (comparison == 0)
                {
                    return mid;
                }
                else if (comparison < 0)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        /// <summary>
        /// Simple O(n) linear scan used internally by RemoveStudent, where we
        /// cannot assume the registry is sorted and don't want RemoveStudent
        /// to have the side effect of reordering it.
        /// </summary>
        private int LinearSearchIndexById(string id)
        {
            for (int i = 0; i < _registry.Count; i++)
            {
                if (_registry.Get(i).Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
