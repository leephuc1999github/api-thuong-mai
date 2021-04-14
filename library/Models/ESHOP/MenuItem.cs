using library.Models.ESHOP.Enums;

namespace library.Models.ESHOP
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public MenuState State { get; set; }
        public int? ParentId { get; set; }
    }
}
