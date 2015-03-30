namespace ATMDataBase.Data.ATMDatabaseData
{
    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    public interface IATMDatabaseData
    {
        IGenericRepository<CardAccount> CardAccounts { get; }

        IGenericRepository<TransactionHistory> TransactionHistories { get; }
    }
}
