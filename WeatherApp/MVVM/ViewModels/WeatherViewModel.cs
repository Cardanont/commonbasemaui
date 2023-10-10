using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.MVVM.ViewModels
{
    public class WeatherViewModel
    {
        public ICommand SearchCommand =>
            new Command(async (searchText) =>
            {
                var location = 
                await GetCoordinatesAsync(searchText.ToString());
            });

        //public async Task<Location> GetCoordinatesAsync(string address)
        //{
        //    var locations = await Geocoding.GetLocationsAsync(address);

        //    return locations?.FirstOrDefault();
        //}

        // async task to get coordinates from address

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
