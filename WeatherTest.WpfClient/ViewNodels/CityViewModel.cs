﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using WeatherTest.WpfClient.WeatherServiceReference;

namespace WeatherTest.WpfClient.ViewNodels
{
    public class CityViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.City> Cities { get; set; }
        public ObservableCollection<Models.BoxingTemperature> Temperatures { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        private readonly WeatherServiceClient _client;

        private int _selectedCityId;

        public int SelectedCityId
        {
            get { return _selectedCityId; }
            set
            {
                _selectedCityId = value;
                OnPropertyChanged("SelectedCityId");
                
                GetCityWeather(value);
                OnPropertyChanged("Temperatures");
            }
        }

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
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                Cities = new ObservableCollection<Models.City>(data);
            });
        }

        private void GetCityWeather(int cityId = 0)
        {
            if (cityId == 0) return;

            _dispatcher.Invoke(() =>
            {
                var result = _client.GetCityWeather(cityId);

                var data = result.Select(t => new Models.Temperature
                {
                    Degree = t.Degree,
                    DateTime = t.DateTime
                })
                .OrderBy(t=> t.DateTime)
                .Select(t=> new Models.BoxingTemperature 
                { 
                    Temperature = t
                })
                .ToList();

                Temperatures = new ObservableCollection<Models.BoxingTemperature>(data);
            });
        }
    }
}
