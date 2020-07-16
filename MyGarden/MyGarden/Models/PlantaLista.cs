using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyGarden.Models
{
    [Table("PlantaLista")]
    class PlantaLista
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomePopularPL { get; set; }
        public string NomeCientificoPL { get; set; }
    }
}
