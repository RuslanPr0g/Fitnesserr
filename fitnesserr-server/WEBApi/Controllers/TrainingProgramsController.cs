using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.DTOs;
using Core.Entities;
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
        public async Task<ActionResult> Put(Guid id, [FromBody] TrainingProgramUpdateDto trainingProgram)
        {
            var trainingProgramModelFromRepo = await _repository.GetTrainingAsync(id);

            if (trainingProgramModelFromRepo is not null)
            {
                _mapper.Map(trainingProgram, trainingProgramModelFromRepo);

                await _repository.UpdateTrainingProgram(trainingProgramModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Training Program has been fully updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // PATCH api/TrainingPrograms/guid
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<TrainingProgramUpdateDto> trainingProgram)
        {
            var trainingProgramModelFromRepo = await _repository.GetTrainingAsync(id);

            if (trainingProgramModelFromRepo is not null)
            {
                var trainingProgramToPatch = _mapper.Map<TrainingProgramUpdateDto>(trainingProgramModelFromRepo);

                trainingProgram.ApplyTo(trainingProgramToPatch, ModelState);

                if (TryValidateModel(trainingProgramToPatch) == false)
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(trainingProgramToPatch, trainingProgramModelFromRepo);

                await _repository.UpdateTrainingProgram(trainingProgramModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Training Program has been updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/TrainingPrograms/guid
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var trainingModeldFromRepo = await _repository.GetTrainingAsync(id);

            if (trainingModeldFromRepo is not null)
            {
                _repository.DeleteTrainingProgram(trainingModeldFromRepo);

                await _repository.SaveChangesAsync();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
