using System.ComponentModel;

namespace DailyMiracle.Views
{
    [DesignTimeVisible(true)]
    public partial class StartPage
    {
        public static StartPage Instance { get; set; }

        public StartPage()
        {
            InitializeComponent();
            Instance = this;
        }
    }
}