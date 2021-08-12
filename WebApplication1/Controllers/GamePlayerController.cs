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
    public class GamePlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GamePlayerController> _logger;
        private readonly IMapper _mapper;
        public GamePlayerController(IUnitOfWork unitOfWork, ILogger<GamePlayerController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGamePlayers([FromQuery] RequestParams requestParams)
        {
            var gamePlayers = await _unitOfWork.GamePlayers.GetPaged(requestParams);
            var results = _mapper.Map<IList<GamePlayerDTO>>(gamePlayers);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetGamePlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGamePlayer(int id)
        {
            var gamePlayer = await _unitOfWork.GamePlayers.Get(q => q.Id == id);
            var results = _mapper.Map<GamePlayerDTO>(gamePlayer);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGamePlayer([FromBody] CreateGamePlayerDTO gamePlayerDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGamePlayer)}");
                return BadRequest(ModelState);
            }
            var gamePlayer = _mapper.Map<GamePlayer>(gamePlayerDTO);
            await _unitOfWork.GamePlayers.Insert(gamePlayer);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetGamePlayer", new { id = gamePlayer.Id }, gamePlayer);
        }
    }
}
