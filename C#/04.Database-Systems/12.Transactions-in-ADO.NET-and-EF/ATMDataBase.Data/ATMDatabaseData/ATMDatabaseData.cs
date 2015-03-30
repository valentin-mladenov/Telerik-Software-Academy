namespace ATMDataBase.Data.ATMDatabaseData
{
    using System;
    using System.Collections.Generic;

    using ATMDataBase.Data.Repositories;
    using ATMDataBase.Model;

    public class ATMDatabaseData : IATMDatabaseData
    {

        private readonly IATMDataBaseContext context;
        private readonly IDictionary<Type, object> repositories;

        public ATMDatabaseData(IATMDataBaseContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public ATMDatabaseData()
            : this(new ATMDataBaseContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<CardAccount> CardAccounts
        {
            get
            {
                return new GenericRepository<CardAccount>(this.context);
            }
        }

        public IGenericRepository<TransactionHistory> TransactionHistories
        {
            get
            {
                return new GenericRepository<TransactionHistory>(this.context);
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}