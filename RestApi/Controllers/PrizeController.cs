using Microsoft.AspNetCore.Mvc;
using RestApi.Mappers;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private IConfiguration _configuration;
        private string _url = "";
        private PrizeManager _manager;
        private readonly ILogger _logger;
        public PrizeController(IConfiguration configuration, IPrizeRepository prizeRepository, ILoggerFactory loggerFactory)
        {
            _manager = new PrizeManager(prizeRepository);
            _configuration = configuration;
            _url = configuration.GetValue<string>("launchUrl");
            _logger = loggerFactory.AddFile("./Logs/Prizelogs/PrizesLog.txt").CreateLogger("Prize");
        }
    }
}
