using AutoMapper;
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
        public async Task<ActionResult<IEnumerable<TrainingDoneReadDto>>> Get()
        {
            var trainingDone = await _repository.GetTrainingDoneAsync();

            return Ok(_mapper.Map<IEnumerable<TrainingDoneReadDto>>(trainingDone));
        }

        // GET api/TrainingDone/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TrainingDoneReadDto>>> Get(Guid userId)
        {
            var trainingDone = await _repository.GetTrainingDoneAsync(userId);

            return Ok(_mapper.Map<IEnumerable<TrainingDoneReadDto>>(trainingDone));
        }

        // POST api/TrainingDone
        [HttpPost]
        public async Task<ActionResult<TrainingDoneReadDto>> Post([FromBody] TrainingDoneCreateDto training)
        {
            var trainingDoneModel = _mapper.Map<TrainingDone>(training);

            await _repository.FinishTrainingAsync(trainingDoneModel);

            await _repository.SaveChangesAsync();

            var trainingDoneResponseModel = _mapper.Map<TrainingDoneReadDto>(trainingDoneModel);

            return Ok(trainingDoneResponseModel);
        }
    }
}
