namespace ATMDataBase.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionHistory
    {
        public TransactionHistory()
        {
        }

        public TransactionHistory(CardAccount cardAccount, decimal amount)
        {
            this.Ammount = amount;
            this.CardNumber = cardAccount.CardNumber;
            this.TransactionDate = DateTime.Now.ToShortDateString();
            this.CardAccount = cardAccount;
        }

        [Key]
        public int TransactionHistoryID { get; private set; }

        [StringLength(10)]
        public string CardNumber { get; private set; }

        public string TransactionDate { get; private set; }

        public decimal Ammount { get; private set; }

        public virtual CardAccount CardAccount { get; set; }
    }
}