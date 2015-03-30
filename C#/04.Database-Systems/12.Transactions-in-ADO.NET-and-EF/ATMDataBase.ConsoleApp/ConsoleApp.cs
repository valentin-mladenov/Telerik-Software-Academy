// I use entity framework code first so transactions are always on
namespace ATMDataBase.ConsoleApp
{
    using System;
    using System.Transactions;

    using ATMDataBase.Data;
    using ATMDataBase.Data.ATMDatabaseData;

    public class ConsoleApp
    {
        public static void Main()
        {
            var context = new ATMDataBaseContext();
            var db = new ATMDatabaseData(context);
            using (var scope = new TransactionScope())
            {
                var trans = new ATMTransactions();

                //Task1: to populate the data
                trans.AddAccountCards(db);
                foreach (var cardAccount in db.CardAccounts.All())
                {
                    Console.WriteLine(cardAccount.ToString());
                }

                Console.WriteLine("Data added.");

                //Task2 & 3: I decide to use snapshot for transaction log.
                var tranState = trans.WithdrawlMoney(db, context, false);
                Console.WriteLine(tranState ? "Transaction Successful!!!" : "Transaction Fail!!!");

                scope.Complete();
            }
        }
    }
}