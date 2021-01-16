using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using WEBApi.Models;
using WEBApi.Repository;

namespace WEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> Get()
        {
            var users = _repository.GetUsers();

            return Ok(users);
        }

        // GET api/Users/guid
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> Get(Guid id)
        {
            var user = _repository.GetUser(id);

            return user is null ? NotFound() : Ok(user);
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
