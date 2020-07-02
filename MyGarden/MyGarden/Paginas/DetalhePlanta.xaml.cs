using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Models;
using MyGarden.Banco;
using System.Security.Cryptography.X509Certificates;

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
    }
}