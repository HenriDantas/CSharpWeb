using ScreenSoundWEB.Response;
using System.Net.Http.Json;

namespace ScreenSoundWEB.Services
{
    public class ArtistaService
    {
        private readonly HttpClient _httpClient;

        public ArtistaService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ArtistaResponse>?> GetArtistasAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ArtistaResponse>>("artistas");
        }
    }
}
