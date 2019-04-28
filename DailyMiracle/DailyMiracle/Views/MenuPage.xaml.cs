using DailyMiracle.Models;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace DailyMiracle.Views
{
    [DesignTimeVisible(true)]
    public partial class MenuPage
    {
        MainPage RootPage => Application.Current.MainPage as MainPage;

        public MenuPage()
        {
            InitializeComponent();

            var menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Silence, Title="Тишина" },
                new HomeMenuItem {Id = MenuItemType.Silence, Title="Тишина" },
                //new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                //new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = ((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}