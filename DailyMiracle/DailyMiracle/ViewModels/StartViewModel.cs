﻿using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public StartViewModel()
        {
            MagicalDays = 17;
            GotoBeginCommand = new Command(GotoBegin);
            GotoCalendarCommand = new Command(GotoCalendar);
            GotoDiaryCommand = new Command(GotoDiary);
            GotoSettingsCommand = new Command(GotoSettings);
        }

        public int MagicalDays { get; set; }

        public Command GotoBeginCommand { get; set; }

        public Command GotoCalendarCommand { get; set; }

        public Command GotoDiaryCommand { get; set; }

        public Command GotoSettingsCommand { get; set; }

        
        private async void GotoBegin()
        {
            await RootPage.NavigateFromMenu((int)MenuItemType.Silence);
        }

        private void GotoCalendar()
        {
        }

        private void GotoDiary()
        {
        }

        private void GotoSettings()
        {
        }
    }
}