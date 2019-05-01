using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using DailyMiracle.Views;

namespace DailyMiracle.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private int _secondsSpent;
        private TimeSpan _activityTime = TimeSpan.FromMinutes(10);
        private bool _stopTimer;
        string _time = "10:00";

        public BaseViewModel()
        {
            OnSwipedCommand = new Command(OnSwiped);
        }


        public MainPage RootPage => Application.Current.MainPage as MainPage;

        public Command OnSwipedCommand { get; set; }

        public string Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        protected virtual void OnSwiped(object parameter)
        {
        }

        public void OnNavigatedFrom()
        {
            _stopTimer = true;
        }

        public void OnNavigatedTo()
        {
            _stopTimer = false;
            StartTimer();
        }

        protected virtual void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }


        private bool OnTimerTick()
        {
            if (_stopTimer)
                return false;

            _secondsSpent++;

            var elapsedSeconds = _activityTime.TotalSeconds - _secondsSpent;
            var elapsedTime = TimeSpan.FromSeconds(elapsedSeconds);

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

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
