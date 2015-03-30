namespace _01.Connect_To_Northwind
{
    using System.Data.Entity;

    public interface ICustomNorthwindEntity
    {
        int SaveChanges();

        DbSet<Customer> Customers { get; set; }
    }
}