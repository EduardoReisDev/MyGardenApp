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
            ConsultarPlantas();

        }

        public void ConsultarPlantas()
        {
            Database database = new Database();
            Lista = database.Consultar();
            ListaPlantas.ItemsSource = Lista;

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

        public void GoEditar(object sender, EventArgs args)
        {
            Image btnEditar = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)btnEditar.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;

            Navigation.PushAsync(new EditarPlanta(planta));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Image btnExcluir = (Image)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)btnExcluir.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            Database database = new Database();
            database.Exclusao(planta);

            ConsultarPlantas();
        }
    }
}