using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using QueratoCheck.ViewModels;
using QueratoCheck.Views;
using QueratoCheck.Model;

namespace QueratoCheck
{
 
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new ExportingExcelViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InformationEntryPage
            {
                BindingContext = new Information()
            });
        }
        
        async void ResultClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultadosPage());
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new InformationEntryPage
                {
                    BindingContext = e.SelectedItem as Information
                });
            }
        }

       
    }
}