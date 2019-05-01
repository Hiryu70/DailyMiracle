using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class AffirmationViewModel : BaseViewModel
    {
        public AffirmationViewModel()
        {
            Title = "Аффирмации";
            Description =
                "Позитивные утверждения для проектирования и развития мировозрения для улучшения любой области жизни.";

            StartTimerCommand = new Command(StartTimer);
        }

        public Command StartTimerCommand { get; set; }

        protected override async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Visualization);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)MenuItemType.Silence);
                    break;
            }
        }

    }
}