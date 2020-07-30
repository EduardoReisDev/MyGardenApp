using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Banco;
using MyGarden.Models;
using Xamarin.Essentials;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarPlanta : ContentPage
    {
        private Planta planta { get; set; }

        string dia1 = null;
        string dia2 = null;
        string dia3 = null;
        string dia4 = null;
        string dia5 = null;
        string dia6 = null;
        string dia7 = null;
        string NomeArquivo = null;

        public void BtnSegunda(object sender, ToggledEventArgs e)
        {
            dia1 = "Segunda";
        }

        public void BtnTerca(object sender, ToggledEventArgs e)
        {
            dia2 = "Terca";
        }

        public void BtnQuarta(object sender, ToggledEventArgs e)
        {
            dia3 = "Quarta";
        }

        public void BtnQuinta(object sender, ToggledEventArgs e)
        {
            dia4 = "Quinta";
        }

        public void BtnSexta(object sender, ToggledEventArgs e)
        {
            dia5 = "Sexta";
        }

        public void BtnSabado(object sender, ToggledEventArgs e)
        {
            dia6 = "Sabado";
        }

        public void BtnDomingo(object sender, ToggledEventArgs e)
        {
            dia7 = "Domingo";
        }

        public EditarPlanta(Planta planta)
        {
            InitializeComponent();
            this.planta = planta;

            NomePopular.Text = planta.NomePopular;
            NomeCientifico.Text = planta.NomeCientifico;
            Observacao.Text = planta.Observacao;
        }

        public async void AbrirCamera(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Nenhuma Câmera", ":( Nenuma Câmera disponível.", "OK");
                return;
            }

            var arquivo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 40,
                SaveToAlbum = true,
            });

            NomeArquivo = arquivo.Path;

            await DisplayAlert("Foto selecionada com sucesso!", NomeArquivo, "OK");

            if (arquivo == null)
            {
                await DisplayAlert("Alerta", "Nenhum arquivo selecionado", "OK");
            }
        }


        public async void AbrirGaleria(object sender, EventArgs args)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");

                return;
            }

            var arquivo = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                CompressionQuality = 40

            });

            NomeArquivo = arquivo.Path;

            await DisplayAlert("Foto selecionada com sucesso!", NomeArquivo, "OK");

            if (arquivo == null)
                return;
        }

        public void Salvar(object sender, EventArgs args)
        {
            planta.NomePopular = NomePopular.Text;
            planta.NomeCientifico = NomeCientifico.Text;
            planta.Observacao = Observacao.Text;
            planta.DiaUm = dia1;
            planta.DiaDois = dia2;
            planta.DiaTres = dia3;
            planta.DiaQuatro = dia4;
            planta.DiaCinco = dia5;
            planta.DiaSeis = dia6;
            planta.DiaSete = dia7;

            Database database = new Database();
            database.Atualizacao(planta);

            DisplayAlert("MyGarden","Parabéns, planta editada com sucesso!", "Ótimo");

            App.Current.MainPage = new NavigationPage(new TabbedPage1());
        }

        public void GoHome(object sender, EventArgs args) 
        {
            App.Current.MainPage = new NavigationPage(new TabbedPage1());
        }
    }
}