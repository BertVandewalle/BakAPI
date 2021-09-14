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
            var games = await _unitOfWork.Games.GetPaged(requestParams, q => q.OrderByDescending(g => g.StartDateTime));
            var results = _mapper.Map<IList<GameDTO>>(games);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _unitOfWork.Games.Get(q => q.Id == id);
            var results = _mapper.Map<GameDTO>(game);
            return Ok(results);
        }

        [HttpGet("Today")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGamesToday()
        {
            var currentDateTimeUtc = DateTime.UtcNow;
            var yesterDayDateTimeUtc = currentDateTimeUtc.AddDays(-1);
            var gamesToday = await _unitOfWork.Games.GetAll(q => q.StartDateTime>=yesterDayDateTimeUtc, q => q.OrderBy(g => g.StartDateTime));
            var results = _mapper.Map<IList<GameDTO>>(gamesToday);
            return Ok(results);
        }

        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateGame([FromBody] CreateGameDTO gameDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateGame)}");
                return BadRequest(ModelState);
            }
            gameDTO.RedScore = gameDTO.RedDefScore + gameDTO.RedOffScore;
            gameDTO.GreScore = gameDTO.GreDefScore + gameDTO.GreOffScore;
            if (gameDTO.RedScore > gameDTO.GreScore) gameDTO.Winner = "Red";
            else gameDTO.Winner = "Green";

            if (gameDTO.DuoGreId == 0)
            {
                var duoRed = await _unitOfWork.Duos.Get(d => d.DefPlayerId == gameDTO.RedDefId && d.OffPlayerId == gameDTO.RedOffId);
                var duoGre = await _unitOfWork.Duos.Get(d => d.DefPlayerId == gameDTO.GreDefId && d.OffPlayerId == gameDTO.GreOffId);
                gameDTO.DuoRedId = duoRed.Id;
                gameDTO.DuoGreId = duoGre.Id;
            }
            var game = _mapper.Map<Game>(gameDTO);
            await _unitOfWork.Games.Insert(game);
            await _unitOfWork.Save();
            var deltaElo = await UpdateStats.Update_Elo_PlayerStats(game, _unitOfWork,_logger);

            

            //return CreatedAtRoute("GetGame", new { id = game.Id }, new List<object> { game.Id, deltaElo });
            return Ok(new List<object> { game.Id, deltaElo });
        }



        //[HttpPut("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> UpdateGame(int id, [FromBody] UpdateGameDTO gameDTO)
        //{
        //    if (!ModelState.IsValid || id < 1)
        //    {
        //        _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateGame)}");
        //        return BadRequest(ModelState);
        //    }

        //    var game = await _unitOfWork.Games.Get(q => q.Id == id);
        //    if (game == null)
        //    {
        //        return BadRequest("Submitted data is invalid");
        //    }
        //    gameDTO.RedScore = gameDTO.RedDefScore + gameDTO.RedOffScore;
        //    _mapper.Map(gameDTO, game);
        //    _unitOfWork.Games.Update(game);
        //    await _unitOfWork.Save();

        //    return NoContent();
        //}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(DeleteGame)}");
                return BadRequest();
            }

            var game = await _unitOfWork.Games.Get(q => q.Id == id);
            if (game == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(DeleteGame)}");
                return BadRequest("Submitted data is invalid");
            }
            await _unitOfWork.Games.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAllGames()
        {
            var games = await _unitOfWork.Games.GetAll();
            if (games == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAllGames)}");
                return BadRequest("Submitted data is invalid");
            }
            var gameIds = from game in games select game.Id;
            foreach (int Id in gameIds)
            {
                await _unitOfWork.Games.Delete(Id);
            }
            await _unitOfWork.Save();
            return NoContent();
        }



    }

}
