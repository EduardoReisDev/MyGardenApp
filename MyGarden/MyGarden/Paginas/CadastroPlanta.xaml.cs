using System;
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
        string NomeArquivo = null;

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
            bool value = e.Value;

            if (value == true)
            {
                dia1 = "Segunda";
            }

            else
            {
                dia1 = null;
            }
        }

        public void BtnTerca(object sender, ToggledEventArgs e)
        {

            bool value = e.Value;

            if (value == true)
            {
                dia2 = "Terca";
            }

            else
            {
                dia2 = null;
            }
        }

        public void BtnQuarta(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                dia3 = "Quarta";
            }

            else
            {
                dia3 = null;
            }
        }

        public void BtnQuinta(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                dia4 = "Quinta";
            }

            else
            {
                dia4 = null;
            }
        }

        public void BtnSexta(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                dia5 = "Sexta";
            }

            else
            {
                dia5 = null;
            }
        }

        public void BtnSabado(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                dia6 = "Sabado";
            }

            else
            {
                dia6 = null;
            }
        }

        public void BtnDomingo(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                dia7 = "Domingo";
            }

            else
            {
                dia7 = null;
            }
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
                PhotoSize = PhotoSize.Medium,
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

            var arquivo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            { 
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 40
                
            });

            NomeArquivo = arquivo.Path;

            await DisplayAlert("Foto selecionada com sucesso!", NomeArquivo, "OK");

            if (arquivo == null)
                return;
        }

        public async void SalvarAction(object sender, EventArgs args)
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
                DiaSete = dia7,
                Imagem = NomeArquivo,
            };

            //Salvar informacoes no banco
            Database database = new Database();
            database.Cadastro(planta);

            //Tela de sucesso
            await Navigation.PushAsync(new SucessoPlanta());
        }
    }
}