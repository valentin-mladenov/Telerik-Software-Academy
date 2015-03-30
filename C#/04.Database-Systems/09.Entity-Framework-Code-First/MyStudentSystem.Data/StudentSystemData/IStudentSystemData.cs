namespace MyStudentSystem.Data.StudentSystemData
{
    using MyStudentSystem.Data.Repositories;
    using MyStudentSystem.Model;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Student> Students { get; }

        IGenericRepository<Homework> Homeworks { get; }

        IGenericRepository<Material> Materials { get; }
    }
}