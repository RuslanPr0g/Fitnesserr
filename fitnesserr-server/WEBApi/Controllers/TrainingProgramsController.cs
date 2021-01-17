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
    public class TrainingProgramsController : ControllerBase
    {
        private readonly ITrainingProgramRepo _repository;
        private readonly IMapper _mapper;

        public TrainingProgramsController(ITrainingProgramRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET: api/TrainingPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingProgramReadDto>>> Get()
        {
            var trainingPrograms = await _repository.GetTrainingsAsync();

            return Ok(_mapper.Map<IEnumerable<TrainingProgramReadDto>>(trainingPrograms));
        }

        // GET api/TrainingPrograms/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainingProgramReadDto>>>  Get(Guid userId)
        {
            var trainingProgram = await _repository.GetTrainingsAsync(userId);

            return Ok(_mapper.Map<IEnumerable<TrainingProgramReadDto>>(trainingProgram));
        }

        // POST api/TrainingPrograms
        [HttpPost]
        public async Task<ActionResult<TrainingProgramReadDto>> Post([FromBody] TrainingProgramCreateDto training)
        {
            var trainingProgramModel = _mapper.Map<TrainingProgram>(training);

            await _repository.AddTrainingAsync(trainingProgramModel);

            await _repository.SaveChangesAsync();

            var trainingProgramResponseModel = _mapper.Map<TrainingProgramReadDto>(trainingProgramModel);

            return Ok(trainingProgramResponseModel);
        }

        // PUT api/TrainingPrograms/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] TrainingProgram value)
        {
            // update TrainingProgram
        }

        // DELETE api/TrainingPrograms/guid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete TrainingProgram
        }
    }
}
