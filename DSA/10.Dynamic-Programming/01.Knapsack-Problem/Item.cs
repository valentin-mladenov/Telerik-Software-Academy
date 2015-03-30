namespace _01.Knapsack_Problem
{
    public class Item
    {
        public Item(int weight, int price, string name)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }
    }
}