
namespace AdventureWorks.DataAccess.SearchCriterias
{
    public abstract class BaseSearchCriteria
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public BaseSearchCriteria()
        {
            Page = 1;
            PageSize = 10;
        }
        
    }
}
