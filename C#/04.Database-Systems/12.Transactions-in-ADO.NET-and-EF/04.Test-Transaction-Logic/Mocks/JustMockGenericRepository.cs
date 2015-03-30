namespace _04.Test_Transaction_Logic.Mocks
{
    using System.Linq;

    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    using Telerik.JustMock;

    public class JustMockGenericRepository : GenericReositoryMock
    {
        public JustMockGenericRepository()
        {
        }

        protected override void ArrangeCardsRepositoryMock()
        {
            this.CardAccounts = Mock.Create<IGenericRepository<CardAccount>>();
            Mock.Arrange(() => this.CardAccounts.Add(Arg.IsAny<CardAccount>())).DoNothing();
            Mock.Arrange(() => this.CardAccounts.All()).Returns(this.FakeAccountsCollection as IQueryable<CardAccount>);
            Mock.Arrange(() => this.CardAccounts.FindThis(c => c.CardNumber == Arg.AnyString)).Returns(this.FakeAccountsCollection.Where(c => c.CardNumber == "1234567890") as IQueryable<CardAccount>);
            this.TransactionHistories = Mock.Create<IGenericRepository<TransactionHistory>>();
            Mock.Arrange(() => this.TransactionHistories.Add(Arg.IsAny<TransactionHistory>())).DoNothing();
        }
    }
}