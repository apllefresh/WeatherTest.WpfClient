using System.Linq;
using System.Windows;
using WeatherTest.WpfClient.WeatherServiceReference;

namespace WeatherTest.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WeatherServiceClient _client; 

        public MainWindow()
        {
            InitializeComponent();
            _client = new WeatherServiceClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = _client.GetCities();
            tb.Text = string.Join("\n", t.Select(s => s.Name).ToList());
        }
    }
}
