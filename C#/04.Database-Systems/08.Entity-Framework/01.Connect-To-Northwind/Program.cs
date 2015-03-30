namespace _01.Connect_To_Northwind
{
    using System;
    using System.Data.Entity.Core;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;

    using _01.Connect_To_Northwind.DAO;

    public class Program
    {
        // Task 2
        public static void CustomerActions(CustomNorthwindEntity northwindDb)
        {
            var ataroClima = new Customer()
            {
                CustomerID = "BGNCS",
                CompanyName = "Ataro Clima EOOD"
            };

            var ataroClimaModified = ataroClima;
            ataroClimaModified.City = "Plovdiv";

            var dao = new Dao(northwindDb);

            dao.InsertCustomer(ataroClima);

            dao.ModifyCustomer(ataroClima, ataroClimaModified);

            dao.DeleteCustomer(ataroClimaModified);
        }

        // Task 3
        public static void CustomersWithOrdersFrom1997ShipedToCanadaLINQ
            (NorthwindEntities northwindDb)
        {
            var orders = northwindDb.Customers.Join(
                northwindDb.Orders,
                (c => c.CustomerID),
                (o => o.CustomerID),
                (o, c) => new { FromCustomer = c.Customer.CompanyName,
                            OrderderedAt = c.OrderDate.Value.Year,
                            ToCountry = c.ShipCountry })
                            .Where(c=>c.OrderderedAt == 1997 && c.ToCountry == "Canada");

            foreach (var order in orders)
            {
                string strFormat = string.Format(
                    "Order from {0} at {1} shiped to {2}",
                    order.FromCustomer,
                    order.OrderderedAt,
                    order.ToCountry);

                Console.WriteLine(strFormat);
            }
        }

        // Task 4
        public static void CustomersWithOrdersFrom1997ShipedToCanadaMSSQL
            (NorthwindEntities northwindDb)
        {
            var orders = from customer in northwindDb.Customers
                         join order in northwindDb.Orders on customer.CustomerID equals order.CustomerID
                         where order.OrderDate.Value.Year == 1997 && order.ShipCountry == "Canada"
                         select
                             new
                                 {
                                     FromCustomer = customer.CompanyName,
                                     OrderderedAt = order.OrderDate.Value.Year,
                                     ToCountry = order.ShipCountry
                                 };
          
            foreach (var order in orders)
            {
                string strFormat = string.Format(
                    "Order from {0} at {1} shiped to {2}",
                    order.FromCustomer,
                    order.OrderderedAt,
                    order.ToCountry);

                Console.WriteLine(strFormat);
            }
        }

        // Task 5
        public static void SalesByRegion(NorthwindEntities northwindDb,
            DateTime startDate, DateTime endDate, string shipRegion)
        {
            var sales = from currentSales in northwindDb.Sales_by_Year(startDate, endDate)
                        join order in northwindDb.Orders.Where(o=>o.ShipRegion == shipRegion)
                        on currentSales.OrderID equals order.OrderID
                        select currentSales;

            foreach (var sale in sales)
            {
                string strFormat = string.Format(
                    "Order amount {0} from {1} with order id {2} shiped to {3}",
                    sale.Subtotal,
                    sale.ShippedDate.Value.ToShortDateString(),
                    sale.OrderID,
                    shipRegion);

                Console.WriteLine(strFormat);
            }
        }

        // Task 6
        public static void CreateNortwindTwin(NorthwindEntities northwindDb)
        {
             // Twin creation
            var createNWTwinScript = "CREATE DATABASE NorthwindTwin ON PRIMARY " 
                                     + "(NAME = NorthwindTwin, "
                                     + "FILENAME = 'E:\\NorthwindTwin.mdf', "
                                     + "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) "
                                     + "LOG ON (NAME = NorthwindTwinLog, " 
                                     + "FILENAME = 'E:\\NorthwindTwin.ldf', "
                                     + "SIZE = 1MB, " + "MAXSIZE = 5MB, " + "FILEGROWTH = 10%)";

            var northwindTwinCreateConnection =
                new SqlConnection("Server=.; " + "Database=master; " + "Integrated Security=true");

            northwindTwinCreateConnection.Open();
            using (northwindTwinCreateConnection)
            {
                SqlCommand twinInctanceCreator = new SqlCommand(createNWTwinScript, northwindTwinCreateConnection);
                twinInctanceCreator.ExecuteNonQuery();
            }
            northwindTwinCreateConnection.Close();

            // Twin data population and insertion
            IObjectContextAdapter context = northwindDb;
            string DBscript = context.ObjectContext.CreateDatabaseScript();

            DBscript.Replace("Northwind", "NorthwindTwin");

            var northwindTwinConnection =
                new SqlConnection("Server=.; " + "Database=NorthwindTwin; "
                    + "Integrated Security=true");

            northwindTwinConnection.Open();
            using (northwindTwinConnection)
            {
                SqlCommand twinActualCreator = new SqlCommand(DBscript, northwindTwinConnection);
                twinActualCreator.ExecuteNonQuery();
            }
            northwindTwinConnection.Close();
        }

        // Task 7
        public static void DealWithConcurrentSaveChanges(NorthwindEntities northwindDb)
        {
            using (var northwindDB2 = new NorthwindEntities())
            {
                var nortwindOperation = northwindDb.Customers.Where(c => c.CompanyName != "Plovdiv");
                var nortwind2Operation = northwindDB2.Customers.Where(c => c.CompanyName != "Plovdiv");

                try
                {

                    foreach (var customer in nortwindOperation)
                    {
                        Console.WriteLine(customer.CompanyName);

                    }

                    foreach (var customer in nortwind2Operation)
                    {
                        Console.WriteLine(customer.CompanyName);
                    }

                    int num1 = northwindDb.SaveChanges();
                    Console.WriteLine("No conflicts. " + num1 + " updates saved. Nothing to worry about");
                    int num2 = northwindDB2.SaveChanges();
                    Console.WriteLine("No conflicts. " + num2 + " updates saved. Nothing to worry about");
                }
                catch (OptimisticConcurrencyException)
                {
                    var adapter = (IObjectContextAdapter)northwindDB2;
                    var objectContext = adapter.ObjectContext;
                    objectContext.Refresh(RefreshMode.ClientWins, nortwind2Operation);

                    // Save changes.
                    northwindDB2.SaveChanges();
                    Console.WriteLine("OptimisticConcurrencyException " + "handled and changes saved");
                }
            }
        }

        // Task 8
        public static void EmployeeTerritoryEntitySet(NorthwindEntities northwindDb)
        {
            var employees = from employee in northwindDb.Employees select employee;

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    "Employee " + employee.FirstName + " " + employee.LastName + " in territories ");

                foreach (var territory in employee.EntityTerritories)
                {
                    Console.Write(territory.TerritoryDescription.Trim()+" ");
                }
                Console.WriteLine();
            }
        }

        // Task 9
        public static void NewOrderWithTransaction(NorthwindEntities northwindDb)
        {
            var order = new Order()
                            {
                                CustomerID = "BGNCS",
                                EmployeeID = 5,
                                OrderDate = DateTime.Now,
                                ShipCountry = "Bulgaria"
                            };

            using (var dbTransaction = northwindDb.Database.BeginTransaction())
            {
                try
                {
                    northwindDb.Orders.Add(order);
                    northwindDb.SaveChanges();

                    dbTransaction.Commit();
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                }
            }
        }

        //task 10
        public static void CreateTheProcedure(NorthwindEntities northwindDb)
        {
            var procedureString = "CREATE PROCEDURE usp_TotalIncomePerSupplier "
                + "@supplier NVARCHAR(50), @Beginning_Date Date, @Ending_Date Date AS "
                + "SELECT SUM(od.UnitPrice) FROM [dbo].[Order Details] od "
                + "JOIN Orders o ON o.OrderID = od.OrderID "
                + "JOIN Products p ON p.ProductID = od.ProductID "
                + "JOIN Suppliers s ON s.SupplierID = p.SupplierID "
                + "WHERE (o.ShippedDate BETWEEN @Beginning_Date AND @Ending_Date) "
                + "AND s.CompanyName = @supplier";

            northwindDb.Database.ExecuteSqlCommand(procedureString);
            northwindDb.SaveChanges();
        }

        public static void TotalIncomeForSupplier(NorthwindEntities northwindDb,
            DateTime startDate, DateTime endDate, string supplier)
        {
            var totalIncome = northwindDb
                .usp_TotalIncomePerSupplier(supplier, startDate, endDate).First();

            Console.WriteLine("Company Name: " +supplier+ " with income: "+totalIncome.Value);

            northwindDb.SaveChanges();
        }

        static void Main()
        {
            // Task1: Using the Visual Studio Entity Framework designer create
            // a DbContext for the Northwind database
           
            using (var northwindDb = new NorthwindEntities())
            {
                // Task 2: Create a DAO class with static methods which provide
                // functionality for inserting, modifying and deleting customers.
                // Write a testing class.
                using (var customNorthwindDb = new CustomNorthwindEntity())
                {
                    CustomerActions(customNorthwindDb);
                }

                // Task 3: Write a method that finds all customers who have orders
                // made in 1997 and shipped to Canada.
                Console.WriteLine("Task 3");
                CustomersWithOrdersFrom1997ShipedToCanadaLINQ(northwindDb);
                Console.WriteLine();

                // Task 4: Implement previous by using native SQL query and
                // executing it through the DbContext.
                Console.WriteLine("Task 4");
                CustomersWithOrdersFrom1997ShipedToCanadaMSSQL(northwindDb);
                Console.WriteLine();

                // Task 5: Write a method that finds all the sales by specified
                // region and period (start / end dates).
                SalesByRegion(northwindDb, new DateTime(1990,1,1), DateTime.Now, "RJ");

                // Task 6: Create a database called NorthwindTwin with the same
                // structure as Northwind using the features from DbContext.
                // Find for the API for schema generation in MSDN or in Google.
                CreateNortwindTwin(northwindDb);

                // Task 7: Try to open two different data contexts and perform concurrent
                // changes on the same records. What will happen at SaveChanges()?
                // How to deal with it?
                DealWithConcurrentSaveChanges(northwindDb);

                // Task 8: By inheriting the Employee entity class create a class which
                // allows employees to access their corresponding territories as
                // property of type EntitySet<T>
                EmployeeTerritoryEntitySet(northwindDb);

                // Task 9: Create a method that places a new order in the Northwind database.
                // The order should contain several order items. Use transaction to ensure the
                // data consistency.
                NewOrderWithTransaction(northwindDb);

                // Task 10: Create a stored procedures in the Northwind database for finding
                // the total incomes for given supplier name and period (start date, end date).
                // Implement a C# method that calls the stored procedure and returns the
                // retuned record set.
                CreateTheProcedure(northwindDb);
                TotalIncomeForSupplier(northwindDb, DateTime.Parse("1990.10.10").Date, DateTime.Now.Date, "Exotic Liquids");
            }
        }
    }
}