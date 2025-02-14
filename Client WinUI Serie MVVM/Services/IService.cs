
using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_WinUI_Serie_MVVM.Services
{
    public interface IService
    {
        Task<List<Serie>> GetSerieAsync();
        Task<Serie> GetSerieAsync(string nomControleur,int serieid);
        Task<bool> PostSerieAsync(Serie nouvelleSerie);
        Task<bool> PutSerieAsync(int serieId, Serie serieMiseAJour);
        Task<bool> DeleteSerieAsync(int serieId);

    }
}