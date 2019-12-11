using System.Collections.Generic;

namespace BookiApi.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string CodPostal { get; set; }
        public float Classificacao { get; set; }
        public int LocalizacaoId { get; set; }
        public ICollection<TarifasHotel> Tarifas { get; set; }
    }
}
