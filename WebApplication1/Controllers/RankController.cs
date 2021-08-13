using AutoMapper;
using BakAPI.Data;
using BakAPI.IRepository;
using BakAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    public class RankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RankController> _logger;
        private readonly IMapper _mapper;
        public RankController(IUnitOfWork unitOfWork, ILogger<RankController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRanks([FromQuery] RequestParams requestParams)
        {
            var players = await _unitOfWork.Ranks.GetPaged(requestParams);
            var results = _mapper.Map<IList<RankDTO>>(players);
            return Ok(results);
        }






    }

}
