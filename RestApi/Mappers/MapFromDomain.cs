using Domain.Entity;
using RestApi.Exceptions;
using RestApi.Models.Output;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RestApi.Mappers
{
    public class MapFromDomain
    {
        public static ChallengeRESTOutputDTO MapFromChallengeDomain(Challenge challenge)
        {
            try
            {
                string challengeURL = $"/challenge/{challenge.Id}";
                List<ItemRESTOutputDTO> recipes = new List<ItemRESTOutputDTO>();
                List<PrizeRESTOutputDTO> prices = new List<PrizeRESTOutputDTO>();
                foreach (Item i in challenge.RecipeToVotes.Keys)
                {
                    recipes.Add(MapFromItemDomain(i));
                }
                foreach (Prize p in challenge.Prizes)
                {
                    prices.Add(new PrizeRESTOutputDTO(p.Logo, p.Description, p.Name, p.Company, p.Id));
                }
                string month = challenge.Month.ToString("MMMM", CultureInfo.CreateSpecificCulture("nl")) + " " + challenge.Month.Year.ToString();
                ChallengeRESTOutputDTO dto = new ChallengeRESTOutputDTO(challenge.Id, challenge.Name, challenge.Description, challenge.DefaultPicture, prices, month, recipes);
                return dto;
            }
            catch (Exception ex) { throw new MapException("MapFromChallengeDomain"); }
        }
        public static List<PartRESTOutputDTO> MapFromPartDomain(Dictionary<Part, double> parts)
        {
            try
            {
                List<PartRESTOutputDTO> partsDTO = new List<PartRESTOutputDTO>();

                foreach (Part p in parts.Keys)
                {
                    partsDTO.Add(new PartRESTOutputDTO(p.Name, p.UnitOfMeasurement));
                }
                return partsDTO;
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromPartDomain", ex);
            }
        }
        public static ItemRESTOutputDTO MapFromItemDomain(Item item)
        {
            try
            {
                return new ItemRESTOutputDTO(new List<PartRESTOutputDTO>(MapFromPartDomain(item.AmountOfParts)), item.Id, item.Title, item.Photos);
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromUtemDomain", ex);
            }
        }
        public static UserRESTOutputDTO MapFromUserDomain(User user)
        {
            try
            {
                return new UserRESTOutputDTO(user.Id, user.Email, user.LastName, user.FirstName);
            }catch (Exception ex)
            {
                throw new MapException("MapFromUserDomain", ex);
            }
        }
    }
}
