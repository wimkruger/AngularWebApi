using System;
namespace AdventureWorks.DataAccess.SearchCriterias
{
    public class VendorSearchCriteria : BaseSearchCriteria
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int? CreditRating { get; set; }
        public bool? Active { get; set; }
        public bool? PreferredVendorStatus { get; set; }
    }
}
