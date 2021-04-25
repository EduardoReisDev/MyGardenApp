using SQLite;

namespace MyGarden.Models
{
    [Table("PlantaLista")]
    public class PlantaLista
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomePopularPL { get; set; }
        public string NomeCientificoPL { get; set; }
    }
}
