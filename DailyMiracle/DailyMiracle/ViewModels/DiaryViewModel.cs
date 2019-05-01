using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class DiaryViewModel : BaseViewModel
    {
        public DiaryViewModel()
        {
            Title = "Ведение дневника";
            Description =
                "Ведите дневник для прочищения мозгов, выявления новых идей, повторения и признания прогресса.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }
        
        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Reading);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Visualization);
                    break;
            }
        }
    }
}