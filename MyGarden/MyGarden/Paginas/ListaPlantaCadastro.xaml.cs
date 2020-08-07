using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //cancelar
            await Navigation.PushAsync(new ListaPlanta());
        }

        public async void SalvarAction(object sender, EventArgs args)
        {
            //Obter dados da tela
            PlantaLista plantalista = new PlantaLista
            {
                NomePopularPL = NomePopularPL.Text,
                NomeCientificoPL = NomeCientificoPL.Text,
            };

            //Salvar informacoes no banco
            Database database = new Database();
            database.CadastroPL(plantalista);

            await DisplayAlert("MyGarden", "Planta adicionada na minha lista de desejo.", "OK");

            //Tela de sucesso
            await Navigation.PushAsync(new ListaPlanta());
        }
    }
}