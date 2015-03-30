namespace SchoolTester
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentConstructorTest()
        {
            string studentName = "Pesho";
            int studentNumber = 12365;

            Student student = new Student(studentName, studentNumber);

            string studName = student.Name;
            int studNumber = student.Number;

            Assert.IsNotNull(student);
            Assert.AreEqual("Pesho", student.Name);
            Assert.AreEqual(12365, student.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentNumberMoreThanAllowedTest()
        {
            string studentName = "Pesho";
            int studentNumber = 123655;

            Student student = new Student(studentName, studentNumber);

            Assert.IsTrue(studentNumber >= 10000 && studentNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentNumberLessThanAllowedTest()
        {
            string studentName = "Pesho";
            int studentNumber = 1236;

            Student student = new Student(studentName, studentNumber);

            Assert.IsTrue(studentNumber >= 10000 && studentNumber <= 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameWhiteSpaceTest()
        {
            string studentName = " ";
            int studentNumber = 12365;

            Student student = new Student(studentName, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameEmptySpaceTest()
        {
            string studentName = string.Empty;
            int studentNumber = 12356;

            Student student = new Student(studentName, studentNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameNullTest()
        {
            string studentName = null;
            int studentNumber = 12356;

            Student student = new Student(studentName, studentNumber);
        }
    }
}