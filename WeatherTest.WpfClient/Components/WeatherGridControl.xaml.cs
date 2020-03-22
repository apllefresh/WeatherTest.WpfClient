using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for WeatherGridControl.xaml
    /// </summary>
    public partial class WeatherGridControl : UserControl
    {
        public ObservableCollection<Models.BoxingTemperature> Data
        {
            get 
            { 
                return (ObservableCollection<Models.BoxingTemperature>)GetValue(DataProperty); 
            }
            set 
            { 
                SetValue(DataProperty, value);
            }
        }

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register(
            "Data",
            typeof(ObservableCollection<Models.BoxingTemperature>),
            typeof(WeatherGridControl),
            new FrameworkPropertyMetadata(new ObservableCollection<Models.BoxingTemperature>()));

        public WeatherGridControl()
        {
            InitializeComponent();
        }
    }
}
