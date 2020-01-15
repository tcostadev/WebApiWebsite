using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookiApi.Data;
using BookiApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookiApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _dataContext.Users;
            return Ok(users);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetUsersSearch(int? id, string nome)
        {
            var users = _dataContext.Users
                          .Where(x => id.HasValue ? x.Id == id : 1 == 1)
                          .Where(x => nome != null ? x.Nome == nome : 1 == 1);

            if (users == null)
                return NotFound("No User found");

            return Ok(users);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            var entity = _dataContext.Users.Find(id);
            if (entity == null)
            {
                return NotFound("No User Found...");
            }
            else
            {
                entity.Nome = user.Nome;
                entity.Username = user.Username;
                entity.Password = user.Password;
                entity.Morada = user.Morada;
                entity.CodigoPostal = user.CodigoPostal;
                entity.LocalizacaoId = user.LocalizacaoId;
                _dataContext.SaveChanges();
                return Ok("User Updated Successfully");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("No User Found...");
            }
            else
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
                return Ok("User Deleted Successfully");
            }
        }

    }
}