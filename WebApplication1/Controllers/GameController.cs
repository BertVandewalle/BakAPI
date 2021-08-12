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
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GameController> _logger;
        private readonly IMapper _mapper;
        public GameController(IUnitOfWork unitOfWork, ILogger<GameController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGames([FromQuery] RequestParams requestParams)
        {
            var games = await _unitOfWork.Games.GetPaged(requestParams);
            var results = _mapper.Map<IList<GameDTO>>(games);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _unitOfWork.Games.Get(q => q.Id == id, new List<string> { "GamePlayers" });
            var results = _mapper.Map<GameDTO>(game);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameDTO gameDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGame)}");
                return BadRequest(ModelState);
            }
            var game = _mapper.Map<Game>(gameDTO);
            await _unitOfWork.Games.Insert(game);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }
    }

}
