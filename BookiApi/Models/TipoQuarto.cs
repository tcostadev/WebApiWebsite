using System.Collections.Generic;

namespace BookiApi.Models
{
    public class TipoQuarto
    {
        public int Id { get; set; }
        public string Designacao { get; set; }
        public int Capacidade { get; set; }
        public ICollection<TarifasHotel> Tarifas { get; set; }
    }
}
