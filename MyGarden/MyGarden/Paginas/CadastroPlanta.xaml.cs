using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Models;
using MyGarden.Banco;
using Plugin.Media;
using Plugin.Media.Abstractions;
using MyGarden.Helpers;

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

        string interno = null;
        string externo = null;

        string solPleno = null;
        string meiaSombra = null;
        string luzDifusa = null;

        string NomeArquivo = null;

        public CadastroPlanta()
        {
            InitializeComponent();

            UltimaAdubacao.Date = DateTime.Today;
            ProximaAdubacao.Date = DateTime.Today;
            Aquisicao.Date = DateTime.Today;
        }

        public async void GoHome(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Home());
        }

        public void BtnInterno(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                interno = "Ambiente interno";
            }

            else
            {
                interno = null;
            }
        }

        public void BtnExterno(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                externo = "Ambiente externo";
            }

            else
            {
                externo = null;
            }
        }

        public void BtnSolPleno(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                solPleno = "Sol pleno";
            }

            else
            {
                solPleno = null;
            }
        }

        public void BtnMeiaSombra(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                meiaSombra = "Meia sombra";
            }

            else
            {
                meiaSombra = null;
            }
        }

        public void BtnLuzDifusa(object sender, ToggledEventArgs e)
        {
            bool value = e.Value;

            if (value == true)
            {
                luzDifusa = "Luz difusa ou sombra";
            }

            else
            {
                luzDifusa = null;
            }
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

        [Obsolete]
        public async void AbrirCamera(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Nenhuma Câmera", "Nenhuma Câmera disponível.", "OK");
                return;
            }

            var isPermissionGranted = await PermissionsHelper.RequestCameraAndGalleryPermissions();

            if (!isPermissionGranted)
            {
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

        [Obsolete]
        public async void AbrirGaleria(object sender, EventArgs args)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");

                return;
            }

            var isPermissionGranted = await PermissionsHelper.RequestCameraAndGalleryPermissions();

            if (!isPermissionGranted)
            {
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
            string ambienteAux = string.Empty;
            string iluminacaoAux = string.Empty;

            if(interno != null)
            {
                ambienteAux = interno;
            }
            if(externo != null)
            {
                ambienteAux = externo;
            }

            if(solPleno != null)
            {
                iluminacaoAux = solPleno;
            }
            if(meiaSombra != null)
            {
                iluminacaoAux = meiaSombra;
            }
            if(luzDifusa != null)
            {
                iluminacaoAux = luzDifusa;
            }

            //Obter dados da tela
            Planta planta = new Planta
            {
                NomePopular = NomePopular.Text,
                NomeCientifico = NomeCientifico.Text,
                Observacao = Observacao.Text,

                Ambiente = ambienteAux,
                Iluminacao = iluminacaoAux,

                UltimaAdubacao = (DateTime)UltimaAdubacao.Date,
                ProximaAdubacao = (DateTime)ProximaAdubacao.Date,
                Aquisicao = (DateTime)Aquisicao.Date,

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