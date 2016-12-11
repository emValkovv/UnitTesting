using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name)
        {
            this.Name = name;
            this.uniqueNumber = UniqueId.GenerateId();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name can't be null!");
                }
                else if(value.Trim() == "")
                {
                    throw new ArgumentNullException("The name can't be null!");
                }
                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                this.uniqueNumber = value;
            }
        }

        public void JoinCourse (Course course)
        {
            course.AddStudent(this);
        }

        public void LeaveCourse (Course course)
        {
            course.RemoveStudent(this);
        }
    }
}
