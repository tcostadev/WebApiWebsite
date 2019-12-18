using System;

namespace BookiApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int NrHospedes { get; set; }
        public int UserId { get; set; }
        public int TarifaHotelId { get; set; }
    }
}


