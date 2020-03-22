using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherTest.WpfClient.Components
{
    public partial class WeatherControl : UserControl
    {
        public Models.Temperature WeatherData
        {
            get
            {
                return (Models.Temperature)GetValue(WeatherDataProperty);
            }
            set
            {
                SetValue(WeatherDataProperty, value);
            }
        }

        public static readonly DependencyProperty WeatherDataProperty = DependencyProperty.Register(
            "WeatherData",
            typeof(Models.Temperature),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(new Models.Temperature()));

        public WeatherControl()
        {
            InitializeComponent();
        }
    }
}
