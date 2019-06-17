using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using DailyMiracle.Annotations;
using DailyMiracle.Models;
using DailyMiracle.Views;
using Xamarin.Forms;

namespace DailyMiracle.ViewModels
{
    public sealed class StartViewModel : INotifyPropertyChanged
    {
        private readonly IMiracleDaysRepository _miracleDaysRepository;
        private int _miracleDaysCount;
        private IEnumerable<MiracleDay> _miracleDays;

        public StartViewModel(IMiracleDaysRepository miracleDaysRepository)
        {
            _miracleDaysRepository = miracleDaysRepository;
            GotoBeginCommand = new Command(GotoBegin);
            GotoCalendarCommand = new Command(GotoCalendar);
            UpdateCommand = new Command(Update);
            AddCommand = new Command(Add);
            ClearCommand = new Command(Clear);
        }


        public MainPage RootPage => Application.Current.MainPage as MainPage;

        public IEnumerable<MiracleDay> MiracleDays
        {
            get => _miracleDays;
            set
            {
                _miracleDays = value;
                OnPropertyChanged();
            }
        }

        public int MiracleDaysCount
        {
            get => _miracleDaysCount;
            set
            {
                _miracleDaysCount = value;
                OnPropertyChanged();
            }
        }

        public Command GotoBeginCommand { get; set; }

        public Command GotoCalendarCommand { get; set; }

        public Command UpdateCommand { get; set; }

        public Command AddCommand { get; set; }

        public Command ClearCommand { get; set; }

        private async void GotoBegin()
        {
            await StartPage.Instance.Navigation.PushModalAsync(new ActivitiesPage());
        }

        private void GotoCalendar()
        {
        }

        private async void Update()
        {
            MiracleDays = await _miracleDaysRepository.GetMiracleDaysAsync();
            MiracleDaysCount = MiracleDays.Count();
        }

        private async void Add()
        {
            var miracleDay = new MiracleDay
            {
                Id = 0,
                Date = DateTime.Now
            };

            await _miracleDaysRepository.AddMiracleDayAsync(miracleDay);
            Update();
        }

        private async void Clear()
        {
            foreach (var miracleDay in MiracleDays)
            {
                await _miracleDaysRepository.RemoveMiracleDayAsync(miracleDay.Id);
            }
            Update();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}