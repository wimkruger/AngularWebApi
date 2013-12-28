namespace Domain
{
    public class Permission : AuditableEntity
    {
        public virtual string JavaObjectName { get; set; }
        public virtual bool CanCreate { get; set; }
        public virtual bool CanRead { get; set; }
        public virtual bool CanUpdate { get; set; }
        public virtual bool CanDelete { get; set; }
        public virtual bool ShowOnMap { get; set; }
    }
}