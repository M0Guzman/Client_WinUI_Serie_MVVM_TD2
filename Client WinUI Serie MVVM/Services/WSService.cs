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
            Client.BaseAddress = new Uri("http://localhost:5062/api/");
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


        public async Task<List<Serie>> GetSerieAsync()
        {
            try
            {
                return await Client.GetFromJsonAsync<List<Serie>>("series");
            }
            catch (Exception ex)
            {
                return null;
            }
            

        }

        public async Task<Serie> GetSerieAsync(string nomControleur, int serieId)
        {

            try
            {
                return await Client.GetFromJsonAsync<Serie>(string.Concat(nomControleur,"/",serieId));
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public async Task<bool> PostSerieAsync(Serie nouvelleSerie)
        {
            // Envoyer la requête POST
            HttpResponseMessage response = await Client.PostAsJsonAsync<Serie>($"series/{nouvelleSerie.Serieid}", nouvelleSerie);

            // Vérifier si la requête a réussi
            return true;

        }
        public async Task<bool> PutSerieAsync(int serieId, Serie serieMiseAJour)
        {
            // Envoyer la requête PUT
            HttpResponseMessage response = await Client.PutAsJsonAsync<Serie>($"series/{serieId}", serieMiseAJour);

            // Vérifier si la requête a réussi
            return true;

        }

        public async Task<bool> DeleteSerieAsync(int serieId)
        {
           
                // Envoyer la requête DELETE
                HttpResponseMessage response = await Client.DeleteAsync($"series/{serieId}");

                // Vérifier si la requête a réussi
                return response.IsSuccessStatusCode; // ou response.EnsureSuccessStatusCode() si vous préférez lever une exception en cas d'échec
            
        }


    }
}
