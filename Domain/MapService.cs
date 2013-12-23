
namespace Domain
{
    public class MapService : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual int LayerOrder { get; set; }
        public virtual int MinimunResolution { get; set; }
        public virtual int MaximumResolution { get; set; }
        public virtual MapServiceType ServiceType { get; set; }
        public virtual string ServiceName { get { return Url.Split('/')[4]; } }
        public virtual string Folder { get { return Url.Split('/')[3]; } }
    }
}
