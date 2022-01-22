using System;
using System.IO;
using Xamarin.Forms;
using QueratoCheck.Model;
using System.Collections.Generic;

namespace QueratoCheck
{
    public partial class InformationEntryPage : ContentPage
    {
        public InformationEntryPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (
                !string.IsNullOrEmpty(Ant.Text) &&
               !string.IsNullOrEmpty(Post.Text) &&
               !string.IsNullOrEmpty(Kmax.Text) &&
               !string.IsNullOrEmpty(Kmin.Text) &&
               !string.IsNullOrEmpty(Mean.Text) &&
               !string.IsNullOrEmpty(Sim.Text) &&
               !string.IsNullOrEmpty(Astig.Text) &&
               !string.IsNullOrEmpty(Thin.Text))

            {
                var ant = double.Parse(Ant.Text);
                var post = double.Parse(Post.Text);
                var kmax = double.Parse(Kmax.Text);
                var kmin = double.Parse(Kmin.Text);
                var mean = double.Parse(Mean.Text);
                var sim = double.Parse(Sim.Text);
                var astig = double.Parse(Astig.Text);
                var thin = double.Parse(Thin.Text);

                double p1, p3, p4, p5, p7, p8, suma;
                if (ant > 0.04)
                { p1 = 1; }
                else
                { p1 = 0; }

                if (kmax > 47.2)
                { p3 = 1; }
                else
                { p3 = 0; }

                if (kmin > 47.2)
                { p4 = 1; }
                else
                { p4 = 0; }

                if (mean > 47.2)
                { p5 = 1; }
                else
                { p5 = 0; }

                if (astig > 3)
                { p7 = 1; }
                else
                { p7 = 0; }

                if (thin < 463)
                { p8 = 1; }
                else
                { p8 = 0; }

                suma = p1 + p3 + p4 + p5 + p7 + p8;
                string resultado = "";

                if (post > 0.037)
                { resultado = "Sospechoso de queratocono. Puede ser un posible candidato a ser operado.";
                    Analisis.Text = resultado;
                }
                else if ((25 <= mean && mean <= 65) || (115 <= mean && mean <= 155))
                { resultado = "Sospechoso de queratocono. Puede ser un posible candidato a ser operado.";
                    Analisis.Text = resultado;
                }
                else if (suma >= 3 && suma <= 5)
                { resultado = "Sospechoso de queratocono. Puede ser un posible candidato a ser operado.";
                    Analisis.Text = resultado;
                }
                else if (suma == 6)
                { resultado = " Tiene queratocono. Es candidato a ser operado";
                    Analisis.Text = resultado;
                }
                else
                { resultado = "Ojo normal. Todo está bien";
                    Analisis.Text = resultado;
                }

                DisplayAlert("Resultado", resultado, "Ok");



            }
            else
            {
                DisplayAlert("Datos incorrectos", "Llenar todas las casillas", "Ok");
            }

        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Information)BindingContext;
            note.Date = DateTime.Now;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Information)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }

}