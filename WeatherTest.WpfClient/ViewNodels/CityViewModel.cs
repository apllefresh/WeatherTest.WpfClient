using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Threading;
using WeatherTest.WpfClient.Models;
using WeatherTest.WpfClient.WeatherServiceReference;

namespace WeatherTest.WpfClient.ViewNodels
{
    public class CityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.City> Cities { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        private readonly WeatherServiceClient _client;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            GetData();
        }

        public CityViewModel()
        {
            _client = new WeatherServiceClient();
            Cities = new ObservableCollection<Models.City>();
            GetData();
        }

        private void GetData()
        {
            _dispatcher.Invoke(() =>
            {
                var result = _client.GetCities();

                var data = result.Select(c => new Models.City
                (
                    c.Id,
                    c.Name
                )).ToList();

                Cities = new ObservableCollection<Models.City>(data);
            });
        }
    }
}
