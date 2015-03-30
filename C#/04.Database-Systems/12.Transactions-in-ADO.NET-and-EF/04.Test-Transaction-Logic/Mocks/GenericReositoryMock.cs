namespace _04.Test_Transaction_Logic.Mocks
{
    using System.Collections.Generic;

    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    public abstract class GenericReositoryMock : IGenericReositoryMock
    {
        public GenericReositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeCardsRepositoryMock();
        }

        public IGenericRepository<TransactionHistory> TransactionHistories { get; protected set; }

        public IGenericRepository<CardAccount> CardAccounts { get; protected set; }

        protected ICollection<CardAccount> FakeAccountsCollection { get; private set; }

        protected ICollection<TransactionHistory> FakeTransactionHistoryCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeAccountsCollection = new List<CardAccount>
            {
                new CardAccount("1234567890", "2005", 19863.23M),
                new CardAccount("1234567892", "2205", 29863.23M),
                new CardAccount("1234567893", "2035", 39863.23M),
                new CardAccount("1234567891", "2105", 49863.23M)
            };

            this.FakeTransactionHistoryCollection = new List<TransactionHistory>
            {
                new TransactionHistory(new CardAccount("1234567890", "2005", 19863.23M), 100.23M),
                new TransactionHistory(new CardAccount("1234567892", "2205", 29863.23M), 200.23M),
                new TransactionHistory(new CardAccount("1234567893", "2035", 39863.23M), 300.23M),
                new TransactionHistory(new CardAccount("1234567891", "2105", 49863.23M), 400.23M)
            };
        }

        protected abstract void ArrangeCardsRepositoryMock();
    }
}
