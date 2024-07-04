using ExamenP3GArguello.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3GArguello.Repositories
{
    public class CountryRepository
    {

        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Country>();
        }

        //Constructor
        public CountryRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public async Task <Country> RetornaPais()
        {
            HttpClient client = new HttpClient();
            string url = "https://restcountries.com/v3.1/all";
            var response = client.GetAsync(url);
            string response_json = await response.Result.Content.ReadAsStringAsync();

            Country country = JsonConvert.DeserializeObject<Country>(response_json);

            return country;
        }
        public void GuardarCountry(Country country)
        {
            conn.Insert(country);
        }


        public void EliminarCountry(Country country)
        {
            conn.Delete(country);
        }

        public List<Country> DevuelveListaCountry()
        {
            return conn.Table<Country>().ToList();
        }

        internal async Task<Country> RetornaPaisAsync()
        {
            throw new NotImplementedException();
        }
    }
}
