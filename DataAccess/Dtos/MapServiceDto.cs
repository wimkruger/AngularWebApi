using Domain;

namespace DataAccess.Dtos
{
    public class MapServiceDto : BaseDto
    {
        public  string Name { get; set; }
        public  string Url { get; set; }
        public  int LayerOrder { get; set; }
        public  MapServiceType ServiceType { get; set; }
        public  string ServiceName { get; set; }
        public  string Folder { get; set; }
        public  decimal? MinimunResolution { get; set; }
        public  decimal? MaximumResolution { get; set; }
        public  decimal? Opacity { get; set; }
        public  bool SupportMapOperations { get; set; }
        public  bool SupportQueryOperations { get; set; }
        public  bool SupportDataOperations { get; set; }
        public  bool VisibleByDefault { get; set; }
    }
}