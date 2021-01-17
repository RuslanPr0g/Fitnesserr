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
        public async Task<ActionResult<IEnumerable<TrainingReadDto>>> Get()
        {
            var trainingPrograms = await _repository.GetTrainingsAsync();

            return Ok(_mapper.Map<IEnumerable<TrainingReadDto>>(trainingPrograms));
        }

        // GET api/Trainings/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingReadDto>> Get(Guid id)
        {
            var trainingPrograms = await _repository.GetTrainingsAsync();

            return Ok(_mapper.Map<TrainingReadDto>(trainingPrograms));
        }

        // POST api/Trainings
        [HttpPost]
        public async Task<ActionResult<TrainingReadDto>> Post([FromBody] TrainingCreateDto training)
        {
            var trainingModel = _mapper.Map<Training>(training);

            await _repository.AddTrainingAsync(trainingModel);

            await _repository.SaveChangesAsync();

            var trainingResponseModel = _mapper.Map<TrainingReadDto>(trainingModel);

            return Ok(trainingResponseModel);
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
