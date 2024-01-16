using Domain.Entity;
using Persistence.DatalayerModel;
using Persistence.Mappers;
using RestApi.Mappers;

namespace Persistence.Repositories
{
    public class PrizeRepository : IPrizeRepository
    {
        private ChallengeContext ctx = new ChallengeContext();
        // returns list of all prizes
        public IReadOnlyList<Prize> GetAllPrizes()
        {
            return ctx.Prizes.Select(x => MapPrize.MapFromDB(x)).ToList();
        }
    }
}
