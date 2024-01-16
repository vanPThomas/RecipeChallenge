using Domain.Entity;
using RestApi.Exceptions;
using RestApi.Models.Input;

namespace RestApi.Mappers
{
    public class MapToDomain
    {
        public static Challenge MapToChallengeDomain(ChallengeRESTInputDTO dto)
        {
            try
            {
                List<Prize> prizes = new List<Prize>();

                foreach (PrizeRESTInputDTO prizeDTO in dto.prizes)
                {
                    prizes.Add(new Prize(prizeDTO.Logo, prizeDTO.Name, prizeDTO.Description, prizeDTO.Company));
                }

                return new Challenge(dto.name, dto.description, dto.defaultPicture, prizes, new DateTime(DateTime.Now.Year, dto.month, 1));
            }
            catch (Exception ex) { throw new MapException(ex.Message); }
        }
        public static Item MapToItemDomain(ItemRESTInputDTO dto)
        {
            try
            {
            Dictionary<Part, double> parts = new Dictionary<Part, double>();
            foreach (PartRESTInputDTO part in dto.parts)
            {
                parts.Add(new Part(part.Name, part.UnitOfMeasurment), 1.0);
            }
            Item item = new Item(parts, dto.Title, dto.Photos);
            return item;
            }catch (Exception ex)
            {
                throw new MapException(ex.Message);
            }
        }
        public static User MapToUserDomain(UserRESTInputDTO dto)
        {
            try
            {
                return new User(dto.Email, dto.FirstName, dto.LastName);
            }
            catch (Exception ex)
            {
                throw new MapException("MapToUserDomain", ex);
            }
        }
    }
}
