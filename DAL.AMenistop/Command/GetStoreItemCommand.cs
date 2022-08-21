using DAL.AMenistop.DTO;
using DAL.AMenistop.Interfaces;
using DAL.AMenistop.Models;
using DAL.AMenistop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AMenistop.Command
{
    public class GetStoreItemCommand
    {
        private IStoreItemRepository _storeItemRepository;
        public GetStoreItemCommand()
        {
            _storeItemRepository = new StoreItemRepository();
        }

        public IEnumerable<StoreItemDTO> GetAll()
        {
            IEnumerable<StoreItem> storeItems = _storeItemRepository.GetAll();
            IList<StoreItemDTO> result = new List<StoreItemDTO>();

            foreach (var storeItem in storeItems)
            {
                result.Add(new StoreItemDTO()
                {
                    Id = storeItem.Id,
                    Name = storeItem.Name,
                    SellPrice = storeItem.SellPrice,
                    BuyPrice = storeItem.BuyPrice,
                    Quantity = storeItem.Quantity
                });
            }

            return result;
        }

        public StoreItemDTO GetById(int id)
        {
            StoreItem storeItem = _storeItemRepository.GetById(id);
            StoreItemDTO result = new StoreItemDTO();

            result.Id = storeItem.Id;
            result.Name = storeItem.Name;
            result.SellPrice = storeItem.SellPrice;
            result.BuyPrice = storeItem.BuyPrice;
            result.Quantity = storeItem.Quantity;

            return result;
        }
    }
}
