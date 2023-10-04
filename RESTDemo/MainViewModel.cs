using System.Text.Json;
using System.Windows.Input;

namespace RESTDemo
{
    public class MainViewModel
    {
        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://65193268818c4e98ac6021ad.mockapi.io";

        public MainViewModel()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                //PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public ICommand GetAllUsersCommand => 
            new Command(async () =>
        {
            var url = $"{baseUrl}/users";
            var response = 
            await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();
                using(var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = 
                    await JsonSerializer.DeserializeAsync<List<User>>(responseStream, _serializerOptions);
                }
            }
        });

    }
}
