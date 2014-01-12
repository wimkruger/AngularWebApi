using System.Collections.Generic;

namespace DataAccess.Dtos
{
    public class MenuItemDto : BaseDto
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string ActionText { get; set; }
        public int Sequence { get; set; }
        public int IndentLevel { get; set; }
        public virtual IList<MenuItemDto> Items { get; set; }
    }
}