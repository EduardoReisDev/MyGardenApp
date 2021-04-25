using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SucessoPlanta : ContentPage
    {
        public SucessoPlanta()
        {
            InitializeComponent();
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}