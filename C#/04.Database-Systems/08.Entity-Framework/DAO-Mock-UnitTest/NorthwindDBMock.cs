using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Connect_To_Northwind;

namespace DAO_Mock_UnitTest
{
    public class NorthwindDBMock
    {
        public NorthwindDBMock()
        {
            this.PopulateFakeDataBase();
          //  this.ArrangeCustomerMock();
        }

       // public DAO Methods { get; protected set; }

        public ICollection<Customer> FakeCustomerCollection { get; private set; }

        public void PopulateFakeDataBase()
        {
            this.FakeCustomerCollection = new List<Customer>
                                              {
                                                  new Customer()
                                                      {
                                                          CustomerID = "BGNCS",
                                                          CompanyName = "Ataro Clima EOOD"
                                                      },
                                                  new Customer()
                                                      {
                                                          CustomerID = "BGNCT",
                                                          CompanyName = "Ataro Clima EOOD Varna"
                                                      }
                                              };
        }

       // protected virtual void ArrangeCustomerMock();
    }
}