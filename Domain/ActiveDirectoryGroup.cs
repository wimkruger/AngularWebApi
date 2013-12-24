namespace Domain
{
    public class ActiveDirectoryGroup : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}