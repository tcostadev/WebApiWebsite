using System.Collections.Generic;

namespace BookiApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string CodigoPostal { get; set; }
        public int LocalizacaoId { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
