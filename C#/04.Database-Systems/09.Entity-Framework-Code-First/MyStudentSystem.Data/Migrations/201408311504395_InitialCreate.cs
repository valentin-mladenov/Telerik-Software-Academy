namespace MyStudentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MaterialID = c.Int(nullable: false),
                        HomeworkID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        HomworkID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TimeSent = c.DateTime(nullable: false),
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HomworkID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        FacultyNumber = c.Guid(nullable: false),
                        CourseID = c.Int(nullable: false),
                        HomeworkID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialID = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseID })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materials", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Homework", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Homework", "CourseID", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropIndex("dbo.Materials", new[] { "CourseID" });
            DropIndex("dbo.Homework", new[] { "StudentID" });
            DropIndex("dbo.Homework", new[] { "CourseID" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Materials");
            DropTable("dbo.Students");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
        }
    }
}