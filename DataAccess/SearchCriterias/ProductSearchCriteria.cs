using System;
using AdventureWorks.Domain;
namespace AdventureWorks.DataAccess.SearchCriterias
{
    public class ProductSearchCriteria : BaseSearchCriteria
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal? ListPrice { get; set; }
        public DateTime? SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public int? Size { get; set; }
        public decimal? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public int? Category { get; set; }
        public string SubCategory { get; set; }
    }
}
