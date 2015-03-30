namespace _01.Connect_To_Northwind
{
    using System.Data.Entity;

    public class CustomNorthwindEntity : NorthwindEntities, ICustomNorthwindEntity
    {
        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new DbSet<Customer> Customers
        {
            get
            {
                return base.Customers;
            }
            set
            {
                base.Customers = value;
            }
        }
    }
}