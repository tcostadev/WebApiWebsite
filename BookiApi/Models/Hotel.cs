using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class Hotel
    {
        public int idHotel { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public string codPostal { get; set; }
        public float classificacao { get; set; }
        public Localizacao idLocalizacao { get; set; }
    }
}
