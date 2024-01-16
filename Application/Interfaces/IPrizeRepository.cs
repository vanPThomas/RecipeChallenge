using Domain.Entity;

namespace RestApi.Mappers
{
    public interface IPrizeRepository
    {
        IReadOnlyList<Prize> GetAllPrizes();
    }
}