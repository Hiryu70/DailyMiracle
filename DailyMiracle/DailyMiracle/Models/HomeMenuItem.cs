namespace DailyMiracle.Models
{
    public enum MenuItemType
    {
        Silence,
        Affirmation,
        Visualization,
        Diary,
        Reading,
        Sport,
        Browse,
        About
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
