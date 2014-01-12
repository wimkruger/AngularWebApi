using System.Collections.Generic;

namespace DataAccess.Dtos
{
    public class MenuDto : BaseDto
    {
        public string Name { get; set; }
        public int ProfileId { get; set; }
        public int SequenceNumber { get; set; }
        public IList<MenuItemDto> Items { get; set; }
    }
}