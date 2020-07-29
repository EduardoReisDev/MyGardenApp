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
    public partial class Termos : ContentPage
    {
        public Termos()
        {
            InitializeComponent();
        }

        public async void GoBemVindo(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TabbedPage1());
        }
    }
}