
using System.Collections.Generic;

namespace Domain
{
    public class MapService : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual int LayerOrder { get; set; }
        public virtual decimal? MinimunResolution { get; set; }
        public virtual decimal? MaximumResolution { get; set; }
        public virtual MapServiceType ServiceType { get; set; }
        public virtual string ServiceName { get { return Url.Split('/')[4]; } }
        public virtual string Folder { get { return Url.Split('/')[3]; } }
        public virtual decimal? Opacity { get; set; }
        public virtual bool SupportMapOperations { get; set; }
        public virtual bool SupportQueryOperations { get; set; }
        public virtual bool SupportDataOperations { get; set; }
        public virtual bool VisibleByDefault { get; set; }

        public virtual IList<MapLayer> MapLayers { get; set; }
    }
}
