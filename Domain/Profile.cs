using System.Collections.Generic;
namespace Domain
{
    public class Profile : AuditableEntity
    {
        public virtual string Name { get; set; }
        public virtual int Sequence { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<MapService> MapServices { get; set; }
        public virtual IList<ActiveDirectoryGroup> ActiveDirectoryGroups { get; set; }
        public virtual IList<Permission> Permissions { get; set; }
        public virtual IList<Menu> Menus { get; set; }
    }
}
