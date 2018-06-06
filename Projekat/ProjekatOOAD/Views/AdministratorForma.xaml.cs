using ProjekatOOAD.Models;
using ProjekatOOAD.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatOOAD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Administrator : Page
    {
        public static ObservableCollection<Lokal> o;

        public Administrator()
        {
           
            this.InitializeComponent();
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
            o = new ObservableCollection<Lokal>();
        }

        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        AdministratorViewModel viewModel;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel = (AdministratorViewModel)e.Parameter;
            DataContext = viewModel;
            

        }
        

        private void comboPonudeObrisi_Loaded(object sender, RoutedEventArgs e)
        {
            o = new ObservableCollection<Lokal>();
            foreach (Lokal a in viewModel.Dernek.Ponude)
            {
                o.Add(a);
            }
            comboPonudeObrisi.ItemsSource = o;
            comboPonudeObrisi.DisplayMemberPath = "Naziv";
            
        }

        private void comboPonudeObrisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewModel.ponudaZaBrisanje = (Lokal)comboPonudeObrisi.SelectedItem;
        }

        private void comboPonudeAzuriraj_Loaded(object sender, RoutedEventArgs e)
        {
            
            comboPonudeAzuriraj.ItemsSource = o;
            comboPonudeAzuriraj.DisplayMemberPath = "Naziv";
        }

        private void comboPonudePutovanja_Loaded(object sender, RoutedEventArgs e)
        {
            
            comboPonudePutovanja.ItemsSource = o;
            comboPonudePutovanja.DisplayMemberPath = "Naziv";
        }

        private void comboPonudeAzuriraj_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewModel.ponudaZaMijenjanje = (Lokal)comboPonudeObrisi.SelectedItem;

        }

        private void comboPonudePutovanja_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewModel.opis = (Lokal)comboPonudeObrisi.SelectedItem;

        }
        
    }
}
