namespace AdventureWorks.DataAccess.SearchCriterias
{
    public class ProductInventorySearchCriteria : ProductSearchCriteria
    {
        public string LocationName { get; set; }
        public int? Quantity { get; set; }
    }
}
