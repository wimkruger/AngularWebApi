using Domain;

namespace DataAccess.Mappings
{
    public class MenuItemMapping : AuditableEntityMap<MenuItem>
    {
         public MenuItemMapping() : base()
         {
             Table("APP_MENU_ITEM");
             Map(x => x.ActionText, "MENU_ACTION_TEXT");
             Map(x => x.IndentLevel, "INDENT_LEVEL");
             Map(x => x.MenuId, "APP_MENU_ID");
             Map(x => x.Sequence, "SEQUENCE_NO");

         }
    }
}