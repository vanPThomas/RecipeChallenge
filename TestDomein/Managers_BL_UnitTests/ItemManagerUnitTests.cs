using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Core.Application.Interfaces;
using Domain.Entity;

namespace TestDomain.Managers_BL_UnitTests {
    public class ItemManagerUnitTests {
        private class FakeItemRepository : IItemRepository {
            public Item RegisterItemToDB(Item item, int challengeId) {
                return new Item(new Dictionary<Part, double> { { new Part( "Part1", "Kilo"), 2.0 } }, 1, "Item1", new List<string> { "Photo1" });
            }

            public Item GetItemFromDB(int id) {
                return new Item(new Dictionary<Part, double> { { new Part("Part1", "Kilo"), 2.0 } }, 1, "Item1", new List<string> { "Photo1" });
            }

            public bool ItemExists(int id) {
                return id == 1;
            }

            public Item AddVoteToItem(Item item) {
                //temp
                return new Item(new Dictionary<Part, double> { { new Part("Part1", "Kilo"), 2.0 } }, 1, "Item1", new List<string> { "Photo1" });
            }
        }

        private class FakeChallengeRepository : IChallengeRepository {
            public bool ChallengeExist(int id) {
                return id == 1;
            }

            public Challenge CreateChallenge(Challenge challenge) {
                throw new NotImplementedException();
            }

            public IReadOnlyList<Challenge> GetAllChallenges() {
                throw new NotImplementedException();
            }

            public Challenge GetChallenge(int id) {
                throw new NotImplementedException();
            }
        }

        Item mockItem = new Item(new Dictionary<Part, double> { { new Part("Part3", "Kilo"), 4.0 } }, 3, "Item3", new List<string> { "Photo3" });

        [Fact]
        public void Constructor_Valid_Not_Null() {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();

            Assert.NotNull(new ItemManager(itemRepository, challengeRepository));
        }

        [Fact]
        public void AddItem_InValid_Null() {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);

            Assert.Throws<ItemManagerException>(() => itemManager.AddItem(null, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void AddItem_InValid_ChallengeID_Null(int challengeId) {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);

            Assert.Throws<ItemManagerException>(() => itemManager.AddItem(mockItem, challengeId));
        }

        [Fact]
        public void AddItem_InValid_Challenge_Does_Not_Exist() {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);

            Assert.Throws<ItemManagerException>(() => itemManager.AddItem(mockItem, 9));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetItem_InValid_ID(int itemId) {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);

            Assert.Throws<ItemManagerException>(() => itemManager.GetItem(itemId));
        }

        [Fact]
        public void GetItem_InValid_Item_Does_Not_Exist() {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);

            Assert.Throws<ItemManagerException>(() => itemManager.GetItem(9));
        }

        [Fact]
        public void GetItem_WhenItemExists_ShouldCallGetItemFromDBOnItemRepository() {
            FakeItemRepository itemRepository = new FakeItemRepository();
            FakeChallengeRepository challengeRepository = new FakeChallengeRepository();
            ItemManager itemManager = new ItemManager(itemRepository, challengeRepository);
            int itemId = 1;

            Item retrievedItem = itemManager.GetItem(itemId);

            Assert.NotNull(retrievedItem);
            Assert.Equal(itemId, retrievedItem.Id);
        }
    }
}
