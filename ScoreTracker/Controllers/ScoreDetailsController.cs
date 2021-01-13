using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoreTracker.Data;
using ScoreTracker.Dtos;
using ScoreTracker.Models;

namespace ScoreTracker.Controllers
{
    [Route("api/Score")]
    [ApiController]
    public class ScoreDetailsController : ControllerBase
    {
        private readonly IScoreTrackerRepo _scoreTrackerRepo;
        private readonly ILogger<ScoreDetailsController> _logger;
        private readonly IMapper _mapper;

        public ScoreDetailsController(IScoreTrackerRepo scoreTrackerRepo, ILogger<ScoreDetailsController> logger,IMapper mapper)
        {
            _scoreTrackerRepo = scoreTrackerRepo;
            _logger = logger;
            _mapper = mapper;
        }


        // GET api/Score/{score}
        [HttpGet("{score}")]
        public ActionResult GetNumberOfScoresAboveThreshold(int score)
        {
            _logger.LogInformation($"Fetching number of records where scores are above {score}");

            var numberOfScoresAboveThreshold=_scoreTrackerRepo.GetNumberOfScoresAboveThreshold(score);
            if (numberOfScoresAboveThreshold != null)
            {
                _logger.LogInformation($"Success:The number of records above score:{score} is {numberOfScoresAboveThreshold}");
                return Ok(numberOfScoresAboveThreshold);
            }
            return NotFound();
        }

        // PUT api/Score/{player},{score}
        [HttpPut("{player},{score}")]
        public ActionResult UpdateScoreforPlayer(string  player, int score)
        {
            _logger.LogInformation($"Updating the score for the player:{player}");
            var updatedResults = (ICollection<ScoreDetails>)_scoreTrackerRepo.UpdateScoreForPlayer(player, score);
            
            if (updatedResults != null && updatedResults.Count > 0)
            {
                _logger.LogInformation($"Success:The score for player:{player} is updated with a value:{score}");
                return Ok(_mapper.Map<IEnumerable<ScoreDetailsDto>>(updatedResults));
            }
            return NotFound();
        }
        
    }
}
