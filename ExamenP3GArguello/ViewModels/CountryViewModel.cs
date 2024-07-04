using ExamenP3GArguello.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenP3GArguello.ViewModels
{
    public class CountryViewModel : INotifyPropertyChanged
    {
        private Country _model;

        public Country Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                }
            }
        }

        public ICommand ComandoMostrarPaises { get; }

        public CountryViewModel()
        {
            ComandoMostrarPaises = new Command(() => { });
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
