using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeatherTest.WpfClient.Models
{
    public class BoxingTemperature : INotifyPropertyChanged
    {
        private Temperature _temperature;

        public Temperature Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
