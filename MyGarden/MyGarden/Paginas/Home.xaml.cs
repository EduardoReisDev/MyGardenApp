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
            lblCount.Text = Lista.Count.ToString();
        }

        public async void GoDetalhe(object sender, EventArgs args)
        {
            Frame 
            await Navigation.PushAsync(new DetalhePlanta());
        }

        public async void GoCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CadastroPlanta());
        }
    }
}