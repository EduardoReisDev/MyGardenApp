using System;
using System.Collections.Generic;
using System.Text;
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
        public string DiaUm { get; set; }
        public string DiaDois { get; set; }
        public string DiaTres { get; set; }
        public string DiaQuatro { get; set; }
        public string DiaCinco { get; set; }
        public string DiaSeis { get; set; }
        public string DiaSete { get; set; }
    }
}
