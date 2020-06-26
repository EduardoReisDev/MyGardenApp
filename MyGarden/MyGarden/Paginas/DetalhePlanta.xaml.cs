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
    public partial class DetalhePlanta : ContentPage
    {
        public DetalhePlanta()
        {
            InitializeComponent();
        }

        public async void GoEditar(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EditarPlanta());
        }
    }
}