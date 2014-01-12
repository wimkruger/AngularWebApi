namespace Domain
{
    public class MenuItem : AuditableEntity
    {
        public virtual int MenuId { get; set; }
        public virtual string Name { get; set; }
        public virtual string ActionText { get; set; }
        public virtual int Sequence { get; set; }
        public virtual int IndentLevel { get; set; }
    }
}