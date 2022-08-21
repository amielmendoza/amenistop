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
    public class UpdateStoreItemCommand
    {
        private IStoreItemRepository _storeItemRepository;
        private StoreItemDTO _storeItemDTO;
        public UpdateStoreItemCommand(StoreItemDTO storeItemDTO)
        {
            _storeItemDTO = storeItemDTO;
            _storeItemRepository = new StoreItemRepository();
        }
        

        public void Update() {
            StoreItem storeItem = new StoreItem() {
                Name = _storeItemDTO.Name,
                SellPrice = _storeItemDTO.SellPrice,
                BuyPrice = _storeItemDTO.BuyPrice,
                Quantity = _storeItemDTO.Quantity
            };

            _storeItemRepository.Update(storeItem);
        }
    }
}
