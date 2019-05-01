using System.ComponentModel;
using DailyMiracle.Models;
using DailyMiracle.ViewModels;

namespace DailyMiracle.Views
{
    [DesignTimeVisible(true)]
    public partial class ActivityPage
    {
        public ActivityPage(PageProperties properties)
        {
            BindingContext = new ActivityPageViewModel(properties);

            InitializeComponent();
        }
    }
}