using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class ReadingViewModel : BaseViewModel
    {
        public ReadingViewModel()
        {
            Title = "Чтение";
            Description =
                "Читайте минимум 10 страниц в день. Помните о конечной цели чтения.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }

        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Sport);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Diary);
                    break;
            }
        }
    }
}