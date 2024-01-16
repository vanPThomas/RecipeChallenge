namespace RestApi.Models.Output
{
    public class PrizeRESTOutputDTO
    {
        public PrizeRESTOutputDTO(string logo, string description, string name, string company, int id)
        {
            Logo = logo;
            Description = description;
            Name = name;
            Company = company;
            Id = id;
        }
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
