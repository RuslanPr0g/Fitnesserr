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
        public async Task<ActionResult<IEnumerable<UserReadDto>>> Get()
        {
            var users = await _repository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        // GET api/Users/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> Get(Guid id)
        {
            var user = await _repository.GetUserAsync(id);

            return user is null ? NotFound() : Ok(_mapper.Map<UserReadDto>(user));
        }

        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Post([FromBody] UserCreateDto user)
        {
            // TODO: validate the user, token, etc..

            var userModel = _mapper.Map<User>(user);

            await _repository.RegisterUserAsync(userModel);

            await _repository.SaveChangesAsync();

            var userResponseModel = _mapper.Map<UserReadDto>(userModel);

            return Ok(userResponseModel);
        }

        // PUT api/Users/guid
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UserUpdateDto user)
        {
            var userModelFromRepo = await _repository.GetUserAsync(id);

            if(userModelFromRepo is not null)
            {
                _mapper.Map(user, userModelFromRepo);

                await _repository.UpdateUser(userModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("User has been updated!");
            } else
            {
                return NotFound();
            }
        }
    }
}
