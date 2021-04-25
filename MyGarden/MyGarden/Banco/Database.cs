using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using MyGarden.Models;

namespace MyGarden.Banco
{
    class Database
    {
        private readonly SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Planta>();
            _conexao.CreateTable<PlantaLista>();
        }

        public List<Planta> Consultar()
        {
            return _conexao.Table<Planta>().ToList();
        }

        public List<PlantaLista> ConsultarPL()
        {
            return _conexao.Table<PlantaLista>().ToList();
        }

        public List<Planta> Pesquisar(String palavra)
        {
            return _conexao.Table<Planta>().Where(a => a.NomePopular.Contains(palavra)).ToList();
        }

        public List<PlantaLista> PesquisarPL(String palavralista)
        {
            return _conexao.Table<PlantaLista>().Where(a => a.NomePopularPL.Contains(palavralista)).ToList();
        }

        public Planta ObterVagaPorId(int id)
        {
            return _conexao.Table<Planta>().Where(a => a.Id == id).FirstOrDefault();
        }

        public PlantaLista ObterVagaPorIdPL(int id)
        {
            return _conexao.Table<PlantaLista>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void Cadastro(Planta planta)
        {
            _conexao.Insert(planta);
        }

        public void CadastroPL(PlantaLista plantalista)
        {
            _conexao.Insert(plantalista);
        }

        public void Atualizacao(Planta planta)
        {
            _conexao.Update(planta);
        }

        public void AtualizacaoPL(PlantaLista plantalista)
        {
            _conexao.Update(plantalista);
        }

        public void Exclusao(Planta planta)
        {
            _conexao.Delete(planta);
        }

        public void ExclusaoPL(PlantaLista plantalista)
        {
            _conexao.Delete(plantalista);
        }
    }
}
