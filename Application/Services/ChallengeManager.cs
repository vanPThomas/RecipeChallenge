using Application.Exceptions;
using Application.Interfaces;
using Domain.Entity;

namespace Application.Services
{
    public class ChallengeManager {
        private IChallengeRepository _repo;
        // constructor
        public ChallengeManager(IChallengeRepository repo) {
            _repo = repo;
        }
        // Calls repo to return challenges and checks if list contains challenges
        public IReadOnlyList<Challenge> GetAllChallenges() {
            try {
                IReadOnlyList<Challenge> challenges = _repo.GetAllChallenges();
                if (challenges.Count == 0) throw new ChallengeManagerException("There are no challenges");
                return challenges;
            } catch (ChallengeDLException ex) {
                throw new ChallengeDLException("Data layer error", ex);
            } catch (ChallengeManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("GetAllChallenges", ex);
            }
        }
        // Calls repo to check if challenge exists then return said challenge
        public Challenge GetChallenge(int id) {
            try {
                if (id <= 0) throw new ChallengeManagerException("Id must be positive");
                if (!_repo.ChallengeExist(id)) throw new ChallengeManagerException("Challenge does not exist");
                return _repo.GetChallenge(id);
            } catch (ChallengeDLException ex) {
                throw new ChallengeDLException("Data layer error", ex);
            } catch (ChallengeManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("GetChallenge", ex);
            }
        }
        // Checks if challenge is not null and writes it away to database
        public Challenge AddChallenge(Challenge challenge) {
            try {
                if (challenge == null) throw new ChallengeManagerException("Challenge cannot be null");
                return _repo.CreateChallenge(challenge);
            } catch (ChallengeDLException ex) {
                throw new ChallengeDLException("Data layer error", ex);
            } catch (ChallengeManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("AddChallenge", ex);
            }
        }
    }
}
