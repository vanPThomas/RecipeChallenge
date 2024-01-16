using Application.Exceptions;
using Application.Interfaces;
using Core.Application.Interfaces;
using Domain.Entity;

namespace Application.Services
{
    public class ItemManager {
        private IItemRepository _itemRepo;
        private IChallengeRepository _challengeRepo;

        public ItemManager(IItemRepository itemRepository, IChallengeRepository challengeRepository) {
            try {
                _itemRepo = itemRepository;
                _challengeRepo = challengeRepository;
            } catch (ItemDLException e) {
                throw new ItemDLException("Data layer error", e);
            } catch (Exception) {
                throw;
            }
        }
        // Check if item is not null and that challenge exist | write item to db | returns item with id
        public Item AddItem(Item item, int challengeId) {
            try {
                if (item == null) throw new ItemManagerException("Item is null");
                if (challengeId <= 0) throw new ItemManagerException("ChallengeID must be positive");
                if (!_challengeRepo.ChallengeExist(challengeId)) throw new ItemManagerException("Challenge does not exist");
                return _itemRepo.RegisterItemToDB(item, challengeId);
            } catch (ItemDLException ex) {
                throw new ItemDLException("Data layer error", ex);
            } catch (ItemManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("AddItem", ex);
            }
        }
        // checks if id is possible | checks id item exists | returns item
        public Item GetItem(int id) {
            try {
                if (id <= 0) throw new ItemManagerException("ItemID must be positive");
                if (!_itemRepo.ItemExists(id)) throw new ItemManagerException("Item does not exist");
                return _itemRepo.GetItemFromDB(id);
            } catch (ItemDLException e) {
                throw new ItemDLException("Data layer error", e);
            } catch (ItemManagerException ex) {
                throw ex;
            } catch (Exception ex) {
                throw new Exception("GetItem", ex);
            }
        }

        public Item AddVoteToItem(int itemId)
        {
            try
            {
                if (itemId <= 0) throw new ItemManagerException("ItemID must be positive");
                if (!_itemRepo.ItemExists(itemId)) throw new ItemManagerException("Item does not exist");
                Item item = _itemRepo.GetItemFromDB(itemId);
                return _itemRepo.AddVoteToItem(item);
            } catch (ItemDLException e)
            {
               throw new ItemDLException("Data layer error", e);
            } catch (ItemManagerException ex)
            {
               throw ex;
            } catch (Exception ex)
            {
               throw new Exception("GetItem", ex);
            }
        }
    }
}