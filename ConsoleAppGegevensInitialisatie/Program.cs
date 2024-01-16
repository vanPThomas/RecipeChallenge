using Application.Interfaces;
using Application.Services;
using Domain.Entity;
using Persistence.DatalayerModel;
using Persistence.Mappers;
using Persistence.Repositories;

List<Challenge> challengeList = new List<Challenge>();
IChallengeRepository repo = new ChallengeRepository();
ChallengeManager cm = new ChallengeManager(repo);
ChallengeContext ctx = new ChallengeContext();

//challenge
Challenge challenge1 = new Challenge("Challenge1", "Description", "LinkPicture", new List<Prize> { new Prize("Logo", "NaamPrijs", "Description", "company") }, DateTime.Now);
Part p = new Part("part", "unit");
Dictionary<Part, double> reccipe = new Dictionary<Part, double>();
reccipe.Add(p, 2);
List<string> photos = new List<string> { "string", "test" };
Item i = new Item(reccipe, "title", photos);
challenge1.RecipeToVotes.Add(i, 2);
challengeList.Add(challenge1);
//ChallengeDB cDB = MapChallenge.MapToDB(challenge1);

//challenge
Challenge challenge2 = new Challenge("Challenge2", "Description", "LinkPicture", new List<Prize> { new Prize("Logo", "NaamPrijs", "Description", "company") }, DateTime.Now);
Part p2 = new Part("part2", "unit2");
Dictionary<Part, double> reccipe2 = new Dictionary<Part, double>();
reccipe2.Add(p2, 2);
List<string> photos2 = new List<string> { "string2", "test2" };
Item i2 = new Item(reccipe2, "title2", photos2);
challenge2.RecipeToVotes.Add(i2, 2);
challengeList.Add(challenge2);
MapChallenge.MapToDB(challenge2);

//challenge
Challenge challenge3 = new Challenge("Challenge3", "Description", "LinkPicture", new List<Prize> { new Prize("Logo", "NaamPrijs", "Description", "company") }, DateTime.Now);
Part p3 = new Part("part3", "unit3");
Dictionary<Part, double> reccipe3 = new Dictionary<Part, double>();
reccipe3.Add(p3, 2);
List<string> photos3 = new List<string> { "string3", "test3" };
Item i3 = new Item(reccipe3, "title3", photos3);
challenge3.RecipeToVotes.Add(i3, 2);
challengeList.Add(challenge3);

foreach (Challenge c in challengeList)
{
    repo.CreateChallenge(c);
}