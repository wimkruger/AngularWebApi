using AdventureWorks.Domain;
using System.Linq;
using AdventureWorks.DataAccess.Utils;

namespace AdventureWorks.DataAccess.Specifications
{
    public class VendorSpecification : ISpecification<Vendor>
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public int? CreditRating { get; set; }
        public bool? Active { get; set; }
        public bool? PreferredVendorStatus { get; set; }

        public IQueryable<Vendor> IsSatisfiedBy(IQueryable<Vendor> queryable)
        {
            return queryable
                .NullableWhere(x => x.Name == Name)
                .NullableWhere(x => x.AccountNumber == AccountNumber)
                .NullableWhere(x => x.CreditRating == CreditRating)
                .NullableWhere(x => x.Active == Active)
                .NullableWhere(x => x.PreferredVendorStatus == PreferredVendorStatus);
        }
    }
}
