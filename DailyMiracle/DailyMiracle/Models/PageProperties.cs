namespace DailyMiracle.Models
{
    public class PageProperties
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public MenuItemType Left { get; set; }

        public MenuItemType Right { get; set; }
    }
}