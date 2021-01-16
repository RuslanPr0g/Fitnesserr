using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBApi.Models;
using WEBApi.Repository;

namespace WEBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingProgramsController : ControllerBase
    {
        private readonly ITrainingProgramRepo _repository;

        public TrainingProgramsController(ITrainingProgramRepo repository)
        {
            this._repository = repository;
        }

        // GET: api/TrainingPrograms
        [HttpGet]
        public ActionResult<IEnumerable<TrainingProgram>> Get()
        {
            var trainingPrograms = _repository.GetTrainings();

            return Ok(trainingPrograms);
        }

        // GET api/TrainingPrograms/guid
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TrainingProgram>> Get(Guid userId)
        {
            var trainingProgram = _repository.GetTrainings(userId);

            return Ok(trainingProgram);
        }

        // POST api/TrainingPrograms
        [HttpPost]
        public void Post([FromBody] TrainingProgram value)
        {
            // add TrainingProgram
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
