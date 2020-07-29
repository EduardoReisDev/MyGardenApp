using Java.Lang;
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
    public partial class Opcoes : ContentPage
    {
        public Opcoes()
        {
            InitializeComponent();
        }

        [Obsolete]
        public void GoFeedback (object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("mailto:eduardoreisdev@gmail.com?subject=MyGarden_Feedback"));
        }

        [Obsolete]
        public void GoAvalieApp(object sender, EventArgs args)
        {
            Device.OpenUri(new Uri("https://play.google.com/store?hl=pt_BR"));
        }

        public async void GoTermos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Termos());
        }

        public async void GoHelp(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ComoFunciona());
        }

        public async void GoSair(object sender, EventArgs args)
        {
            string action = await DisplayActionSheet("Sair do MyGarden?", "Cancelar", null, "Sim, quero sair.", "Não");
            if (action == "Sim, quero sair.")
            {
                JavaSystem.Exit(0);
            }
            else
            {
                await Navigation.PushAsync(new TabbedPage1());
            }
        }
    }
}