namespace _01.Connect_To_Northwind.DAO
{
    using System;
    using System.Linq;

    public class Dao : IDao
    {
        private ICustomNorthwindEntity entity;

        public Dao(ICustomNorthwindEntity entity)
        {
            this.entity = entity;
        }
        public void InsertCustomer(Customer customer)
        {
            bool isInDb = IsCustomerInDatabase(customer);

            if (isInDb)
            {
                throw new ArgumentException("Customer allready in database.");
            }

            this.entity.Customers.Add(customer);
            this.entity.SaveChanges();
        }

        public void ModifyCustomer(Customer customer, Customer modifiedCustomer)
        {
            bool isInDb = IsCustomerInDatabase(customer);

            if (!isInDb)
            {
                throw new ArgumentException("Custumer isn't in database, please use InsertCustomer instead.");
            }

            DeleteCustomer(customer);
            InsertCustomer(modifiedCustomer);
            this.entity.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            bool isInDb = IsCustomerInDatabase(customer);

            if (!isInDb)
            {
                throw new ArgumentException("Wrong operation, Custumer isn't in database.");
            }

            this.entity.Customers.Remove(customer);
            this.entity.SaveChanges();
        }




        private bool IsCustomerInDatabase(Customer customer)
        {
            bool isInDb = this.entity.Customers.Any(c => c.CustomerID == customer.CustomerID);

            return isInDb;
        }
    }
}