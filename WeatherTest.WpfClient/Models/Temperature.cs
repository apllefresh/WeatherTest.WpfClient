using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherTest.WpfClient.Models
{
    public class Temperature : INotifyPropertyChanged
    {
        private int _degree;
        private DateTime _dateTime;

        public int Degree
        {
            get => _degree;
            set
            {
                _degree = value;
                OnPropertyChanged("Degree");
            }
        }
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged("DateTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
