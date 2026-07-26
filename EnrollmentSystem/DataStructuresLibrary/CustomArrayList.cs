// CustomArrayList.cs
// REVIEW: look at what this file is named, then look at whats actually inside it. theres a
// whole program with a Main living in here, and the name declared right below doesnt match
// where this stuff is supposed to sit. give this one a proper read top to bottom
using System;

namespace StudentRegistryApp
{
    // 1. Data Model
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Program { get; set; }

        public Student(int id, string name, string program)
        {
            Id = id;
            Name = name;
            Program = program;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {Name} | Program: {Program}";
        }
    }

    // 2. Custom Data Structure
    
    public class CustomArrayList<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;

        public CustomArrayList(int initialCapacity = 4)
        {
            _items = new T[initialCapacity];
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of bounds.");
            }
            return _items[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is out of bounds.");
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = default(T);
            _count--;
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            Array.Copy(_items, newArray, _count);
            _items = newArray;
        }
    }

    //implementation of the StudentRegistry class that uses the CustomArrayList to manage student records.
    public class StudentRegistry
    {
        private CustomArrayList<Student> _studentList = new CustomArrayList<Student>();

        // 1. RegisterStudent(Student student): Inserts a record.
        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("\nCannot register a null student record.");
                return;
            }

            _studentList.Add(student);
            Console.WriteLine($"\n✓ Registered successfully: {student.Name}");
        }

        // 2. UnregisterStudent(int index): Removes a record by index.
        public void UnregisterStudent(int index)
        {
            try
            {
                Student removed = _studentList.Get(index);
                _studentList.RemoveAt(index);
                Console.WriteLine($"\n✓ Unregistered: {removed.Name} (at index {index})");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\n[Error]: {ex.Message}");
            }
        }

        // 3. GetStudentDetails(int index): Returns a record by index.
        public Student GetStudentDetails(int index)
        {
            try
            {
                return _studentList.Get(index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\n[Error]: {ex.Message}");
                return null;
            }
        }

        // 4. ShowAllStudents(): Outputs the entire array state.
        public void ShowAllStudents()
        {
            Console.WriteLine("\n================ CURRENT REGISTRY STATE ================");
            if (_studentList.Count == 0)
            {
                Console.WriteLine("Registry is empty.");
            }
            else
            {
                for (int i = 0; i < _studentList.Count; i++)
                {
                    Console.WriteLine($"[Index {i}] {_studentList.Get(i)}");
                }
            }
            Console.WriteLine("========================================================\n");
        }
    }

    //the interactive part of the program that allows users to interact with the StudentRegistry system.
    class Program
    {
        static void Main(string[] args)
        {
            StudentRegistry registry = new StudentRegistry();
            bool running = true;

            while (running)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("       STUDENT REGISTRY SYSTEM          ");
                Console.WriteLine("========================================");
                Console.WriteLine("[1] Register Student");
                Console.WriteLine("[2] Unregister Student by Index");
                Console.WriteLine("[3] Get Student Details by Index");
                Console.WriteLine("[4] Show All Students");
                Console.WriteLine("[5] Exit");
                Console.Write("Enter choice (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Student ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("\n[Error]: Invalid ID number.");
                            break;
                        }

                        Console.Write("Enter Student Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        string program = Console.ReadLine();

                        registry.RegisterStudent(new Student(id, name, program));
                        break;

                    case "2":
                        Console.Write("Enter index to unregister: ");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            registry.UnregisterStudent(removeIndex);
                        }
                        else
                        {
                            Console.WriteLine("\n[Error]: Invalid index input.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter index to view details: ");
                        if (int.TryParse(Console.ReadLine(), out int viewIndex))
                        {
                            Student student = registry.GetStudentDetails(viewIndex);
                            if (student != null)
                            {
                                Console.WriteLine($"\n[Details Found]: {student}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n[Error]: Invalid index input.");
                        }
                        break;

                    case "4":
                        registry.ShowAllStudents();
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("\nExiting System...");
                        break;

                    default:
                        Console.WriteLine("\n[Error]: Invalid option. Select 1 to 5.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
