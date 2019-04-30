using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace DailyMiracle.Droid
{
    [Activity(Theme = "@style/Theme.Splash", 
        MainLauncher = true, 
        NoHistory  = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            var startUpwork = new Task(SimulateStartup);
            startUpwork.Start();
        }

        private async void SimulateStartup()
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}