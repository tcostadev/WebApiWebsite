using BookiApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookiApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hoteis { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Capacidade> Capacidades { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<TipoQuarto> TiposQuarto { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capacidade>(entity =>
            {
                entity.HasKey(x=> new { 
                    x.HotelId, x.TarifasHotelId
                });

            });
        }
    }
}
