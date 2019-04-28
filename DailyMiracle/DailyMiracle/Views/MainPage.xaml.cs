using DailyMiracle.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
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

            _menuPages.Add((int)MenuItemType.Silence, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Silence:
                        _menuPages.Add(id, new NavigationPage(new SilencePage()));
                        break;
                    case (int)MenuItemType.Affirmation:
                        _menuPages.Add(id, new NavigationPage(new AffirmationPage()));
                        break;
                    case (int)MenuItemType.Visualization:
                        _menuPages.Add(id, new NavigationPage(new VisualizationPage()));
                        break;
                    case (int)MenuItemType.Diary:
                        _menuPages.Add(id, new NavigationPage(new DiaryPage()));
                        break;
                    case (int)MenuItemType.Reading:
                        _menuPages.Add(id, new NavigationPage(new ReadingPage()));
                        break;
                    case (int)MenuItemType.Sport:
                        _menuPages.Add(id, new NavigationPage(new SportPage()));
                        break;
                        //case MenuItemType.Browse:
                        //    _menuPages.Add(id, new NavigationPage(new ItemsPage()));
                        //    break;
                        //case MenuItemType.About:
                        //    _menuPages.Add(id, new NavigationPage(new AboutPage()));
                        //    break;
                }
            }

            var newPage = _menuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}