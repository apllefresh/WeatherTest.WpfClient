using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WeatherTest.WpfClient.ViewNodels;

namespace WeatherTest.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        private ApplicationViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new ApplicationViewModel();
            DataContext = model;
        }

        private void SelectCityButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCityTag = (sender as Button)?.Tag;
            if (selectedCityTag != null && int.TryParse(selectedCityTag.ToString(), out var selectedCityId))
            {
                model.SelectedCityId = selectedCityId;
                model.OnPropertyChanged("SelectedCityId");
            }
        }
    }
}
