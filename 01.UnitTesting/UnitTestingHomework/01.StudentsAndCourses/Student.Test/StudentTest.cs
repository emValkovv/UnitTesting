using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsAndCourses;
using System.Collections;
using System.Collections.Generic;

namespace StudentAndCourses.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentName_ShouldBeLike_InputName()
        {
            string name = "Petar";
            var obj = new Student(name);

            Assert.AreEqual(name, obj.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentName_CantBe_Null()
        {
            string name = null;
            var obj = new Student(name);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentName_CantBe_NullWithDoubleComma()
        {
            string name = "";
            var obj = new Student(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentName_CantBe_NullWithSpaces()
        {
            string name = "      ";
            var obj = new Student(name);
        }

        [TestMethod]
        public void Id_MustBe_Unique()
        {
            var studentOne = new Student("Ivan");
            var studentTwo = new Student("Georgi");

            Assert.AreNotEqual(studentOne.UniqueNumber, studentTwo.UniqueNumber);
        }

        [TestMethod]
        public void Students_JoinCourse_Join()
        {
            var studentOne = new Student("Ivan");
            var course = new Course("Math");
            studentOne.JoinCourse(course);

            Assert.AreEqual(1, course.CourseStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LeaveCourse_JoinNull()
        {
            var studentOne = new Student("Ivan");
            var courseOne = new Course(null);

            studentOne.JoinCourse(courseOne);
        }

        [TestMethod]
        public void Student_LeaveCourse_Leave()
        {
            var studentOne = new Student("Ivan");
            var courseOne = new Course("Math");

            studentOne.JoinCourse(courseOne);
            studentOne.LeaveCourse(courseOne);

            Assert.AreEqual(0, courseOne.CourseStudents.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LeaveCourse_LeaveNull()
        {
            var studentOne = new Student("Ivan");
            var courseOne = new Course(null);

            studentOne.LeaveCourse(courseOne);
        }
    }
}
