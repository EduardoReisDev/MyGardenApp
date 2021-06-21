using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Models;
using MyGarden.Banco;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPlantaCadastro : ContentPage
    {
        public ListaPlantaCadastro()
        {
            InitializeComponent();
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        public async void BackPageButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public async void SalvarAction(object sender, EventArgs args)
        {
            PlantaLista plantalista = new PlantaLista
            {
                NomePopularPL = NomePopularPL.Text,
                NomeCientificoPL = NomeCientificoPL.Text,
            };

            Database database = new Database();
            database.CadastroPL(plantalista);

            await DisplayAlert("MyGarden", "Planta adicionada na minha lista de desejo.", "OK");

            await Navigation.PopAsync();
        }
    }
}