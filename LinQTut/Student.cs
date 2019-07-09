using System;
using System.Collections.Generic;

namespace LinQTut
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }
        public int CityId { get; private set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student
                {
                    StudentID = 1,
                    Name = "Marcin",
                    CityId = 1,
                    TotalMarks = 1000

                },
                new Student
                {
                    StudentID = 2,
                    Name = "Monika",
                    CityId = 2,
                    TotalMarks = 1100

                },
                new Student
                {
                    StudentID = 3,
                    Name = "Marta",
                    CityId = 3,
                    TotalMarks = 1200

                },
                new Student
                {
                    StudentID = 4,
                    Name = "Maciej",
                    CityId = 4,
                    TotalMarks = 1300

                },
                new Student
                {
                    StudentID = 5,
                    Name = "Milena",
                    CityId = 4,
                    TotalMarks = 1400
                },
                new Student
                {
                    StudentID = 6,
                    Name = "Małgosia",
                    CityId = 5,
                    TotalMarks = 1600
                },   new Student
                {
                    StudentID = 7,
                    Name = "Małgosia",

                    TotalMarks = 1700
                },
                  new Student
                {
                    StudentID = 8,
                    Name = "Gosia",
                    CityId = 6,
                    TotalMarks = 1700
                }
            };
            return students;
        }

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   StudentID == student.StudentID &&
                   Name == student.Name &&
                   TotalMarks == student.TotalMarks &&
                   CityId == student.CityId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StudentID, Name, TotalMarks, CityId);
        }
    }
}
