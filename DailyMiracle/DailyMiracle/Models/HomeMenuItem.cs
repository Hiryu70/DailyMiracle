﻿namespace DailyMiracle.Models
{
    public enum MenuItemType
    {
        Start,
        Silence,
        Affirmation,
        Visualization,
        Diary,
        Reading,
        Sport,
        Calendar,
        Settings,
        Browse,
        About
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
