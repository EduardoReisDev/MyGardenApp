using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        public async void GoDetalhe(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new DetalhePlanta());
        }

        public async void GoCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CadastroPlanta());
        }
    }
}