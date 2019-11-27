using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Models
{
    public class ReservaHotel
    {
        public int idReservaHotel { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int nrHospedes { get; set; }
    }
}


