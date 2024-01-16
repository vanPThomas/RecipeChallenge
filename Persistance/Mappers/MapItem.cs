using Domain.Entity;
using Persistence.DatalayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mappers
{
    public static class MapItem
    {
        public static Item MapFromDB(ItemDB db)
        {
            List<string> photos = db.Photos.Select(photo => MapPhoto.mapFromDB(photo)).ToList();

            var amountOfParts = db.Parts
                .Select(part => new Part(part.Name, "0"))
                .ToDictionary(part => part, _ => 0.0);

            return new Item(amountOfParts, db.Id, db.Title, photos);
        }

        public static ItemDB MapToDB(Item item)
        {
            ItemDB db = new ItemDB(item.Title);
            db.Parts = new List<PartDB>();
            db.Photos = new List<PhotoDB>();
            foreach(Part p in item.AmountOfParts.Keys)
            {
                db.Parts.Add(MapPart.MapToDB(p));
            }
            foreach(string p in item.Photos)
            {
                db.Photos.Add(new PhotoDB(p));
            }
            return db;
        }
    }
}
