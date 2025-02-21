using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Client_WinUI_Serie_MVVM.Models;
using Client_WinUI_Serie_MVVM.Services;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Client_WinUI_Serie_MVVM.ViewModels
{
    public class UpdateSerieViewModel : INotifyPropertyChanged
    {
        private Serie _serieToAdd;

        public UpdateSerieViewModel()
        {
            _serieToAdd = new Serie();
            Modifier = new RelayCommand(ModifierSerie);
            Supprimer = new RelayCommand(SupprimerSerie);
            Recherche = new RelayCommand(RechercheSerie);
        }
        public Serie SerieToAdd
        {
            get => _serieToAdd;
            set { _serieToAdd = value; OnPropertyChanged(nameof(SerieToAdd)); }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void MessageAsync(string title, string message)
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };

            Dialog.XamlRoot = App.MainRoot.XamlRoot;
            Dialog.ShowAsync();

        }

        public IRelayCommand Modifier { get;}
        
        public async void ModifierSerie()
        {
            WSService servise = new WSService("http://localhost:5062/api/");
            bool result = await servise.PutSerieAsync(SerieToAdd.Serieid,SerieToAdd);
            if (result == true)
                MessageAsync("Confirmation", "Vous avez modifier une nouvelle serie");
        }

        public IRelayCommand Supprimer { get; }

        public async void SupprimerSerie()
        {
            WSService servise = new WSService("http://localhost:5062/api/");
            bool result = await servise.DeleteSerieAsync(SerieToAdd.Serieid);
            if (result == true)
                MessageAsync("Confirmation", "Vous avez supprimer une nouvelle serie");
        }

        public IRelayCommand Recherche { get; }

        public async void RechercheSerie()
        {
            WSService servise = new WSService("http://localhost:5062/api/");
            Task<Serie> result = servise.GetSerieAsync("series",SerieToAdd.Serieid);
            
        }

    }    
}
