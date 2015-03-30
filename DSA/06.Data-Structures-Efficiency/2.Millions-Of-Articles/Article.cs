namespace _2.Millions_Of_Articles
{
    using System;
    using System.Text;

    public class Article : IComparable<Article>
    {
        public Article(string title, string vendor, long barcode, decimal price)
        {
            this.Barcode = barcode;
            this.Price = price;
            this.Title = title;
            this.Vendor = vendor;
        }

        public long Barcode { get; private set; }

        public string Vendor { get; private set; }

        public string Title { get; private set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine(
                "Product " + this.Title + " from " + this.Vendor + " with price " + this.Price + ", barcode: "
                + this.Barcode);

            return result.ToString();
        }

        public int CompareTo(Article other)
        {
            if (this.Barcode == other.Barcode)
            {
                return this.Price.CompareTo(other.Price);
            }

            return this.Barcode.CompareTo(other.Barcode);
        }
    }
}