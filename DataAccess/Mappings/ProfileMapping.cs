using Domain;
using FluentNHibernate.Mapping;
namespace DataAccess.Mappings
{
    public class ProfileMapping : EntityMapping<Profile>
    {
        public ProfileMapping() : base()
        {
            Table("PROFILE");
            Map(x => x.Name, "PROFILE_NAME");
            Map(x => x.Sequence, "SEQUENCE_NO");
            Map(x => x.Description, "DESCR");
            HasManyToMany<MapService>(x => x.MapServices).LazyLoad().
                Table("PROFILE_MAP_SERVICE").ParentKeyColumn("PROFILE_ID").ChildKeyColumn("MAP_SERVICE_ID");
            HasManyToMany<ActiveDirectoryGroup>(x => x.ActiveDirectoryGroups).LazyLoad().
                Table("USER_GROUP_PROFILE").ParentKeyColumn("PROFILE_ID").ChildKeyColumn("USER_GROUP_ID");
            HasMany<SearchEntity>(x => x.SearchEntities).KeyColumn("PROFILE_ID").LazyLoad();
        }
    }
}
