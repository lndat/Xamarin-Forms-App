using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMitAlles
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            IncreaseCommand = new Command(IncreaseCount);
        }

        public ICommand IncreaseCommand { get; }

        int count = 0;
        public string DisplayCount => $"Sie haben {count} mal geklickt";
        public string DisplayName => $"Eingetragener Name: {Name}";

        public event PropertyChangedEventHandler PropertyChanged;



        string name = string.Empty;
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }
                else
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        //methods
        void OnPropertyChanged(string name)
        {

            // ui update 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        void OnPropertyChanged2([CallerMemberName] string propertyName = null)
        {

            // ui update 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void IncreaseCount()
        {

            count++;
            OnPropertyChanged2(nameof(DisplayCount));
        }
    }
}
