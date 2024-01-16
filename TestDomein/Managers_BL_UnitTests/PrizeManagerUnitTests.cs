using Application.Exceptions;
using Domain.Entity;
using RestApi.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain.Managers_BL_UnitTests {
    public class PrizeManagerUnitTests {
        private class FakePrizeRepository : IPrizeRepository {
            public IReadOnlyList<Prize> GetAllPrizes() {
                return new List<Prize> { new Prize(1, "Logo1", "Prize1", "BestPrize", "Company1")};
            }
        }

        [Fact]
        public void Constructor_Valid() {
            FakePrizeRepository repo = new FakePrizeRepository();

            Assert.NotNull(new PrizeManager(repo));
        }

        [Fact]
        public void GetAllPrizes_Valid() {
            FakePrizeRepository repo = new FakePrizeRepository();
            PrizeManager manager = new PrizeManager(repo);

            IReadOnlyList<Prize> prizes = manager.GetAllPrizes();

            Assert.NotNull(prizes);
            Assert.Single(prizes);
        }
    }
}
