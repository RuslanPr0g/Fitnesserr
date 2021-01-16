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
    public class TrainingDoneController : ControllerBase
    {
        private readonly ITrainingDoneRepo _repository;
        private readonly IMapper _mapper;

        public TrainingDoneController(ITrainingDoneRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        // GET: api/TrainingDone
        [HttpGet]
        public ActionResult<IEnumerable<TrainingDoneReadDto>> Get()
        {
            var trainingDone = _repository.GetTrainingDone();

            return Ok(_mapper.Map<IEnumerable<TrainingDoneReadDto>>(trainingDone));
        }

        // GET api/TrainingDone/guid
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TrainingDoneReadDto>> Get(Guid userId)
        {
            var trainingDone = _repository.GetTrainingDone(userId);

            return Ok(_mapper.Map<IEnumerable<TrainingDoneReadDto>>(trainingDone));
        }

        // POST api/TrainingDone
        [HttpPost]
        public void Post([FromBody] TrainingDone value)
        {
            // add TrainingDone
        }

        // PUT api/exercises/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TrainingDone value)
        {
            // update TrainingDone
        }

        // DELETE api/TrainingDone/guid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete TrainingDone
        }
    }
}
