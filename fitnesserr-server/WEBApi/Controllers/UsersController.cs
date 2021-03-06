﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using Core.Entities;
using WEBApi.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WEBApi.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        // POST api/Users/login
        [HttpPost("/login")]
        public async Task<ActionResult<UserReadDto>> Login([FromBody] UserLoginDto user)
        {
            var userFromRepo = await _repository.LoginUserAsync(user);

            if (userFromRepo is not null)
                return Ok(_mapper.Map<UserReadDto>(userFromRepo));
            else
                return NotFound(user);
        }

        [AllowAnonymous]
        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<UserReadDto>> Post([FromBody] UserCreateDto user)
        {
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

            if (userModelFromRepo is not null)
            {
                _mapper.Map(user, userModelFromRepo);

                await _repository.UpdateUser(userModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("User has been fully updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // PATCH api/Users/guid
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<UserUpdateDto> user)
        {
            var userModelFromRepo = await _repository.GetUserAsync(id);

            if (userModelFromRepo is not null)
            {
                var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);

                user.ApplyTo(userToPatch, ModelState);

                if (TryValidateModel(userToPatch) == false)
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(userToPatch, userModelFromRepo);

                await _repository.UpdateUser(userModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("User has been updated!");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
