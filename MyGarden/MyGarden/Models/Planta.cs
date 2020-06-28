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
        public DateTime Data { get; set; }
    }
}
