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
    public class DeleteStoreItemCommand : StoreItemDTO
    {
        private IStoreItemRepository _storeItemRepository;
        public DeleteStoreItemCommand(int id)
        {
            Id = id;
            _storeItemRepository = new StoreItemRepository();
        }


        public void Delete()
        {
            _storeItemRepository.Delete(Id);
        }
    }
}
