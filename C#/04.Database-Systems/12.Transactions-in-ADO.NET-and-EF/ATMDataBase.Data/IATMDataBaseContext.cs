namespace ATMDataBase.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using ATMDataBase.Model;

    public interface IATMDataBaseContext
    {
        IDbSet<CardAccount> CardAccounts { get; set; }

        IDbSet<TransactionHistory> TransactionHistories { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}