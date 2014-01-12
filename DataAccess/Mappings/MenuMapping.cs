using Domain;

namespace DataAccess.Mappings
{
    public class MenuMapping : AuditableEntityMap<Menu>
    {
         public MenuMapping() : base()
         {
             Table("APP_MENU");
             Map(x => x.Name, "MENU_NAME");
             Map(x => x.ProfileId, "PROFILE_ID");
             Map(x => x.SequenceNumber, "SEQUENCE_NO");
             HasMany<MenuItem>(x => x.Items).KeyColumn("APP_MENU_ID").Not.LazyLoad();
         }
    }
}