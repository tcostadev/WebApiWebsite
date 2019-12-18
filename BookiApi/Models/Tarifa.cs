namespace BookiApi.Models
{
    public class Tarifa
    {
        public int Id { get; set; }
        public int TipoQuartoId { get; set; }
        public float Preco { get; set; }
        public int HotelId { get; set; }

    }
}
