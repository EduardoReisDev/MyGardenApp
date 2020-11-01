using System;
using System.IO;
using MyGarden.Banco;
using MyGarden.iOS.Banco;
using Xamarin.Forms;

[assembly:Dependency(typeof(Caminho))]
namespace MyGarden.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoDaBiblioteca = Path.Combine(caminhoDaPasta, "..", "Library");

            string caminhoBanco = Path.Combine(caminhoDaBiblioteca, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}
