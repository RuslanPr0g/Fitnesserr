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

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        // GET api/Users/guid
        [HttpGet("{id}")]
        public ActionResult<UserReadDto> Get(Guid id)
        {
            var user = _repository.GetUser(id);

            return user is null ? NotFound() : Ok(_mapper.Map<UserReadDto>(user));
        }

        // POST api/Users
        [HttpPost]
        public ActionResult<UserReadDto> Post([FromBody] UserCreateDto user)
        {
            // TODO: validate the user, token, etc..

            var userModel = _mapper.Map<User>(user);

            _repository.RegisterUser(userModel);

            _repository.SaveChanges();

            return Ok(userModel);
        }

        // PUT api/Users/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] User user)
        {
            // update User
        }

        // DELETE api/Users/guid
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            // delete User
        }
    }
}
