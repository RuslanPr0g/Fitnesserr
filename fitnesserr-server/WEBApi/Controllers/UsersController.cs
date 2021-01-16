using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;
using WEBApi.Repository;

namespace WEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;

        public UsersController(IUserRepo repository)
        {
            this._repository = repository;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = _repository.GetUsers();

            return Ok(users);
        }

        // GET api/Users/guid
        [HttpGet("{id}")]
        public ActionResult<User> Get(Guid id)
        {
            var user = _repository.GetUser(id);

            return Ok(user);
        }

        // POST api/Users
        [HttpPost]
        public void Post([FromBody] User value)
        {
            // add User
        }

        // PUT api/Users/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User value)
        {
            // update User
        }

        // DELETE api/Users/guid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete User
        }
    }
}
