﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using WeatherTest.WpfClient.WeatherServiceReference;

namespace WeatherTest.WpfClient.ViewNodels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.City> Cities { get; set; }
        public ObservableCollection<Models.BoxingTemperature> Temperatures { get; set; }
        private Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        private readonly WeatherServiceClient _client;

        private int _selectedCityId;

        public int SelectedCityId
        {
            get => _selectedCityId;
            set
            {
                _selectedCityId = value;
                OnPropertyChanged("SelectedCityId");
                
                GetCityWeather(value);
                OnPropertyChanged("Temperatures");
            }
        }

        private bool _isNotEnoughDataForSelectedCity;
        public bool IsNotEnoughDataForSelectedCity
        {
            get => _isNotEnoughDataForSelectedCity;
            set
            {
                _isNotEnoughDataForSelectedCity = value;
                OnPropertyChanged("IsNotEnoughDataForSelectedCity");
            }
        }

        private DateTime _currentDate;
        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged("CurrentDate");
            }
        }

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ApplicationViewModel()
        {
            _client = new WeatherServiceClient();
            Cities = new ObservableCollection<Models.City>();
            GetData();
            IsNotEnoughDataForSelectedCity = true;
            CurrentDate = DateTime.Now.AddDays(1).Date;
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
                var result = _client.GetCityWeather(cityId, _currentDate);

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

                IsNotEnoughDataForSelectedCity = !data.Any();

                Temperatures = new ObservableCollection<Models.BoxingTemperature>(data);
            });
        }
    }
}
