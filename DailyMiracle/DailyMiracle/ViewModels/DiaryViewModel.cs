using System;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class DiaryViewModel : BaseViewModel
    {
        string _time = "10:00";
        private DateTime _startTime;


        public DiaryViewModel()
        {
            Title = "Ведение дневника";
            Description =
                "Ведите дневник для прочищения мозгов, выявления новых идей, повторения и признания прогресса.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }

        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        private void StartTimer()
        {
            _startTime = DateTime.Now;

            OnTimerTick();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        private bool OnTimerTick()
        {
            var endTime = _startTime + TimeSpan.FromMinutes(10);
            var elapsedTime = endTime - DateTime.Now;

            if (elapsedTime.TotalSeconds > 0)
            {
                var minutes = elapsedTime.Minutes.ToString("00");   
                var seconds = elapsedTime.Seconds.ToString("00");   
                Time = $"{minutes}:{seconds}";
            }
            else
            {
                Time = "00:00";
                return false;
            }

            return true;
        }
    }
}