using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_WinUI_Serie_MVVM.Services;
using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Client_WinUI_Serie_MVVM.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {


        [TestMethod()]
        public async Task PostSerieTestAsync()
        {
            Serie serie = new Serie
            {
                Serieid = 601,
                Titre = "Scrubs",
                Resume = "resume",
                Nbsaisons = 2,
                Nbepisodes = 24,
                Anneecreation = 2024,
                Network = "Netflix"
            };

            WSService wsService = new WSService(); // Pass the HttpClient instance

            var result = await wsService.PostSerieAsync(serie);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task PutSerieAsyncTest()
        {
            Serie serie = new Serie
            {
                Serieid = 601,
                Titre = "Scrubs",
                Resume = "resume",
                Nbsaisons = 3,
                Nbepisodes = 36,
                Anneecreation = 2024,
                Network = "Netflix"
            };

           WSService wsService = new WSService(); // Pass the HttpClient instance

            var result = await wsService.PutSerieAsync(601,serie);

            Assert.IsTrue(result);
        }

        

        [TestMethod()]
        public async Task GetSerieAsyncTest()
        {
            string title = "Scrubs";

            WSService wsService = new WSService(); // Pass the HttpClient instance

            Serie serie = await wsService.GetSerieAsync("series",1);

            Assert.AreEqual(title, serie.Titre, "titre get 1");
        }
    }
}