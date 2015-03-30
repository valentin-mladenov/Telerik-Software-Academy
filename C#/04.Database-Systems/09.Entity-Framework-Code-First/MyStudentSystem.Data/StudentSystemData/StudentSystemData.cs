namespace MyStudentSystem.Data.StudentSystemData
{
    using System;
    using System.Collections.Generic;

    using MyStudentSystem.Data.Repositories;
    using MyStudentSystem.Model;

    public class StudentSystemData : IStudentSystemData
    {
        private IMyStudentSystemContext context;
        private IDictionary<Type, object> repositories;

        public StudentSystemData(IMyStudentSystemContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public StudentSystemData()
            : this(new MyStudentSystemContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Course> Courses
        {
            get { return new GenericRepository<Course>(this.context);}
        }

        public IGenericRepository<Student> Students
        {
            get { return new GenericRepository<Student>(this.context); }
        }

        public IGenericRepository<Homework> Homeworks
        {
            get { return new GenericRepository<Homework>(this.context); }
        }

        public IGenericRepository<Material> Materials
        {
            get { return new GenericRepository<Material>(this.context); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}