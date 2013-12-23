using Domain;

namespace DataAccess.Dtos
{
    public class MapServiceDto : BaseDto
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual int LayerOrder { get; set; }
        public virtual MapServiceType ServiceType { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual string Folder { get; set; }
    }
}