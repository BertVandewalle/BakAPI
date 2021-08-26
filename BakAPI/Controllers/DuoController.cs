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
    public class DuoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DuoController> _logger;
        private readonly IMapper _mapper;
        public DuoController(IUnitOfWork unitOfWork, ILogger<DuoController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDuos([FromQuery] RequestParams requestParams)
        {
            var duos = await _unitOfWork.Duos.GetPaged(requestParams);
            var results = _mapper.Map<IList<DuoDTO>>(duos);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetDuo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDuo(int id)
        {
            var duo = await _unitOfWork.Duos.Get(q => q.Id == id);
            var results = _mapper.Map<DuoDTO>(duo);
            return Ok(results);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDuo([FromBody] DuoDTO duoDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDuo)}");
                return BadRequest(ModelState);
            }
            var duo = _mapper.Map<Duo>(duoDTO);
            await _unitOfWork.Duos.Insert(duo);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetDuo", new { id = duo.Id }, duo);
        }
    }
}
