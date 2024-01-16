using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Item
    {
        public Item(Dictionary<Part, double> amountOfParts, int id, string title, List<string> photos)
        {
            AmountOfParts = amountOfParts;
            SetId(id);
            SetTitle(title);
            SetPhotos(photos);
        }
        public Item(Dictionary<Part, double> amountOfParts, string title, List<string> photos)
        {
            AmountOfParts = amountOfParts;
            SetTitle(title);
            SetPhotos(photos);
        }

       
        public Dictionary<Part, double> AmountOfParts { get; set; }
        public int Id { get; set; }
        public string Title { get; private set; }
        public List<string> Photos { get; private set; }
        public int Votes { get; private set; } = 0;

        public void SetId(int id) {
            if (id <= 0) throw new ItemException("SetId - Id is less than or equal to 0");
            Id = id;
        }

        public void SetTitle(string title) {
            if (string.IsNullOrWhiteSpace(title)) throw new ItemException("SetTitle - Title is null or whitespace");
            Title = title;
        }

        public void SetPhotos(List<string> photos) {
            if (photos.Count() == 0) throw new ItemException("SetPhotos - List is empty.");
            Photos = photos;
        }

        public void AddVote()
        {
            Votes++;
        }
    }
}

