using System;
namespace Domain
{
    public class AuditableEntity : Entity
    {
        public virtual DateTime ModifiedDate { get; set; } 
    }
}
