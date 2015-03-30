namespace ATMDataBase.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    public class ATMDataBaseContext : DbContext, IATMDataBaseContext
    {
        public ATMDataBaseContext()
            : base("ATMDatabase")
        {
        }

        //public ATMDataBaseContext()
        //    : base("ATMDatabase")
        //{
        //}

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionHistory> TransactionHistories { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}