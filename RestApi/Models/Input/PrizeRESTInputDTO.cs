namespace RestApi.Models.Input
{
    public class PrizeRESTInputDTO
    {
        

        public PrizeRESTInputDTO(string logo, string name, string description, string company)
        {
            Logo = logo;
            Name = name;
            Description = description;
            Company = company;
        }

        public string Logo { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }
    }
}
