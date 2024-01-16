using Application.Exceptions;
using Domain.Entity;

namespace RestApi.Mappers
{
    public class PrizeManager {
        private IPrizeRepository _repo;

        public PrizeManager(IPrizeRepository repo) {
            _repo = repo;
        }
        // Asks repo for list of prizes | checks if list is not empty | returns list
        public IReadOnlyList<Prize> GetAllPrizes() {
            try {
                IReadOnlyList<Prize> prizes = _repo.GetAllPrizes();
                if (prizes.Count == 0) throw new PrizeManagerException("There are no prizes");
                return prizes;
            } catch (PrizeDLException ex) {
                throw new PrizeDLException("GetAllPrizes", ex);
            } catch (PrizeManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("GetAllPrizes", ex);
            }
        }
    }
}