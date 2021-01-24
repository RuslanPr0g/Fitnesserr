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
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepo _repository;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseRepo repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseReadDto>>> Get()
        {
            var exercises = await _repository.GetExercisesAsync();

            return Ok(_mapper.Map<IEnumerable<ExerciseReadDto>>(exercises));
        }

        // GET api/Exercises/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseReadDto>> Get(Guid id)
        {
            var exercise = await _repository.GetExerciseAsync(id);

            return Ok(_mapper.Map<ExerciseReadDto>(exercise));
        }

        // POST api/Exercises
        [HttpPost]
        public async Task<ActionResult<ExerciseReadDto>> Post([FromBody] ExerciseCreateDto exercise)
        {
            var exerciseModel = _mapper.Map<Exercise>(exercise);

            await _repository.AddExerciseAsync(exerciseModel);

            await _repository.SaveChangesAsync();

            var exerciseResponseModel = _mapper.Map<ExerciseReadDto>(exerciseModel);

            return Ok(exerciseResponseModel);
        }

        // PUT api/Exercises/guid
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] ExerciseUpdateDto exercise)
        {
            var exerciseModelFromRepo = await _repository.GetExerciseAsync(id);

            if (exerciseModelFromRepo is not null)
            {
                _mapper.Map(exercise, exerciseModelFromRepo);

                await _repository.UpdateExercise(exerciseModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Exercise has been fully updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // PATCH api/Exercises/guid
        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ExerciseUpdateDto> exercise)
        {
            var exerciseModelFromRepo = await _repository.GetExerciseAsync(id);

            if (exerciseModelFromRepo is not null)
            {
                var exerciseToPatch = _mapper.Map<ExerciseUpdateDto>(exerciseModelFromRepo);

                exercise.ApplyTo(exerciseToPatch, ModelState);

                if (TryValidateModel(exerciseToPatch) == false)
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(exerciseToPatch, exerciseModelFromRepo);

                await _repository.UpdateExercise(exerciseModelFromRepo);

                await _repository.SaveChangesAsync();

                return Ok("Exercise has been updated!");
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/Exercises/guid
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var exerciseModeldFromRepo = await _repository.GetExerciseAsync(id);

            if (exerciseModeldFromRepo is not null)
            {
                _repository.DeleteExercise(exerciseModeldFromRepo);

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
