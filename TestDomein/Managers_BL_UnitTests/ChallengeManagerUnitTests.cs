using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TestDomain.Managers_BL_UnitTests {
    public class ChallengeManagerUnitTests {
        private class MockChallengeRepository : IChallengeRepository {
            public bool GetAllChallengesCalled { get; private set; } = false;
            public bool ChallengeExistCalled { get; private set; } = false;
            public bool GetChallengeCalled { get; private set; } = false;
            public bool CreateChallengeCalled { get; private set; } = false;

            public IReadOnlyList<Challenge> GetAllChallenges() {
                GetAllChallengesCalled = true;

                return new List<Challenge>();
            }

            public bool ChallengeExist(int id) {
                ChallengeExistCalled = true;

                return id == 1; // For testing purposes, assuming the challenge with ID 1 exists
            }

            public Challenge GetChallenge(int id) {
                GetChallengeCalled = true;

                return new Challenge { Id = id, Name = "Test Challenge" };
            }

            public Challenge CreateChallenge(Challenge challenge) {
                CreateChallengeCalled = true;

                return challenge;
            }
        }

        [Fact]
        public void Constructor_Not_Null() {
            MockChallengeRepository repo = new MockChallengeRepository();

            Assert.NotNull(new ChallengeManager(repo));
        }

        [Fact]
        public void GetAllChallenges_InValid() {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);

            Assert.Throws<ChallengeManagerException>(() => manager.GetAllChallenges());
            Assert.True(repo.GetAllChallengesCalled);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void GetChallenge_InValid_NegativeID(int id) {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);

            Assert.Throws<ChallengeManagerException>(() => manager.GetChallenge(id));
        }

        [Fact]
        public void GetChallenge_InValid_DoesNotExist() {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);

            Assert.Throws<ChallengeManagerException>(() => manager.GetChallenge(2));
            Assert.True(repo.ChallengeExistCalled);
        }

        [Fact]
        public void GetChallenge_Valid() {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);

            Challenge challenge = manager.GetChallenge(1);

            Assert.NotNull(challenge);
            Assert.Equal(1, challenge.Id);
            Assert.True(repo.ChallengeExistCalled);
            Assert.True(repo.GetChallengeCalled);
        }

        [Fact]
        public void AddChallenge_InValid_Null() {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);

            Assert.Throws<ChallengeManagerException>(() => manager.AddChallenge(null));
        }

        [Fact]
        public void AddChallenge_Valid_Repo() {
            MockChallengeRepository repo = new MockChallengeRepository();
            ChallengeManager manager = new ChallengeManager(repo);
            Challenge challengeToAdd = new Challenge { Id = 1, Name = "Test Challenge" };

            Challenge addedChallenge = manager.AddChallenge(challengeToAdd);

            Assert.NotNull(addedChallenge);
            Assert.True(repo.CreateChallengeCalled);
        }
    }
}

