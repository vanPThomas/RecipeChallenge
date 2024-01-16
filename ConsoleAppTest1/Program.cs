using Application.Interfaces;
using Application.Services;
using Core.Application.Interfaces;
using Domain.Entity;
using Persistence;
using Persistence.Mappers;
using Persistence.Repositories;
using RestApi.Mappers;

IItemRepository itemRepo = new ItemRepository();
IChallengeRepository repo = new ChallengeRepository();
IPrizeRepository prizeRepo = new PrizeRepository();
Challenge challenge = new Challenge("bla", "discription", "defaultpic", new List<Prize>{new Prize("logo", "name", "description", "company")}, DateTime.Now);
Part p = new Part("badabing", "unit");
Dictionary<Part, double> reccipe = new Dictionary<Part, double>();
reccipe.Add(p, 2);
List<string> photos = new List<string> { "babagoul", "skhlksdf" };
Item i = new Item(reccipe, "kbkgk", photos);
challenge.RecipeToVotes.Add(i, 2);
//MapBLtoDL.MapChallengeToChallengeDB(challenge);

//repo.CreateChallenge(challenge);
IReadOnlyList<Challenge> challenges = repo.GetAllChallenges();


//itemRepo.RegisterItemToDB(i, 13);
//IReadOnlyList<Prize> prizes = prizeRepo.GetAllPrizes();
//Console.WriteLine("foop");
