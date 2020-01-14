using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookiApi.Data;
using BookiApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookiApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarifasController : ControllerBase
    {
        private DataContext _dataContext;

        public TarifasController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// 
        /// 
        /// Retorna todas as Tarifas
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        //ALL -  GET: api/<controller>
        [HttpGet]
        public IActionResult GetTarifas()
        {
            var tarifas = _dataContext.Tarifas;
            return Ok(tarifas);
        }

        /// <summary>
        /// 
        /// 
        /// Retorna Tarifa --> Search by ID
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/1
        [HttpGet("{id}")]
        public IActionResult GetTarifalById(int id)
        {
            var tarifa = _dataContext.Tarifas.FirstOrDefault(s => s.Id == id);
            if (tarifa == null)
            {
                return NotFound("No Tarifa found with id:" + id);
            }
            return Ok(tarifa);
        }

        /// <summary>
        /// 
        /// 
        /// Retorna Tarifa --> Search by HotelID
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/nome
        [HttpGet("{key}")]
        public IActionResult GetTarifaHotelID(int idHotel)
        {
            var tarifa = _dataContext.Tarifas.Where(s => s.HotelId.Equals(idHotel));
            if (tarifa == null || tarifa.Count() == 0)
            {
                return NotFound("No Tarifa found for Hotel id:" + idHotel);
            }
            return Ok(tarifa);
        }

        /// <summary>
        /// 
        /// 
        /// Retorna Tarifa --> Search by Hotel Name
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/<controller>/nome
        [HttpGet("{String}")]
        public IActionResult GetTarifaHotelName(String nomeHotel)
        {
            var hotelNameID = _dataContext.Hoteis.Where(s => s.Nome.Contains(nomeHotel)).Select(s => s.Id).FirstOrDefault();

            var tarifaByHotel = _dataContext.Tarifas.Where(s => s.HotelId.Equals(hotelNameID));
            if (tarifaByHotel == null || tarifaByHotel.Count() == 0)
            {
                return NotFound("No Tarifa found for hotel : " + nomeHotel);
            }
            return Ok(tarifaByHotel);
        }


        /// <summary>
        /// 
        /// 
        /// inserir Tarifa 
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // POST api/<controller>
        [HttpPost]
        public IActionResult PostTarifa(Tarifa tarifa)
        {
                _dataContext.Tarifas.Add(tarifa);
                _dataContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        /// 
        /// 
        /// atualizar Tarifa 
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // PUT: api/<controller>/1
        [HttpPut("{id}")]
        public IActionResult PutTarifa(int id, Tarifa tarifa)
        {
            var entity = _dataContext.Tarifas.Find(id);
            if (entity == null)
            {
                return NotFound("No Tarifa Found...");
            }
            else
            {
                entity.HotelId = tarifa.HotelId;
                entity.Preco = tarifa.Preco;
                entity.TipoQuartoId = tarifa.TipoQuartoId;
                _dataContext.SaveChanges();
                return Ok("Tarifa Updated Successfully");
            }
        }

        /// <summary>
        /// 
        /// 
        /// apagar Tarifa 
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        // DELETE: api/<controller>/1
        [HttpDelete("{id}")]
        public IActionResult DeleteTarifa(int id)
        {
            var tarifa = _dataContext.Tarifas.Find(id);
            if (tarifa == null)
            {
                return NotFound("No Tarifa Found...");
            }
            else
            {
                _dataContext.Tarifas.Remove(tarifa);
                _dataContext.SaveChanges();
                return Ok("Tarifa Deleted Successfully");
            }
        }





    }
}