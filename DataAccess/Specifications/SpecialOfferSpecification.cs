using AdventureWorks.Domain;
using System.Linq;
using System;
using AdventureWorks.DataAccess.Utils;

namespace AdventureWorks.DataAccess.Specifications
{
    public class SpecialOfferSpecification : ISpecification<SpecialOffer>
    {
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Int32? MinQuantity { get; set; }
        public Int32? MaxQuantity { get; set; }
        public Decimal? DiscountPct { get; set; }

        public IQueryable<SpecialOffer> IsSatisfiedBy(IQueryable<SpecialOffer> queryable)
        {
            return queryable
                .NullableWhere(x => x.Type == Type)
                .NullableWhere(x => x.Category == Category)
                .NullableWhere(x => x.StartDate == StartDate);
        }
    }
}
