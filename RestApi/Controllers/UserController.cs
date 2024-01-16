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
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _url;
        private UserManager _manager;
        private readonly ILogger _logger;
        public UserController(IConfiguration configuration, IUserRepository userRepository, ILoggerFactory loggerFactory)
        {
            _manager = new UserManager(userRepository);
            _configuration = configuration;
            _url = configuration.GetValue<string>("launchUrl");
            _logger = loggerFactory.AddFile("./Logs/Userlogs/UsersLog.txt").CreateLogger("User");
        }
        // GET api/user/1
        [HttpGet("{id}")]
        public ActionResult<UserRESTOutputDTO> Get(int id)
        {
            try
            {
                _logger.LogInformation($"User with id: {id} - GetUser called");
                return MapFromDomain.MapFromUserDomain(_manager.GetUser(id));
            }
            catch (UserDLException e)
            {
                _logger.LogError($"User with id: {id} - GetUser DL error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (UserManagerException e)
            {
                _logger.LogError($"User with id: {id} - GetUser error - NotFound - {e.Message}");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"User with id: {id} - GetUser error - BadRequest - {e.Message}");
                return BadRequest();
            }
        }
        // POST api/user
        [HttpPost]
        public ActionResult<UserRESTOutputDTO> Post([FromBody] UserRESTInputDTO userInputDTO)
        {
            try
            {
                _logger.LogInformation($"User {userInputDTO.FirstName} {userInputDTO.LastName} -  PostUser created");
                User user = _manager.AddUser(MapToDomain.MapToUserDomain(userInputDTO));
                return CreatedAtAction(nameof(Get), new { id = user.Id }, MapFromDomain.MapFromUserDomain(user));
            }
            catch (UserDLException e)
            {
                _logger.LogError($"User {userInputDTO.FirstName} {userInputDTO.LastName} - PostUser DL error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (UserManagerException e)
            {
                _logger.LogError($"User {userInputDTO.FirstName} {userInputDTO.LastName} - PostUser error - NotFound - {e.Message}");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"User {userInputDTO.FirstName} {userInputDTO.LastName} - PostUser error - BadRequest - {e.Message}");
                return BadRequest();
            }
        }
    }
}
