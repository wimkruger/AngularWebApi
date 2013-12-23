namespace DataAccess.Dtos
{
    public class ProfileDto : BaseDto
    {
        public string Name { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; }
    }
}