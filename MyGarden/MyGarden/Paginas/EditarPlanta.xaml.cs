using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Banco;
using MyGarden.Models;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPlanta : ContentPage
    {
        private Planta planta { get; set; }

        public EditarPlanta(Planta planta)
        {
            InitializeComponent();

            NomePopular.Text = planta.NomePopular;
            NomeCientifico.Text = planta.NomeCientifico;
            Observacoes.Text = planta.Observacao;
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }

        private void SalvarAction(object sender, EventArgs args)
        {
            planta.NomePopular = NomePopular.Text;
            planta.NomeCientifico = NomeCientifico.Text;
            planta.Observacao = Observacoes.Text;

            Database database = new Database();
            database.Atualizacao(planta);

            App.Current.MainPage = new NavigationPage(new Home());
        }
    }
}