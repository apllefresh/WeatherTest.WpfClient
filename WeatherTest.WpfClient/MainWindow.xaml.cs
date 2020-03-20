using System.Windows;
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
        private CityViewModel model;
        public MainWindow()
        {
            InitializeComponent();
            model = new CityViewModel();
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            model.OnPropertyChanged("Cities");
            model.PropertyChanged += (s,o) =>
            {
                _dispatcher.Invoke(() => CityPanel.Items.Refresh());
            };
            DataContext = model;
        }
    }
}
