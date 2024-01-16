using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mappers;
using RestApi.Models.Input;
using RestApi.Models.Output;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private IConfiguration _configuration;
        private ChallengeManager _manager;
        private PrizeManager _prizeManager;
        private string url = "";
        private readonly ILogger _logger;
        //Constructor
        public ChallengeController(IConfiguration configuration, IChallengeRepository challengeRepo, IPrizeRepository prizeRepo, ILoggerFactory loggerFactory)
        {
            _manager = new ChallengeManager(challengeRepo);
            _configuration = configuration;
            url = configuration.GetValue<string>("launchUrl");
            _prizeManager = new PrizeManager(prizeRepo);
            _logger = loggerFactory.AddFile("./Logs/Challenglogs/ChallengesLog.txt").CreateLogger("Challenge");
        }
        // GET api/challenge/1
        [HttpGet("{id}")]
        public ActionResult<ChallengeRESTOutputDTO> GetChallenge(int id)
        {
            try
            {
                _logger.LogInformation($"Challenge with id: {id} - GetChallenge called");
                return Ok(MapFromDomain.MapFromChallengeDomain(_manager.GetChallenge(id)));
            }
            catch (ChallengeDLException e)
            {
                _logger.LogError($"Challenge with id: {id} - GetChallenge DL error - Internal Server Error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (ChallengeManagerException e)
            {
                _logger.LogError($"Challenge with id: {id} - GetChallenge error - NotFound - {e.Message}");
                return NotFound($"No challenge with id: {id} found");
            }
            catch (Exception e)
            {
                _logger.LogError($"Challenge with id: {id} - GetChallenge error - BadRequest - {e.Message}");
                return BadRequest();
            }
        }
        // GET api/challenge
        [HttpGet]
        public ActionResult<IReadOnlyList<ChallengeRESTOutputDTO>> GetChallenges()
        {
            try
            {
                _logger.LogInformation("Challenges - Get called");
                IReadOnlyList<Challenge> Challenges = _manager.GetAllChallenges();
                List<ChallengeRESTOutputDTO> challengesDTO = new List<ChallengeRESTOutputDTO>();
                foreach (Challenge challenge in Challenges)
                {
                    challengesDTO.Add(MapFromDomain.MapFromChallengeDomain(challenge));
                }
                return Ok(challengesDTO);
            }
            catch (ChallengeDLException e)
            {
                _logger.LogError($"Challenges - Get error - Internal Server Error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (ChallengeManagerException e)
            {
                _logger.LogError($"Challenges - Get error - NotFound - {e.Message}");
                return NotFound("No valid challenges found");
            }
            catch (Exception e)
            {
                _logger.LogError($"Challenges - Get error - BadRequest - {e.Message}");
                return BadRequest();
            }
        }
        // POST api/challenge
        [HttpPost]
        public ActionResult<ChallengeRESTOutputDTO> Post([FromBody] ChallengeRESTInputDTO challengeDTO)
        {
            try
            {
                _logger.LogInformation($"Challenge {challengeDTO.name} - Post called");
                Challenge challenge = _manager.AddChallenge(MapToDomain.MapToChallengeDomain(challengeDTO));
                return CreatedAtAction(nameof(GetChallenge), new { id = challenge.Id }, MapFromDomain.MapFromChallengeDomain(challenge));
            }
            catch (ChallengeDLException e)
            {
                _logger.LogError($"Challenge {challengeDTO.name} - Post error - Internal Server Error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (ChallengeManagerException e)
            {
                _logger.LogError($"Challenge {challengeDTO.name} - Post error - NotFound - {e.Message}");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"Challenge {challengeDTO.name} - Post error - BadRequest - {e.Message}");
                return BadRequest(e.Message);
            }
        }
    }
}
