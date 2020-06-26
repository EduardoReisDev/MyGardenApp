using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Linq;
using Xamarin.Forms;
using MyGarden.Models;

namespace MyGarden.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Planta>();
        }

        public List<Planta> Consultar()
        {
            return _conexao.Table<Planta>().ToList();
        }

        public List<Planta> Pesquisar(String palavra)
        {
            return _conexao.Table<Planta>().Where(a => a.NomePopular.Contains(palavra)).ToList();
        }

        public Planta ObterVagaPorId(int id)
        {
            return _conexao.Table<Planta>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void Cadastro(Planta planta)
        {
            _conexao.Insert(planta);
        }

        public void Atualizacao(Planta planta)
        {
            _conexao.Update(planta);
        }

        public void Exclusao(Planta planta)
        {
            _conexao.Delete(planta);
        }
    }
}
