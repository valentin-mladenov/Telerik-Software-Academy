namespace _01.Connect_To_Northwind.DAO
{
    interface IDao
    {
        void InsertCustomer(Customer customer);

        void ModifyCustomer(Customer customer, Customer modifiedCustomer);

        void DeleteCustomer(Customer customer);
    }
}