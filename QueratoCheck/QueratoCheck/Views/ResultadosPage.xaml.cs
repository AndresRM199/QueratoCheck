using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueratoCheck.Views;
using QueratoCheck.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QueratoCheck.ViewModels;

namespace QueratoCheck.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultadosPage : ContentPage
    {
        public ResultadosPage()
        {
            InitializeComponent();
            BindingContext = new ExportingExcelViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
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