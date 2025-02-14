using Microsoft.VisualStudio.TestTools.UnitTesting;
using Client_WinUI_Serie_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_WinUI_Serie_MVVM.Models.EntityFramework;

namespace Client_WinUI_Serie_MVVM.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void PostSerieAsyncTest()
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

            var result = PostSerieAsync(serie);



        }
        [TestMethod()]
        public void PutSerieAsync()
        {

        }

        [TestMethod()]
        public void GetSerieAsync()
        {

        }

        [TestMethod()]
        public void GetSerieAsync(int id)
        {

        }


    }
}