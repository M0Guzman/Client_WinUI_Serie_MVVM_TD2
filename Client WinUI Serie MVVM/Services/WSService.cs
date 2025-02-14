using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Text.Json.Serialization;



namespace Client_WinUI_Serie_MVVM.Services
{
    public class WSService : IService
    {
        private readonly HttpClient httpClient;

        private HttpClient client;

        public HttpClient Client
        {
            get { return client; }
            set { client = value; }
        }

        public WSService()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5223/api");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public WSService(string uri)
        {
            Client = new HttpClient();
            if (Uri.TryCreate(uri, UriKind.Absolute, out Uri baseUri))
            {
                Client.BaseAddress = baseUri;
            }
            else
            {
                throw new ArgumentException("Invalid URI provided.", nameof(uri));
            }

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
        }


        public async Task<List<Serie>> GetSerieAsync(string nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception e)
            {
                
                return null;
            }

        }

        public async Task<Serie> GetSerieAsync(int serieId)
        {
            string url = string.Concat("api/series/", serieId.ToString());

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    Serie serie = JsonSerializer.Deserialize<Serie>(jsonString);

                    return serie;
                }
                else
                {
                    throw new Exception("Erreur lors de la récupération de la série.");
                }
            }
        }
        public async Task<bool> PostSerieAsync(Serie nouvelleSerie)
        {
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = await client.PostAsJsonAsync<Serie>("api/series", nouvelleSerie);

                if (response.IsSuccessStatusCode)
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<bool> PutSerieAsync(int serieId, Serie serieMiseAJour)
        {
            using (HttpClient client = new HttpClient())
            {
                // Convertir l'objet 'serieMiseAJour' en JSON
                string jsonContent = JsonSerializer.Serialize(serieMiseAJour);
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Envoyer la requête PUT
                HttpResponseMessage response = await client.PutAsync($"api/series/{serieId}", content);

                // Vérifier si la requête a réussi
                return response.IsSuccessStatusCode; // ou response.EnsureSuccessStatusCode() si vous préférez lever une ex

            }
        }

        public async Task<bool> DeleteSerieAsync(int serieId)
        {
            using (HttpClient client = new HttpClient())
            {
                // Envoyer la requête DELETE
                HttpResponseMessage response = await client.DeleteAsync($"api/series/{serieId}");

                // Vérifier si la requête a réussi
                return response.IsSuccessStatusCode; // ou response.EnsureSuccessStatusCode() si vous préférez lever une exception en cas d'échec
            }
        }


    }
}
