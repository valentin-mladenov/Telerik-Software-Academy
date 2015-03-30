namespace MyStudentSystem.Data.Migrations
{
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Migrations;

    using MyStudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<MyStudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "MyStudentSystem.Data.MyStudentSystemContext";
        }

        protected override void Seed(MyStudentSystemContext context)
        {
            var student = new Student { FullName = "Suc Kseed", };
            var course = new Course { Description = "Working", Name = "Entity Framework" };
            course.Students.Add(student);

            context.Students.Add(student);
            context.Courses.Add(course);
        }
    }
}