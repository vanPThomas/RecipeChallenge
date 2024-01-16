using Domain.Entity;

namespace Core.Application.Interfaces
{
    public interface IItemRepository
    {
        
        bool ItemExists(int id);
        Item GetItemFromDB(int id);
        Item RegisterItemToDB(Item item, int challengeId);
        Item AddVoteToItem(Item item);
    }
}