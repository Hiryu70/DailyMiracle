using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class SportViewModel : BaseViewModel
    {
        public SportViewModel()
        {
            Title = "Физические упражнения";
            Description =
                "Подойдут спортзал, пробежка, йога и другие упражнения, которые заставят вас взбодриться.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }


        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Start);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Reading);
                    break;
            }
        }
    }
}