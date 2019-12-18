using System.Collections.Generic;

namespace BookiApi.Models
{
    public class Localizacao
    {
        public int Id { get; set; }
        public string LocalizacaoDs { get; set; }

        public ICollection<Hotel> Hoteis { get; set; }
    }
}
