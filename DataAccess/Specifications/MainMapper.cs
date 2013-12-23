using AutoMapper;
using AdventureWorks.DataAccess.SearchCriterias;
namespace AdventureWorks.DataAccess.Specifications
{
    public class MainMapper
    {
        public static void MapSpecialOffer()
        {
            Mapper.CreateMap<SpecialOfferSearchCriteria, SpecialOfferSpecification>();
        }

        public static void MapProduct()
        {
            Mapper.CreateMap<ProductSearchCriteria, ProductSpecification>();
        }
    }
}
