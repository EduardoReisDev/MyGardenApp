using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Models;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhePlanta : ContentPage
    {
        public DetalhePlanta(Planta planta)
        {
            InitializeComponent();
            VerificaDiaUm(planta);
            VerificaDiaDois(planta);
            VerificaDiaTres(planta);
            VerificaDiaQuatro(planta);
            VerificaDiaCinco(planta);
            VerificaDiaSeis(planta);
            VerificaDiaSete(planta);
            BindingContext = planta;
        }

        public async void BackPageButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        public void VerificaDiaUm(Planta planta)
        {
            if (planta.DiaUm == null)
            {
                DiaUm.IsVisible = false;
            }

            else
            {
                DiaUm.IsVisible = true;
            }
        }

        public void VerificaDiaDois(Planta planta)
        {
            if (planta.DiaDois == null)
            {
                DiaDois.IsVisible = false;
            }

            else
            {
                DiaDois.IsVisible = true;
            }
        }

        public void VerificaDiaTres(Planta planta)
        {
            if (planta.DiaTres == null)
            {
                DiaTres.IsVisible = false;
            }

            else
            {
                DiaTres.IsVisible = true;
            }
        }

        public void VerificaDiaQuatro(Planta planta)
        {
            if (planta.DiaQuatro == null)
            {
                DiaQuatro.IsVisible = false;
            }

            else
            {
                DiaQuatro.IsVisible = true;
            }
        }

        public void VerificaDiaCinco(Planta planta)
        {
            if (planta.DiaCinco == null)
            {
                DiaCinco.IsVisible = false;
            }

            else
            {
                DiaCinco.IsVisible = true;
            }
        }

        public void VerificaDiaSeis(Planta planta)
        {
            if (planta.DiaSeis == null)
            {
                DiaSeis.IsVisible = false;
            }

            else
            {
                DiaSeis.IsVisible = true;
            }
        }

        public void VerificaDiaSete(Planta planta)
        {
            if (planta.DiaSete == null)
            {
                DiaSete.IsVisible = false;
            }

            else
            {
                DiaSete.IsVisible = true;
            }
        }
    }
}