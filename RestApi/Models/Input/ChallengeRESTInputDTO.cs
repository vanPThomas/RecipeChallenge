using Domain.Entity;

namespace RestApi.Models.Input
{
    public class ChallengeRESTInputDTO
    {
        public ChallengeRESTInputDTO(string name, string description, string defaultPicture, List<PrizeRESTInputDTO> prizes, int month)
        {
            this.name = name;
            this.description = description;
            this.defaultPicture = defaultPicture;
            this.prizes = prizes;
            this.month = month;
        }

        public string name { get; set; }
        public string description { get; set; }
        public string defaultPicture { get; set; }
        public List<PrizeRESTInputDTO> prizes { get; set; }
        public int month { get; set; }
    }
}
