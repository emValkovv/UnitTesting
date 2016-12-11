using StudentsAndCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Course
    {
        private string nameOfCourse;
        private ICollection<Student> courseStudents;

        public Course(string nameOfCourse)
        {
            this.NameOfCourse = nameOfCourse;
            this.CourseStudents = new List<Student>();
        }

        public string NameOfCourse
        {
            get
            {
                return this.nameOfCourse;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tha name of course can't be null!");
                }
                if (value.Trim() == "")
                {
                    throw new ArgumentNullException("Tha name of course can't be null!");
                }
                this.nameOfCourse = value;
            }
        }

        public ICollection<Student> CourseStudents
        {
            get
            {
                return new List<Student>(this.courseStudents);
            }
            private set
            {
                this.courseStudents = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (courseStudents.Count < 30)
            {
                courseStudents.Add(student);
            }
            else
            {
                throw new ArgumentException("The course can't have more than 30 students!");
            }
        }

        public void RemoveStudent(Student student)
        {
            if (courseStudents.Count > 0)
            {
                courseStudents.Remove(student);
            }
            else
            {
                throw new ArgumentException("The course can't have less than 1 students!");
            }
        }
    }
}
