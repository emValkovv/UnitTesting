using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAndCourses;

namespace StudentAndCourses.Test
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void NameOfCourse_ShouldBe_Correctly()
        {
            var course = new Course("Math");

            Assert.AreEqual("Math", course.NameOfCourse);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameOfCourse_CantBe_Null()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameOfCourse_CantBe_OnlyWhiteSpaces()
        {
            var course = new Course("    ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameOfCourse_CantBe_OnlyWithDoubleComma()
        {
            var course = new Course("");
        }

        [TestMethod]
        public void AddStudentToCourse()
        {
            var course = new Course("Math");
            var studentOne = new Student("Ivan");
            var studentTwo = new Student("Georgi");

            course.AddStudent(studentOne);
            course.AddStudent(studentTwo);

            Assert.AreEqual(2, course.CourseStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullStudentToCourse()
        {
            var course = new Course("Math");
            var studentOne = new Student(null);

            course.AddStudent(studentOne);
        }

        [TestMethod]
        public void StudentLeaveCourse()
        {
            var course = new Course("Math");
            var studentOne = new Student("Ivan");
            var studentTwo = new Student("Georgi");

            course.AddStudent(studentOne);
            course.AddStudent(studentTwo);
            course.RemoveStudent(studentTwo);

            Assert.AreEqual(1, course.CourseStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingMoreThan30StudentsToCourse()
        {
            var course = new Course("Math");
            for (int i = 0; i <= 30; i++)
            {
                string number = i.ToString();
                course.AddStudent(new Student(number));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovingStudentFromEmptyCourse()
        {
            var course = new Course("Math");
            var studentOne = new Student("Georgi");

            course.RemoveStudent(studentOne);
        }
    }
}
