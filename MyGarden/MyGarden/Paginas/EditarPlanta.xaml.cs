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
            Observacao.Text = planta.Observacao;
        }

        public void Salvar(object sender, EventArgs args)
        {
            planta.NomePopular = NomePopular.Text;
            planta.NomeCientifico = NomePopular.Text;
            planta.Observacao = Observacao.Text;

            Database database = new Database();
            database.Atualizacao(planta);

            App.Current.MainPage = new NavigationPage(new Home());
        }

        public async void GoHome(object sender, EventArgs args)
        {
           await DisplayAlert("Nome popular", NomePopular.Text, "ok");
           await DisplayAlert("Nome cientifico", NomeCientifico.Text, "ok");
           await DisplayAlert("Observacao", Observacao.Text, "ok");
        }
    }
}