using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class TipoQuarto
    {
        public int idTipoQuarto { get; set; }
        public string designacao { get; set; }
        public int capacidade { get; set; }
    }
}
