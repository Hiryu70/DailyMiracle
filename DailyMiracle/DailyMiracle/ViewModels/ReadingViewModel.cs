using System;
using DailyMiracle.Models;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public class ReadingViewModel : BaseViewModel
    {
        string _time = "10:00";
        private DateTime _startTime;


        public ReadingViewModel()
        {
            Title = "Чтение";
            Description =
                "Читайте минимум 10 страниц в день. Помните о конечной цели чтения.";

            StartTimerCommand = new Command(StartTimer);
        }


        public Command StartTimerCommand { get; set; }

        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

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