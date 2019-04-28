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
        readonly Dictionary<MenuItemType, NavigationPage> _menuPages = new Dictionary<MenuItemType, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            _menuPages.Add(MenuItemType.Silence, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(MenuItemType id)
        {
            if (!_menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuItemType.Silence:
                        _menuPages.Add(id, new NavigationPage(new SilencePage()));
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