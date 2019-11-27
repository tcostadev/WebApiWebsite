using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class CapacidadeTipoQuartocs
    {
        public TipoQuarto idTipoQuarto { get; set; }
        public Hotel idHotel { get; set; }
        public int nrQuartosDisponiveis { get; set; }
    }
}
