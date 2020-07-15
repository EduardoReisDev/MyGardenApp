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
    public partial class BemVindo : ContentPage
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        public async void GoTermos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Termos());
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}