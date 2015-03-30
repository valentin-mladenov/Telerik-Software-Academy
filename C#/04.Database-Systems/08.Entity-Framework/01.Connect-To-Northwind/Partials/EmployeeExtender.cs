namespace _01.Connect_To_Northwind
{
    using System.Linq;
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var result = new EntitySet<Territory>();
                var listTerritories = this.Territories.ToList();
                result.AddRange(listTerritories);

                return result;
            }
        }
    }
}