using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Client_WinUI_Serie_MVVM.Models;

namespace Client_WinUI_Serie_MVVM.ViewModels
{
    public class AddSerieViewModel : INotifyPropertyChanged
    {
        private Serie _serieToAdd;
        public Serie SerieToAdd
        {
            get => _serieToAdd;
            set { _serieToAdd = value; OnPropertyChanged(nameof(SerieToAdd)); }
        }

        public ICommand AddSerieCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddSerieViewModel()
        {
            SerieToAdd = new Serie();
            AddSerieCommand = new RelayCommand(AddSerie, CanAddSerie);
        }

        private void AddSerie()
        {
            // Simuler un enregistrement (ex: appel API plus tard)
            Console.WriteLine($"Série ajoutée : {SerieToAdd.Titre}");
        }

        private bool CanAddSerie()
        {
            return !string.IsNullOrWhiteSpace(SerieToAdd.Titre) &&
                   !string.IsNullOrWhiteSpace(SerieToAdd.Resume) &&
                   !string.IsNullOrWhiteSpace(SerieToAdd.Network) &&
                   SerieToAdd.Nbsaisons > 0 &&
                   SerieToAdd.Nbepisodes > 0 &&
                   SerieToAdd.Anneecreation > 1990;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();
        public event EventHandler CanExecuteChanged;
    }
}
