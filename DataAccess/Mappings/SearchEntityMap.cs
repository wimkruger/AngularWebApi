using Domain;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class SearchEntityMap : EntityMapping<SearchEntity>
    {
         public SearchEntityMap() : base()
         {
             Table("PROFILE_CONFIG");
             Map(x => x.JavaObjectName, "APP_OBJ_NAME_VALUE");
             Map(x => x.MapServiceLayerId, "MAP_FEATURE_DISPLAY_ID");
             Map(x => x.ShowOnMap, "SHOW_ON_MAP").CustomType("YesNo");
             Map(x => x.CanUpdate, "UPDATE_ACCESS").CustomType("YesNo");
             Map(x => x.CanDelete, "DELETE_ACCESS").CustomType("YesNo");
             Map(x => x.CanCreate, "CREATE_ACCESS").CustomType("YesNo");
             Map(x => x.CanRead, "READ_ACCESS").CustomType("YesNo");
         }
    }
}