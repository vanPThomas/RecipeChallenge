using Core.Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.DatalayerModel;
using Persistence.Mappers;

namespace Persistence.Repositories
{
    public class ItemRepository : IItemRepository
    {
        ChallengeContext ctx = new ChallengeContext();
        // Returns item with id
        public Item GetItemFromDB(int id)
        {
            return MapItem.MapFromDB(ctx.Items
                .Where(x => x.Id == id)
                .Include(s => s.Photos)
                .Include(s => s.Parts)
                .FirstOrDefault());
        }
        // returns true id item exists
        public bool ItemExists(int id)
        {
            return ctx.Items.Any(x => x.Id == id);
        }
        // Writes item without id away to db and returns the same item with an id
        public Item RegisterItemToDB(Item item, int challengeId)
        {
            ItemDB itemDb = MapItem.MapToDB(item);
            ctx.Items.Attach(itemDb);
            itemDb.ChallengeDBId = challengeId;
            ctx.Items.Add(itemDb);
            ctx.SaveChanges();
            item.Id = itemDb.Id;
            return item;
        }

        public Item AddVoteToItem(Item item)
        {
            ItemDB itemDB = ctx.Items.SingleOrDefault(x => x.Id == item.Id);
            itemDB.Votes++;
            ctx.SaveChanges();
            return MapItem.MapFromDB(itemDB);
        }
    }
}
