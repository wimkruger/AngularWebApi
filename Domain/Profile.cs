using System.Collections.Generic;
namespace Domain
{
    public class Profile : Entity
    {
        public virtual string Name { get; set; }
        public virtual int Sequence { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<MapService> MapServices { get; set; }
    }
}
