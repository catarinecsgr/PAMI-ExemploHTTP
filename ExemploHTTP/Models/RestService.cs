using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace ExemploHTTP.Models
{
    public class RestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions; //pega um json e transforma em um objeto

        public ObservableCollection<Postagem> Postagens { get; set; }
        public ObservableCollection<Photo> Photos { get; set; }

        public RestService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<Postagem>> GetPostagensAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Postagens = JsonSerializer.Deserialize<ObservableCollection<Postagem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Postagens ?? [];
        }

        public async Task<ObservableCollection<Photo>> GetPhotosAsync()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/photos");
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Photos = JsonSerializer.Deserialize<ObservableCollection<Photo>>(content, _serializerOptions);
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Photos ?? [];
        }
    }
}
