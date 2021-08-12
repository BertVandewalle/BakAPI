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
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlayerController> _logger;
        private readonly IMapper _mapper;
        public PlayerController(IUnitOfWork unitOfWork, ILogger<PlayerController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayers([FromQuery] RequestParams requestParams)
        {
            var players = await _unitOfWork.Players.GetPaged(requestParams);
            var results = _mapper.Map<IList<PlayerDTO>>(players);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetPlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _unitOfWork.Players.Get(q => q.Id == id, new List<string> { "GamePlayers" });
            var results = _mapper.Map<PlayerDTO>(player);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerDTO playerDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreatePlayer)}");
                return BadRequest(ModelState);
            }
            var player = _mapper.Map<Player>(playerDTO);
            await _unitOfWork.Players.Insert(player);
            await _unitOfWork.Save();
            return CreatedAtRoute("GetPlayer", new { id = player.Id }, player);
        }
    }

}
