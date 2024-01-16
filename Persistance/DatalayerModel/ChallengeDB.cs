using System.ComponentModel.DataAnnotations;

namespace Domain.Entity {
    public class ChallengeDB {
        public ChallengeDB()
        {
        }

        public ChallengeDB(int id, string name, string description, string defaultPicture, DateTime month) {
            Id = id;
            Name = name;
            Description = description;
            DefaultPicture = defaultPicture;
            Month = month;
            
        }        

        [Key]
        public int Id { get; private set; }
        [MaxLength(500)]
        [Required]
        public string Name { get; private set; }
        [MaxLength(500)]
        [Required]
        public string Description { get; private set; }
        [MaxLength(500)]
        [Required]
        public string DefaultPicture { get; private set; }
        public List<PrizeDB> Prizes { get; set; } = new List<PrizeDB>();
        public DateTime Month { get; private set; }
        public ICollection<ItemDB> Recipes { get; set; } = new List<ItemDB>();

        // public Dictionary<Item, int> RecipeToVotes { get; private set; } //init ipv private set?
    }
}