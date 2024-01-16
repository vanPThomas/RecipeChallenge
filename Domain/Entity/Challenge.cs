using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Challenge
    {
        public Challenge()
        {
        }
        public Challenge(int id, string name, string description, string defaultPicture, List<Prize> prizes, DateTime month)
        {
            SetId(id);
            SetName(name);
            SetDescription(description);
            SetDefaultPicture(defaultPicture);
            SetPrizes(prizes);
            SetMonth(month);
            
        }
        public Challenge(string name, string description, string defaultPicture, List<Prize> prizes, DateTime month)
        {
            SetName(name);
            SetDescription(description);
            SetDefaultPicture(defaultPicture);
            SetPrizes(prizes);
            SetMonth(month);
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultPicture { get; set; }
        public List<Prize> Prizes { get; set; }
        public DateTime Month { get; set; }
        public Dictionary<Item, int> RecipeToVotes { get; set; } = new Dictionary<Item, int>(); //init ipv private set?

        public void SetId(int id) {
            if (id <= 0) throw new ChallengeException("SetId - Id is less than or equal to 0");
            Id = id;
        }

        public void SetName(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ChallengeException("SetName - Name is null or whitespace");
            Name = name;
        }

        public void SetDescription(string description) {
            if (string.IsNullOrWhiteSpace(description)) throw new ChallengeException("SetDescription - Description is null or whitespace");
            Description = description;
        }

        public void SetDefaultPicture(string defaultPicture) {
            if (string.IsNullOrWhiteSpace(defaultPicture)) throw new ChallengeException("SetDefaultPicture - Default picture string is null or whitespace.");
            DefaultPicture = defaultPicture;
        }

        public void SetPrizes(List<Prize> prizes) {
            //if (prizes.Count() == 0) throw new ChallengeException("SetPrizes - Prizes list is empty.");
            Prizes = prizes;
        }

        public void SetMonth(DateTime date) {
            if (date == DateTime.MinValue) throw new ChallengeException("SetMonth - Date is not filled in.");
            Month = date;
        }
    }
}
