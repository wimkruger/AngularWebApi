using Domain;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings
{
    public class ActiveDirectoryGroupMap : EntityMapping<ActiveDirectoryGroup>
    {
         public ActiveDirectoryGroupMap() : base()
         {
             Table("USER_GROUP");
             Map(x => x.Name, "LDAP_GROUP_NAME");
             Map(x => x.Description, "DESCR");
         }
    }
}