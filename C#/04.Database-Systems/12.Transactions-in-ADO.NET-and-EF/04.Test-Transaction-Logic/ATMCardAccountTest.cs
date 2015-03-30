namespace _04.Test_Transaction_Logic
{
    using System;
    using System.Transactions;

    using ATMDataBase.Data;
    using ATMDataBase.Data.ATMDatabaseData;
    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _04.Test_Transaction_Logic.Mocks;

    [TestClass]
    public class ATMCardAccountTest
    {
        private readonly IGenericRepository<CardAccount> cardsData;
        private IGenericRepository<TransactionHistory> transactionsData;
        private ATMDatabaseData db;
        private ATMDataBaseContext context;

        public ATMCardAccountTest()
            : this(new JustMockGenericRepository())
        {
        }

        public ATMCardAccountTest(IGenericReositoryMock cardsDataMock)
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCardWithLongerCardNumberTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("12345678909", "2005", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCardWithShorterCardNumberTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("123456789", "2005", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCardWithLetterInCardNumberTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("12345678h9", "2005", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCardWithEmptyCardNumberTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("", "2005", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCardWithLongerCardPinTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("12345678909", "20005", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddCardWithShorterCardPinTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("1234567829", "205", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCardWithLetterInCardPinTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("1234567829", "2e05", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCardWithEmptyCardPinTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("1234567890", "", 19863.23M);

                this.db.CardAccounts.Add(invalidCard);

                scope.Dispose();
            }
        }

        [TestMethod]
        public void CardAccountToStringMetodTest()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                var invalidCard = new CardAccount("1234567890", "2503", 19863.23M);

                var str = invalidCard.ToString();

                Assert.IsNotNull(str);
                scope.Dispose();
            }
        }
    }
}
