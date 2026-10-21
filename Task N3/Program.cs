namespace Task_N3
{
    class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; }

        public Student(int studentId, string name, int age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;
            this.Courses = new List<Course>();

        }

        public bool Enroll(Course course)
        {
            this.Courses.Add(course);
            return true;
        }
        public string PrintDetails()
        {
            return $"Student Id: {StudentId}, Student Name: {Name}, Age: {Age}";
        }

    }

    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(int instructorId, string name, string Specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = Specialization;
        }

        public string PrintDetails()
        {
            return $"Instructor Id: {InstructorId}, Name: {Name}, Specialization: {Specialization}";
        }

    }

    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }
        public Course(int courseId, string Title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = Title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            return $"Course Id: {CourseId}, Title: {Title}, Instructor: {Instructor.Name}";
        }
    }
    class School
    {
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }
        public List<Instructor> Instructors { get; set; }

        public School()
        {
            this.Students = new List<Student>();
            this.Courses = new List<Course>();
            this.Instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            this.Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            this.Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            this.Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].StudentId == studentId)
                {
                    return this.Students[i];
                }
            }

            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].CourseId == courseId)
                {
                    return this.Courses[i];
                }
            }

            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < this.Instructors.Count; i++)
            {
                if (this.Instructors[i].InstructorId == instructorId)
                {
                    return this.Instructors[i];
                }
            }

            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                student.Enroll(course);
                return true;
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //Student st1 = new Student(1, "Abdelaziz", 26);
            //Instructor inst1 = new Instructor(1, "Bahaa", "C#");
            //Course c1 = new Course(1, "Angular", inst1);
            //School school = new School();

            //school.AddStudent(st1);
            //school.AddInstructor(inst1);
            //school.AddCourse(c1);

            //st1.Enroll(new Course(1, "Angular", new Instructor(1, "Bahaa", "Programming")));

            //st1.Enroll(new Course(2, "React", new Instructor(2, "Ahmed", "Programming")));


            //Console.WriteLine(st1.PrintDetails());
            //Console.WriteLine(inst1.PrintDetails());
            //Console.WriteLine(c1.PrintDetails());
            //Console.WriteLine(school.FindStudent(1).PrintDetails());
            //Console.WriteLine(school.FindCourse(1).PrintDetails());
            //Console.WriteLine(school.FindInstructor(1).PrintDetails());


            School school = new School();

            int choice;

            do
            {
                Console.WriteLine("\n===== Student Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student by ID or Name");
                Console.WriteLine("9. Find Course by ID or Name");
                Console.WriteLine("10. Exit");

                Console.Write("Choose an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Add Student
                        Console.Write("Enter Student ID: ");
                        int studentId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Student Name: ");
                        string StudentName = Console.ReadLine();

                        Console.Write("Enter Student Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student(studentId, StudentName, age);

                        if (school.AddStudent(student))
                        {
                            Console.WriteLine("Student added successfully!");
                        }

                        break;

                    case 2:
                        // Add Instructor
                        Console.Write("Enter Instructor ID: ");
                        int instructorId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Instructor Name: ");
                        string InstructorName = Console.ReadLine();

                        Console.Write("Enter Specialization: ");
                        string specialization = Console.ReadLine();

                        Instructor instructor = new Instructor(
                            instructorId, InstructorName, specialization
                        );

                        if (school.AddInstructor(instructor))
                        {
                            Console.WriteLine("Instructor added successfully!");
                        }

                        break;

                    case 3:
                        // Add Course
                        Console.Write("Enter Course ID: ");
                        int courseId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Course Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Instructor ID: ");
                        int instId = Convert.ToInt32(Console.ReadLine());

                        Instructor inst = school.FindInstructor(instId);


                        Course course = new Course(courseId, title, inst);

                        if (school.AddCourse(course))
                        {
                            Console.WriteLine("Course added successfully!");
                        }

                        break;

                    case 4:
                        // Enroll Student in Course
                        Console.Write("Enter Student ID: ");
                        int studId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Course ID: ");
                        int couId = Convert.ToInt32(Console.ReadLine());

                        bool enrolled = school.EnrollStudentInCourse(studId, couId);

                        if (enrolled)
                        {
                            Console.WriteLine("Student enrolled successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Student or course not found");
                        }

                        break;

                    case 5:
                        // Show All Students
                        if (school.Students.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            Console.WriteLine("All Students:");
                            for (int i = 0; i < school.Students.Count; i++)
                            {
                                Console.WriteLine(school.Students[i].PrintDetails());
                            }
                        }
                        break;

                    case 6:
                        // Show All Courses
                        if (school.Courses.Count == 0)
                        {
                            Console.WriteLine("No courses found.");
                        }
                        else
                        {
                            Console.WriteLine("All Courses:");
                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                Console.WriteLine(school.Courses[i].PrintDetails());
                            }
                        }
                        break;

                    case 7:
                        // Show All Instructors
                        if (school.Instructors.Count == 0)
                        {
                            Console.WriteLine("No Instructors found.");
                        }
                        else
                        {
                            Console.WriteLine("All Instructors:");
                            for (int i = 0; i < school.Instructors.Count; i++)
                            {
                                Console.WriteLine(school.Instructors[i].PrintDetails());
                            }
                        }
                        break;

                    case 8:
                        // Find Student

                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by Name");
                        Console.Write("Choose search method: ");

                        int searchChoice = Convert.ToInt32(Console.ReadLine());

                        if (searchChoice == 1)
                        {
                            Console.Write("Enter Student ID: ");
                            int sId = Convert.ToInt32(Console.ReadLine());

                            Student Fstudent = school.FindStudent(sId);

                            if (Fstudent != null)
                            {
                                Console.WriteLine(Fstudent.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                        }
                        else if (searchChoice == 2)
                        {
                            Console.Write("Enter Student Name: ");
                            string name = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i < school.Students.Count; i++)
                            {
                                if (school.Students[i].Name.Contains(name))
                                {
                                    Console.WriteLine(school.Students[i].PrintDetails());
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Student not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid search choice.");
                        }

                        break;


                    case 9:
                        // Find Course
                        Console.WriteLine("1. Find by ID");
                        Console.WriteLine("2. Find by Name");
                        Console.Write("Choose search method: ");

                        int searchC = Convert.ToInt32(Console.ReadLine());

                        if (searchC == 1)
                        {
                            Console.Write("Enter Course ID: ");
                            int cId = Convert.ToInt32(Console.ReadLine());

                            Course Fcourse = school.FindCourse(cId);

                            if (Fcourse != null)
                            {
                                Console.WriteLine(Fcourse.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        else if (searchC == 2)
                        {
                            Console.Write("Enter Course Name: ");
                            string name = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i < school.Courses.Count; i++)
                            {
                                if (school.Courses[i].Title.Contains(name))
                                {
                                    Console.WriteLine(school.Courses[i].PrintDetails());
                                    found = true;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid search choice.");
                        }

                        break;

                    case 10:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 10);


        }
    }
}
