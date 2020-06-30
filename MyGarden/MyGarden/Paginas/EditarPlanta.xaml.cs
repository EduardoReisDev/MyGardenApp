using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Banco;
using MyGarden.Models;
using Xamarin.Essentials;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPlanta : ContentPage
    {
        private Planta planta { get; set; }

        string dia1 = null;
        string dia2 = null;
        string dia3 = null;
        string dia4 = null;
        string dia5 = null;
        string dia6 = null;
        string dia7 = null;

        public void BtnSegunda(object sender, ToggledEventArgs e)
        {
            dia1 = "Segunda";
        }

        public void BtnTerca(object sender, ToggledEventArgs e)
        {
            dia2 = "Terca";
        }

        public void BtnQuarta(object sender, ToggledEventArgs e)
        {
            dia3 = "Quarta";
        }

        public void BtnQuinta(object sender, ToggledEventArgs e)
        {
            dia4 = "Quinta";
        }

        public void BtnSexta(object sender, ToggledEventArgs e)
        {
            dia5 = "Sexta";
        }

        public void BtnSabado(object sender, ToggledEventArgs e)
        {
            dia6 = "Sabado";
        }

        public void BtnDomingo(object sender, ToggledEventArgs e)
        {
            dia7 = "Domingo";
        }

        public EditarPlanta(Planta planta)
        {
            InitializeComponent();
            this.planta = planta;

            NomePopular.Text = planta.NomePopular;
            NomeCientifico.Text = planta.NomeCientifico;
            Observacao.Text = planta.Observacao;
        }

        public void Salvar(object sender, EventArgs args)
        {
            planta.NomePopular = NomePopular.Text;
            planta.NomeCientifico = NomeCientifico.Text;
            planta.Observacao = Observacao.Text;
            planta.DiaUm = dia1;
            planta.DiaDois = dia2;
            planta.DiaTres = dia3;
            planta.DiaQuatro = dia4;
            planta.DiaCinco = dia5;
            planta.DiaSeis = dia6;
            planta.DiaSete = dia7;

            Database database = new Database();
            database.Atualizacao(planta);

            DisplayAlert("MyGarden","Parabéns, planta editada com sucesso!", "Ótimo");

            App.Current.MainPage = new NavigationPage(new Home());
        }

        public void GoHome(object sender, EventArgs args) 
        {
            App.Current.MainPage = new NavigationPage(new Home());
        }
    }
}