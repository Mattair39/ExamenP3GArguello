using ExamenP3GArguello.Models;
using ExamenP3GArguello.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

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
                    OnPropertyChanged(nameof(Model));
                }
                
            }
        }

        public ICommand ComandoMostrarPaises { get; }

        public CountryViewModel()
        {
            Model = new Country();  
            ComandoMostrarPaises = new Command(async () => await ObtenerCountry ());
        }


        public async Task <Country> ObtenerCountry()
        {
            CountryRepository repo = new CountryRepository("country.db");
            Country country = await repo.RetornaPaisAsync();
            repo.GuardarCountry(country);
            Model.name = country.name;
            OnPropertyChanged(nameof(Model));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
