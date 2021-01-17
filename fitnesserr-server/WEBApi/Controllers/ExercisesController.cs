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
        public ActionResult<IEnumerable<ExerciseReadDto>> Get()
        {
            var exercises = _repository.GetExercises();

            return Ok(_mapper.Map<IEnumerable<ExerciseReadDto>>(exercises));
        }

        // GET api/Exercises/guid
        [HttpGet("{id}")]
        public ActionResult<ExerciseReadDto> Get(Guid id)
        {
            var exercise = _repository.GetExercise(id);

            return Ok(_mapper.Map<ExerciseReadDto>(exercise));
        }

        // POST api/Exercises
        [HttpPost]
        public ActionResult<ExerciseReadDto> Post([FromBody] ExerciseCreateDto exercise)
        {
            var exerciseModel = _mapper.Map<Exercise>(exercise);

            _repository.AddExercise(exerciseModel);

            _repository.SaveChanges();

            var exerciseResponseModel = _mapper.Map<ExerciseReadDto>(exerciseModel);

            return Ok(exerciseResponseModel);
        }

        // PUT api/Exercises/guid
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Exercise exercise)
        {
            // update Exercise
        }

        // DELETE api/Exercises/guid
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // delete Exercise
        }
    }
}
