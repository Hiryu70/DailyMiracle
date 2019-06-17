using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyMiracle.Models;
using DailyMiracle.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyMiracle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitiesPage 
    {
        public ActivitiesPage()
        {
            InitializeComponent();

            var activities = new ObservableCollection<ActivityPageViewModel>();

            var properties = new PageProperties();
            properties.Title = "Тишина";
            properties.Description =
                "Начинайте день со спокойствия, ясностью и безмятежностью, сосредоточтесь на самом важном в жизни.";
            properties.Image = "silence.png";
            properties.Left = MenuItemType.Affirmation;
            properties.Right = MenuItemType.Start;

            var properties2 = new PageProperties();

            properties2.Title = "Аффирмации";
            properties2.Description =
                "Позитивные утверждения для проектирования и развития мировозрения для улучшения любой области жизни.";
            properties2.Image = "affirmation.png";
            properties2.Left = MenuItemType.Visualization;
            properties2.Right = MenuItemType.Silence;

            activities.Add(new ActivityPageViewModel(properties));
            activities.Add(new ActivityPageViewModel(properties2));

            ItemsSource = activities;
        }
    }
}