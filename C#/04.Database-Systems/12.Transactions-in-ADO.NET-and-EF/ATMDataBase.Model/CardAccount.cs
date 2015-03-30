namespace ATMDataBase.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CardAccount
    {
        private const int CardNumberLength = 10;

        private const int CardPinLength = 4;

        private string cardNumber;

        private string cardPin;

        private ICollection<TransactionHistory> transactions;

        public CardAccount()
        {
            this.transactions = new HashSet<TransactionHistory>();
        }

        public CardAccount(string cardNumber = "", string cardPin = "", decimal cardCash = 0)
        {
            this.CardNumber = cardNumber;
            this.CardPin = cardPin;
            this.CardCash = cardCash;
            this.transactions = new HashSet<TransactionHistory>();
        }

        [Key]
        public int CardAccountID { get; set; }

        [StringLength(10)]
        public string CardNumber
        {
            get
            {
                return this.cardNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The input can't be NULL.");
                }

                if (value.Length != CardNumberLength)
                {
                    throw new ArgumentOutOfRangeException("The number of the card must be exactly 10 chars long");
                }

                long parser = 0;
                if (!long.TryParse(value, out parser))
                {
                    throw new ArgumentException("The input for card number isn't number.");
                }

                this.cardNumber = value;
            }
        }

        [StringLength(4)]
        public string CardPin
        {
            get
            {
                return this.cardPin;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The input can't be NULL.");
                }

                if (value.Length != CardPinLength)
                {
                    throw new ArgumentOutOfRangeException("The number of the card must be exactly 4 chars long");
                }

                short parser = 0;
                if (!short.TryParse(value, out parser))
                {
                    throw new ArgumentException("The input for card number isn't number.");
                }

                this.cardPin = value;
            }
        }

        public decimal CardCash { get; set; }

        public virtual ICollection<TransactionHistory> Transactions
        {
            get
            {
                return this.transactions;
            }

            set
            {
                this.transactions = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append("Number: " + this.CardNumber + " with amount: " + this.CardCash);

            return result.ToString();
        }
    }
}