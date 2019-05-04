using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DailyMiracle.Models;
using Xamarin.Forms;

using DailyMiracle.Views;

namespace DailyMiracle.ViewModels
{
    public sealed class ActivityPageViewModel : INotifyPropertyChanged
    {
        private int _secondsSpent;
        private readonly TimeSpan _activityTime = TimeSpan.FromMinutes(10);
        private bool _stopTimer;
        string _time = "10:00";
        private readonly MenuItemType _leftSwipe;
        private readonly MenuItemType _rightSwipe;


        public ActivityPageViewModel(PageProperties properties)
        {
            Title = properties.Title;
            Description = properties.Description;
            Image = properties.Image;
            _leftSwipe = properties.Left;
            _rightSwipe = properties.Right;

            OnSwipedCommand = new Command(OnSwiped);
            OnTapCommand = new Command(OnTap);
        }


        private MainPage RootPage => Application.Current.MainPage as MainPage;

        public Command OnTapCommand { get; set; }

        public Command OnSwipedCommand { get; set; }

        public string Image { get; set; }

        public bool Pause
        {
            get => RootPage.Pause;
            set => RootPage.Pause = value;
        }

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

        private async void OnSwiped(object parameter)
        {
            var direction = parameter as string;
            switch (direction)
            {
                case "Left":
                    await RootPage.NavigateFromMenu((int)_leftSwipe);
                    break;
                case "Right":
                    await RootPage.NavigateFromMenu((int)_rightSwipe);
                    break;
            }
        }

        public void OnTap()
        {
            RootPage.Pause = !RootPage.Pause;

            if (RootPage.Pause)
            {
                _stopTimer = true;
            }
            else
            {
                _stopTimer = false;
                StartTimer();
            }
            OnPropertyChanged(nameof(Pause));
        }

        public void OnNavigatedFrom()
        {
            _stopTimer = true;
        }

        public void OnNavigatedTo()
        {
            OnPropertyChanged(nameof(Pause));
            if (RootPage.Pause)
                return;

            _stopTimer = false;
            StartTimer();
        }

        private void StartTimer()
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

        private bool SetProperty<T>(ref T backingStore, T value,
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
