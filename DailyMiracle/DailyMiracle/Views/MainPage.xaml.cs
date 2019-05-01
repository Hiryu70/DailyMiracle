using DailyMiracle.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DailyMiracle.ViewModels;
using Xamarin.Forms;

namespace DailyMiracle.Views
{
    [DesignTimeVisible(true)]
    public partial class MainPage
    {
        readonly Dictionary<int, NavigationPage> _menuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            _menuPages.Add((int)MenuItemType.Start, (NavigationPage)Detail);
        }

        public bool Pause { get; set; }

        public async Task NavigateFromMenu(int id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                var properties = new PageProperties();
                switch (id)
                {
                    case (int)MenuItemType.Start:
                        _menuPages.Add(id, new NavigationPage(new StartPage()));
                        break;
                    case (int)MenuItemType.Silence:
                        properties.Title = "Тишина";
                        properties.Description =
                            "Начинайте день со спокойствия, ясностью и безмятежностью, сосредоточтесь на самом важном в жизни.";
                        properties.Image = "silence.png";
                        properties.Left = MenuItemType.Affirmation;
                        properties.Right = MenuItemType.Start;
                        break;
                    case (int)MenuItemType.Affirmation:
                        properties.Title = "Аффирмации";
                        properties.Description =
                            "Позитивные утверждения для проектирования и развития мировозрения для улучшения любой области жизни.";
                        properties.Image = "affirmation.png";
                        properties.Left = MenuItemType.Visualization;
                        properties.Right = MenuItemType.Silence;
                        break;
                    case (int)MenuItemType.Visualization:
                        properties.Title = "Визуализация";
                        properties.Description =
                            "Визуализируйте свои главнейшие цели, сокровенные желания, невероятные мечты.";
                        properties.Image = "visualization.png";
                        properties.Left = MenuItemType.Diary;
                        properties.Right = MenuItemType.Affirmation;
                        break;
                    case (int)MenuItemType.Diary:
                        properties.Title = "Ведение дневника";
                        properties.Description =
                            "Ведите дневник для прочищения мозгов, выявления новых идей, повторения и признания прогресса.";
                        properties.Image = "visualization.png";
                        properties.Left = MenuItemType.Reading;
                        properties.Right = MenuItemType.Visualization;
                        break;
                    case (int)MenuItemType.Reading:
                        properties.Title = "Чтение";
                        properties.Description =
                            "Читайте минимум 10 страниц в день. Помните о конечной цели чтения.";
                        properties.Image = "reading.png";
                        properties.Left = MenuItemType.Sport;
                        properties.Right = MenuItemType.Diary;
                        break;
                    case (int)MenuItemType.Sport:
                        properties.Title = "Физические упражнения";
                        properties.Description =
                            "Подойдут спортзал, пробежка, йога и другие упражнения, которые заставят вас взбодриться.";
                        properties.Image = "sport.png";
                        properties.Left = MenuItemType.Start;
                        properties.Right = MenuItemType.Reading;
                        break;
                }
                _menuPages.Add(id, new NavigationPage(new ActivityPage(properties)));
            }

            var newPage = _menuPages[id];
            if (newPage != null && Detail != newPage)
            {
                if (((NavigationPage) Detail).CurrentPage.BindingContext is ActivityPageViewModel fromViewModel)
                {
                    fromViewModel.OnNavigatedFrom();
                }

                Detail = newPage;

                if (newPage.CurrentPage.BindingContext is ActivityPageViewModel toViewModel)
                {
                    toViewModel.OnNavigatedTo();
                }

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}