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
    public partial class Home : ContentPage
    {
        List<Planta> Lista { get; set; }

        public Home()
        {
            InitializeComponent();
            Database database = new Database();
            Lista = database.Consultar();
            ListaPlantas.ItemsSource = database.Consultar();
            LblCount.Text = Lista.Count.ToString();
        }

        public async void GoDetalhe(object sender, EventArgs args)
        {
            Frame GoDetalhe = (Frame)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)GoDetalhe.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            await Navigation.PushAsync(new DetalhePlanta(planta));
        }

        public void PesquisarAction (object sender, TextChangedEventArgs args)
        {
            ListaPlantas.ItemsSource = Lista.Where(a => a.NomePopular.Contains(args.NewTextValue)).ToList();
        }

        public async void GoCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CadastroPlanta());
        }
    }
}