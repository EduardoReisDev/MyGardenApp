using System;
using SQLite;

namespace MyGarden.Models
{
    [Table("Planta")]
    public class Planta
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomePopular { get; set; }
        public string NomeCientifico { get; set; }
        public string Observacao { get; set; }

        public string Iluminacao { get; set; }
        public string Ambiente { get; set; }

        public DateTime UltimaAdubacao { get; set; }
        public DateTime ProximaAdubacao { get; set; }
        public DateTime Aquisicao { get; set; }

        public string DiaUm { get; set; }
        public string DiaDois { get; set; }
        public string DiaTres { get; set; }
        public string DiaQuatro { get; set; }
        public string DiaCinco { get; set; }
        public string DiaSeis { get; set; }
        public string DiaSete { get; set; }
        public string Imagem { get; set; }
    }
}
