using Domain.Entity;

namespace RestApi.Models.Output
{
    public class ChallengeRESTOutputDTO
    {
        public ChallengeRESTOutputDTO(int id, string name, string description, string defaultPicture, IReadOnlyList<PrizeRESTOutputDTO> prizes, string month)
        {
            Id = id;
            Name = name;
            Description = description;
            DefaultPicture = defaultPicture;
            Prizes = prizes;
            Month = month;
        }

        public ChallengeRESTOutputDTO(int id, string name, string description, string defaultPicture, IReadOnlyList<PrizeRESTOutputDTO> prizes, string month, List<ItemRESTOutputDTO> recipes) : this(id, name, description, defaultPicture, prizes, month)
        {
            Recipes = recipes;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultPicture { get; set; }
        public IReadOnlyList<PrizeRESTOutputDTO> Prizes { get; set; }
        public string Month { get; set; }
        public List<ItemRESTOutputDTO> Recipes { get; set; }
    }
}
