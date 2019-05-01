using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class SilenceViewModel : BaseViewModel
    {
        public SilenceViewModel()
        {
            Title = "Тишина";
            Description =
                "Начинайте день со спокойствия, ясностью и безмятежностью, сосредоточтесь на самом важном в жизни.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }


        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Affirmation);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Start);
                    break;
            }
        }
    }
}