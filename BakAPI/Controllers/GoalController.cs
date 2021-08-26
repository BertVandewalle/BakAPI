using AutoMapper;
using BakAPI.Data;
using BakAPI.IRepository;
using BakAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GoalController> _logger;
        private readonly IMapper _mapper;
        public GoalController(IUnitOfWork unitOfWork, ILogger<GoalController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoals([FromQuery] RequestParams requestParams)
        {
            var goals = await _unitOfWork.Goals.GetPaged(requestParams);
            var results = _mapper.Map<IList<GoalDTO>>(goals);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetGoal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGoal(int id)
        {
            var goal = await _unitOfWork.Goals.Get(q => q.Id == id);
            var results = _mapper.Map<GoalDTO>(goal);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGoal([FromBody] CreateGoalDTO goalDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGoal)}");
                return BadRequest(ModelState);
            }
            var goal = _mapper.Map<Goal>(goalDTO);
            await _unitOfWork.Goals.Insert(goal);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetGoal", new { id = goal.Id }, goal);
        }
    }
}
