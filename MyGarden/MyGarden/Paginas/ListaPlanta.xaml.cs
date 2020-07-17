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
    public partial class ListaPlanta : ContentPage
    {
        public ListaPlanta()
        {
            InitializeComponent();
        }

        public async void GoCadastro(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ListaPlantaCadastro());
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaPlantas.ItemsSource = Lista.Where(a => a.NomePopularPL.Contains(args.NewTextValue)).ToList();
        }
    }
}