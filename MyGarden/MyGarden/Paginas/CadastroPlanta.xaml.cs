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
    public partial class CadastroPlanta : ContentPage
    {
        public CadastroPlanta()
        {
            InitializeComponent();
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            //Obter dados da tela
            Planta planta = new Planta();
            planta.NomePopular = NomePopular.Text;
            planta.NomeCientifico = NomeCientifico.Text;
            planta.Observacoes = Observacoes.Text;

            //Salvar informacoes no banco
            Database database = new Database();
            database.Cadastro(planta);

            //Voltar para tela de pesquisa
            App.Current.MainPage = new NavigationPage(new Home());

        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}