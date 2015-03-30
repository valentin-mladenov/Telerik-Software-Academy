// The mocks works with the actual database i don't understand.
// What else i have to mock.... the database, the context
// This is becoming annoing.
// The border test are not the problem here. This mocking business is.
// I give up, simply don't know more.
// I decide to use TransactionScope to cancel the transaction after test. THIS IS NOT CORRECT.
namespace _04.Test_Transaction_Logic
{
    using System.Transactions;

    using ATMDataBase.ConsoleApp;
    using ATMDataBase.Data;
    using ATMDataBase.Data.ATMDatabaseData;
    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _04.Test_Transaction_Logic.Mocks;

    [TestClass]
    public class ATMTransactionsTest
    {

        private readonly IGenericRepository<CardAccount> cardsData;
        private IGenericRepository<TransactionHistory> transactionsData;
        private ATMDatabaseData db;
        private ATMDataBaseContext context;

        public ATMTransactionsTest()
            : this(new JustMockGenericRepository())
        {
        }

        public ATMTransactionsTest(IGenericReositoryMock cardsDataMock)
        {
            this.cardsData = cardsDataMock.CardAccounts;
            this.transactionsData = cardsDataMock.TransactionHistories;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.context = new ATMDataBaseContext();
            this.db = new ATMDatabaseData(this.context);
        }

        [TestMethod]
        public void AddAccountCardsTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                var trans = new ATMTransactions();

                trans.AddAccountCards(this.db);

                scope.Dispose();
            }
        }

        [TestMethod]
        public void WithdrawlMoneyTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var trans = new ATMTransactions();

                trans.WithdrawlMoney(this.db, this.context, true);
                
                scope.Dispose();
            }
        }
    }
}
