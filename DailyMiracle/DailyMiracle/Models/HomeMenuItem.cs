namespace DailyMiracle.Models
{
    public enum MenuItemType
    {
        Silence,
        Browse,
        About
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
