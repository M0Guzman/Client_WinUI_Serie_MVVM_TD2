using Client_WinUI_Serie_MVVM.Services;
using Client_WinUI_Serie_MVVM.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Client_WinUI_Serie_MVVM.Models.EntityFramework;
using Client_WinUI_Serie_MVVM.ViewModels;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Client_WinUI_Serie_MVVM
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new AddSerieViewModel();
        }

        private void AjouterSerie(object sender, RoutedEventArgs e)
        {
            Serie serie = new Serie 
            {
                
                Titre = TextBoxTitre.Text,
                Resume = TextBoxResume.Text,
                Nbsaisons = Convert.ToInt16(BoxNbsaisons.Text),
                Nbepisodes = Convert.ToInt16(BoxNbepisodes.Text),
                Anneecreation = Convert.ToInt16(BoxAnneeCreation.Text),
                Network = BoxChaine.Text

            };
             bool result = WSService.PostSerieAsync(serie);
        }
    }
}
