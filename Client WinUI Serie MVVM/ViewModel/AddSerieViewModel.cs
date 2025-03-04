﻿using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Client_WinUI_Serie_MVVM.Models;
using Client_WinUI_Serie_MVVM.Services;
using Microsoft.UI.Xaml.Controls;
using Client_WinUI_Serie_MVVM.View;
using Microsoft.UI.Xaml;

namespace Client_WinUI_Serie_MVVM.ViewModels
{
    public class AddSerieViewModel : INotifyPropertyChanged
    {
        private Serie _serieToAdd;

        public AddSerieViewModel()
        {
            _serieToAdd = new Serie();
            Ajouter = new RelayCommand(AjouterSerie);
            Modifier = new RelayCommand(ModifierSerie);
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

        public IRelayCommand Ajouter { get;}
        private Window m_window;
        public static FrameworkElement MainRoot { get; private set; }
        public async void AjouterSerie()
        {
           
            
            WSService servise = new WSService("http://localhost:5062/api/");
            bool result = await servise.PostSerieAsync(SerieToAdd);
            if(result == true)
                MessageAsync("Confirmation", "Vous avez ajouter une nouvelle serie");
        }
        public IRelayCommand Modifier { get; }
        public async void ModifierSerie()
        {
            Frame rootFrame = new Frame();
            this.m_window = new MainWindow();
            this.m_window.Content = rootFrame;
            m_window.Activate();
            rootFrame.Navigate(typeof(AddSerie));
            MainRoot = m_window.Content as FrameworkElement;
        }

        
    }

}    

