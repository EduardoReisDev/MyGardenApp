using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Models;
using MyGarden.Banco;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MyGarden.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPlanta : ContentPage
    {
        string dia1 = null;
        string dia2 = null;
        string dia3 = null;
        string dia4 = null;
        string dia5 = null;
        string dia6 = null;
        string dia7 = null;

        public CadastroPlanta()
        {
            InitializeComponent();
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }

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
                SaveToAlbum = true,
            });

            string NomeArquivo = arquivo.AlbumPath;
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

            var arquivo = await CrossMedia.Current.PickPhotoAsync();

            string NomeArquivo = arquivo.AlbumPath;
            await DisplayAlert("Foto selecionada com sucesso!", NomeArquivo, "OK");

            if (arquivo == null)
                return;
        }

        public void SalvarAction(object sender, EventArgs args)
        {
            //Obter dados da tela
            Planta planta = new Planta
            {
                NomePopular = NomePopular.Text,
                NomeCientifico = NomeCientifico.Text,
                Observacao = Observacao.Text,
                DiaUm = dia1,
                DiaDois = dia2,
                DiaTres = dia3,
                DiaQuatro = dia4,
                DiaCinco = dia5,
                DiaSeis = dia6,
                DiaSete = dia7
            };

            //Salvar informacoes no banco
            Database database = new Database();
            database.Cadastro(planta);

            DisplayAlert("MyGarden", "Parabéns, planta cadastrada com sucesso!", "Ótimo");

            //Voltar para tela de pesquisa
            App.Current.MainPage = new NavigationPage(new Home());
        }
    }
}