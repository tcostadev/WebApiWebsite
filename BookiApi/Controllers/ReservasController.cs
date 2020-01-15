using BookiApi.Data;
using BookiApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : Controller
    {
        private DataContext _dataContext;

        public ReservasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetReservas()
        {
            var reservas = _dataContext.Reservas;
            return Ok(reservas);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetReservasSearch(int? id, DateTime? data)
        {
            var reserva = _dataContext.Reservas
                          .Where(x => id.HasValue ? x.Id == id : 1 == 1)
                          .Where(x => data.HasValue ? data >= x.DataInicio && data <= x.DataFim : 1 == 1);

            if (reserva == null)
                return NotFound("No Reserva found");

            return Ok(reserva);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult SaveReserva(Reserva reserva)
        {
            _dataContext.Reservas.Add(reserva);
            _dataContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateReserva(int id, Reserva reserva)
        {
            var entity = _dataContext.Reservas.Find(id);
            if (entity == null)
            {
                return NotFound("No Reserva Found...");
            }
            else
            {
                entity.DataInicio = reserva.DataInicio;
                entity.DataFim = reserva.DataFim;
                entity.NrHospedes = reserva.NrHospedes;
                entity.UserId = reserva.UserId;
                entity.TarifaHotelId = reserva.TarifaHotelId;
                _dataContext.SaveChanges();
                return Ok("Reserva Updated Successfully");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReserva(int id)
        {
            var reserva = _dataContext.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound("No Reserva Found...");
            }
            else
            {
                _dataContext.Reservas.Remove(reserva);
                _dataContext.SaveChanges();
                return Ok("Reserva Deleted Successfully");
            }
        }
    }
}
