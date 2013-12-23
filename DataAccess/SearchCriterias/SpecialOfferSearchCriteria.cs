
using System;
namespace AdventureWorks.DataAccess.SearchCriterias
{
    public class SpecialOfferSearchCriteria : BaseSearchCriteria
    {
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Int32? MinQuantity { get; set; }
        public Int32? MaxQuantity { get; set; }
        public Decimal? DiscountPct { get; set; }
    }
}
