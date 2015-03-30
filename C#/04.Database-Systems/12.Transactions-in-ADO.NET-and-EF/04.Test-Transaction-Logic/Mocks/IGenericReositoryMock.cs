namespace _04.Test_Transaction_Logic.Mocks
{
    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    public interface IGenericReositoryMock
    {
        IGenericRepository<TransactionHistory> TransactionHistories {get;}

        IGenericRepository<CardAccount> CardAccounts { get; }
    }
}
