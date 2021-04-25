using Xamarin.Forms;
using MyGarden.Banco;
using System.IO;
using MyGarden.Droid.Banco;

[assembly: Dependency(typeof(Caminho))]

namespace MyGarden.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string NomeArquivoBanco)
        {
            var caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoDaPasta, NomeArquivoBanco);

            return caminhoBanco;
        }
    }
}