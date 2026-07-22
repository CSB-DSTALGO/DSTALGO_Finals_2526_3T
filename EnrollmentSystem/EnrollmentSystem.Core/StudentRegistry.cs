using System;
using DataStructuresLibrary;

namespace EnrollmentSystem.Core
{
    /// <summary>
    /// Student Registry module utilizing CustomArrayList for in-memory student record lifecycle operations.
    /// Provides sorting via QuickSort and lookups via Binary Search.
    /// </summary>
    public class StudentRegistry
    {
        // Underlying custom array list storage for Student entities
        private readonly CustomArrayList<Student> _registry;

        /// <summary>
        /// Tracks whether registry is currently sorted by Student ID to validate Binary Search preconditions.
        /// </summary>
        private bool _isSortedById;

        /// <summary>
        /// Initializes a new instance of StudentRegistry.
        /// </summary>
        public StudentRegistry()
        {
            _registry = new CustomArrayList<Student>();
            _isSortedById = false;
        }

        /// <summary>
        /// Inserts a new Student entity record into the registry array.
        /// UML Signature: + RegisterStudent(s: Student): void
        /// </summary>
        /// <param name="student">Student instance to register.</param>
        /// <exception cref="ArgumentNullException">Thrown if student reference is null.</exception>
        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Cannot register null student record.");
            }

            _registry.Add(student);
            _isSortedById = false; // New un-sorted element inserted
        }

        /// <summary>
        /// Removes student record at target index and shifts array items left.
        /// UML Signature: + UnregisterStudent(idx: int): void
        /// </summary>
        /// <param name="index">Target array index to unregister.</param>
        public void UnregisterStudent(int index)
        {
            _registry.RemoveAt(index);
        }

        /// <summary>
        /// Fetches and prints student record details at specified index to console UI.
        /// UML Signature: + GetStudentDetails(idx: int): void
        /// </summary>
        /// <param name="index">Target array index.</param>
        public void GetStudentDetails(int index)
        {
            Student student = _registry.Get(index);
            Console.WriteLine("=== STUDENT RECORD DETAILS ===");
            Console.WriteLine($"Index Location : {index}");
            Console.WriteLine($"Student Info   : {student}");
        }

        /// <summary>
        /// Prints complete list of enrolled students stored in array list.
        /// UML Signature: + ShowAllStudents(): void
        /// </summary>
        public void ShowAllStudents()
        {
            if (_registry.Count == 0)
            {
                Console.WriteLine("No enrolled students found in the registry.");
                return;
            }

            Console.WriteLine("=== CURRENT ENROLLED STUDENTS REGISTRY ===");
            for (int i = 0; i < _registry.Count; i++)
            {
                Student student = _registry.Get(i);
                Console.WriteLine($"[Index {i}] {student}");
            }
        }

        /// <summary>
        /// Sorts enrolled students ascending by Student ID using QuickSort algorithm.
        /// </summary>
        public void SortRegistryById()
        {
            // Execute QuickSort passing Student ID comparison delegate
            _registry.QuickSort((s1, s2) => s1.Id.CompareTo(s2.Id));
            _isSortedById = true;
            Console.WriteLine("Student registry successfully sorted by Student ID (QuickSort).");
        }

        /// <summary>
        /// Searches for student record by ID using Binary Search algorithm.
        /// </summary>
        /// <param name="studentId">Target Student ID integer lookup.</param>
        /// <returns>Zero-based index of matched student, or -1 if not found.</returns>
        public int SearchStudentById(int studentId)
        {
            if (!_isSortedById)
            {
                SortRegistryById();
            }

            return _registry.BinarySearch(
                studentId,
                student => student.Id,
                (id1, id2) => id1.CompareTo(id2)
            );
        }

        public int GetStudentCount() => _registry.Count;

        public Student GetStudentAt(int index) => _registry.Get(index);

        public bool RemoveStudent(int id)
        {
            for (int i = 0; i < _registry.Count; i++)
            {
                if (_registry.Get(i).Id == id)
                {
                    _registry.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
