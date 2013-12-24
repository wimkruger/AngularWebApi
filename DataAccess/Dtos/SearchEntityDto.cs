namespace DataAccess.Dtos
{
    public class SearchEntityDto
    {
        public  string JavaObjectName { get; set; }
        public  int MapServiceLayerId { get; set; }
        public  bool CanCreate { get; set; }
        public  bool CanRead { get; set; }
        public  bool CanUpdate { get; set; }
        public  bool CanDelete { get; set; }
        public  bool ShowOnMap { get; set; } 
    }
}