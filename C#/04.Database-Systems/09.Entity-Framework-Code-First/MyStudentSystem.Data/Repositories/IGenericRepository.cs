namespace MyStudentSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T> where T: class
    {
        IQueryable<T> All();

        IQueryable<T> FindThis(Expression<Func<T, bool>> condition);

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        void Detach(T entity);
    }
}