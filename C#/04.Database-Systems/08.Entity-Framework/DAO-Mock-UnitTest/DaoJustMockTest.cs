namespace DAO_Mock_UnitTest
{
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using _01.Connect_To_Northwind;
    using _01.Connect_To_Northwind.DAO;

    [TestClass]
    public class DaoJustMockTest
    {
        [TestMethod]
        public void InsertNewCustomer()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CustomNorthwindEntity>());

            var mockContext = new CustomNorthwindEntity();
            var mockSet = new Mock<DbSet<Customer>>();
            var ataroClima = new Customer() { CustomerID = "BGLEC", CompanyName = "Ataro Climca EOOD" };

            //mockContext.Setup(c => c.Customers.Add(It.IsAny<Customer>())).Returns(ataroClima);
            //mockContext.Setup(c => c.Customers.Any()).Returns(false);
           // mockContext.Setup(c => c.SaveChanges()).Equals(true);

            var dao = new Dao(mockContext);

            dao.InsertCustomer(ataroClima);
        }
    }
}