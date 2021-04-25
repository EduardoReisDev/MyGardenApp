using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyGarden.Banco;
using MyGarden.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using MyGarden.Helpers;

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

        public void DiaUmVerifica(Planta planta)
        {
            if (planta.DiaUm == "Segunda")
            {
                DiaUm.IsToggled = true;
            }

            else
            {
                DiaUm.IsToggled = false;
            }
        }

        public void DiaDoisVerifica(Planta planta)
        {
            if (planta.DiaDois == "Terca")
            {
                DiaDois.IsToggled = true;
            }

            else
            {
                DiaDois.IsToggled = false;
            }
        }

        public void DiaTresVerifica(Planta planta)
        {
            if (planta.DiaTres == "Quarta")
            {
                DiaTres.IsToggled = true;
            }

            else
            {
                DiaTres.IsToggled = false;
            }
        }

        public void DiaQuatroVerifica(Planta planta)
        {
            if (planta.DiaQuatro == "Quinta")
            {
                DiaQuatro.IsToggled = true;
            }

            else
            {
                DiaQuatro.IsToggled = false;
            }
        }

        public void DiaCincoVerifica(Planta planta)
        {
            if (planta.DiaCinco == "Sexta")
            {
                DiaCinco.IsToggled = true;
            }

            else
            {
                DiaCinco.IsToggled = false;
            }
        }

        public void DiaSeisVerifica(Planta planta)
        {
            if (planta.DiaSeis == "Sabado")
            {
                DiaSeis.IsToggled = true;
            }

            else
            {
                DiaSeis.IsToggled = false;
            }
        }

        public void DiaSeteVerifica(Planta planta)
        {
            if (planta.DiaSete == "Domingo")
            {
                DiaSete.IsToggled = true;
            }

            else
            {
                DiaSete.IsToggled = false;
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

        public EditarPlanta(Planta planta)
        {
            InitializeComponent();
            this.planta = planta;
            DiaUmVerifica(planta);
            DiaDoisVerifica(planta);
            DiaTresVerifica(planta);
            DiaQuatroVerifica(planta);
            DiaCincoVerifica(planta);
            DiaSeisVerifica(planta);
            DiaSeteVerifica(planta);

            NomePopular.Text = planta.NomePopular;
            NomeCientifico.Text = planta.NomeCientifico;

            Observacao.Text = planta.Observacao;
        }

        [Obsolete]
        public async void AbrirCamera(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Nenhuma Câmera", ":( Nenuma Câmera disponível.", "OK");
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

            if (arquivo == null)
            {
                return;
            }
                
            NomeArquivo = arquivo.Path;

            await DisplayAlert("Foto selecionada com sucesso!", NomeArquivo, "OK");
        }

        public async void Salvar(object sender, EventArgs args)
        {
            if(NomeArquivo == null)
            {
                NomeArquivo = planta.Imagem;
            }

            else
            {
                planta.Imagem = NomeArquivo;
            }

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
            planta.Imagem = NomeArquivo;

            Database database = new Database();
            database.Atualizacao(planta);

            await DisplayAlert("MyGarden","Parabéns, planta editada com sucesso!", "Ótimo");

            await Navigation.PushAsync(new Home());
        }

        public async void GoHome(object sender, EventArgs args) 
        {
            await Navigation.PushAsync(new Home());
        }
    }
}