using PropertyChanged;
using System.Text.Json;
using System.Windows.Input;
using WeatherApp.MVVM.Models;

namespace WeatherApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {

        public WeatherData WeatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        private HttpClient client;

        public WeatherViewModel()
        {
            client = new HttpClient();
            WeatherData = new WeatherData();
        }

        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                PlaceName= searchText.ToString();
                var location = 
                await GetCoordinatesAsync(searchText.ToString());
                await GetWeather(location);
            });

        //public async Task<Location> GetCoordinatesAsync(string address)
        //{
        //    var locations = await Geocoding.GetLocationsAsync(address);

        //    return locations?.FirstOrDefault();
        //}

        public async Task GetWeather(Location location)
        {
            var url =
                $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";

            var response = await client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                using(var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<WeatherData>(responseStream);
                    WeatherData = data;
                }
            }
        }

        public async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding.GetLocationsAsync(address);

            Location location = locations?.FirstOrDefault();

            if(location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
            return location;
        }
    }
}
