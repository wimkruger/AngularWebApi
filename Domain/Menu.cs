using System.Collections.Generic;

namespace Domain
{
    public class Menu : AuditableEntity
    {
        public virtual string Name { get; set; }
        public virtual int ProfileId { get; set; }
        public virtual int SequenceNumber { get; set; }
        public virtual IList<MenuItem> Items { get; set;}
        public Menu()
        {
            Items = new List<MenuItem>();
        }
    }
}