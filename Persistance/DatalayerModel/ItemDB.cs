using Persistence.DatalayerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ItemDB
    {
        public ItemDB()
        {
        }

        public ItemDB(string title) {
            Title = title;
        }

        public ItemDB(int id, string title) {
            Id = id;
            Title = title;
        }

        public ItemDB(ICollection<PartDB> parts, string title, List<PhotoDB> photos) {
            Parts = parts;
            Title = title;
            Photos = photos;
        }

        public ItemDB(int id, string title, int challengeId) : this(id, title)
        {
            ChallengeDBId = challengeId;
        }

        public ICollection<PartDB> Parts { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; private set; }
        public List<PhotoDB> Photos { get; set; }
        public int ChallengeDBId { get; set; }
        public int Votes { get; set; } = 0;
        
    }
}

