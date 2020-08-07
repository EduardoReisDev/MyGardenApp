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
    public partial class ComoFunciona : ContentPage
    {
        public ComoFunciona()
        {
            InitializeComponent();
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Opcoes());
        }
    }
}