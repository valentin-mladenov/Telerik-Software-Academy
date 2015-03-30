namespace MyStudentSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MyStudentSystem.Data.Migrations;
    using MyStudentSystem.Model;

    public class MyStudentSystemContext : DbContext, IMyStudentSystemContext
    {
        public MyStudentSystemContext()
            : base("MyStudentSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyStudentSystemContext, Configuration>());
        }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Material> Materials { get; set; }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}