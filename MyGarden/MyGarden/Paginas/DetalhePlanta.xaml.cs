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
    public partial class DetalhePlanta : ContentPage
    {
        public DetalhePlanta(Planta planta)
        {
            InitializeComponent();
            BindingContext = planta;
        }

        public void GoEditar(object sender, EventArgs args)
        {
            Button btnEditar = (Button)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)btnEditar.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            Navigation.PushAsync(new EditarPlanta(planta));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Button btnExcluir = (Button)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)btnExcluir.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            Database database = new Database();
            database.Exclusao(planta);
        }
    }
}