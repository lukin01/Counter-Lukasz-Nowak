using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Views
{
    public class CounterModel : INotifyPropertyChanged
    {
        private int _counterValue;

        public string Name { get; set; } = "";

        public int CounterValue
        {
            get { return _counterValue; }
            set
            {
                _counterValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CounterValue)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Increase()
        {
            CounterValue++;
        }
        public void Decrease()
        {
            CounterValue--;
        }
    }
}
