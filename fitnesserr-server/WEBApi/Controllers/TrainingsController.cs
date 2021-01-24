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
using Microsoft.AspNetCore.Authorization;

namespace WEBApi.Controllers
{
    [Authorize]
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
            var trainingPrograms = await _repository.GetTrainingAsync(id);

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

        // PUT api/trainings/guid
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TrainingUpdateDto training)
        {
            var trainingModelFromRepo = await _repository.GetTrainingAsync(id);

            if (trainingModelFromRepo is not null)
            {
                _mapper.Map(training, trainingModelFromRepo);

                await _repository.UpdateTraining(trainingModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Training has been fully updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // PATCH api/trainings/guid
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<TrainingUpdateDto> user)
        {
            var trainingModelFromRepo = await _repository.GetTrainingAsync(id);

            if (trainingModelFromRepo is not null)
            {
                var trainingToPatch = _mapper.Map<TrainingUpdateDto>(trainingModelFromRepo);

                user.ApplyTo(trainingToPatch, ModelState);

                if (TryValidateModel(trainingToPatch) == false)
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(trainingToPatch, trainingModelFromRepo);

                await _repository.UpdateTraining(trainingModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Training has been updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/Trainings/guid
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var trainingModelFromRepo = await _repository.GetTrainingAsync(id);

            if(trainingModelFromRepo is not null)
            {
                _repository.DeleteTraining(trainingModelFromRepo);

                await _repository.SaveChangesAsync();

                return NoContent();
            } else
            {
                return NotFound();
            }
        }
    }
}
