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
    public class NewStoreItemCommand
    {
        private IStoreItemRepository _storeItemRepository;
        private StoreItemDTO _storeItemDTO;
        public NewStoreItemCommand(StoreItemDTO storeItemDTO)
        {
            _storeItemDTO = storeItemDTO;
            _storeItemRepository = new StoreItemRepository();
        }


        public StoreItemDTO Add()
        {
            StoreItem storeItem = new StoreItem()
            {
                Name = _storeItemDTO.Name,
                SellPrice = _storeItemDTO.SellPrice,
                BuyPrice = _storeItemDTO.BuyPrice,
                Quantity = _storeItemDTO.Quantity
            };

            storeItem = _storeItemRepository.Add(storeItem);
            _storeItemDTO.Id = storeItem.Id;

            return _storeItemDTO;
        }
    }
}
