using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Core.Application.Interfaces;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using RestApi.Mappers;
using RestApi.Models.Input;
using RestApi.Models.Output;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IConfiguration _configuration;
        private ItemManager _manager;
        private string url = "";
        private readonly ILogger _logger;
        //constructor
        public ItemController(IConfiguration configuration, IItemRepository itemRepo, ILoggerFactory loggerFactory, IChallengeRepository chalRepo)
        {
            _manager = new ItemManager(itemRepo, chalRepo);
            _configuration = configuration;
            this.url = configuration.GetValue<string>("launchUrl");
            _logger = loggerFactory.AddFile("./Logs/ItemLogs/ItemsLog.txt").CreateLogger("Item");
        }
        // GET api/item/1
        [HttpGet("{id}")]
        public ActionResult<ItemRESTOutputDTO> GetItem(int id)
        {
            try
            {
                _logger.LogInformation($"Item with id: {id} - GetItem called");
                return Ok(MapFromDomain.MapFromItemDomain(_manager.GetItem(id)));
            }
            catch (ItemDLException ex)
            {
                _logger.LogError($"Item with id: {id} - GetItem error - Internal Server Error - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (ItemManagerException ex)
            {
                _logger.LogError($"Item with id: {id} - GetItem error - NotFound - {ex.Message}");
                return NotFound($"Item with id: {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Item with id: {id} - GetItem error - BadRequest - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        // POST api/item
        [HttpPost]
        public ActionResult Post([FromBody] ItemRESTInputDTO itemDTO, int challengeId)
        {
            try
            {
                _logger.LogInformation($"Item {itemDTO.Title} -  PostItem created");
                Item item = _manager.AddItem(MapToDomain.MapToItemDomain(itemDTO), challengeId);
                return CreatedAtAction(nameof(GetItem), new { id = item }, MapFromDomain.MapFromItemDomain(item));
            }
            catch (ItemDLException e)
            {
                _logger.LogError($"Item {itemDTO.Title} - PostItem DL error - {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (ItemManagerException e)
            {
                _logger.LogError($"Item {itemDTO.Title} - PostItem error - NotFound - {e.Message}");
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError($"Item {itemDTO.Title} - PostItem error - BadRequest - {e.Message}");
                return BadRequest(e.Message);
            }

        }
        // PUT api/item/vote
        [HttpPut]
        public ActionResult AddVoteToItem(int itemId)
        {
            try
            {
               

                Item existing = _manager.AddVoteToItem(itemId);
                return Ok(existing);

            } catch (ItemDLException e)
            {
                // Handle data layer exception
                return StatusCode(500, "Data layer error: " + e.Message);
            } catch (ItemManagerException e)
            {
                // Handle manager exception
                return BadRequest("Item manager error: " + e.Message);
            } catch (Exception e)
            {
                // Handle other exceptions
                return StatusCode(500, "Internal server error: " + e.Message);
            }
        }
    }
}
