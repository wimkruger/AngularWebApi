using Domain;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class ActiveDirectoryGroupMap : ClassMap<ActiveDirectoryGroup>
    {
         public ActiveDirectoryGroupMap() : base()
         {
             Table("USER_GROUP");
             Schema("PROFILEDATA");
             Id(x => x.Id, "OBJECT_ID");//.GeneratedBy.Custom<OrionIdGenerator>(p => p.AddParam("classnamekey", LastUsedIdClassName.Profile.ToString()));
             Map(x => x.Name, "LDAP_GROUP_NAME");
             Map(x => x.Description, "DESCR");
         }
    }
}