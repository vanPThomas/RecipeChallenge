using Domain.Entity;
using Persistence.DatalayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapChallenge
    {
        public static ChallengeDB MapToDB(Challenge challenge)
        {
            ChallengeDB db = new ChallengeDB(challenge.Id, challenge.Name, challenge.Description, challenge.DefaultPicture, challenge.Month);
            db.Prizes = new List<PrizeDB>();
            db.Recipes = new List<ItemDB>();
            
            foreach(Prize p in challenge.Prizes)
            {
                db.Prizes.Add(MapPrize.MapToDB(p));
            }

            foreach(Item i in challenge.RecipeToVotes.Keys)
            {
                db.Recipes.Add(MapItem.MapToDB(i));
            }            
            return db;
        }
        public static Challenge MapFromDB(ChallengeDB challengeDB)
        {
            Challenge challenge = new Challenge(challengeDB.Id, challengeDB.Name, challengeDB.Description, challengeDB.DefaultPicture, new List<Prize>(), challengeDB.Month);
            if (challengeDB.Prizes.Count > 0)
            {
                foreach (PrizeDB prize in challengeDB.Prizes)
                {
                    challenge.Prizes.Add(MapPrize.MapFromDB(prize));
                }
            }
            if (challengeDB.Recipes.Count > 0)
            {
                foreach (ItemDB item in challengeDB.Recipes)
                {
                    challenge.RecipeToVotes.Add(MapItem.MapFromDB(item), 0);
                }
            }
            return challenge;
        } 
    }
}
