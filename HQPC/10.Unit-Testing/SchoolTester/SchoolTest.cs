namespace SchoolTester
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorNameTest()
        {
            string name = "Telerik Academy";

            School school = new School(name);

            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void SchoolStudentAddTest()
        {
            string name = "Telerik Academy";
            School school = new School(name);
            Student student = new Student("Pesho", 12365);


            school.AddStudent(student);

            Assert.IsTrue(school.GetStudents.Count == 1, "Incorrect adding");
        }

        [TestMethod]
        public void SchoolStudentDeleteTest()
        {
            string name = "Telerik Academy";
            School school = new School(name);
            Student student = new Student("Pesho", 12365);

            school.AddStudent(student);
            school.DeleteStudent(student);

            Assert.IsTrue(school.GetStudents.Count == 0, "There are still students in School");
        }

        [TestMethod]
        public void SchoolGetStudentsTest()
        {
            string name = "Telerik Academy";
            School school = new School(name);
            Student student = new Student("Pesho", 12365);

            school.AddStudent(student);
            Student studInSchool = school.GetStudents[0];

            Assert.AreEqual(student, studInSchool);
        }

        [TestMethod]
        public void SchoolCourseAddTest()
        {
            string schoolName = "Telerik Academy";
            School school = new School(schoolName);
            string courseName = "HQPC";
            Course course = new Course(courseName);

            school.AddCourse(course);

            Assert.IsTrue(school.GetCourses.Count == 1, "Incorrect adding of course");
        }


        [TestMethod]
        public void SchoolCourseDeleteTest()
        {
            string SchoolName = "Telerik Academy";
            School school = new School(SchoolName);
            string courseName = "HQPC";
            Course course = new Course(courseName);

            school.AddCourse(course);
            school.DeleteCourse(course);

            Assert.IsTrue(school.GetCourses.Count == 0, "There are still courses in School");
        }

        [TestMethod]
        public void SchoolGetCoursesTest()
        {
            string SchoolName = "Telerik Academy";
            School school = new School(SchoolName);
            string courseName = "HQPC";
            Course course = new Course(courseName);

            school.AddCourse(course);
            Course courseInSchool = school.GetCourses[0];

            Assert.AreEqual(course, courseInSchool);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            string name = "Telerik Academy";
            School school = new School(name);

            Course javascript = new Course("Javascript");
            school.DeleteCourse(javascript);
        }
    }
}