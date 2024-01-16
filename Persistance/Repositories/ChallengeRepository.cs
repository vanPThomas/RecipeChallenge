using Application.Exceptions;
using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatalayerModel;
using Persistence.Mappers;

namespace Persistence.Repositories
{
    public class ChallengeRepository : IChallengeRepository {
        ChallengeContext ctx = new ChallengeContext();
        public ChallengeRepository() {

        }
        // returns true if challenge with given id exists
        public bool ChallengeExist(int id) {
            try {
                return ctx.Challenges.Any(c => c.Id == id);
            } catch (Exception ex) {
                throw new ChallengeDLException("ChallengeExist", ex);
            }
        }
        // Creates new challenge and returns it
        public Challenge CreateChallenge(Challenge challenge) {
            try {
                ChallengeDB challengeDB = MapChallenge.MapToDB(challenge);
                ctx.Challenges.Add(challengeDB);
                ctx.SaveChanges();
                challenge.Id = challengeDB.Id;
                return challenge;
            } catch (Exception ex) {
                throw new ChallengeDLException("CreateChallenge", ex);
            }
        }
        // returns list of all challenges
        public IReadOnlyList<Challenge> GetAllChallenges() {
            try {
                return ctx.Challenges
                     .Include(s => s.Prizes)
                     .Include(s => s.Recipes)
                     .ThenInclude(z => z.Parts)
                     .Include(z => z.Recipes)
                     .ThenInclude(z => z.Photos)
                     .Where(x => x.Month <= DateTime.Now)
                     .OrderByDescending(x => x.Month)
                     .Select(x => MapChallenge.MapFromDB(x))
                     .ToList();
            } catch (Exception ex) {
                throw new ChallengeDLException("GetAllChallenges", ex);
            }
        }
        // Returns challenge with specific id
        public Challenge GetChallenge(int id) {
            try {
                return MapChallenge.MapFromDB(ctx.Challenges.Where(x => x.Id == id)
                    .Include(s => s.Prizes)
                    .Include(s => s.Recipes)
                    .ThenInclude(z => z.Parts)
                    .Include(z => z.Recipes)
                    .ThenInclude(z => z.Photos)
                    .FirstOrDefault());
            } catch (Exception ex) {
                throw new ChallengeDLException($"GetChallenge {id} error", ex);
            }
        }
    }
}
