using DailyMiracle.ViewModels;
using System.ComponentModel;

namespace DailyMiracle.Views
{
    [DesignTimeVisible(true)]
    public partial class SilencePage
    {
        SilenceViewModel _viewModel;

        public SilencePage(SilenceViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public SilencePage()
        {
            InitializeComponent();
            
            _viewModel = new SilenceViewModel();
            BindingContext = _viewModel;
        }
    }
}