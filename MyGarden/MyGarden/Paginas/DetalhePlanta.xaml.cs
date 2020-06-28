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
            Button GoEditar = (Button)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)GoEditar.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            Navigation.PushAsync(new Paginas.EditarPlanta(planta));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Button ExcluirAction = (Button)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)ExcluirAction.GestureRecognizers[0];
            Planta planta = tapGest.CommandParameter as Planta;
            Database database = new Database();
            database.Exclusao(planta);

            Navigation.PushAsync(new Home());        
        }
    }
}