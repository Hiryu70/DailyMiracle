using DailyMiracle.ViewModels;
using DailyMiracle.Views;

namespace DailyMiracle
{
    public partial class App
    {
        public App(IMiracleDaysRepository miracleDaysRepository)
        {
            InitializeComponent();

            var startViewModel = new StartViewModel(miracleDaysRepository);
            startViewModel.UpdateCommand.Execute(null);
            var startPage = new StartPage
            {
                BindingContext = startViewModel
            };
            MainPage = startPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}