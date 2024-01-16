using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PrizeDB
    {
        public PrizeDB()
        {
        }
        public PrizeDB(string logo, string name, string description, string company) {
            Logo = logo;
            Name = name;
            Description = description;
            Company = company;
        }

        public PrizeDB(int id, string logo, string name, string description, string company) {
            Id = id;
            Logo = logo;
            Name = name;
            Description = description;
            Company = company;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(500)]
        public string Logo { get; set; }
        [MaxLength(500)]
        [Required]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Company { get; set; }
        //public int ChallengeDBId { get; set; }
    }
}
