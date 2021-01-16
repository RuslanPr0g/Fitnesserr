﻿using AutoMapper;
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
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingRepo _repository;
        private readonly IMapper _mapper;

        public TrainingsController(ITrainingRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET: api/Trainings
        [HttpGet]
        public ActionResult<IEnumerable<TrainingReadDto>> Get()
        {
            var trainingPrograms = _repository.GetTrainings();

            return Ok(trainingPrograms);
        }

        // GET api/Trainings/guid
        [HttpGet("{id}")]
        public ActionResult<TrainingReadDto> Get(Guid id)
        {
            var trainingPrograms = _repository.GetTrainings();

            return Ok(trainingPrograms);
        }

        // POST api/Trainings
        [HttpPost]
        public void Post([FromBody] Training value)
        {
            // add Training
        }

        // PUT api/Trainings/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Training value)
        {
            // update Training
        }

        // DELETE api/Trainings/guid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete Training
        }
    }
}
