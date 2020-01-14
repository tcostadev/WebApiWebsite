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
    public class HotelController : ControllerBase
    {
        private DataContext _dataContext;

        public HotelController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        /// <summary>
        /// 
        /// 
        /// Retorna todos os hoteis
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        //ALL -  GET: api/<controller>
        [HttpGet]
        public IActionResult GetHoteis()
        {
            var hoteis = _dataContext.Hoteis;
            return Ok(hoteis);
        }



        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel ---> search by ID
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/1
        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _dataContext.Hoteis.FirstOrDefault(s => s.Id == id);
            if (hotel == null)
            {
                return NotFound("No Hotel found with id:"+id);
            }
            return Ok(hotel);
        }




        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel  ---> search by nome 
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/nome
        [HttpGet("{String}")]
        public IActionResult GetHotelByName( String nome)
        {           
            var hotel = _dataContext.Hoteis.Where(s => s.Nome.Contains(nome));
            if (hotel==null)
            {
                return NotFound("No Hotel found with Name:" + nome);
            }
            return Ok(hotel);
        }


        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel  ---> search by nome e morada
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/nome
        [HttpGet("{String}")]
        public IActionResult GetHotelCustom(String nome, String morada)
        {
            
            if (nome != null && morada != null)
            {
                var hotel = _dataContext.Hoteis.Where(s => s.Nome.Contains(nome)).Where(s => s.Morada.Contains(morada));
                if (hotel == null)
                {
                    return NotFound("No Hotel found with Name:" + nome);
                }
                return Ok(hotel);
            }
            else
                return NotFound("Bad URL Format"); 
        }


        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel  ---> search by cod Postal
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/codPostal
        [HttpGet("{String}")]
        public IActionResult GetHotelByCodPostal(String codPostal)
        {
            var hotel = _dataContext.Hoteis.Where(s => s.CodPostal.StartsWith(codPostal));
            if (hotel == null)
            {
                return NotFound("No Hotel found with CodPostal:" + codPostal);
            }
            return Ok(hotel);
        }

        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel  ---> search by clasificassao
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/nome
        [HttpGet("{int}")]
        public IActionResult GetHotelByClass(int stars)
        {
            var hotel = _dataContext.Hoteis.Where(s => s.Classificacao.Equals(stars));
            if (hotel == null || hotel.Count() == 0)
            {
                return NotFound("No Hotel found with classification of " + stars + " stars");
            }
            return Ok(hotel);
        }


        /// <summary>
        /// 
        /// 
        /// Retorna o Hotel  ---> search by nome localidade
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // GET: api/<controller>/nome
        [HttpGet("{string}")]
        public IActionResult GetHotelByLocalidade(string localidade)
        {
            var localizacao = _dataContext.Localizacoes.Where(s => s.LocalizacaoDs.Contains(localidade)).Select(s => s.Id );

            int localId = localizacao.FirstOrDefault();

            var hotel = _dataContext.Hoteis.Where(s => s.LocalizacaoId.Equals(localId));
            if (hotel == null || hotel.Count()==0)
            {
                return NotFound("No Hotel found for location: " + localidade );
            }
            return Ok(hotel);
        }



        /// <summary>
        /// 
        /// 
        /// Inserir novo Hotel
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // POST api/<controller>
        [HttpPost]
        public IActionResult PostHotel(Hotel hotel)
        {
            _dataContext.Hoteis.Add(hotel);
            _dataContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }



        /// <summary>
        /// 
        /// 
        /// Atualizar dados do Hotel
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // PUT: api/<controller>/1
        [HttpPut("{id}")]
        public IActionResult PutHotel(int id, Hotel hotel)
        {
            var entity = _dataContext.Hoteis.Find(id);
            if (entity == null)
            {
                return NotFound("No Hotel Found...");
            }
            else
            {
                entity.Nome = hotel.Nome;
                entity.Morada = hotel.Morada;
                entity.CodPostal = hotel.CodPostal;
                entity.LocalizacaoId = hotel.LocalizacaoId;
                entity.Tarifas = hotel.Tarifas;
                entity.Capacidades = hotel.Capacidades;
                _dataContext.SaveChanges();
                return Ok("Hotel Updated Successfully");
            }
        }

        /// <summary> 
        /// 
        /// 
        /// Apagar o Hotel
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        // DELETE: api/<controller>/1
        [HttpDelete("{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _dataContext.Hoteis.Find(id);
            if (hotel == null)
            {
                return NotFound("No Hotel Found...");
            }
            else
            {
                _dataContext.Hoteis.Remove(hotel);
                _dataContext.SaveChanges();
                return Ok("Hotel Deleted Successfully");
            }
        }               

    }
}