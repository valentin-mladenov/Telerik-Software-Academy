namespace _2.Fast_Find_In_Collection
{
    using System;
    using System.Text;

    class Product : IComparable<Product>
    {
        public Product()
        {
        }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other.Price == this.Price)
            {
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append("Name: " + this.Name + " Price: " + this.Price);

            return sb.ToString();
        }
    }
}