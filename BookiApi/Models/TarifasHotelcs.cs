using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class TarifasHotelcs
    {
        public int idTarifa { get; set; }
        public TipoQuarto idTipoQuarto { get; set; }
        public float preco { get; set; }
        public Hotel idHotel { get; set; }

    }
}
