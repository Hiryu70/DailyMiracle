using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class VisualizationViewModel : BaseViewModel
    {
        public VisualizationViewModel()
        {
            Title = "Визуализация";
            Description =
                "Визуализируйте свои главнейшие цели, сокровенные желания, невероятные мечты.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }

        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Diary);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Affirmation);
                    break;
            }
        }
    }
}